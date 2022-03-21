
namespace BetterAttributes.Settings {
    public class DefaultSettings : ISettings {
        public bool cutAllHeroes { get; set; } = true;
        public float cutChancePerVigor { get; set; } = .01f;
        public bool moralAllHeroes { get; set; } = true;
        public float moralBonusPerControl { get; set; } = 0.02f;
        public bool healthIncAllHeroes { get; set; } = true;
        public float healthIncreasePerEndurance { get; set; } = 0.02f;
        public float percentIncreasePerCunning { get; set; } = 0.02f;
        public bool cunningAllHeros { get; set; } = true;
        public bool wageAllHeroes { get; set; } = true;
        public float wageDecreasePerSocial { get; set; } = .02f;
        public bool xpAllHeroes { get; set; } = true;
        public float xpBonusPerIntelligence { get; set; } = 0.02f;
        public int levelsPerAttributePoint { get; set; } = 3;
        public int focusPointsPerLevel { get; set; } = 1;
    }
}
