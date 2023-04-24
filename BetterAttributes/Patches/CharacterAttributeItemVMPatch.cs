using System;
using System.Collections.Generic;

using HarmonyLib;

using BetterAttributes.Utils;

using TaleWorlds.Core;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
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
                Helper.WriteToLog("Issue with CharacterAttributeItemVMPatch.CharacterAttributeItemVM postfix. Exception output: " + e);
            }
        }

        private static List<CustomAtrObject> getAllBonusForGivenAttribute(CharacterAttribute ca, int lvl) {

            List<CustomAtrObject> aplicableBonuses = new List<CustomAtrObject>();

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


            if (Helper.GetAttributeTypeFromIndex(Helper.settings.melDmgBonusAttribute) == ca && Helper.settings.melDmgBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, melDmgText + (Helper.settings.melDmgBonus * lvl).ToString("P") + "", Helper.settings.melDmgBonusPlayerOnly));
            
            if (Helper.GetAttributeTypeFromIndex(Helper.settings.rngDmgBonusAttribute) == ca && Helper.settings.rngDmgBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, rngDmgText + (Helper.settings.rngDmgBonus * lvl).ToString("P") + "", Helper.settings.rngDmgBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.healthBonusAttribute) == ca && Helper.settings.healthBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, healthText + (Helper.settings.healthBonus * lvl).ToString("P") + "", Helper.settings.healthBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.healthRegenBonusAttribute) == ca && Helper.settings.healthRegenBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, healthRegenText + (Helper.settings.healthRegenBonus * lvl).ToString("P") + "", Helper.settings.healthRegenBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.staggerBonusAttribute) == ca && Helper.settings.staggerBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, staggerText + (Helper.settings.staggerBonus * lvl).ToString("P") + "", Helper.settings.staggerBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.simBonusAttribute) == ca && Helper.settings.simBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, simText + (Helper.settings.simBonus * lvl).ToString("P") + "", Helper.settings.simBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.persuasionBonusAttribute) == ca && Helper.settings.persuasionBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, persuasionText + (Helper.settings.persuasionBonus * lvl).ToString("P") + "", true));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.renownBonusAttribute) == ca && Helper.settings.renownBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, renownText + (Helper.settings.renownBonus * lvl).ToString("P") + "", Helper.settings.renownBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.moraleBonusAttribute) == ca && Helper.settings.moraleBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, moraleText + (Helper.settings.moraleBonus * lvl).ToString("P") + "", Helper.settings.moraleBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.partyMoraleBonusAttribute) == ca && Helper.settings.partyMoraleBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, partyMoraleText + (Helper.settings.partyMoraleBonus * lvl).ToString("P") + "", Helper.settings.partyMoraleBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.wageBonusAttribute) == ca && Helper.settings.wageBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, wageText + (Helper.settings.wageBonus * lvl).ToString("P") + "", Helper.settings.wageBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.partySizeBonusAttribute) == ca && Helper.settings.partySizeBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, partySizeText + (Helper.settings.partySizeBonus * lvl).ToString("P") + "", Helper.settings.partySizeBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.incomeBonusAttribute) == ca && Helper.settings.incomeBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, incomeText + (Helper.settings.incomeBonus * lvl).ToString("P") + "", Helper.settings.incomeBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.influenceBonusAttribute) == ca && Helper.settings.influenceBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, influenceText + (Helper.settings.influenceBonus * lvl).ToString("P") + "", Helper.settings.influenceBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.xpBonusAttribute) == ca && Helper.settings.xpBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, xpText + (Helper.settings.xpBonus * lvl).ToString("P") + "", Helper.settings.xpBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.partyLeaderXPBonusAttribute) == ca && Helper.settings.partyLeaderXPBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, partyLeaderXPText + (Helper.settings.partyLeaderXPBonus * lvl).ToString("P") + "", true));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.companionBonusAttribute) == ca && Helper.settings.companionBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, companionText + (Helper.settings.companionBonus * lvl).ToString() + "", true));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.reloadBonusAttribute) == ca && Helper.settings.reloadBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, reloadText + (Helper.settings.reloadBonus * lvl).ToString("P") + "", Helper.settings.reloadBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.handlingBonusAttribute) == ca && Helper.settings.handlingBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, handlingText + (Helper.settings.handlingBonus * lvl).ToString("P") + "", Helper.settings.handlingBonusPlayerOnly));

            if (Helper.GetAttributeTypeFromIndex(Helper.settings.movementBonusAttribute) == ca && Helper.settings.movementBonusEnabled)
                aplicableBonuses.Add(new CustomAtrObject(ca, movementText + (Helper.settings.movementBonus * lvl).ToString("P") + "", Helper.settings.movementBonusPlayerOnly));

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
