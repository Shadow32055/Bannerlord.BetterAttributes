using BetterAttributes.Utils;
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
        public static void MaxHitpoints(ref ExplainedNumber __result, CharacterObject character, bool includeDescriptions = false) {
            try {
                if (Helper.settings.healthBonusEnabled) {
                    if (!character.IsHero)
                        return;

                    if (!character.IsPlayerCharacter && Helper.settings.healthBonusPlayerOnly)
                        return;

                    __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.healthBonus, Helper.GetAttributeTypeFromText(Helper.settings.healthBonusAttribute), character), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.healthBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultCharacterStatsModelPatch.MaxHitpoints postfix. Exception output: " + e);
            }
        }
    }
}
