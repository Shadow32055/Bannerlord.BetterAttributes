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

        public static CharacterAttribute GetAttributeTypeFromText(string text) {
            TextObject to = new TextObject(text, null);

            if (to == new TextObject("{=BA_Mf0D9r}Vigor", null)) {
                return DefaultCharacterAttributes.Vigor;
            } else if (to == new TextObject("{=BA_yXzbqm}Control", null)) {
                return DefaultCharacterAttributes.Control;
            } else if (to == new TextObject("{=BA_3xcrKW}Endurance", null)) {
                return DefaultCharacterAttributes.Endurance;
            } else if (to == new TextObject("{=BA_v92Ex5}Cunning", null)) {
                return DefaultCharacterAttributes.Cunning;
            } else if (to == new TextObject("{=BA_YtXewV}Social", null)) {
                return DefaultCharacterAttributes.Social;
            } else {
                return DefaultCharacterAttributes.Intelligence;
            }
        }
    }
}