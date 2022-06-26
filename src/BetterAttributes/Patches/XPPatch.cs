using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace BetterAttributes.Patches {
    class XPPatch {
        private static FieldInfo hdFieldInfo = null;

        [HarmonyPatch(typeof(Hero), "AddSkillXp")]
        static void Postfix(Hero __instance, SkillObject skill, float xpAmount) {
            try {
                if (xpAmount > 0 && __instance.PartyBelongedTo != null && !__instance.IsPartyLeader) {
                    MobileParty party = __instance.PartyBelongedTo;
                    if (party.EffectiveScout == __instance && skill.Name.ToString() == "Scouting" && true
                        || party.EffectiveEngineer == __instance && skill.Name.ToString() == "Engineering" && true
                        || party.EffectiveSurgeon == __instance && skill.Name.ToString() == "Medicine" && true
                        || party.EffectiveQuartermaster == __instance && skill.Name.ToString() == "Steward" && true) {
                        if (hdFieldInfo == null) GetFieldInfo();
                        Hero partyLeader = party.LeaderHero ?? null;
                        if (partyLeader != null) {
                            HeroDeveloper plhd = (HeroDeveloper)hdFieldInfo.GetValue(partyLeader);
                            float newXpAmount = (float)(xpAmount * .25);
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