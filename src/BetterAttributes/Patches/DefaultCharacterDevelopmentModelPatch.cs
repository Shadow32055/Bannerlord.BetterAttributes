using BetterAttributes.Utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel))]
    class DefaultCharacterDevelopmentModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.LevelsPerAttributePoint), MethodType.Getter)]
        public static void LevelsPerAttributePoint(ref int __result) {
            __result = Helper.settings.levelsPerAttributePoint;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.FocusPointsPerLevel), MethodType.Getter)]
        public static void FocusPointsPerLevel(ref int __result) {
            __result = Helper.settings.focusPointsPerLevel;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.MaxFocusPerSkill), MethodType.Getter)]
        public static void MaxFocusPerSkill(ref int __result) {
            __result = Helper.settings.maxFocusPointsPerSkill;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.MaxAttribute), MethodType.Getter)]
        public static void MaxAttribute(ref int __result) {
            __result = Helper.settings.maxAttributeLevel;
        }




    }
}
