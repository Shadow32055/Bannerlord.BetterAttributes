using BetterAttributes.Utils;
using HarmonyLib;
using SandBox.GameComponents;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel))]
    class SandboxAgentStatCalculateModelPatch {


        [HarmonyPostfix]
        [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), nameof(SandboxAgentStatCalculateModel.UpdateAgentStats))]
        public static void UpdateAgentStats(Agent agent, AgentDrivenProperties agentDrivenProperties) {
            try {
                if (agent is null)
                    return;

                if (!agent.IsHuman)
                    return;

                if (!agent.IsHero)
                    return;

                if (Helper.settings.reloadBonusEnabled) {
                    if (!agent.IsMainAgent && Helper.settings.reloadBonusPlayerOnly)
                        return;

                    agentDrivenProperties.ReloadSpeed *= 1 + Helper.GetAttributeEffect(Helper.settings.reloadBonus, Helper.GetAttributeTypeFromText(Helper.settings.reloadBonusAttribute), (CharacterObject)agent.Character);
                }

                if (Helper.settings.handlingBonusEnabled) {
                     if (!agent.IsMainAgent && Helper.settings.handlingBonusPlayerOnly)
                        return;

                    agentDrivenProperties.HandlingMultiplier *= 1 + Helper.GetAttributeEffect(Helper.settings.handlingBonus, Helper.GetAttributeTypeFromText(Helper.settings.handlingBonusAttribute), (CharacterObject)agent.Character);
                }

                if (Helper.settings.movementBonusEnabled) {
                     if (!agent.IsMainAgent && Helper.settings.movementBonusPlayerOnly)
                        return;

                    agentDrivenProperties.MaxSpeedMultiplier *= 1 + Helper.GetAttributeEffect(Helper.settings.movementBonus, Helper.GetAttributeTypeFromText(Helper.settings.movementBonusAttribute), (CharacterObject)agent.Character);
                }

            } catch (Exception e) {
                Helper.WriteToLog("Issue with SandboxAgentStatCalculateModelPatch.UpdateAgentStats postfix. Exception output: " + e);
            }
        }
    }
}
