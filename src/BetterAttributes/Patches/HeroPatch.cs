using BetterAttributes.Utils;
using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace BetterAttributes.Patches {
    [HarmonyPatch(typeof(Hero))]
    class HeroPatch {
        
        private static FieldInfo hdFieldInfo = null;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Hero), "AddSkillXp")]
        public static void AddSkillXp(ref Hero __instance, SkillObject skill, float xpAmount) {
            try {

                if (xpAmount > 0 && __instance.PartyBelongedTo != null && !__instance.IsPartyLeader) {

                    MobileParty party = __instance.PartyBelongedTo;

                    if (party.EffectiveScout == __instance && skill.Name.ToString() == new TextObject("{=LJ6Krlbr}Scouting", null).ToString()
                        || party.EffectiveEngineer == __instance && skill.Name.ToString() == new TextObject("{=engineeringskill}Engineering", null).ToString()
                        || party.EffectiveSurgeon == __instance && skill.Name.ToString() == new TextObject("{=JKH59XNp}Medicine", null).ToString()
                        || party.EffectiveQuartermaster == __instance && skill.Name.ToString() == new TextObject("{=stewardskill}Steward", null).ToString()) {

                        if (hdFieldInfo == null) GetFieldInfo();

                        Hero partyLeader = party.LeaderHero ?? null;

                        if (partyLeader != null) {
                            HeroDeveloper plhd = (HeroDeveloper)hdFieldInfo.GetValue(partyLeader);
                            float newXpAmount = (float)(xpAmount * Helper.GetAttributeEffect(Helper.settings.partyLeaderXPBonus, Helper.GetAttributeTypeFromText(Helper.settings.partyLeaderXPBonusAttribute), (CharacterObject)partyLeader.CharacterObject));
                            plhd.AddSkillXp(skill, newXpAmount, true, true);
                        }
                    }
                }

            } catch (Exception e) {
                Helper.WriteToLog("Issue with HeroPatch.AddSkillXp postfix. Exception output: " + e);
            }
        }

        private static void GetFieldInfo() {
            hdFieldInfo = typeof(Hero).GetField("_heroDeveloper", BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }
}