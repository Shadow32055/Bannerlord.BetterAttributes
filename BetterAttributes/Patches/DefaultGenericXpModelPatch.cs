using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultGenericXpModel))]
    class DefaultGenericXpModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultGenericXpModel), nameof(DefaultGenericXpModel.GetXpMultiplier))]
        public static void GetXpMultiplier(ref float __result, Hero hero) {
            try {
                if (BetterAttributes.Settings.XpBonusEnabled) {
                    if (hero is null)
                        return;

                    if (!hero.IsHumanPlayerCharacter && BetterAttributes.Settings.XpBonusPlayerOnly)
                        return;

                    __result = __result * (1 + AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.XpBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.XpBonusAttribute), hero.CharacterObject));
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e);
            }
        }
    }
}
