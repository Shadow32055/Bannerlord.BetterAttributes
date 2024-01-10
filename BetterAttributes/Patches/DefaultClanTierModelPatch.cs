using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultClanTierModel))]
    class DefaultClanTierModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetCompanionLimit))]
        public static void GetCompanionLimit(ref int __result, Clan clan) {
            try {
                if (BetterAttributes.Settings.CompanionBonusEnabled) {
                    __result = __result + (int)AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.CompanionBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.CompanionBonusAttribute), Hero.MainHero.CharacterObject);
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributes.ModName, "DefaultClanTierModelPatch.GetCompanionLimit threw exception: " + e);
            }
        }
    }
}
