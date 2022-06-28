using BetterAttributes.Utils;
using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(Hero), "AddSkillXp")]
    class XPPatch {
        
        private static FieldInfo hdFieldInfo = null;

        public static void Postfix(ref Hero __instance, SkillObject skill, float xpAmount) {
            try {

                if (xpAmount > 0 && __instance.PartyBelongedTo != null && !__instance.IsPartyLeader) {

                    MobileParty party = __instance.PartyBelongedTo;

                    if (party.EffectiveScout == __instance && skill.Name.ToString() == "Scouting"
                        || party.EffectiveEngineer == __instance && skill.Name.ToString() == "Engineering"
                        || party.EffectiveSurgeon == __instance && skill.Name.ToString() == "Medicine"
                        || party.EffectiveQuartermaster == __instance && skill.Name.ToString() == "Steward") {

                        if (hdFieldInfo == null) GetFieldInfo();

                        Hero partyLeader = party.LeaderHero ?? null;

                        if (partyLeader != null) {
                            HeroDeveloper plhd = (HeroDeveloper)hdFieldInfo.GetValue(partyLeader);
                            float newXpAmount = (float)(xpAmount * Helper.GetAttributeEffect(Helper.settings.partyLeaderXPBonus, Helper.GetAttributeTypeFromText(Helper.settings.partyLeaderXPBonusAttribute), (CharacterObject)partyLeader.CharacterObject));
                            plhd.AddSkillXp(skill, newXpAmount, true, true);
                            //InformationManager.DisplayMessage(new InformationMessage($"{skill.Name} Role xp: {xpAmount} Leader xp: {newXpAmount}. Percentage: .25", TaleWorlds.Library.Color.Black));
                        }
                    }
                }
                
            } catch (Exception ex) {
                InformationManager.DisplayMessage(new InformationMessage($"An exception occurred whilst trying to apply role xp to party leader: {ex}", TaleWorlds.Library.Color.Black));
            }
        }

        private static void GetFieldInfo() {
            hdFieldInfo = typeof(Hero).GetField("_heroDeveloper", BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }
}