using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes.Patches {
    [HarmonyPatch]
    internal class MissionPatch {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Mission), "UpdateMomentumRemaining")]
        private static bool UpdateMomentumRemaining(ref float momentumRemaining, Blow b, in AttackCollisionData collisionData, Agent attacker, Agent victim, in MissionWeapon attackerWeapon, ref bool isCrushThrough) {
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

                if (MathHelper.RandomChance (AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.SliceChance, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.SliceChanceAttribute), (CharacterObject)attacker.Character))) {
                

                    if (attacker.IsMainAgent) {
						NotifyHelper.WriteMessage("Cut through!", MsgType.Good);
					}

                    return false;
                }

            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "Mission.UpdateMomentumRemaining threw exception: " + e);
            }

            return true;
        }
    }
}
