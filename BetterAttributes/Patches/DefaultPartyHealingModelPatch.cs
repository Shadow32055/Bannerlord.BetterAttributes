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
                if (BetterAttributes.Settings.HealthRegenBonusEnabled) {

                    if (party.LeaderHero is null)
                        return;
                    
                    if (__result.ResultNumber <= 0)
                        return;

                    if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HealthRegenBonusAttribute) != AttributeHelper.None) {
                        __result.AddFactor(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.HealthRegenBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HealthRegenBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HealthRegenBonusAttribute).Name + " Bonus", null));
                    }
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultPartyHealingModel.GetDailyHealingHpForHeroes threw exception: " + e);
            }
        }
    }
}
