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
        public static void GetEffectivePartyMorale(ref ExplainedNumber __result, MobileParty mobileParty) {
            try {
                if (SubModule._settings.partyMoraleBonusEnabled) {
                    if (mobileParty.LeaderHero is null)
                        return;

                    if (!mobileParty.LeaderHero.IsHumanPlayerCharacter && SubModule._settings.partyMoraleBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(SubModule._settings.partyMoraleBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.partyMoraleBonusAttribute), mobileParty.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.partyMoraleBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultClanFinanceModelPatch.CalculateClanIncomeInternal threw exception: " + e, Severity.High);
            }
        }
    }
}
