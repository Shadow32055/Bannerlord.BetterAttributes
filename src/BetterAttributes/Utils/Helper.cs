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

            return effect * attributeLvl;
        }

        public static CharacterAttribute GetAttributeTypeFromText(string text) {

            if (text == "Vigor") {
                return DefaultCharacterAttributes.Vigor;
            } else if (text == "Control") {
                return DefaultCharacterAttributes.Control;
            } else if (text == "Endurance") {
                return DefaultCharacterAttributes.Endurance;
            } else if (text == "Cunning") {
                return DefaultCharacterAttributes.Cunning;
            } else if (text == "Social") {
                return DefaultCharacterAttributes.Social;
            } else {
                return DefaultCharacterAttributes.Intelligence;
            }
        }
    }
}