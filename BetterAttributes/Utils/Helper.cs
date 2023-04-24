using BetterAttributes.Settings;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

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

        public static float GetAttributeEffect(float bonus, CharacterAttribute attrbiute, CharacterObject character) {
            int attributeLvl = 1;

            if (attrbiute == DefaultCharacterAttributes.Vigor) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Vigor);
            } else if (attrbiute == DefaultCharacterAttributes.Control) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Control);
            } else if (attrbiute == DefaultCharacterAttributes.Endurance) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Endurance);
            } else if (attrbiute == DefaultCharacterAttributes.Cunning) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Cunning);
            } else if (attrbiute == DefaultCharacterAttributes.Social) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Social);
            } else if (attrbiute == DefaultCharacterAttributes.Intelligence) {
                attributeLvl = character.HeroObject.GetAttributeValue(DefaultCharacterAttributes.Intelligence);
            }

            return bonus * attributeLvl;
        }

        public static CharacterAttribute GetAttributeTypeFromIndex(int index) {

            if (index == 1) {
                return DefaultCharacterAttributes.Vigor;
            } else if (index == 2) {
                return DefaultCharacterAttributes.Control;
            } else if (index == 3) {
                return DefaultCharacterAttributes.Endurance;
            } else if (index == 4) {
                return DefaultCharacterAttributes.Cunning;
            } else if (index == 5) {
                return DefaultCharacterAttributes.Social;
            } else {
                return DefaultCharacterAttributes.Intelligence;
            }
        }
    }
}