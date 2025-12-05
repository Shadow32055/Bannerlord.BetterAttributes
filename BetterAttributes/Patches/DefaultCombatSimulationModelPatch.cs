using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace BetterAttributes.Patches
{
    [HarmonyPatch(typeof(DefaultCombatSimulationModel))]
    class DefaultCombatSimulationModelPatch
    {

        [HarmonyPostfix]
        [HarmonyPatch(nameof(DefaultCombatSimulationModel.SimulateHit),
            new Type[] {
                typeof(CharacterObject),
                typeof(CharacterObject),
                typeof(PartyBase),
                typeof(PartyBase),
                typeof(float),
                typeof(MapEvent),
                typeof(float),
                typeof(float)
            }
        )]
        public static void SimulateHit(CharacterObject strikerTroop, CharacterObject struckTroop, PartyBase strikerParty, PartyBase struckParty, float strikerAdvantage, MapEvent battle, float strikerSideMorale, float struckSideMorale, ref ExplainedNumber __result)
        {
            try
            {
                if (BetterAttributes.Settings.SimBonusEnabled)
                {
                    if (!strikerTroop.IsHero)
                        return;

                    if (!strikerTroop.IsPlayerCharacter && BetterAttributes.Settings.SimBonusPlayerOnly)
                        return;

                    var factor = (AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.SimBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.SimBonusAttribute), strikerTroop.HeroObject.CharacterObject) + 1);
                    __result.AddFactor(factor);
#if DEBUG
                    NotifyHelper.WriteMessage($"Simulate Hero Hit: {__result.ResultNumber}", MsgType.Notify);
#endif
                }
            }
            catch (Exception e)
            {
                NotifyHelper.WriteError(BetterAttributes.ModName, "DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e);
            }
        }

        // ---------- War Sail bonus? ----------
        [HarmonyPostfix]
        [HarmonyPatch(nameof(DefaultCombatSimulationModel.SimulateHit),
            new Type[]
            {
                typeof(Ship),
                typeof(Ship),
                typeof(PartyBase),
                typeof(PartyBase),
                typeof(SiegeEngineType),
                typeof(float),
                typeof(MapEvent),
                typeof(int)
            },
            new ArgumentType[]
            {
                ArgumentType.Normal,
                ArgumentType.Normal,
                ArgumentType.Normal,
                ArgumentType.Normal,
                ArgumentType.Normal,
                ArgumentType.Normal,
                ArgumentType.Normal,
                ArgumentType.Out // <-- specify that last int is an out parameter
            }
        )]
        public static void SimulateHit(Ship strikerShip, Ship struckShip, PartyBase strikerParty, PartyBase struckParty, SiegeEngineType siegeEngine, float strikerAdvantage, MapEvent battle, ref int troopCasualties, ref ExplainedNumber __result)
        {
            try
            {
                if (BetterAttributes.Settings.SimBonusEnabled)
                {
                    var heroObject = strikerShip.Owner.LeaderHero;

                    if (heroObject == null)
                        return;

                    if (!heroObject.IsHumanPlayerCharacter && BetterAttributes.Settings.SimBonusPlayerOnly)
                        return;

                    var factor = (AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.SimBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.SimBonusAttribute), heroObject.CharacterObject) + 1);
                    __result.AddFactor(factor);
#if DEBUG
                    NotifyHelper.WriteMessage($"Simulate Ship Hit: {__result.ResultNumber}", MsgType.Notify);
#endif
                }
            }
            catch (Exception e)
            {
                NotifyHelper.WriteError(BetterAttributes.ModName, "DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e);
            }
        }

    }
}
