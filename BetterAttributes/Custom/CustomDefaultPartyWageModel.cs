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
                if (BetterAttributes.Settings.WageBonusEnabled) {
                    if (mobileParty is not null) {
                        if (mobileParty.LeaderHero is not null) {
                            if ((!mobileParty.LeaderHero.IsHumanPlayerCharacter && !BetterAttributes.Settings.WageBonusPlayerOnly) || mobileParty.LeaderHero.IsHumanPlayerCharacter) {
                                totalWage.AddFactor(-AttributeHelper.GetAttributeEffect(BetterAttributes.Settings.WageBonus, AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.WageBonusAttribute), mobileParty.LeaderHero.CharacterObject), new TextObject(AttributeHelper.GetAttributeTypeFromIndex(BetterAttributes.Settings.WageBonusAttribute).Name + " Bonus", null));
                            }
                        }
                    }
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributes.ModName, "CustomDefaultPartyWageModel.GetTotalWage threw exception: " + e);
            }

            return totalWage;
        }
    }
}
