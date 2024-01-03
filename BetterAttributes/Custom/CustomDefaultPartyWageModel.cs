using BetterCore.Utils;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace BetterAttributes.Custom {

    public class CustomDefaultPartyWageModel : DefaultPartyWageModel {
        public override ExplainedNumber GetTotalWage(MobileParty mobileParty, bool includeDescriptions = false) {
            ExplainedNumber totalWage = base.GetTotalWage(mobileParty, includeDescriptions);
            try {
                if (SubModule._settings.wageBonusEnabled) {
                    if (mobileParty is not null) {
                        if (mobileParty.LeaderHero is not null) {
                            if ((!mobileParty.LeaderHero.IsHumanPlayerCharacter && !SubModule._settings.wageBonusPlayerOnly) || mobileParty.LeaderHero.IsHumanPlayerCharacter) {
                                totalWage.AddFactor(-AttributeHelper.GetAttributeEffect(SubModule._settings.wageBonus, AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.wageBonusAttribute), mobileParty.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(SubModule._settings.wageBonusAttribute).Name + " Bonus", null));
                            }
                        }
                    }
                }
            } catch (Exception e) {
                Logger.SendMessage("CustomDefaultPartyWageModel.GetTotalWage threw exception: " + e, Severity.High);
            }

            return totalWage;
        }
    }
}
