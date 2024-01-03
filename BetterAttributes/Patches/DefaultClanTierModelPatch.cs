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
                if (SubModule._settings.companionBonusEnabled) {
                    __result = __result + (int)AttributeHelper.GetAttributeEffect(SubModule._settings.companionBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.companionBonusAttribute), Hero.MainHero.CharacterObject);
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultClanTierModelPatch.GetCompanionLimit threw exception: " + e, Severity.High);
            }
        }
    }
}
