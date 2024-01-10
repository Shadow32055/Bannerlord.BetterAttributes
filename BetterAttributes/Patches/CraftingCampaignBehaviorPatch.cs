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
                if (BetterAttributes.Settings.SmithingBonusEnabled) {

                    if (hero == Hero.MainHero)
                        __result = __result + (int)(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.SmithingBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.SmithingBonusAttribute), (CharacterObject)hero.CharacterObject) + 1);
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "CraftingCampaignBehaviorPatch.GetMaxHeroCraftingStamina threw exception: " + e);
            }
        }
    }
}
