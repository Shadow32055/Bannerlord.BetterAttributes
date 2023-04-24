using BetterAttributes.Utils;
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
                if (Helper.settings.healthRegenBonusEnabled) {

                    if (party.LeaderHero is null)
                        return;
                    
                    if (__result.ResultNumber <= 0)
                        return;

                    __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.healthRegenBonus, Helper.GetAttributeTypeFromIndex(Helper.settings.healthRegenBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromIndex(Helper.settings.healthRegenBonusAttribute).Name + " Bonus", null));

                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultPartyHealingModelPatch.GetDailyHealingHpForHeroes postfix. Exception output: " + e);
            }
        }
    }
}
