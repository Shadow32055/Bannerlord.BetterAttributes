using BetterAttributes.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel))]
    class DefaultAgentApplyDamageModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.CalculateStaggerThresholdMultiplier))]
        public static void CalculateStaggerThresholdMultiplier(Agent defenderAgent, ref float __result) {
            try {
                if (Helper.settings.staggerBonusEnabled) {
                    if (!defenderAgent.IsHero)
                        return;

                    if (defenderAgent.IsAIControlled && Helper.settings.staggerBonusPlayerOnly)
                        return;

                    __result = __result * (Helper.GetAttributeEffect(Helper.settings.staggerBonus, Helper.GetAttributeTypeFromText(Helper.settings.staggerBonusAttribute), (CharacterObject)defenderAgent.Character) + 1);
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultAgentApplyDamageModelPatch.CalculateStaggerThresholdMultiplier postfix. Exception output: " + e);
            }
        }
    }
}
