using BetterAttributes.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes.Patches {

	[HarmonyPatch]
	class PrefixPatches {

		[HarmonyPrefix]
		[HarmonyPatch(typeof(Mission), "UpdateMomentumRemaining")]
		private static bool UpdateMomentumRemaining(ref float momentumRemaining, Blow b, in AttackCollisionData collisionData, Agent attacker, Agent victim, in MissionWeapon attackerWeapon, ref bool isCrushThrough) {
			try {

				if (attacker == null) {
					return true;
				}

				if (Helper.settings.cutAllHeroes) {
					if (!attacker.IsHero) {
						//Not a hero, let TW method run
						return true;
					}
				} else {
					if (!attacker.IsMainAgent) {
						//Not main agent, let TW method run
						return true;
					}
				}

				CharacterObject co = attacker.Character as CharacterObject;

				double cutThroughChance = co.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Vigor) * Helper.settings.cutChancePerVigor;

				double random = MBRandom.RandomFloat;

				if (random <= Helper.GetAttributeEffect(Helper.settings.cutChancePerVigor, DefaultCharacterAttributes.Vigor, co)) {

					/*if (attacker.IsMainAgent) {
						Helper.DisplayFriendlyMsg("cut through!");
					}*/

					return false;
				}

			} catch (Exception e) {
				Helper.WriteToLog("Issue with cut through. " + e);
			}

			//If all fails let TW method take over
			return true;
		}
	}
}
