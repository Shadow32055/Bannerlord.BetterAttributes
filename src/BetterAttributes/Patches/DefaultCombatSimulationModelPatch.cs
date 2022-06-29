using BetterAttributes.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultCombatSimulationModel))]
    class DefaultCombatSimulationModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCombatSimulationModel), nameof(DefaultCombatSimulationModel.SimulateHit))]
        public static void SimulateHit(CharacterObject strikerTroop, CharacterObject struckTroop, PartyBase strikerParty, PartyBase struckParty, float strikerAdvantage, MapEvent battle, ref int __result) {
            try {
                if (Helper.settings.simBonusEnabled) {
                    if (!strikerTroop.IsHero)
                        return;

                    if (!strikerTroop.IsPlayerCharacter && Helper.settings.simBonusPlayerOnly)
                        return;


                    __result = __result * (int)(Helper.GetAttributeEffect(Helper.settings.simBonus, Helper.GetAttributeTypeFromText(Helper.settings.simBonusAttribute), strikerTroop.HeroObject.CharacterObject) + 1);
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultCombatSimulationModelPatch.SimulateHit postfix. Exception output: " + e);
            }
        }
    }
}
