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

                if (SubModule._settings.melDmgBonusEnabled && attackerWeapon.IsMeleeWeapon) {

                    if (attackInformation.IsAttackerAIControlled && SubModule._settings.melDmgBonusPlayerOnly)
                        return;

                    inflictedDamage = inflictedDamage * (int)(AttributeHelper.GetAttributeEffect(SubModule._settings.melDmgBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.melDmgBonusAttribute), (CharacterObject)attackInformation.AttackerAgentCharacter) + 1 );
                }
            } catch (Exception e) {
                Logger.SendMessage("MissionCombatMechanicsHelperPatch.ComputeBlowDamage threw exception: " + e, Severity.High);
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

                if (SubModule._settings.rngDmgBonusEnabled) {

                    if (attackInformation.IsAttackerAIControlled && SubModule._settings.rngDmgBonusPlayerOnly)
                        return;

                    float val = AttributeHelper.GetAttributeEffect(SubModule._settings.rngDmgBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.rngDmgBonusAttribute), (CharacterObject)attackInformation.AttackerAgentCharacter) + 1;
                    specialMagnitude *= val;
                }
            } catch (Exception e) {
                Logger.SendMessage("MissionCombatMechanicsHelperPatch.ComputeBlowMagnitude threw exception: " + e, Severity.High);
            }
        }
    }
}
