using BetterAttributes.Utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;

//TODO: Revisit, dosent work
namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(CharacterAttributeItemVM), MethodType.Constructor)]
    [HarmonyPatch(new Type[] { typeof(Hero), typeof(CharacterAttribute), typeof(CharacterVM), typeof(Action<CharacterAttributeItemVM>), typeof(Action<CharacterAttributeItemVM>) })]
    class AttributeVMPatches {

        public static void Postfix(ref CharacterAttributeItemVM __instance, Hero hero, CharacterAttribute currAtt, CharacterVM developerVM, Action<CharacterAttributeItemVM> onInpectAttribute, Action<CharacterAttributeItemVM> onAddAttributePoint) {

            string text = "";

            List<CustomAtrObject> bonuses = getAllBonusForGivenAttribute(currAtt, hero.GetAttributeValue(currAtt));

            foreach (CustomAtrObject co in bonuses) {
                text += co.text + (co.bonus * co.level).ToString("P") + "\n";
            }

            __instance.IncreaseHelpText = text + "\n" + __instance.IncreaseHelpText;
        }

        private static List<CustomAtrObject> getAllBonusForGivenAttribute(CharacterAttribute ca, int lvl) {

            List<CustomAtrObject> aplicableBonuses = new List<CustomAtrObject>();

            if (Helper.GetAttributeTypeFromText(Helper.settings.melDmgBonusAttribute) == ca && Helper.settings.melDmgBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.melDmgBonus, "Increases melee damage by ", lvl));
            
            if (Helper.GetAttributeTypeFromText(Helper.settings.rngDmgBonusAttribute) == ca && Helper.settings.rngDmgBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.rngDmgBonus, "Increases range damage by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.healthBonusAttribute) == ca && Helper.settings.healthBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.healthBonus, "Increases HP by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.staggerBonusAttribute) == ca && Helper.settings.staggerBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.staggerBonus, "Increases stagger interrupt by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.simBonusAttribute) == ca && Helper.settings.simBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.simBonus, "Increases simulation by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.persuasionBonusAttribute) == ca && Helper.settings.persuasionBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.persuasionBonus, "Increases persuasion by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.renownBonusAttribute) == ca && Helper.settings.renownBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.renownBonus, "Increases renown earned from victories by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.moraleBonusAttribute) == ca && Helper.settings.moraleBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.moraleBonus, "Increases moral earned from victories by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.partyMoraleBonusAttribute) == ca && Helper.settings.partyMoraleBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.partyMoraleBonus, "Increases party moral by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.wageBonusAttribute) == ca && Helper.settings.wageBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.wageBonus, "Decreases party wages by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.partySizeBonusAttribute) == ca && Helper.settings.partySizeBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.partySizeBonus, "Increases party size by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.incomeBonusAttribute) == ca && Helper.settings.incomeBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.incomeBonus, "Increases gross income by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.influenceBonusAttribute) == ca && Helper.settings.influenceBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.influenceBonus, "Increases influence earned from victories by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.xpBonusAttribute) == ca && Helper.settings.xpBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.xpBonus, "Increases experience gain by ", lvl));

            if (Helper.GetAttributeTypeFromText(Helper.settings.partyLeaderXPBonusAttribute) == ca && Helper.settings.partyLeaderXPBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, Helper.settings.partyLeaderXPBonus, "Increases party leader experience gain by ", lvl));

            return aplicableBonuses;
        }
    }


    internal class CustomAtrObject {
        public CharacterAttribute characterAttribute;
        public float bonus;
        public string text;
        public int level;

        public CustomAtrObject(CharacterAttribute ca, float b, string s, int lvl) {
            characterAttribute = ca;
            bonus = b;
            text = s;
            level = lvl;
        }
    }
}
