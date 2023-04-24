using BetterAttributes.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Localization;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultClanFinanceModel))]
    class DefaultClanFinanceModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculateClanIncomeInternal")]
        public static void CalculateClanIncomeInternal(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false) {
            try {
                if (Helper.settings.incomeBonusEnabled) {
                    if (clan.IsEliminated)
                        return;

                    if (clan.Leader is null)
                        return;

                    if (!clan.Leader.IsHumanPlayerCharacter && Helper.settings.incomeBonusPlayerOnly)
                        return;

                    goldChange.Add(goldChange.ResultNumber * Helper.GetAttributeEffect(Helper.settings.incomeBonus, Helper.GetAttributeTypeFromIndex(Helper.settings.incomeBonusAttribute), clan.Leader.CharacterObject), new TextObject(Helper.GetAttributeTypeFromIndex(Helper.settings.incomeBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultClanFinanceModelPatch.CalculateClanIncomeInternal postfix. Exception output: " + e);
            }
        }
    }
}
