using BetterCore.Utils;
using HarmonyLib;
using SandBox.GameComponents;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel))]
    class DefaultAgentApplyDamageModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateStaggerThresholdDamage))]
        public static void CalculateStaggerThresholdDamage(Agent defenderAgent, in Blow blow, ref float __result) {
            try {
                if (SubModule._settings.staggerBonusEnabled) {
                    if (!defenderAgent.IsHero)
                        return;

                    if (defenderAgent.IsAIControlled && SubModule._settings.staggerBonusPlayerOnly)
                        return;

                    __result = __result * (AttributeHelper.GetAttributeEffect(SubModule._settings.staggerBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.staggerBonusAttribute), (CharacterObject)defenderAgent.Character) + 1);
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultAgentApplyDamageModelPatch.CalculateStaggerThresholdDamage threw exception: " + e, Severity.High);
            }
        }
    }
}
