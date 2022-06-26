using BetterAttributes.Utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;

//TODO: Revisit, dosent work
namespace BetterAttributes.Patches {
    class AttributeVMPatches {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(CharacterAttributeItemVM), MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(Hero), typeof(CharacterAttribute), typeof(CharacterVM), typeof(Action<CharacterAttributeItemVM>), typeof(Action<CharacterAttributeItemVM>) })]
        public static void Postfix(CharacterAttributeItemVM __instance, Hero hero, CharacterAttribute currAtt, CharacterVM developerVM, Action<CharacterAttributeItemVM> onInpectAttribute, Action<CharacterAttributeItemVM> onAddAttributePoint) {

            string text = "testing";

            List<CustomAtrObject> bonuses = getAllBonusForGivenAttribute(currAtt);

            foreach (CustomAtrObject co in bonuses) {
                text += co.text + co.bonus.ToString("P") + "\n";
            }

            Helper.DisplayFriendlyMsg("testing!");
            __instance.IncreaseHelpText = text + __instance.IncreaseHelpText;

        }


        private static List<CustomAtrObject> getAllBonusForGivenAttribute(CharacterAttribute ca) {

            List<CustomAtrObject> aplicableBonuses = new List<CustomAtrObject>();

            if (Helper.settings.melDmgBonusAttribute == ca.ToString())
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.melDmgBonus, "Increases melee damage by "));

            if (Helper.settings.rngDmgBonusAttribute == ca.ToString())
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.rngDmgBonus, "Increases range damage by "));

            //"Increases HP by "
            //"Increases party size limit by "
            //"Increases persuade chance by " 
            //"Increases renown gain by " 
            //"Increases influnce gain by " 
            //"Increases learning rate for all skills by " 
            //"Increases clan income by "

            return aplicableBonuses;
        }
    }
}

internal class CustomAtrObject {
    public CharacterAttribute characterAttribute;
    public float bonus;
    public string text;

    public CustomAtrObject(CharacterAttribute ca, float b, string s) {
        characterAttribute = ca;
        bonus = b;
        text = s;
    }
}
