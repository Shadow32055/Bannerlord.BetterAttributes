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
        public static void MaxHitpoints(ref ExplainedNumber __result, CharacterObject character, bool includeDescriptions = false) {
            try {
                if (SubModule._settings.healthBonusEnabled) {
                    if (!character.IsHero)
                        return;

                    if (!character.IsPlayerCharacter && SubModule._settings.healthBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(SubModule._settings.healthBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.healthBonusAttribute), character), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.healthBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultCharacterStatsModelPatch.MaxHitpoints threw exception: " + e, Severity.High);
            }
        }
    }
}
