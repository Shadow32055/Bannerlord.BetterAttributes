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
                if (SubModule._settings.renownBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && SubModule._settings.renownBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(SubModule._settings.renownBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.renownBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.renownBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultBattleRewardModelPatch.CalculateRenownGain threw exception: " + e, Severity.High);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateMoraleGainVictory))]
        public static void CalculateMoraleGainVictory(PartyBase party, float renownValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {
                if (SubModule._settings.moraleBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && SubModule._settings.moraleBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(SubModule._settings.moraleBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.moraleBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.moraleBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultBattleRewardModelPatch.CalculateMoraleGainVictory threw exception: " + e, Severity.High);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateInfluenceGain))]
        public static void CalculateInfluenceGain(PartyBase party, float influenceValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {
                if (SubModule._settings.influenceBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && SubModule._settings.influenceBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(SubModule._settings.influenceBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.influenceBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.influenceBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultAgentApplyDamageModelPatch.CalculateStaggerThresholdDamage threw exception: " + e, Severity.High);
            }
        }
    }
}
