using BetterAttributes.Utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultClanTierModel))]
    class DefaultClanTierModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetCompanionLimit))]
        public static void GetCompanionLimit(ref int __result, Clan clan) {
            try {
                if (Helper.settings.companionBonusEnabled) {
                    __result = __result + (int)Helper.GetAttributeEffect(Helper.settings.companionBonus, Helper.GetAttributeTypeFromText(Helper.settings.companionBonusAttribute), Hero.MainHero.CharacterObject);
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with GetCompanionLimit Postfix. Exception output: " + e);
            }
        }
    }
}
