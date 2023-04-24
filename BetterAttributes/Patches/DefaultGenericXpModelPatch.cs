using BetterAttributes.Utils;
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
                if (Helper.settings.xpBonusEnabled) {
                    if (hero is null)
                        return;

                    if (!hero.IsHumanPlayerCharacter && Helper.settings.xpBonusPlayerOnly)
                        return;

                    __result = __result * (1 + Helper.GetAttributeEffect(Helper.settings.xpBonus, Helper.GetAttributeTypeFromIndex(Helper.settings.xpBonusAttribute), hero.CharacterObject));
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultGenericXpModelPatch.GetXpMultiplier postfix. Exception output: " + e);
            }
        }
    }
}
