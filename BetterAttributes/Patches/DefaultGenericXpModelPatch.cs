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
                if (SubModule._settings.xpBonusEnabled) {
                    if (hero is null)
                        return;

                    if (!hero.IsHumanPlayerCharacter && SubModule._settings.xpBonusPlayerOnly)
                        return;

                    __result = __result * (1 + AttributeHelper.GetAttributeEffect(SubModule._settings.xpBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.xpBonusAttribute), hero.CharacterObject));
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e, Severity.High);
            }
        }
    }
}
