using BetterAttributes.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultBattleRewardModel))]
    class DefaultBattleRewardModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateRenownGain))]
        public static void CalculateRenownGain(PartyBase party, float renownValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {
                if (Helper.settings.renownBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && Helper.settings.renownBonusPlayerOnly)
                        return;

                    __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.renownBonus, Helper.GetAttributeTypeFromText(Helper.settings.renownBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.renownBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultBattleRewardModelPatch.CalculateRenownGain Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateMoraleGainVictory))]
        public static void CalculateMoraleGainVictory(PartyBase party, float renownValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {
                if (Helper.settings.moraleBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && Helper.settings.moraleBonusPlayerOnly)
                        return;

                    __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.moraleBonus, Helper.GetAttributeTypeFromText(Helper.settings.moraleBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.moraleBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultBattleRewardModelPatch.CalculateMoraleGainVictory Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateInfluenceGain))]
        public static void CalculateInfluenceGain(PartyBase party, float influenceValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {
                if (Helper.settings.influenceBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && Helper.settings.influenceBonusPlayerOnly)
                        return;

                    __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.influenceBonus, Helper.GetAttributeTypeFromText(Helper.settings.influenceBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.influenceBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultBattleRewardModelPatch.CalculateInfluenceGain Postfix. Exception output: " + e);
            }
        }
    }
}
