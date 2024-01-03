using BetterCore.Utils;
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
                if (SubModule._settings.simBonusEnabled) {
                    if (!strikerTroop.IsHero)
                        return;

                    if (!strikerTroop.IsPlayerCharacter && SubModule._settings.simBonusPlayerOnly)
                        return;


                    __result = __result * (int)(AttributeHelper.GetAttributeEffect(SubModule._settings.simBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.simBonusAttribute), strikerTroop.HeroObject.CharacterObject) + 1);
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e, Severity.High);
            }
        }
    }
}
