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
                if (BetterAttributes.Settings.SimBonusEnabled) {
                    if (!strikerTroop.IsHero)
                        return;

                    if (!strikerTroop.IsPlayerCharacter && BetterAttributes.Settings.SimBonusPlayerOnly)
                        return;


                    __result = __result * (int)(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.SimBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.SimBonusAttribute), strikerTroop.HeroObject.CharacterObject) + 1);
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e);
            }
        }
    }
}
