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
        public static void GetDailyHealingHpForHeroes(ref ExplainedNumber __result, PartyBase party, bool isPrisoners, bool includeDescriptions) {
            try {
                if (!BetterAttributes.Settings.HealthRegenBonusEnabled)
                    return;

                if (party is null)
                    return;

                if (!party.IsMobile)
                    return;

                if (party.LeaderHero is null)
                    return;

                if (__result.ResultNumber <= 0)
                    return;

                float factor = AttributeHelper.GetAttributeEffect(
                    BetterAttributes.Settings.HealthRegenBonus,
                    AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HealthRegenBonusAttribute),
                    party.LeaderHero.CharacterObject
                );

                __result.AddFactor(factor, new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HealthRegenBonusAttribute).Name + " Bonus", null));
#if DEBUG
                NotifyHelper.WriteMessage($"Daily Healing: {__result.ResultNumber}", MsgType.Notify);
#endif
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "DefaultPartyHealingModel.GetDailyHealingHpForHeroes threw exception: " + e);
            }
        }
    }
}
