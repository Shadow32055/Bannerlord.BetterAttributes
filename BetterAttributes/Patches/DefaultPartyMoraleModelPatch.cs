using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultPartyMoraleModel))]
    class DefaultPartyMoraleModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartyMoraleModel), nameof(DefaultPartyMoraleModel.GetEffectivePartyMorale))]
        public static void GetEffectivePartyMorale(ref ExplainedNumber __result, MobileParty mobileParty, bool includeDescription) {
            try {
                if (BetterAttributes.Settings.PartyMoraleBonusEnabled) {
                    if (mobileParty.LeaderHero is null)
                        return;

                    if (!mobileParty.LeaderHero.IsHumanPlayerCharacter && BetterAttributes.Settings.PartyMoraleBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.PartyMoraleBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.PartyMoraleBonusAttribute), mobileParty.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.PartyMoraleBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e);
            }
        }
    }
}
