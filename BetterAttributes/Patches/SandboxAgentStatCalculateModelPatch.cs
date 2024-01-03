using BetterCore.Utils;
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

                bool applyBonus = false;

                if (SubModule._settings.reloadBonusEnabled) {
                    if (!SubModule._settings.reloadBonusPlayerOnly) {
                        //Should be all heroes
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.ReloadSpeed *= 1 + AttributeHelper.GetAttributeEffect(SubModule._settings.reloadBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.reloadBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (SubModule._settings.handlingBonusEnabled) {
                    if (!SubModule._settings.handlingBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.HandlingMultiplier *= 1 + AttributeHelper.GetAttributeEffect(SubModule._settings.handlingBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.handlingBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (SubModule._settings.movementBonusEnabled) {
                    if (!SubModule._settings.movementBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.MaxSpeedMultiplier *= 1 + AttributeHelper.GetAttributeEffect(SubModule._settings.movementBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.movementBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (SubModule._settings.accuracyBonusEnabled) {
                    if (!SubModule._settings.accuracyBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.WeaponInaccuracy /= AttributeHelper.GetAttributeEffect(SubModule._settings.accuracyBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.accuracyBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (SubModule._settings.drawBonusEnabled) {
                    if (!SubModule._settings.drawBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.ThrustOrRangedReadySpeedMultiplier *= 1 + AttributeHelper.GetAttributeEffect(SubModule._settings.drawBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.drawBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (SubModule._settings.stabilityBonusEnabled) {
                    if (!SubModule._settings.stabilityBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.WeaponUnsteadyBeginTime *= 1 + AttributeHelper.GetAttributeEffect(SubModule._settings.stabilityBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.stabilityBonusAttribute), (CharacterObject)agent.Character);
                }

            } catch (Exception e) {
                Logger.SendMessage("DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e, Severity.High);
            }
        }
    }
}
