
namespace BetterAttributes.Settings {
    public interface ISettings {

        bool melDmgBonusEnabled { get; set; }
        bool melDmgBonusPlayerOnly { get; set; }
        float melDmgBonus { get; set; }
        int melDmgBonusAttribute { get; set; }

        bool rngDmgBonusEnabled { get; set; }
        bool rngDmgBonusPlayerOnly { get; set; }
        float rngDmgBonus { get; set; }
        int rngDmgBonusAttribute { get; set; }

        bool healthBonusEnabled { get; set; }
        bool healthBonusPlayerOnly { get; set; }
        float healthBonus { get; set; }
        int healthBonusAttribute { get; set; }

        bool healthRegenBonusEnabled { get; set; }
        bool healthRegenBonusPlayerOnly { get; set; }
        float healthRegenBonus { get; set; }
        int healthRegenBonusAttribute { get; set; }

        bool staggerBonusEnabled { get; set; }
        bool staggerBonusPlayerOnly { get; set; }
        float staggerBonus { get; set; }
        int staggerBonusAttribute { get; set; }

        bool simBonusEnabled { get; set; }
        bool simBonusPlayerOnly { get; set; }
        float simBonus { get; set; }
        int simBonusAttribute { get; set; }

        bool persuasionBonusEnabled { get; set; }
        float persuasionBonus { get; set; }
        int persuasionBonusAttribute { get; set; }

        bool renownBonusEnabled { get; set; }
        bool renownBonusPlayerOnly { get; set; }
        float renownBonus { get; set; }
        int renownBonusAttribute { get; set; }

        bool moraleBonusEnabled { get; set; }
        bool moraleBonusPlayerOnly { get; set; }
        float moraleBonus { get; set; }
        int moraleBonusAttribute { get; set; }

        bool partyMoraleBonusEnabled { get; set; }
        bool partyMoraleBonusPlayerOnly { get; set; }
        float partyMoraleBonus { get; set; }
        int partyMoraleBonusAttribute { get; set; }

        bool wageBonusEnabled { get; set; }
        bool wageBonusPlayerOnly { get; set; }
        float wageBonus { get; set; }
        int wageBonusAttribute { get; set; }

        bool partySizeBonusEnabled { get; set; }
        bool partySizeBonusPlayerOnly { get; set; }
        float partySizeBonus { get; set; }
        int partySizeBonusAttribute { get; set; }

        bool incomeBonusEnabled { get; set; }
        bool incomeBonusPlayerOnly { get; set; }
        float incomeBonus { get; set; }
        int incomeBonusAttribute { get; set; }

        bool influenceBonusEnabled { get; set; }
        bool influenceBonusPlayerOnly { get; set; }
        float influenceBonus { get; set; }
        int influenceBonusAttribute { get; set; }

        bool xpBonusEnabled { get; set; }
        bool xpBonusPlayerOnly { get; set; }
        float xpBonus { get; set; }
        int xpBonusAttribute { get; set; }

        bool partyLeaderXPBonusEnabled { get; set; }
        float partyLeaderXPBonus { get; set; }
        int partyLeaderXPBonusAttribute { get; set; }

        bool companionBonusEnabled { get; set; }
        int companionBonus { get; set; }
        int companionBonusAttribute { get; set; }

        bool reloadBonusEnabled { get; set; }
        bool reloadBonusPlayerOnly { get; set; }
        float reloadBonus { get; set; }
        int reloadBonusAttribute { get; set; }

        bool handlingBonusEnabled { get; set; }
        bool handlingBonusPlayerOnly { get; set; }
        float handlingBonus { get; set; }
        int handlingBonusAttribute { get; set; }

        bool movementBonusEnabled { get; set; }
        bool movementBonusPlayerOnly { get; set; }
        float movementBonus { get; set; }
        int movementBonusAttribute { get; set; }

        int levelsPerAttributePoint { get; set; }
        int focusPointsPerLevel { get; set; }
        int maxAttributeLevel { get; set; }
        int maxFocusPointsPerSkill { get; set; }
    }
}
