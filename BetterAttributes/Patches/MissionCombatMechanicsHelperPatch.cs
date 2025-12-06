using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(MissionCombatMechanicsHelper))]
    class MissionCombatMechanicsHelperPatch {
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowDamage")]
        [HarmonyPostfix]
        public static void ComputeBlowDamage(in AttackInformation attackInformation, in AttackCollisionData attackCollisionData, WeaponComponentData attackerWeapon, DamageTypes damageType, float magnitude, int speedBonus, bool cancelDamage, ref int inflictedDamage, ref int absorbedByArmor, ref bool isSneakAttack) {
            try {
                if (attackInformation.AttackerAgentCharacter == null)
                    return;

                if (!attackInformation.AttackerAgentCharacter.IsHero)
                    return;

                if (attackerWeapon == null)
                    return;

                if (BetterAttributes.Settings.MelDmgBonusEnabled && attackerWeapon.IsMeleeWeapon) {

                    if (attackInformation.IsAttackerAIControlled && BetterAttributes.Settings.MelDmgBonusPlayerOnly)
                        return;

                    var dmgBonus = (int)(AttributeHelper.GetAttributeEffect(
                        BetterAttributes.Settings.MelDmgBonus, 
                        AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.MelDmgBonusAttribute), 
                        (CharacterObject)attackInformation.AttackerAgentCharacter) + 1
                    );

                    inflictedDamage = inflictedDamage * dmgBonus;
#if DEBUG
                    NotifyHelper.WriteMessage($"ComputeBlowDamage: {inflictedDamage}", MsgType.Notify);
#endif
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "MissionCombatMechanicsHelperPatch.ComputeBlowDamage threw exception: " + e);
            }
        }

        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowMagnitude")]
        [HarmonyPostfix]
        public static void ComputeBlowMagnitude(in AttackCollisionData acd, in AttackInformation attackInformation, float momentumRemaining, bool cancelDamage, bool hitWithAnotherBone, Vec2 attackerVelocity, Vec2 victimVelocity, ref float baseMagnitude, ref float specialMagnitude, ref float movementSpeedDamageModifier, ref int speedBonusInt) {
            try {
                if (attackInformation.AttackerAgentCharacter == null)
                    return;
                if (!attackInformation.AttackerAgentCharacter.IsHero)
                    return;

                if (BetterAttributes.Settings.RngDmgBonusEnabled) {
                    if (attackInformation.IsAttackerAIControlled && BetterAttributes.Settings.RngDmgBonusPlayerOnly)
                        return;

                    float val = AttributeHelper.GetAttributeEffect(
                        BetterAttributes.Settings.RngDmgBonus,
                        AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.RngDmgBonusAttribute),
                        (CharacterObject)attackInformation.AttackerAgentCharacter
                    ) + 1;

                    specialMagnitude *= val;
#if DEBUG
                    NotifyHelper.WriteMessage($"ComputeBlowMagnitude {specialMagnitude}", MsgType.Notify);
#endif
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "MissionCombatMechanicsHelperPatch.ComputeBlowMagnitude threw exception: " + e);
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "UpdateMomentumRemaining")]
        public static bool UpdateMomentumRemaining(ref float momentumRemaining, in Blow b, in AttackCollisionData collisionData, Agent attacker, Agent victim, in MissionWeapon attackerWeapon, bool isCrushThrough) {
            try {
                if (!BetterAttributes.Settings.SliceEnabled)
                    return true;

                if (attacker == null)
                    return true;

                if (!attacker.IsHero)
                    return true;

                if (BetterAttributes.Settings.SlicePlayerOnly && !attacker.IsPlayerControlled)
                    return true;

                double random = MBRandom.RandomFloat;

                if (MathHelper.RandomChance(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.SliceChance, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.SliceChanceAttribute), (CharacterObject)attacker.Character))) {
                    if (attacker.IsMainAgent)
                        if (BetterAttributes.Settings.SliceNotify)
                            NotifyHelper.WriteMessage("Cut through!", MsgType.Good);

                    return false;
                }

            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "Mission.UpdateMomentumRemaining threw exception: " + e);
            }

            return true;
        }
    }
}
