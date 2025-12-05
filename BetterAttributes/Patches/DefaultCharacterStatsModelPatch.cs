using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Localization;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultCharacterStatsModel))]
    class DefaultCharacterStatsModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterStatsModel), nameof(DefaultCharacterStatsModel.MaxHitpoints))]
        public static void MaxHitpoints(ref ExplainedNumber __result, CharacterObject character, bool includeDescriptions) {
            try {
                if (BetterAttributes.Settings.HealthBonusEnabled) {
                    if (!character.IsHero)
                        return;

                    if (!character.IsPlayerCharacter && BetterAttributes.Settings.HealthBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.HealthBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HealthBonusAttribute), character), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HealthBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "DefaultCharacterStatsModelPatch.MaxHitpoints threw exception: " + e);
            }
        }
    }
}
