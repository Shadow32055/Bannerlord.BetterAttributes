using BetterAttributes.Utils;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BetterAttributes.Custom {
    class CustomDefaultCharacterDevelopmentModel : DefaultCharacterDevelopmentModel {

        public override int LevelsPerAttributePoint {
            get {
                return Helper.settings.levelsPerAttributePoint;
            }
        }

        public override int FocusPointsPerLevel {
            get {
            
                return Helper.settings.focusPointsPerLevel;
            }
        }

        //TODO: Allow user to configure
        public override int MaxFocusPerSkill {
            get {
                return 5;
            }
        }

        public override int MaxAttribute {
            get {
                return Helper.settings.maxAttributeLevel;
            }
        }
    }
}
