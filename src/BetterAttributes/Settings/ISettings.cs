
namespace BetterAttributes.Settings {
    public interface ISettings {

        bool melDmgBonusEnabled { get; set; }
        bool melDmgBonusPlayerOnly { get; set; }
        float melDmgBonus { get; set; }
        string melDmgBonusAttribute { get; set; }

        bool rngDmgBonusEnabled { get; set; }
        bool rngDmgBonusPlayerOnly { get; set; }
        float rngDmgBonus { get; set; }
        string rngDmgBonusAttribute { get; set; }

        bool healthBonusEnabled { get; set; }
        bool healthBonusPlayerOnly { get; set; }
        float healthBonus { get; set; }
        string healthBonusAttribute { get; set; }

        bool staggerBonusEnabled { get; set; }
        bool staggerBonusPlayerOnly { get; set; }
        float staggerBonus { get; set; }
        string staggerBonusAttribute { get; set; }

        bool simBonusEnabled { get; set; }
        bool simBonusPlayerOnly { get; set; }
        float simBonus { get; set; }
        string simBonusAttribute { get; set; }

        bool persuasionBonusEnabled { get; set; }
        float persuasionBonus { get; set; }
        string persuasionBonusAttribute { get; set; }

        bool renownBonusEnabled { get; set; }
        bool renownBonusPlayerOnly { get; set; }
        float renownBonus { get; set; }
        string renownBonusAttribute { get; set; }

        bool moraleBonusEnabled { get; set; }
        bool moraleBonusPlayerOnly { get; set; }
        float moraleBonus { get; set; }
        string moraleBonusAttribute { get; set; }

        bool partyMoraleBonusEnabled { get; set; }
        bool partyMoraleBonusPlayerOnly { get; set; }
        float partyMoraleBonus { get; set; }
        string partyMoraleBonusAttribute { get; set; }

        bool wageBonusEnabled { get; set; }
        bool wageBonusPlayerOnly { get; set; }
        float wageBonus { get; set; }
        string wageBonusAttribute { get; set; }

        bool partySizeBonusEnabled { get; set; }
        bool partySizeBonusPlayerOnly { get; set; }
        float partySizeBonus { get; set; }
        string partySizeBonusAttribute { get; set; }

        bool incomeBonusEnabled { get; set; }
        bool incomeBonusPlayerOnly { get; set; }
        float incomeBonus { get; set; }
        string incomeBonusAttribute { get; set; }

        bool influenceBonusEnabled { get; set; }
        bool influenceBonusPlayerOnly { get; set; }
        float influenceBonus { get; set; }
        string influenceBonusAttribute { get; set; }

        bool xpBonusEnabled { get; set; }
        bool xpBonusPlayerOnly { get; set; }
        float xpBonus { get; set; }
        string xpBonusAttribute { get; set; }


        bool partyLeaderXPBonusEnabled { get; set; }
        float partyLeaderXPBonus { get; set; }
        string partyLeaderXPBonusAttribute { get; set; }

        bool companionBonusEnabled { get; set; }
        int companionBonus { get; set; }
        string companionBonusAttribute { get; set; }


        int levelsPerAttributePoint { get; set; }
        int focusPointsPerLevel { get; set; }
        int maxAttributeLevel { get; set; }
        int maxFocusPointsPerSkill { get; set; }
    }
}
