using BetterCore.Utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(CharacterAttributeItemVM), MethodType.Constructor)]
    [HarmonyPatch(new Type[]
    {
        typeof(Hero),
        typeof(CharacterAttribute),
        typeof(CharacterDeveloperHeroItemVM),
        typeof(Action<CharacterAttributeItemVM>),
        typeof(Action<CharacterAttributeItemVM>)
    })]
    class CharacterAttributeItemVMPatch {

        public static void Postfix(ref CharacterAttributeItemVM __instance, Hero hero, CharacterAttribute currAtt, CharacterDeveloperHeroItemVM developerVM, Action<CharacterAttributeItemVM> onInpectAttribute, Action<CharacterAttributeItemVM> onAddAttributePoint)
        {
            try {
                string text = "";

                List<CustomAtrObject> bonuses = getAllBonusForGivenAttribute(currAtt, hero.GetAttributeValue(currAtt));


                foreach (CustomAtrObject co in bonuses) {

                    if (!hero.IsHumanPlayerCharacter && co.playerOnly)
                        continue;

                    text += co.displayString + "\n";
                }
                
                if (BetterAttributes.Settings.MoreBonusRoom) {
                    __instance.IncreaseHelpText = text;
                } else {
                    __instance.IncreaseHelpText = text + "\n" + __instance.IncreaseHelpText;
                }

            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "CharacterAttributeItemVMPatch.CharacterAttributeItemVM threw exception: " + e);
            }
        }

        private static List<CustomAtrObject> getAllBonusForGivenAttribute(CharacterAttribute ca, int lvl) {

            List<CustomAtrObject> applicableBonuses = new List<CustomAtrObject>();

            TextObject melDmgText = new TextObject(Strings.MelBonusText);
            TextObject rngDmgText = new TextObject(Strings.RngBonusText);
            TextObject healthText = new TextObject(Strings.HealthBonusText);
            TextObject healthRegenText = new TextObject(Strings.HealthRegenBonusText);
            TextObject staggerText = new TextObject(Strings.StaggerBonusText);
            TextObject simText = new TextObject(Strings.SimBonusText);
            TextObject persuasionText = new TextObject(Strings.PersuasionBonusText);
            TextObject renownText = new TextObject(Strings.RenownBonusText);
            TextObject moraleText = new TextObject(Strings.MoraleBonusText);
            TextObject partyMoraleText = new TextObject(Strings.PartyMoraleBonusText);
            TextObject wageText = new TextObject(Strings.WageBonusText);
            TextObject partySizeText = new TextObject(Strings.PartySizeBonusText);
            TextObject incomeText = new TextObject(Strings.IncomeBonusText);
            TextObject influenceText = new TextObject(Strings.InfluenceBonusText);
            TextObject xpText = new TextObject(Strings.XpBonusText);
            TextObject partyLeaderXPText = new TextObject(Strings.PartyLeaderXPBonusText);
            TextObject companionText = new TextObject(Strings.CompanionBonusText);
            TextObject reloadText = new TextObject(Strings.ReloadBonusText);
            TextObject handlingText = new TextObject(Strings.HandlingBonusText);
            TextObject movementText = new TextObject(Strings.MovementBonusText);
            TextObject smithingText = new TextObject(Strings.SmithingBonusText);
            TextObject accuracyText = new TextObject(Strings.AccuracyBonusText);
            TextObject drawText = new TextObject(Strings.DrawBonusText);
            TextObject stabilityText = new TextObject(Strings.StabilityBonusText);
            TextObject sliceText = new TextObject(Strings.SliceBonusText);
            TextObject crushText = new TextObject(Strings.CrushBonusText);


            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.MelDmgBonusAttribute) == ca && BetterAttributes.Settings.MelDmgBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, melDmgText + (BetterAttributes.Settings.MelDmgBonus * lvl).ToString("P") + "", BetterAttributes.Settings.MelDmgBonusPlayerOnly));
            
            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.RngDmgBonusAttribute) == ca && BetterAttributes.Settings.RngDmgBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, rngDmgText + (BetterAttributes.Settings.RngDmgBonus * lvl).ToString("P") + "", BetterAttributes.Settings.RngDmgBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HealthBonusAttribute) == ca && BetterAttributes.Settings.HealthBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, healthText + (BetterAttributes.Settings.HealthBonus * lvl).ToString("P") + "", BetterAttributes.Settings.HealthBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HealthRegenBonusAttribute) == ca && BetterAttributes.Settings.HealthRegenBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, healthRegenText + (BetterAttributes.Settings.HealthRegenBonus * lvl).ToString("P") + "", BetterAttributes.Settings.HealthRegenBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.StaggerBonusAttribute) == ca && BetterAttributes.Settings.StaggerBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, staggerText + (BetterAttributes.Settings.StaggerBonus * lvl).ToString("P") + "", BetterAttributes.Settings.StaggerBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.SimBonusAttribute) == ca && BetterAttributes.Settings.SimBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, simText + (BetterAttributes.Settings.SimBonus * lvl).ToString("P") + "", BetterAttributes.Settings.SimBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.PersuasionBonusAttribute) == ca && BetterAttributes.Settings.PersuasionBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, persuasionText + (BetterAttributes.Settings.PersuasionBonus * lvl).ToString("P") + "", true));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.RenownBonusAttribute) == ca && BetterAttributes.Settings.RenownBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, renownText + (BetterAttributes.Settings.RenownBonus * lvl).ToString("P") + "", BetterAttributes.Settings.RenownBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.MoraleBonusAttribute) == ca && BetterAttributes.Settings.MoraleBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, moraleText + (BetterAttributes.Settings.MoraleBonus * lvl).ToString("P") + "", BetterAttributes.Settings.MoraleBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.PartyMoraleBonusAttribute) == ca && BetterAttributes.Settings.PartyMoraleBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, partyMoraleText + (BetterAttributes.Settings.PartyMoraleBonus * lvl).ToString("P") + "", BetterAttributes.Settings.PartyMoraleBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.WageBonusAttribute) == ca && BetterAttributes.Settings.WageBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, wageText + (BetterAttributes.Settings.WageBonus * lvl).ToString("P") + "", BetterAttributes.Settings.WageBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.PartySizeBonusAttribute) == ca && BetterAttributes.Settings.PartySizeBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, partySizeText + (BetterAttributes.Settings.PartySizeBonus * lvl).ToString("P") + "", BetterAttributes.Settings.PartySizeBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.IncomeBonusAttribute) == ca && BetterAttributes.Settings.IncomeBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, incomeText + (BetterAttributes.Settings.IncomeBonus * lvl).ToString("P") + "", BetterAttributes.Settings.IncomeBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.InfluenceBonusAttribute) == ca && BetterAttributes.Settings.InfluenceBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, influenceText + (BetterAttributes.Settings.InfluenceBonus * lvl).ToString("P") + "", BetterAttributes.Settings.InfluenceBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.XpBonusAttribute) == ca && BetterAttributes.Settings.XpBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, xpText + (BetterAttributes.Settings.XpBonus * lvl).ToString("P") + "", BetterAttributes.Settings.XpBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.PartyLeaderXPBonusAttribute) == ca && BetterAttributes.Settings.PartyLeaderXPBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, partyLeaderXPText + (BetterAttributes.Settings.PartyLeaderXPBonus * lvl).ToString("P") + "", true));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.CompanionBonusAttribute) == ca && BetterAttributes.Settings.CompanionBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, companionText + (BetterAttributes.Settings.CompanionBonus * lvl).ToString() + "", true));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.ReloadBonusAttribute) == ca && BetterAttributes.Settings.ReloadBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, reloadText + (BetterAttributes.Settings.ReloadBonus * lvl).ToString("P") + "", BetterAttributes.Settings.ReloadBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.HandlingBonusAttribute) == ca && BetterAttributes.Settings.HandlingBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, handlingText + (BetterAttributes.Settings.HandlingBonus * lvl).ToString("P") + "", BetterAttributes.Settings.HandlingBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.MovementBonusAttribute) == ca && BetterAttributes.Settings.MovementBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, movementText + (BetterAttributes.Settings.MovementBonus * lvl).ToString("P") + "", BetterAttributes.Settings.MovementBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.SmithingBonusAttribute) == ca && BetterAttributes.Settings.SmithingBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, smithingText + (BetterAttributes.Settings.SmithingBonus * lvl).ToString() + "", true));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.AccuracyBonusAttribute) == ca && BetterAttributes.Settings.AccuracyBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, accuracyText + (BetterAttributes.Settings.AccuracyBonus * lvl).ToString("P") + "", BetterAttributes.Settings.AccuracyBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.DrawBonusAttribute) == ca && BetterAttributes.Settings.DrawBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, drawText + (BetterAttributes.Settings.DrawBonus * lvl).ToString("P") + "", BetterAttributes.Settings.DrawBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.StabilityBonusAttribute) == ca && BetterAttributes.Settings.StabilityBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, stabilityText + (BetterAttributes.Settings.StabilityBonus * lvl).ToString("P") + "", BetterAttributes.Settings.StabilityBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.SliceChanceAttribute) == ca && BetterAttributes.Settings.SliceEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, sliceText + (BetterAttributes.Settings.SliceChance * lvl).ToString("P") + "", BetterAttributes.Settings.SlicePlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.CrushChanceAttribute) == ca && BetterAttributes.Settings.CrushEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, crushText + (BetterAttributes.Settings.CrushChance * lvl).ToString("P") + "", BetterAttributes.Settings.CrushPlayerOnly));

            return applicableBonuses;
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
