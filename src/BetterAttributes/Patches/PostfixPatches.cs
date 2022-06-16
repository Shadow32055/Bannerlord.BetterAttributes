using BetterAttributes.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace BetterAttributes.Patches {

    [HarmonyPatch]
    class PostfixPatches {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
        public static void CalculatePartyWage(ref int __result, MobileParty mobileParty, int budget, bool applyWithdrawals) {
            try {
                if (mobileParty.LeaderHero is null)
                    return;

                if (!Helper.settings.wageAllHeroes && !mobileParty.LeaderHero.IsHumanPlayerCharacter)
                    return;

                __result = (int)(__result * (1 - Helper.GetAttributeEffect(Helper.settings.wageDecreasePerSocial, DefaultCharacterAttributes.Social, mobileParty.LeaderHero.CharacterObject)));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with wage reduction. " + e);
            }
        }

        /*[HarmonyPostfix]
        [HarmonyPatch(typeof(Mission), "ComputeBlowDamage")]
        public static void ComputeBlowDamage(ref AttackInformation attackInformation, ref AttackCollisionData attackCollisionData, in MissionWeapon attackerWeapon, DamageTypes damageType,
            float magnitude, int speedBonus, bool cancelDamage, ref int inflictedDamage, ref int absorbedByArmor) {

            if (attackInformation.AttackerAgentCharacter.IsPlayerCharacter) {
                //Helper.DisplayFriendlyMsg("Might work? - dmg: " + inflictedDamage);
                inflictedDamage = inflictedDamage * 3;
            }
        }*/

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
        public static void MaxHitpoints(ref ExplainedNumber __result, CharacterObject character, bool includeDescriptions = false) {
            try {

                if (!character.IsHero)
                    return;

                if (!Helper.settings.healthIncAllHeroes && !character.IsPlayerCharacter)
                    return;

                __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.healthIncreasePerEndurance, DefaultCharacterAttributes.Endurance, character), new TextObject("Health from Endurance", null));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with hitpoints. " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultGenericXpModel), "GetXpMultiplier")]
        public static void GetXpMultiplier(ref float __result, Hero hero) {
            try {
                if (hero is null)
                    return;

                if (!Helper.settings.xpAllHeroes && !hero.IsHumanPlayerCharacter)
                    return;

                __result = 1;

                //Helper.DisplayFriendlyMsg("Xp Muilti is :" + __result);


            } catch (Exception e) {
                Helper.WriteToLog("Issue with xp multiplier. " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), "LevelsPerAttributePoint", MethodType.Getter)]
        public static void LevelsPerAttributePoint(ref int __result) {
            __result = Helper.settings.levelsPerAttributePoint;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), "FocusPointsPerLevel", MethodType.Getter)]
        public static void FocusPointsPerLevel(ref int __result) {
            __result = Helper.settings.focusPointsPerLevel;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), "MaxAttribute", MethodType.Getter)]
        public static void MaxAttribute(ref int __result) {
            __result = 11;
        }

        /* For when I get more ambitious
        static FieldRef<Hero, SkillEffect> _effectOneHandedSpeed = AccessTools.FieldRefAccess<DefaultSkillEffects, SkillEffect>("_effectOneHandedSpeed");

        [HarmonyPrefix]
        [HarmonyPatch(typeof(HeroDeveloper), "AddAttribute")]
        public static bool AddAttribute(ref HeroDeveloper __instance, CharacterAttribute attrib, int changeAmount, bool checkUnspentPoints = true) {
            if (changeAmount == 0) {
                return true;
            }
            int attributeValue = __instance.Hero.GetAttributeValue(attrib);
            if (attributeValue + changeAmount <= 10 && (__instance.UnspentAttributePoints >= 1 || !checkUnspentPoints)) {
                int value = attributeValue + changeAmount;
                __instance.Hero.S
                __instance.Hero.SetAttributeValueInternal(attrib, value);
                if (checkUnspentPoints) {
                    __instance.UnspentAttributePoints--;
                }
            }

            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Hero), "SetAttributeValueInternal")]
        internal void SetAttributeValueInternal(CharacterAttribute charAttribute, int value, ref Hero __instance) {
            int value2 = MBMath.ClampInt(value, 0, 10);
            __instance._characterAttributes.SetPropertyValue(charAttribute, value2);
        }*/

        /*static FieldRef<DefaultCharacterDevelopmentModel, int> MaxAttributeLevel = AccessTools.FieldRefAccess<DefaultCharacterDevelopmentModel, int>("MaxAttributeLevel");

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), "InitializeSkillsRequiredForLevel")]
        public static void InitializeSkillsRequiredForLevel(DefaultCharacterDevelopmentModel __instance) {
            MaxAttributeLevel(__instance) = 100;
        }*/



        //Moral TaleWorlds.CampaignSystem.SandBox.GameComponents.Party DefaultPartyMoraleModel
        //Party Size TaleWorlds.CampaignSystem.SandBox.GameComponents.Party DefaultPartySizeLimitModel
        //Renown/Infulence TaleWorlds.CampaignSystem.SandBox.GameComponents.Map DefaultBattleRewardModel

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
        public static void GetEffectivePartyMorale(ref ExplainedNumber __result, MobileParty mobileParty, bool includeDescription = false) {
            try {
                if (mobileParty.LeaderHero is null)
                    return;

                if (!Helper.settings.moralAllHeroes && !mobileParty.LeaderHero.IsHumanPlayerCharacter)
                    return;

                __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.moralBonusPerControl, DefaultCharacterAttributes.Control, mobileParty.LeaderHero.CharacterObject), new TextObject("Moral from Control", null));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with party morale. " + e);
            }
        }
    }
}
