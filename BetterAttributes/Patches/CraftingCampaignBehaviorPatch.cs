using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(CraftingCampaignBehavior))]
    class CraftingCampaignBehaviorPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(CraftingCampaignBehavior), nameof(CraftingCampaignBehavior.GetMaxHeroCraftingStamina))]
        public static void GetMaxHeroCraftingStamina(ref int __result, ref CraftingCampaignBehavior __instance, Hero hero) {
            try {
                if (SubModule._settings.smithingBonusEnabled) {

                    if (hero == Hero.MainHero)
                        __result = __result + (int)(AttributeHelper.GetAttributeEffect(SubModule._settings.smithingBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.smithingBonusAttribute), (CharacterObject)hero.CharacterObject) + 1);
                }
            } catch (Exception e) {
                Logger.SendMessage("CraftingCampaignBehaviorPatch.GetMaxHeroCraftingStamina threw exception: " + e, Severity.High);
            }
        }
    }
}
