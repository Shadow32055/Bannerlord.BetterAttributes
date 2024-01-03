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
                if (SubModule._settings.incomeBonusEnabled) {
                    if (clan.IsEliminated)
                        return;

                    if (clan.Leader is null)
                        return;

                    if (!clan.Leader.IsHumanPlayerCharacter && SubModule._settings.incomeBonusPlayerOnly)
                        return;

                    goldChange.Add(goldChange.ResultNumber * AttributeHelper.GetAttributeEffect(SubModule._settings.incomeBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.incomeBonusAttribute), clan.Leader.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.incomeBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e, Severity.High);
            }
        }
    }
}
