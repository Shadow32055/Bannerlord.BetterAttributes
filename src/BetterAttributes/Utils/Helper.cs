using BetterAttributes.Settings;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace BetterAttributes.Utils {
    public class Helper {
        public static string modName = "ForgotToSet";
        public static ISettings settings;

        public static void SetModName(string name) {
            modName = name;
            DisplayFriendlyMsg(modName + " Loaded.");
            //validate();
        }

        public static void DisplayFriendlyMsg(string msg) {
            InformationManager.DisplayMessage(new InformationMessage(msg, Colors.Green));
            WriteToLog(msg);
        }

        public static void DisplayMsg(string msg) {
            InformationManager.DisplayMessage(new InformationMessage(msg));
            WriteToLog(msg);
        }

        public static void DisplayWarningMsg(string msg) {
            InformationManager.DisplayMessage(new InformationMessage(msg, Colors.Red));
            WriteToLog(msg);
        }

        public static void WriteToLog(string text) {
            Debug.Print(modName + ": " + text);
        }

        public static float GetAttributeEffect(float effect, CharacterAttribute attrbiute, CharacterObject character) {
            int attributeLvl = 1;

            if (attrbiute == DefaultCharacterAttributes.Vigor) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Vigor);
            } else if (attrbiute == DefaultCharacterAttributes.Control) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Control);
            } else if (attrbiute == DefaultCharacterAttributes.Endurance) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Endurance);
            } else if (attrbiute == DefaultCharacterAttributes.Social) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Social);
            } else if (attrbiute == DefaultCharacterAttributes.Intelligence) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Intelligence);
            }

            if (settings.cunningAllHeros) {
                return effect * attributeLvl * ((settings.percentIncreasePerCunning * character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Cunning)) + 1);
            } else if (character.IsPlayerCharacter) {
                return effect * attributeLvl * ((settings.percentIncreasePerCunning * character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Cunning)) + 1);
            } else {
                return effect * attributeLvl;
            }
        }

        /*

        private static void validate() {
            DisplayMsg("1: " + getEffectValue (200, 1));
            DisplayMsg("2: " + getEffectValue(200, 2));
            DisplayMsg("3: " + getEffectValue(200, 3));
            DisplayMsg("4: " + getEffectValue(200, 4));
            DisplayMsg("5: " + getEffectValue(200, 5));
            DisplayMsg("6: " + getEffectValue(200, 6));
            DisplayMsg("7: " + getEffectValue(200, 7));
            DisplayMsg("8: " + getEffectValue(200, 8));
            DisplayMsg("9: " + getEffectValue(200, 9));
            DisplayMsg("10: " + getEffectValue(200, 10));
        }

        private static float getEffectValue(float maxEffect, int attribute) {
            if (attribute >= 2) {
                attribute -= 2;
            } else {
                attribute = 0;
            }

            return ((maxEffect * (attribute * attribute + attribute * 2) / 8) / 10) + 1;
        }

        
        private static float maxCunningIncreasePercent = 1;

        public static float GetAttributeEffect(float maxEffect, CharacterAttribute attrbiute, CharacterObject character) {
            int attributeLvl = 1;

            if (attrbiute == DefaultCharacterAttributes.Vigor) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Vigor);
            } else if (attrbiute == DefaultCharacterAttributes.Control) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Control);
            } else if (attrbiute == DefaultCharacterAttributes.Endurance) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Endurance);
            } else if (attrbiute == DefaultCharacterAttributes.Cunning) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Cunning);
                //Cunning cant increase itself
                return getEffectValue(maxEffect, attributeLvl);
            } else if (attrbiute == DefaultCharacterAttributes.Social) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Social);
            } else if (attrbiute == DefaultCharacterAttributes.Intelligence) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Intelligence);
            } else {

            }

            return getEffectValue(maxEffect, attributeLvl) * getEffectValue(maxCunningIncreasePercent, character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Cunning));
        }*/
    }
}