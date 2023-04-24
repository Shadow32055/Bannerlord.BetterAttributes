using BetterAttributes.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultPersuasionModel))]
    class DefaultPersuasionModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPersuasionModel), "GetDefaultSuccessChance")]
        public static void GetDefaultSuccessChance(PersuasionOptionArgs optionArgs, float difficultyMultiplier, ref float __result) {
            try {
                if (Helper.settings.persuasionBonusEnabled) {
                    __result = __result * (Helper.GetAttributeEffect(Helper.settings.persuasionBonus, Helper.GetAttributeTypeFromIndex(Helper.settings.persuasionBonusAttribute), Hero.MainHero.CharacterObject) + 1);
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultPersuasionModelPatch.GetDefaultSuccessChance postfix. Exception output: " + e);
            }
        }
    }
}
