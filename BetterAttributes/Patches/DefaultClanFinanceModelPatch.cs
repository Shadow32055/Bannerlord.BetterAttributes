using BetterCore.Utils;
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
                if (BetterAttributes.Settings.IncomeBonusEnabled) {
                    if (clan.IsEliminated)
                        return;

                    if (clan.Leader is null)
                        return;

                    if (!clan.Leader.IsHumanPlayerCharacter && BetterAttributes.Settings.IncomeBonusPlayerOnly)
                        return;

                    goldChange.Add(goldChange.ResultNumber * AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.IncomeBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.IncomeBonusAttribute), clan.Leader.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.IncomeBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e);
            }
        }
    }
}
