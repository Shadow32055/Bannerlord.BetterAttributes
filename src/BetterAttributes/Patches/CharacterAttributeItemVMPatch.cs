using BetterAttributes.Utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(CharacterAttributeItemVM), MethodType.Constructor)]
    [HarmonyPatch(new Type[] { typeof(Hero), typeof(CharacterAttribute), typeof(CharacterVM), typeof(Action<CharacterAttributeItemVM>), typeof(Action<CharacterAttributeItemVM>) })]
    class CharacterAttributeItemVMPatch {

        public static void Postfix(ref CharacterAttributeItemVM __instance, Hero hero, CharacterAttribute currAtt, CharacterVM developerVM, Action<CharacterAttributeItemVM> onInpectAttribute, Action<CharacterAttributeItemVM> onAddAttributePoint) {
            try {
                string text = "";

                List<CustomAtrObject> bonuses = getAllBonusForGivenAttribute(currAtt, hero.GetAttributeValue(currAtt));


                foreach (CustomAtrObject co in bonuses) {

                    if (!hero.IsHumanPlayerCharacter && co.playerOnly)
                        continue;

                    text += co.displayString + "\n";
                }

                __instance.IncreaseHelpText = text + "\n" + __instance.IncreaseHelpText;
            } catch (Exception e) {
                Helper.WriteToLog("Issue with CharacterAttributeItemVMPatch.CharacterAttributeItemVM postfix. Exception output: " + e);
            }
        }

        private static List<CustomAtrObject> getAllBonusForGivenAttribute(CharacterAttribute ca, int lvl) {

            List<CustomAtrObject> aplicableBonuses = new List<CustomAtrObject>();

            if (Helper.GetAttributeTypeFromText(Helper.settings.melDmgBonusAttribute) == ca && Helper.settings.melDmgBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases melee damage by " + (Helper.settings.melDmgBonus * lvl).ToString("P") + "", Helper.settings.melDmgBonusPlayerOnly));
            
            if (Helper.GetAttributeTypeFromText(Helper.settings.rngDmgBonusAttribute) == ca && Helper.settings.rngDmgBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases ranged damage by " + (Helper.settings.rngDmgBonus * lvl).ToString("P") + "", Helper.settings.rngDmgBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.healthBonusAttribute) == ca && Helper.settings.healthBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases max hit points by " + (Helper.settings.healthBonus * lvl).ToString("P") + "", Helper.settings.healthBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.healthRegenBonusAttribute) == ca && Helper.settings.healthRegenBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases health regen by " + (Helper.settings.healthRegenBonus * lvl).ToString("P") + "", Helper.settings.healthRegenBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.staggerBonusAttribute) == ca && Helper.settings.staggerBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases stagger interrupt by " + (Helper.settings.staggerBonus * lvl).ToString("P") + "", Helper.settings.staggerBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.simBonusAttribute) == ca && Helper.settings.simBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases simulation advantage by " + (Helper.settings.simBonus * lvl).ToString("P") + "", Helper.settings.simBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.persuasionBonusAttribute) == ca && Helper.settings.persuasionBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases persuasion chance by " + (Helper.settings.persuasionBonus * lvl).ToString("P") + "", true));

            if (Helper.GetAttributeTypeFromText(Helper.settings.renownBonusAttribute) == ca && Helper.settings.renownBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases renown earned from victories by " + (Helper.settings.renownBonus * lvl).ToString("P") + "", Helper.settings.renownBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.moraleBonusAttribute) == ca && Helper.settings.moraleBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases morale earned from victories by " + (Helper.settings.moraleBonus * lvl).ToString("P") + "", Helper.settings.moraleBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.partyMoraleBonusAttribute) == ca && Helper.settings.partyMoraleBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases party morale by " + (Helper.settings.partyMoraleBonus * lvl).ToString("P") + "", Helper.settings.partyMoraleBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.wageBonusAttribute) == ca && Helper.settings.wageBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Decreases party wages by " + (Helper.settings.wageBonus * lvl).ToString("P") + "", Helper.settings.wageBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.partySizeBonusAttribute) == ca && Helper.settings.partySizeBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases party size by " + (Helper.settings.partySizeBonus * lvl).ToString("P") + "", Helper.settings.partySizeBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.incomeBonusAttribute) == ca && Helper.settings.incomeBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases gross clan income by " + (Helper.settings.incomeBonus * lvl).ToString("P") + "", Helper.settings.incomeBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.influenceBonusAttribute) == ca && Helper.settings.influenceBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases influence earned from victories by " + (Helper.settings.influenceBonus * lvl).ToString("P") + "", Helper.settings.influenceBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.xpBonusAttribute) == ca && Helper.settings.xpBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases experience gain by " + (Helper.settings.xpBonus * lvl).ToString("P") + "", Helper.settings.xpBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.partyLeaderXPBonusAttribute) == ca && Helper.settings.partyLeaderXPBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Party leader XP from assigned roles " + (Helper.settings.partyLeaderXPBonus * lvl).ToString("P") + "", true));

            if (Helper.GetAttributeTypeFromText(Helper.settings.companionBonusAttribute) == ca && Helper.settings.companionBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases companion limit by +" + (Helper.settings.companionBonus * lvl) + "", true));

            if (Helper.GetAttributeTypeFromText(Helper.settings.reloadBonusAttribute) == ca && Helper.settings.reloadBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases reload speed by " + (Helper.settings.reloadBonus * lvl).ToString("P") + "", Helper.settings.reloadBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.handlingBonusAttribute) == ca && Helper.settings.handlingBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases weapon handling by " + (Helper.settings.handlingBonus * lvl).ToString("P") + "", Helper.settings.handlingBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromText(Helper.settings.movementBonusAttribute) == ca && Helper.settings.movementBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, "Increases movement speed by " + (Helper.settings.movementBonus * lvl).ToString("P") + "", Helper.settings.movementBonusPlayerOnly));

            return aplicableBonuses;
        }
    }

    internal class CustomAtrObject {
        public CharacterAttribute characterAttribute;

        public bool playerOnly;
        public string displayString;

        public CustomAtrObject(CharacterAttribute ca, string ds, bool po) {
            characterAttribute = ca;
            playerOnly = po;
            displayString = ds;
        }
    }
}
