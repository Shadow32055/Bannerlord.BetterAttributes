using BetterAttributes.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(MissionCombatMechanicsHelper))]
    class MissionCombatMechanicsHelperPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowDamage")]
        public static void ComputeBlowDamage(ref AttackInformation attackInformation, ref AttackCollisionData attackCollisionData, WeaponComponentData attackerWeapon, DamageTypes damageType, float magnitude, int speedBonus, bool cancelDamage, ref int inflictedDamage, ref int absorbedByArmor) {
            try {
                if (!attackInformation.AttackerAgentCharacter.IsHero)
                    return;

                if (Helper.settings.melDmgBonusEnabled && attackerWeapon.IsMeleeWeapon) {

                    if (attackInformation.IsAttackerAIControlled && Helper.settings.melDmgBonusPlayerOnly)
                        return;

                    inflictedDamage = inflictedDamage * (int)( Helper.GetAttributeEffect(Helper.settings.melDmgBonus, Helper.GetAttributeTypeFromText(Helper.settings.melDmgBonusAttribute), (CharacterObject)attackInformation.AttackerAgentCharacter) + 1 );
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with MissionCombatMechanicsHelperPatch.ComputeBlowDamage postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowMagnitude")]
        public static void ComputeBlowMagnitude(ref AttackCollisionData acd, ref AttackInformation attackInformation, MissionWeapon weapon, float momentumRemaining, bool cancelDamage, bool hitWithAnotherBone, Vec2 attackerVelocity, Vec2 victimVelocity, ref float baseMagnitude, ref float specialMagnitude, ref float movementSpeedDamageModifier, ref int speedBonusInt) {
            try {
                if (!attackInformation.AttackerAgentCharacter.IsHero)
                    return;

                if (Helper.settings.rngDmgBonusEnabled) {

                    if (attackInformation.IsAttackerAIControlled && Helper.settings.rngDmgBonusPlayerOnly)
                        return;

                    float val = Helper.GetAttributeEffect(Helper.settings.rngDmgBonus, Helper.GetAttributeTypeFromText(Helper.settings.rngDmgBonusAttribute), (CharacterObject)attackInformation.AttackerAgentCharacter) + 1;
                    specialMagnitude *= val;
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with MissionCombatMechanicsHelperPatch.ComputeBlowMagnitude postfix. Exception output: " + e);
            }
        }
    }
}
