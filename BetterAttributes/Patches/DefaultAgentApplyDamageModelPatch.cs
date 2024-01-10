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
                if (BetterAttributes.Settings.StaggerBonusEnabled) {
                    if (!defenderAgent.IsHero)
                        return;

                    if (defenderAgent.IsAIControlled && BetterAttributes.Settings.StaggerBonusPlayerOnly)
                        return;

                    __result = __result * (AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.StaggerBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.StaggerBonusAttribute), (CharacterObject)defenderAgent.Character) + 1);
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultAgentApplyDamageModelPatch.CalculateStaggerThresholdDamage threw exception: " + e);
            }
        }
    }
}
