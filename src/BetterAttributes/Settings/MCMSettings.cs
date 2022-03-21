using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;

namespace BetterAttributes.Settings {

    internal class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettings {

        const string enableForAllHeroes = "Whether this attribute effect applies to all heroes";
        const string chancePerLevel = "The percent chance increase per attribute level. (.02 = 20% chance at atr lvl 10, cunning increases this further by the cunning percent + 1 [.20(max percent at 10) * 1.5(max cunning percent) = 0.3]";

        [SettingPropertyGroup("Vigor")]
        [SettingPropertyBool("Enable slice through for heroes", Order = 0, RequireRestart = false, HintText = enableForAllHeroes)]
        public bool cutAllHeroes { get; set; } = true;

        [SettingPropertyGroup("Vigor")]
        [SettingPropertyFloatingInteger("Slice through chance per vigor", 0f, 10f, "0.00", Order = 0, RequireRestart = false, HintText = chancePerLevel)]
        public float cutChancePerVigor { get; set; } = .01f;


        [SettingPropertyGroup("Control")]
        [SettingPropertyBool("Enable morale increases for heroes", Order = 0, RequireRestart = false, HintText = enableForAllHeroes)]
        public bool moralAllHeroes { get; set; } = true;
        [SettingPropertyGroup("Control")]
        [SettingPropertyFloatingInteger("Morale increase per control", 0f, 10f, "0.00", Order = 0, RequireRestart = false, HintText = chancePerLevel)]
        public float moralBonusPerControl { get; set; } = 0.02f;


        [SettingPropertyGroup("Endurance")]
        [SettingPropertyBool("Enable health increases for heroes", Order = 0, RequireRestart = false, HintText = enableForAllHeroes)]
        public bool healthIncAllHeroes { get; set; } = true;
        [SettingPropertyGroup("Endurance")]
        [SettingPropertyFloatingInteger("Health increase per endurance", 0f, 10f, "0.00", Order = 0, RequireRestart = false, HintText = chancePerLevel)]
        public float healthIncreasePerEndurance { get; set; } = 0.02f;


        [SettingPropertyGroup("Cunning")]
        [SettingPropertyBool("Enable cunning percent increases for heroes", Order = 0, RequireRestart = false, HintText = enableForAllHeroes)]
        public bool cunningAllHeros { get; set; } = true;
        [SettingPropertyGroup("Cunning")]
        [SettingPropertyFloatingInteger("Percent cunning increase Per cunning", 0f, 10f, "0.00", Order = 0, RequireRestart = false, HintText = chancePerLevel)]
        public float percentIncreasePerCunning { get; set; } = 0.05f;


        [SettingPropertyGroup("Social")]
        [SettingPropertyBool("Enable party wage reduction for heroes", Order = 0, RequireRestart = false, HintText = enableForAllHeroes)]
        public bool wageAllHeroes { get; set; } = true;
        [SettingPropertyGroup("Social")]
        [SettingPropertyFloatingInteger("Party wage reduction per social", 0f, 10f, "0.00", Order = 0, RequireRestart = false, HintText = chancePerLevel)]
        public float wageDecreasePerSocial { get; set; } = .02f;


        [SettingPropertyGroup("Intelligence")]
        [SettingPropertyBool("Enable xp rate increase for heroes", Order = 0, RequireRestart = false, HintText = enableForAllHeroes)]
        public bool xpAllHeroes { get; set; } = true;
        [SettingPropertyGroup("Intelligence")]
        [SettingPropertyFloatingInteger("Xp rate increase per intelligence", 0f, 10f, "0.00", Order = 0, RequireRestart = false, HintText = chancePerLevel)]
        public float xpBonusPerIntelligence { get; set; } = 0.02f;

        [SettingPropertyGroup("Attributes")]
        [SettingPropertyInteger("Levels Per Attribute Points", 0, 10, "0", Order = 0, RequireRestart = false, HintText = chancePerLevel)]
        public int levelsPerAttributePoint { get; set; } = 3;

        [SettingPropertyGroup("Focus")]
        [SettingPropertyInteger("Focus Points Per Level", 0, 10, "0", Order = 0, RequireRestart = false, HintText = chancePerLevel)]
        public int focusPointsPerLevel { get; set; } = 1;



        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get; } = "Better Attributes";
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
