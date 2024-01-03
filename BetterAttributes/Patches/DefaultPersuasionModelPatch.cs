using BetterCore.Utils;
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
                if (SubModule._settings.persuasionBonusEnabled) {
                    __result = __result * (AttributeHelper.GetAttributeEffect(SubModule._settings.persuasionBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.persuasionBonusAttribute), Hero.MainHero.CharacterObject) + 1);
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e, Severity.High);
            }
        }
    }
}
