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
        [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateStaggerThresholdDamage))]
        public static void CalculateStaggerThresholdDamage(Agent defenderAgent, ref float __result) {
            try {
                if (Helper.settings.staggerBonusEnabled) {
                    if (!defenderAgent.IsHero)
                        return;

                    if (defenderAgent.IsAIControlled && Helper.settings.staggerBonusPlayerOnly)
                        return;

                    __result = __result * (Helper.GetAttributeEffect(Helper.settings.staggerBonus, Helper.GetAttributeTypeFromIndex(Helper.settings.staggerBonusAttribute), (CharacterObject)defenderAgent.Character) + 1);
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultAgentApplyDamageModelPatch.CalculateStaggerThresholdDamage postfix. Exception output: " + e);
            }
        }
    }
}
