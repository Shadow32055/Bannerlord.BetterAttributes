
namespace BetterAttributes.Settings {
    public class DefaultSettings : ISettings {
        public bool melDmgBonusEnabled { get; set; } = true;
        public bool melDmgBonusPlayerOnly { get; set; } = true;
        public float melDmgBonus { get; set; } = 0.02f;
        public string melDmgBonusAttribute { get; set; } = "Vigor";

        public bool rngDmgBonusEnabled { get; set; } = true;
        public bool rngDmgBonusPlayerOnly { get; set; } = true;
        public float rngDmgBonus { get; set; } = 0.02f;
        public string rngDmgBonusAttribute { get; set; } = "Control";

        public bool healthBonusEnabled { get; set; } = true;
        public bool healthBonusPlayerOnly { get; set; } = true;
        public float healthBonus { get; set; } = 0.02f;
        public string healthBonusAttribute { get; set; } = "Endurance";

        public bool staggerBonusEnabled { get; set; } = true;
        public bool staggerBonusPlayerOnly { get; set; } = true;
        public float staggerBonus { get; set; } = 0.02f;
        public string staggerBonusAttribute { get; set; } = "Endurance";

        public bool simBonusEnabled { get; set; } = true;
        public bool simBonusPlayerOnly { get; set; } = true;
        public float simBonus { get; set; } = 0.02f;
        public string simBonusAttribute { get; set; } = "Cunning";

        public bool persuasionBonusEnabled { get; set; } = true;
        public float persuasionBonus { get; set; } = 0.02f;
        public string persuasionBonusAttribute { get; set; } = "Cunning";

        public bool renownBonusEnabled { get; set; } = true;
        public bool renownBonusPlayerOnly { get; set; } = true;
        public float renownBonus { get; set; } = 0.02f;
        public string renownBonusAttribute { get; set; } = "Cunning";

        public bool moraleBonusEnabled { get; set; } = true;
        public bool moraleBonusPlayerOnly { get; set; } = true;
        public float moraleBonus { get; set; } = 0.02f;
        public string moraleBonusAttribute { get; set; } = "Cunning";

        public bool partyMoraleBonusEnabled { get; set; } = true;
        public bool partyMoraleBonusPlayerOnly { get; set; } = true;
        public float partyMoraleBonus { get; set; } = 0.02f;
        public string partyMoraleBonusAttribute { get; set; } = "Social";

        public bool wageBonusEnabled { get; set; } = true;
        public bool wageBonusPlayerOnly { get; set; } = true;
        public float wageBonus { get; set; } = 0.02f;
        public string wageBonusAttribute { get; set; } = "Social";

        public bool partySizeBonusEnabled { get; set; } = true;
        public bool partySizeBonusPlayerOnly { get; set; } = true;
        public float partySizeBonus { get; set; } = 0.02f;
        public string partySizeBonusAttribute { get; set; } = "Social";

        public bool incomeBonusEnabled { get; set; } = true;
        public bool incomeBonusPlayerOnly { get; set; } = true;
        public float incomeBonus { get; set; } = 0.02f;
        public string incomeBonusAttribute { get; set; } = "Intelligence";

        public bool influenceBonusEnabled { get; set; } = true;
        public bool influenceBonusPlayerOnly { get; set; } = true;
        public float influenceBonus { get; set; } = 0.02f;
        public string influenceBonusAttribute { get; set; } = "Intelligence";

        public bool xpBonusEnabled { get; set; } = true;
        public bool xpBonusPlayerOnly { get; set; } = true;
        public float xpBonus { get; set; } = 0.02f;
        public string xpBonusAttribute { get; set; } = "Intelligence";

        public bool partyLeaderXPBonusEnabled { get; set; } = true;
        public bool partyLeaderXPBonusPlayerOnly { get; set; } = true;
        public float partyLeaderXPBonus { get; set; } = 0.25f;
        public string partyLeaderXPBonusAttribute { get; set; } = "Intelligence";

        public int levelsPerAttributePoint { get; set; } = 3;
        public int focusPointsPerLevel { get; set; } = 1;
        public int maxAttributeLevel { get; set; } = 10;
        public int maxFocusPointsPerSkill { get; set; } = 5; 
    }
}
