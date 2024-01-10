using BetterCore.Utils;
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
                if (BetterAttributes.Settings.RenownBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && BetterAttributes.Settings.RenownBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.RenownBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.RenownBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.RenownBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultBattleRewardModelPatch.CalculateRenownGain threw exception: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateMoraleGainVictory))]
        public static void CalculateMoraleGainVictory(PartyBase party, float renownValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {
                if (BetterAttributes.Settings.MoraleBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && BetterAttributes.Settings.MoraleBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.MoraleBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.MoraleBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.MoraleBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultBattleRewardModelPatch.CalculateMoraleGainVictory threw exception: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateInfluenceGain))]
        public static void CalculateInfluenceGain(PartyBase party, float influenceValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {
                if (BetterAttributes.Settings.InfluenceBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && BetterAttributes.Settings.InfluenceBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.InfluenceBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.InfluenceBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.InfluenceBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultAgentApplyDamageModelPatch.CalculateStaggerThresholdDamage threw exception: " + e);
            }
        }
    }
}
