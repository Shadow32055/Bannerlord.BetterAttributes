using BetterAttributes.Utils;

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
                if (Helper.settings.wageBonusEnabled) {
                    if (mobileParty is not null) {
                        if (mobileParty.LeaderHero is not null) {
                            if ((!mobileParty.LeaderHero.IsHumanPlayerCharacter && !Helper.settings.wageBonusPlayerOnly) || mobileParty.LeaderHero.IsHumanPlayerCharacter) {
                                totalWage.AddFactor(-Helper.GetAttributeEffect(Helper.settings.wageBonus, Helper.GetAttributeTypeFromText(Helper.settings.wageBonusAttribute), mobileParty.LeaderHero.CharacterObject), new TextObject(Helper.GetAttributeTypeFromText(Helper.settings.wageBonusAttribute).Name + " Bonus", null));
                            }
                        }
                    }
                }
            } catch (Exception e) {
                Helper.WriteToLog("Issue with GetTotalWage Postfix. Exception output: " + e);
            }

            return totalWage;
        }
    }
}
