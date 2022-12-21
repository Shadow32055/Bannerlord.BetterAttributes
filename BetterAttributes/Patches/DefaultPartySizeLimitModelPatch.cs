using BetterAttributes.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel))]
    class DefaultPartySizeLimitModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyMemberSizeLimit))]
        public static void GetPartyMemberSizeLimit(ref ExplainedNumber __result, PartyBase party) {
            try {
                if (Helper.settings.partySizeBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && Helper.settings.partySizeBonusPlayerOnly)
                        return;

                    __result.AddFactor(Helper.GetAttributeEffect(Helper.settings.partySizeBonus, Helper.GetAttributeTypeFromText(Helper.settings.partySizeBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.partySizeBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with DefaultPartySizeLimitModelPatch.GetPartyMemberSizeLimit postfix. Exception output: " + e);
            }
        }
    }
}
