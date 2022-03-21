
namespace BetterAttributes.Settings {
    public interface ISettings {
        bool cutAllHeroes { get; set; }
        float cutChancePerVigor { get; set; }
        bool moralAllHeroes { get; set; }
        float moralBonusPerControl { get; set; }
        bool healthIncAllHeroes { get; set; }
        float healthIncreasePerEndurance { get; set; }
        float percentIncreasePerCunning { get; set; }
        bool cunningAllHeros { get; set; }
        bool wageAllHeroes { get; set; }
        float wageDecreasePerSocial { get; set; }
        bool xpAllHeroes { get; set; }
        float xpBonusPerIntelligence { get; set; }
        int levelsPerAttributePoint { get; set; }
        int focusPointsPerLevel { get; set; }
    }
}
