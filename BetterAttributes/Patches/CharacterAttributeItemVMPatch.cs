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
                Logger.SendMessage("CharacterAttributeItemVMPatch.CharacterAttributeItemVM threw exception: " + e, Severity.High);
            }
        }

        private static List<CustomAtrObject> getAllBonusForGivenAttribute(CharacterAttribute ca, int lvl) {

            List<CustomAtrObject> applicableBonuses = new List<CustomAtrObject>();

            TextObject melDmgText = new TextObject("{=BA_OG9G6x}Increases melee damage by ", null);
            TextObject rngDmgText = new TextObject("{=BA_K2bc20}Increases ranged damage by ", null);
            TextObject healthText = new TextObject("{=BA_AgQghj}Increases max hit points by ", null);
            TextObject healthRegenText = new TextObject("{=BA_UnjNW8}Increases healing rate by ", null);
            TextObject staggerText = new TextObject("{=BA_LMYUJp}Increases stagger interrupt by ", null);
            TextObject simText = new TextObject("{=BA_Knsfw3}Increases simulation advantage by ", null);
            TextObject persuasionText = new TextObject("{=BA_wQN5KB}Increases persuasion chance by ", null);
            TextObject renownText = new TextObject("{=BA_kUIdS3}Increases renown earned from victories by ", null);
            TextObject moraleText = new TextObject("{=BA_RVdiBF}Increases morale earned from victories by ", null);
            TextObject partyMoraleText = new TextObject("{=BA_DU8FPt}Increases party morale by ", null);
            TextObject wageText = new TextObject("{=BA_D0gVre}Decreases party wages by ", null);
            TextObject partySizeText = new TextObject("{=BA_EKroYs}Increases party size by ", null);
            TextObject incomeText = new TextObject("{=BA_Kcbi3N}Increases gross clan income by ", null);
            TextObject influenceText = new TextObject("{=BA_TB7JZ7}Increases influence earned from victories by ", null);
            TextObject xpText = new TextObject("{=BA_uMigtx}Increases experience gain by ", null);
            TextObject partyLeaderXPText = new TextObject("{=BA_MJrJJM}Party leader XP from assigned roles ", null);
            TextObject companionText = new TextObject("{=BA_14vFx6}Increases companion limit by +", null);
            TextObject reloadText = new TextObject("{=BA_jxqf6p}Increases reload speed by ", null);
            TextObject handlingText = new TextObject("{=BA_203Gjf}Increases weapon handling by ", null);
            TextObject movementText = new TextObject("{=BA_c11mlx}Increases movement speed by ", null);
            TextObject smithingText = new TextObject("{=BA_capoto}Increases smithing stamina by ", null);
            TextObject accuracyText = new TextObject("{=BA_capoto}Increases accuracy by ", null);
            TextObject drawText = new TextObject("{=BA_capoto}Increases draw speed by ", null);
            TextObject stabilityText = new TextObject("{=BA_capoto}Increases stability by ", null);


            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.melDmgBonusAttribute) == ca && SubModule._settings.melDmgBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, melDmgText + (SubModule._settings.melDmgBonus * lvl).ToString("P") + "", SubModule._settings.melDmgBonusPlayerOnly));
            
            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.rngDmgBonusAttribute) == ca && SubModule._settings.rngDmgBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, rngDmgText + (SubModule._settings.rngDmgBonus * lvl).ToString("P") + "", SubModule._settings.rngDmgBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.healthBonusAttribute) == ca && SubModule._settings.healthBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, healthText + (SubModule._settings.healthBonus * lvl).ToString("P") + "", SubModule._settings.healthBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.healthRegenBonusAttribute) == ca && SubModule._settings.healthRegenBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, healthRegenText + (SubModule._settings.healthRegenBonus * lvl).ToString("P") + "", SubModule._settings.healthRegenBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.staggerBonusAttribute) == ca && SubModule._settings.staggerBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, staggerText + (SubModule._settings.staggerBonus * lvl).ToString("P") + "", SubModule._settings.staggerBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.simBonusAttribute) == ca && SubModule._settings.simBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, simText + (SubModule._settings.simBonus * lvl).ToString("P") + "", SubModule._settings.simBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.persuasionBonusAttribute) == ca && SubModule._settings.persuasionBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, persuasionText + (SubModule._settings.persuasionBonus * lvl).ToString("P") + "", true));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.renownBonusAttribute) == ca && SubModule._settings.renownBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, renownText + (SubModule._settings.renownBonus * lvl).ToString("P") + "", SubModule._settings.renownBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.moraleBonusAttribute) == ca && SubModule._settings.moraleBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, moraleText + (SubModule._settings.moraleBonus * lvl).ToString("P") + "", SubModule._settings.moraleBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.partyMoraleBonusAttribute) == ca && SubModule._settings.partyMoraleBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, partyMoraleText + (SubModule._settings.partyMoraleBonus * lvl).ToString("P") + "", SubModule._settings.partyMoraleBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.wageBonusAttribute) == ca && SubModule._settings.wageBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, wageText + (SubModule._settings.wageBonus * lvl).ToString("P") + "", SubModule._settings.wageBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.partySizeBonusAttribute) == ca && SubModule._settings.partySizeBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, partySizeText + (SubModule._settings.partySizeBonus * lvl).ToString("P") + "", SubModule._settings.partySizeBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.incomeBonusAttribute) == ca && SubModule._settings.incomeBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, incomeText + (SubModule._settings.incomeBonus * lvl).ToString("P") + "", SubModule._settings.incomeBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.influenceBonusAttribute) == ca && SubModule._settings.influenceBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, influenceText + (SubModule._settings.influenceBonus * lvl).ToString("P") + "", SubModule._settings.influenceBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.xpBonusAttribute) == ca && SubModule._settings.xpBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, xpText + (SubModule._settings.xpBonus * lvl).ToString("P") + "", SubModule._settings.xpBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.partyLeaderXPBonusAttribute) == ca && SubModule._settings.partyLeaderXPBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, partyLeaderXPText + (SubModule._settings.partyLeaderXPBonus * lvl).ToString("P") + "", true));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.companionBonusAttribute) == ca && SubModule._settings.companionBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, companionText + (SubModule._settings.companionBonus * lvl).ToString() + "", true));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.reloadBonusAttribute) == ca && SubModule._settings.reloadBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, reloadText + (SubModule._settings.reloadBonus * lvl).ToString("P") + "", SubModule._settings.reloadBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.handlingBonusAttribute) == ca && SubModule._settings.handlingBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, handlingText + (SubModule._settings.handlingBonus * lvl).ToString("P") + "", SubModule._settings.handlingBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.movementBonusAttribute) == ca && SubModule._settings.movementBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, movementText + (SubModule._settings.movementBonus * lvl).ToString("P") + "", SubModule._settings.movementBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.smithingBonusAttribute) == ca && SubModule._settings.smithingBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, smithingText + (SubModule._settings.smithingBonus * lvl).ToString() + "", true));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.accuracyBonusAttribute) == ca && SubModule._settings.accuracyBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, accuracyText + (SubModule._settings.accuracyBonus * lvl).ToString("P") + "", SubModule._settings.accuracyBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.drawBonusAttribute) == ca && SubModule._settings.drawBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, drawText + (SubModule._settings.drawBonus * lvl).ToString("P") + "", SubModule._settings.drawBonusPlayerOnly));

            if (AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.stabilityBonusAttribute) == ca && SubModule._settings.stabilityBonusEnabled)
                applicableBonuses.Add(new CustomAtrObject(ca, stabilityText + (SubModule._settings.stabilityBonus * lvl).ToString("P") + "", SubModule._settings.stabilityBonusPlayerOnly));

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
