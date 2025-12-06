using BetterCore.Utils;
using HarmonyLib;
using SandBox.GameComponents;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel))]
    class SandboxAgentApplyDamageModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateStaggerThresholdDamage))]
        public static void CalculateStaggerThresholdDamage(Agent defenderAgent, in Blow blow, ref float __result) {
            try {
                if (!BetterAttributes.Settings.StaggerBonusEnabled)
                    return;

                if (defenderAgent == null)
                    return;

                if (!defenderAgent.IsHero)
                    return;

                if (defenderAgent.IsAIControlled && BetterAttributes.Settings.StaggerBonusPlayerOnly)
                    return;

                __result = __result * (AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.StaggerBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.StaggerBonusAttribute), (CharacterObject)defenderAgent.Character) + 1);
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "SandboxAgentApplyDamageModelPatch.CalculateStaggerThresholdDamage threw exception: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideCrushedThrough))]
        public static void DecideCrushedThroughPostfix(ref bool __result, Agent attackerAgent) {
            try {

                if (!BetterAttributes.Settings.CrushEnabled)
                    return;

                if (attackerAgent == null)
                    return;

                if (!attackerAgent.IsHero)
                    return;

                if (!attackerAgent.IsPlayerControlled && BetterAttributes.Settings.CrushPlayerOnly)
                    return;

                if (!MathHelper.RandomChance((AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.CrushChance, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.CrushChanceAttribute), (CharacterObject)attackerAgent.Character))))
                    return;

                __result = true;

            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "SandboxAgentApplyDamageModelPatch.DecideCrushedThroughPostfix threw exception: " + e);
            }
        }
    }
}
