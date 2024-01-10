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

                if (BetterAttributes.Settings.ReloadBonusEnabled) {
                    if (!BetterAttributes.Settings.ReloadBonusPlayerOnly) {
                        //Should be all heroes
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.ReloadSpeed *= 1 + AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.ReloadBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.ReloadBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (BetterAttributes.Settings.HandlingBonusEnabled) {
                    if (!BetterAttributes.Settings.HandlingBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.HandlingMultiplier *= 1 + AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.HandlingBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HandlingBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (BetterAttributes.Settings.MovementBonusEnabled) {
                    if (!BetterAttributes.Settings.MovementBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.MaxSpeedMultiplier *= 1 + AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.MovementBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.MovementBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (BetterAttributes.Settings.AccuracyBonusEnabled) {
                    if (!BetterAttributes.Settings.AccuracyBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.WeaponInaccuracy /= AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.AccuracyBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.AccuracyBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (BetterAttributes.Settings.DrawBonusEnabled) {
                    if (!BetterAttributes.Settings.DrawBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.ThrustOrRangedReadySpeedMultiplier *= 1 + AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.DrawBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.DrawBonusAttribute), (CharacterObject)agent.Character);
                }

                applyBonus = false;

                if (BetterAttributes.Settings.StabilityBonusEnabled) {
                    if (!BetterAttributes.Settings.StabilityBonusPlayerOnly) {
                        applyBonus = true;
                    } else if (agent.IsMainAgent) {
                        applyBonus = true;
                    }

                    if (applyBonus)
                        agentDrivenProperties.WeaponUnsteadyBeginTime *= 1 + AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.StabilityBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.StabilityBonusAttribute), (CharacterObject)agent.Character);
                }

            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e);
            }
        }
    }
}
