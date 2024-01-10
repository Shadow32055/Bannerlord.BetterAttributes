using BetterCore.Utils;
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
                if (BetterAttributes.Settings.PartySizeBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && BetterAttributes.Settings.PartySizeBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.PartySizeBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.PartySizeBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.PartySizeBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultPartySizeLimitModelPatch.GetPartyMemberSizeLimit postfix threw exception: " + e);
            }
        }
    }
}
