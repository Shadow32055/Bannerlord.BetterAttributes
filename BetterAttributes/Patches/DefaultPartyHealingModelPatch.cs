using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultPartyHealingModel))]
    class DefaultPartyHealingModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartyHealingModel), nameof(DefaultPartyHealingModel.GetDailyHealingHpForHeroes))]
        public static void GetDailyHealingHpForHeroes(ref ExplainedNumber __result, MobileParty party, bool includeDescriptions = false) {
            try {
                if (SubModule._settings.healthRegenBonusEnabled) {

                    if (party.LeaderHero is null)
                        return;
                    
                    if (__result.ResultNumber <= 0)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(SubModule._settings.healthRegenBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.healthRegenBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.healthRegenBonusAttribute).Name + " Bonus", null));

                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e, Severity.High);
            }
        }
    }
}
