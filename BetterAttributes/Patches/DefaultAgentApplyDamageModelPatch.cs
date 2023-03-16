using System;
using HarmonyLib;
using SandBox.GameComponents;
using BetterAttributes.Utils;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel))]
    class DefaultAgentApplyDamageModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateStaggerThresholdMultiplier))]
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
