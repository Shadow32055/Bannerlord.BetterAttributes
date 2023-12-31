
namespace BetterAttributes.Settings {
    public class DefaultSettings : ISettings {
        public bool melDmgBonusEnabled { get; set; } = true;
        public bool melDmgBonusPlayerOnly { get; set; } = true;
        public float melDmgBonus { get; set; } = 0.02f;
        public int melDmgBonusAttribute { get; set; } = 0;

        public bool rngDmgBonusEnabled { get; set; } = true;
        public bool rngDmgBonusPlayerOnly { get; set; } = true;
        public float rngDmgBonus { get; set; } = 0.02f;
        public int rngDmgBonusAttribute { get; set; } = 1;

        public bool healthBonusEnabled { get; set; } = true;
        public bool healthBonusPlayerOnly { get; set; } = true;
        public float healthBonus { get; set; } = 0.05f;
        public int healthBonusAttribute { get; set; } = 2;

        public bool healthRegenBonusEnabled { get; set; } = true;
        public bool healthRegenBonusPlayerOnly { get; set; } = true;
        public float healthRegenBonus { get; set; } = 0.05f;
        public int healthRegenBonusAttribute { get; set; } = 0;

        public bool staggerBonusEnabled { get; set; } = true;
        public bool staggerBonusPlayerOnly { get; set; } = true;
        public float staggerBonus { get; set; } = 0.02f;
        public int staggerBonusAttribute { get; set; } = 2;

        public bool simBonusEnabled { get; set; } = true;
        public bool simBonusPlayerOnly { get; set; } = true;
        public float simBonus { get; set; } = 0.02f;
        public int simBonusAttribute { get; set; } = 3;

        public bool persuasionBonusEnabled { get; set; } = true;
        public float persuasionBonus { get; set; } = 0.02f;
        public int persuasionBonusAttribute { get; set; } = 3;

        public bool renownBonusEnabled { get; set; } = true;
        public bool renownBonusPlayerOnly { get; set; } = true;
        public float renownBonus { get; set; } = 0.02f;
        public int renownBonusAttribute { get; set; } = 3;

        public bool moraleBonusEnabled { get; set; } = true;
        public bool moraleBonusPlayerOnly { get; set; } = true;
        public float moraleBonus { get; set; } = 0.02f;
        public int moraleBonusAttribute { get; set; } = 3;

        public bool partyMoraleBonusEnabled { get; set; } = true;
        public bool partyMoraleBonusPlayerOnly { get; set; } = true;
        public float partyMoraleBonus { get; set; } = 0.02f;
        public int partyMoraleBonusAttribute { get; set; } = 4;

        public bool wageBonusEnabled { get; set; } = true;
        public bool wageBonusPlayerOnly { get; set; } = true;
        public float wageBonus { get; set; } = 0.02f;
        public int wageBonusAttribute { get; set; } = 4;

        public bool partySizeBonusEnabled { get; set; } = true;
        public bool partySizeBonusPlayerOnly { get; set; } = true;
        public float partySizeBonus { get; set; } = 0.02f;
        public int partySizeBonusAttribute { get; set; } = 4;

        public bool incomeBonusEnabled { get; set; } = true;
        public bool incomeBonusPlayerOnly { get; set; } = true;
        public float incomeBonus { get; set; } = 0.02f;
        public int incomeBonusAttribute { get; set; } = 5;

        public bool influenceBonusEnabled { get; set; } = true;
        public bool influenceBonusPlayerOnly { get; set; } = true;
        public float influenceBonus { get; set; } = 0.02f;
        public int influenceBonusAttribute { get; set; } = 5;

        public bool xpBonusEnabled { get; set; } = true;
        public bool xpBonusPlayerOnly { get; set; } = true;
        public float xpBonus { get; set; } = 0.05f;
        public int xpBonusAttribute { get; set; } = 5;

        public bool partyLeaderXPBonusEnabled { get; set; } = true;
        public float partyLeaderXPBonus { get; set; } = 0.033f;
        public int partyLeaderXPBonusAttribute { get; set; } = 5;

        public bool companionBonusEnabled { get; set; } = true;
        public int companionBonus { get; set; } = 1;
        public int companionBonusAttribute { get; set; } = 4;

        public bool reloadBonusEnabled { get; set; } = true;
        public bool reloadBonusPlayerOnly { get; set; } = true;
        public float reloadBonus { get; set; } = 0.02f;
        public int reloadBonusAttribute { get; set; } = 0;

        public bool handlingBonusEnabled { get; set; } = true;
        public bool handlingBonusPlayerOnly { get; set; } = true;
        public float handlingBonus { get; set; } = 0.02f;
        public int handlingBonusAttribute { get; set; } = 1;

        public bool movementBonusEnabled { get; set; } = true;
        public bool movementBonusPlayerOnly { get; set; } = true;
        public float movementBonus { get; set; } = 0.02f;
        public int movementBonusAttribute { get; set; } = 1;

        public int levelsPerAttributePoint { get; set; } = 3;
        public int focusPointsPerLevel { get; set; } = 1;
        public int maxAttributeLevel { get; set; } = 10;
        public int maxFocusPointsPerSkill { get; set; } = 5; 
    }
}
