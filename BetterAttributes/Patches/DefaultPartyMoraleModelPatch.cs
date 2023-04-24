using BetterAttributes.Utils;
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
                if (Helper.settings.partyMoraleBonusEnabled) {
                    if (mobileParty.LeaderHero is null)
                        return;

                    if (!mobileParty.LeaderHero.IsHumanPlayerCharacter && Helper.settings.partyMoraleBonusPlayerOnly)
                        return;

                    __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.partyMoraleBonus, Helper.GetAttributeTypeFromIndex(Helper.settings.partyMoraleBonusAttribute), mobileParty.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromIndex(Helper.settings.partyMoraleBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultPartyMoraleModelPatch.GetEffectivePartyMorale postfix. Exception output: " + e);
            }
        }
    }
}
