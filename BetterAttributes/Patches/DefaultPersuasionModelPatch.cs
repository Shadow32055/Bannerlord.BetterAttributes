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
                if (BetterAttributes.Settings.PersuasionBonusEnabled) {
                    __result = __result * (AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.PersuasionBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.PersuasionBonusAttribute), Hero.MainHero.CharacterObject) + 1);
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e);
            }
        }
    }
}
