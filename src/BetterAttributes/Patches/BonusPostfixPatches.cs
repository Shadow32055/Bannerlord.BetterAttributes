using System;

using HarmonyLib;

using BetterAttributes.Utils;

using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;

namespace BetterAttributes.Patches {

    [HarmonyPatch]
    class BonusPostfixPatches {

        // Vigor/Control melee/range dmg boost
        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowDamage")]
        public static void ComputeBlowDamage(ref AttackInformation attackInformation, ref AttackCollisionData attackCollisionData, WeaponComponentData attackerWeapon, DamageTypes damageType, float magnitude, int speedBonus, bool cancelDamage, ref int inflictedDamage, ref int absorbedByArmor) {
            try {
                if (!attackInformation.AttackerAgentCharacter.IsHero)
                    return;
                

                if (attackerWeapon.IsRangedWeapon) {

                    if (attackInformation.IsAttackerAIControlled && Helper.settings.rngDmgBonusPlayerOnly)
                        return;
                    

                    inflictedDamage = inflictedDamage * (int)(Helper.GetAttributeEffect(Helper.settings.rngDmgBonus, Helper.GetAttributeTypeFromText(Helper.settings.rngDmgBonusAttribute), (CharacterObject)attackInformation.AttackerAgentCharacter) + 1);
                } else {

                    if (attackInformation.IsAttackerAIControlled && Helper.settings.melDmgBonusPlayerOnly)
                        return;
                    

                    inflictedDamage = inflictedDamage * (int)(Helper.GetAttributeEffect(Helper.settings.melDmgBonus, Helper.GetAttributeTypeFromText(Helper.settings.melDmgBonusAttribute), (CharacterObject)attackInformation.AttackerAgentCharacter) + 1);
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with ComputeBlowDamage Postfix. Exception output: " + e);
            }

        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
        public static void MaxHitpoints(ref ExplainedNumber __result, CharacterObject character, bool includeDescriptions = false) {
            try {

                if (!character.IsHero)
                    return;

                if (!character.IsPlayerCharacter && Helper.settings.healthBonusPlayerOnly)
                    return;

                __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.healthBonus, Helper.GetAttributeTypeFromText(Helper.settings.healthBonusAttribute), character), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.healthBonusAttribute).Name + " Bonus", null));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with MaxHitpoints Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), "CalculateStaggerThresholdMultiplier")]
        public static void CalculateStaggerThresholdMultiplier(Agent defenderAgent, ref float __result) {
            try {
                if (!defenderAgent.IsHero)
                    return;

                if (defenderAgent.IsAIControlled && Helper.settings.staggerBonusPlayerOnly)
                    return;


                __result = __result *(Helper.GetAttributeEffect(Helper.settings.staggerBonus, Helper.GetAttributeTypeFromText(Helper.settings.staggerBonusAttribute), (CharacterObject)defenderAgent.Character) + 1);

            } catch (Exception e) {
                Helper.WriteToLog("Issue with CalculateStaggerThresholdMultiplier Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCombatSimulationModel), "SimulateHit")]
        public static void SimulateHit(CharacterObject strikerTroop, CharacterObject struckTroop, PartyBase strikerParty, PartyBase struckParty, float strikerAdvantage, MapEvent battle, ref int __result) {
            try {
                if (!strikerTroop.IsHero)
                    return;

                if (!strikerTroop.IsPlayerCharacter && Helper.settings.simBonusPlayerOnly)
                    return;


                __result = __result * (int)(Helper.GetAttributeEffect(Helper.settings.simBonus, Helper.GetAttributeTypeFromText(Helper.settings.simBonusAttribute), strikerTroop.HeroObject.CharacterObject) + 1);

            } catch (Exception e) {
                Helper.WriteToLog("Issue with SimulateHit Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPersuasionModel), "GetDefaultSuccessChance")]
        public static void GetDefaultSuccessChance(PersuasionOptionArgs optionArgs, float difficultyMultiplier, ref float __result) {
            try {
                __result = __result * (Helper.GetAttributeEffect(Helper.settings.persuasionBonus, Helper.GetAttributeTypeFromText(Helper.settings.persuasionBonusAttribute), Hero.MainHero.CharacterObject) + 1);

            } catch (Exception e) {
                    Helper.WriteToLog("Issue with GetDefaultSuccessChance Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), "CalculateRenownGain")]
        public static void CalculateRenownGain(PartyBase party, float renownValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {

                if (party.LeaderHero is null)
                    return;
                
                if (!party.LeaderHero.IsHumanPlayerCharacter && Helper.settings.renownBonusPlayerOnly)
                    return;

                __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.renownBonus, Helper.GetAttributeTypeFromText(Helper.settings.renownBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.renownBonusAttribute).Name + " Bonus", null));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with CalculateRenownGain Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), "CalculateMoraleGainVictory")]
        public static void CalculateMoraleGainVictory(PartyBase party, float renownValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {

                if (party.LeaderHero is null)
                    return;

                if (!party.LeaderHero.IsHumanPlayerCharacter && Helper.settings.moraleBonusPlayerOnly)
                    return;

                __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.moraleBonus, Helper.GetAttributeTypeFromText(Helper.settings.moraleBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.moraleBonusAttribute).Name + " Bonus", null));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with CalculateMoraleGainVictory Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
        public static void GetEffectivePartyMorale(ref ExplainedNumber __result, MobileParty mobileParty) {
            try {
                if (mobileParty.LeaderHero is null)
                    return;

                if (!mobileParty.LeaderHero.IsHumanPlayerCharacter && Helper.settings.partyMoraleBonusPlayerOnly)
                    return;

                __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.partyMoraleBonus, Helper.GetAttributeTypeFromText(Helper.settings.partyMoraleBonusAttribute), mobileParty.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.partyMoraleBonusAttribute).Name + " Bonus", null));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with GetEffectivePartyMorale Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        public static void GetPartyMemberSizeLimit(ref ExplainedNumber __result, PartyBase party) {
            try {

                if (party.LeaderHero is null)
                    return;

                if (!party.LeaderHero.IsHumanPlayerCharacter && Helper.settings.partySizeBonusPlayerOnly)
                    return;

                __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.partySizeBonus, Helper.GetAttributeTypeFromText(Helper.settings.partySizeBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.partySizeBonusAttribute).Name + " Bonus", null));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with GetPartyMemberSizeLimit Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculateClanIncomeInternal")]
        public static void CalculateClanIncomeInternal(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false) {

            try {
                //goldChange.Add(1000, new TextObject("More Money!", null));

                if (clan.Leader is null)
                    return;

                if (!clan.Leader.IsHumanPlayerCharacter && Helper.settings.incomeBonusPlayerOnly)
                    return;

                if (goldChange.ResultNumber > 0) 
                    goldChange.AddFactor(Helper.GetAttributeEffect(Helper.settings.incomeBonus, Helper.GetAttributeTypeFromText(Helper.settings.incomeBonusAttribute), clan.Leader.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.incomeBonusAttribute).Name + " Bonus", null));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with CalculateClanIncomeInternal Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultBattleRewardModel), "CalculateInfluenceGain")]
        public static void CalculateInfluenceGain(PartyBase party, float influenceValueOfBattle, float contributionShare, ref ExplainedNumber __result) {
            try {

                if (party.LeaderHero is null)
                    return;

                if (!party.LeaderHero.IsHumanPlayerCharacter && Helper.settings.influenceBonusPlayerOnly)
                    return;

                __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.influenceBonus, Helper.GetAttributeTypeFromText(Helper.settings.influenceBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.influenceBonusAttribute).Name + " Bonus", null));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with CalculateInfluenceGain Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultGenericXpModel), "GetXpMultiplier")]
        public static void GetXpMultiplier(ref float __result, Hero hero) {
            try {
                if (hero is null)
                    return;

                if (!hero.IsHumanPlayerCharacter && Helper.settings.xpBonusPlayerOnly)
                    return;

                __result = __result * (1 + Helper.GetAttributeEffect(Helper.settings.xpBonus, Helper.GetAttributeTypeFromText(Helper.settings.xpBonusAttribute), hero.CharacterObject));

            } catch (Exception e) {
                Helper.WriteToLog("Issue with GetXpMultiplier Postfix. Exception output: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingHpForHeroes")]
        public static void GetDailyHealingHpForHeroes(ref ExplainedNumber __result, MobileParty party, bool includeDescriptions = false) {
            try {
                if (party.LeaderHero is null)
                    return;

                if (Helper.settings.healthBonusEnabled) {
                    float healthboost = party.LeaderHero.CharacterObject.MaxHitPoints() - 100;
                    __result.Add(healthboost / 10, new TextObject("Healing Boost", null));
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with GetDailyHealingHpForHeroes Postfix. Exception output: " + e);
            }
        }
    }
}
