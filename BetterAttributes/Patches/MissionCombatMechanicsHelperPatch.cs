using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(MissionCombatMechanicsHelper))]
    class MissionCombatMechanicsHelperPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowDamage")]
        public static void ComputeBlowDamage(ref AttackInformation attackInformation, ref AttackCollisionData attackCollisionData, WeaponComponentData attackerWeapon, DamageTypes damageType, float magnitude, int speedBonus, bool cancelDamage, ref int inflictedDamage, ref int absorbedByArmor) {
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

                    inflictedDamage = inflictedDamage * (int)(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.MelDmgBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.MelDmgBonusAttribute), (CharacterObject)attackInformation.AttackerAgentCharacter) + 1 );
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "MissionCombatMechanicsHelperPatch.ComputeBlowDamage threw exception: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowMagnitude")]
        public static void ComputeBlowMagnitude(ref AttackCollisionData acd, ref AttackInformation attackInformation, MissionWeapon weapon, float momentumRemaining, bool cancelDamage, bool hitWithAnotherBone, TaleWorlds.Library.Vec2 attackerVelocity, TaleWorlds.Library.Vec2 victimVelocity, ref float baseMagnitude, ref float specialMagnitude, ref float movementSpeedDamageModifier, ref int speedBonusInt) {
            try {
                if (attackInformation.AttackerAgentCharacter == null) 
                    return;

                if (!attackInformation.AttackerAgentCharacter.IsHero)
                    return;

                if (BetterAttributes.Settings.RngDmgBonusEnabled) {

                    if (attackInformation.IsAttackerAIControlled && BetterAttributes.Settings.RngDmgBonusPlayerOnly)
                        return;

                    float val = AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.RngDmgBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.RngDmgBonusAttribute), (CharacterObject)attackInformation.AttackerAgentCharacter) + 1;
                    specialMagnitude *= val;
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "MissionCombatMechanicsHelperPatch.ComputeBlowMagnitude threw exception: " + e);
            }
        }
    }
}
