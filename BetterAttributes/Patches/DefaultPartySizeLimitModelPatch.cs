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
                if (SubModule._settings.partySizeBonusEnabled) {
                    if (party.LeaderHero is null)
                        return;

                    if (!party.LeaderHero.IsHumanPlayerCharacter && SubModule._settings.partySizeBonusPlayerOnly)
                        return;

                    __result.AddFactor(AttributeHelper.GetAttributeEffect(SubModule._settings.partySizeBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.partySizeBonusAttribute), party.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.partySizeBonusAttribute).Name + " Bonus", null));
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultPartySizeLimitModelPatch.GetPartyMemberSizeLimit postfix threw exception: " + e, Severity.High);
            }
        }
    }
}
