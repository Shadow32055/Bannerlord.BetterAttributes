using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;

namespace BetterAttributes.Settings
{

    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {


        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MeleeText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool MelDmgBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MeleeText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool MelDmgBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MeleeText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float MelDmgBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MeleeText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> MelDmgBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 0);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.RangeText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool RngDmgBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.RangeText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool RngDmgBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.RangeText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float RngDmgBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.RangeText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> RngDmgBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 1);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HealthText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool HealthBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HealthText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool HealthBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HealthText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float HealthBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HealthText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> HealthBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 2);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HealthRegenText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool HealthRegenBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HealthRegenText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool HealthRegenBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HealthRegenText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float HealthRegenBonus { get; set; } = .05f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HealthRegenText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> HealthRegenBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 0);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.StaggerText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool StaggerBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.StaggerText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool StaggerBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.StaggerText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float StaggerBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.StaggerText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> StaggerBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 2);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SimText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool SimBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SimText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool SimBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SimText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float SimBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SimText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> SimBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 3);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PersuasionText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool PersuasionBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PersuasionText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float PersuasionBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PersuasionText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> PersuasionBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 3);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.RenownText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool RenownBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.RenownText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool RenownBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.RenownText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float RenownBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.RenownText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> RenownBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 3);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MoralText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool MoraleBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MoralText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool MoraleBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MoralText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float MoraleBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MoralText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> MoraleBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 3);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PartyMoralText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool PartyMoraleBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PartyMoralText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool PartyMoraleBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PartyMoralText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float PartyMoraleBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PartyMoralText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> PartyMoraleBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 4);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.WageText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool WageBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.WageText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool WageBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.WageText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float WageBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.WageText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> WageBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 4);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SizeText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool PartySizeBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SizeText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool PartySizeBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SizeText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float PartySizeBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SizeText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> PartySizeBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 4);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.IncomeText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool IncomeBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.IncomeText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool IncomeBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.IncomeText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float IncomeBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.IncomeText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> IncomeBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 5);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.InfluenceText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool InfluenceBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.InfluenceText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool InfluenceBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.InfluenceText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float InfluenceBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.InfluenceText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> InfluenceBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 5);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.XpText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool XpBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.XpText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool XpBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.XpText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float XpBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.XpText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> XpBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 5);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PartyLeaderXPText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.partyLeaderXPHint)]
        public bool PartyLeaderXPBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PartyLeaderXPText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float PartyLeaderXPBonus { get; set; } = .025f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.PartyLeaderXPText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> PartyLeaderXPBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 5);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.CompanionText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool CompanionBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.CompanionText)]
        [SettingPropertyInteger(Strings.BonusText, 0, 100, "0", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public int CompanionBonus { get; set; } = 1;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.CompanionText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> CompanionBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 4);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.ReloadText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool ReloadBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.ReloadText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool ReloadBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.ReloadText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float ReloadBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.ReloadText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> ReloadBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 0);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HandlingText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool HandlingBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HandlingText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool HandlingBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HandlingText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float HandlingBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.HandlingText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> HandlingBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 1);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MovementText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool MovementBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MovementText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool MovementBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MovementText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float MovementBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.MovementText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> MovementBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 1);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SmithingText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool SmithingBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SmithingText)]
        [SettingPropertyInteger(Strings.BonusText, 0, 250, "0", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public int SmithingBonus { get; set; } = 10;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SmithingText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> SmithingBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 2);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.AccuracyText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool AccuracyBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.AccuracyText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool AccuracyBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.AccuracyText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float AccuracyBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.AccuracyText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> AccuracyBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 1);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.DrawText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool DrawBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.DrawText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool DrawBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.DrawText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float DrawBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.DrawText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> DrawBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 0);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.StabilityText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool StabilityBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.StabilityText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool StabilityBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.StabilityText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float StabilityBonus { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.StabilityText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> StabilityBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 2);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SliceText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool SliceEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SliceText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool SlicePlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SliceText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 1f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float SliceChance { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SliceText)]
        [SettingPropertyBool(Strings.SliceNotifyText, Order = 0, RequireRestart = false, HintText = Strings.SliceNotifyHint)]
        public bool SliceNotify { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.SliceText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> SliceAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 0);




        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.CrushText)]
        [SettingPropertyBool(Strings.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = Strings.EnabledHint)]
        public bool CrushEnabled { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.CrushText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool CrushPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.CrushText)]
        [SettingPropertyFloatingInteger(Strings.BonusText, 0f, 1f, "0.00%", Order = 0, RequireRestart = false, HintText = Strings.BonusHint)]
        public float CrushChance { get; set; } = .02f;

        [SettingPropertyGroup(Strings.BonusesText + "/" + Strings.CrushText)]
        [SettingPropertyDropdown(Strings.AttributeText, Order = 0, RequireRestart = false, HintText = Strings.AttributeHint)]
        public Dropdown<string> CrushAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            Strings.VigorText,
            Strings.ControlText,
            Strings.EnduranceText,
            Strings.CunningText,
            Strings.SocialText,
            Strings.IntelligenceText
        }, selectedIndex: 0);




        [SettingPropertyGroup(Strings.MiscText)]
        [SettingPropertyBool(Strings.MoreBonusText, Order = 0, RequireRestart = false, HintText = Strings.MoreBonusHint)]
        public bool MoreBonusRoom { get; set; } = false;



        public int MelDmgBonusAttribute {
            get {
                return this.MelDmgBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.MelDmgBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int RngDmgBonusAttribute {
            get {
                return this.RngDmgBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.RngDmgBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int HealthBonusAttribute {
            get {
                return this.HealthBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.HealthBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int HealthRegenBonusAttribute {
            get {
                return this.HealthRegenBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.HealthRegenBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int StaggerBonusAttribute {
            get {
                return this.StaggerBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.StaggerBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int SimBonusAttribute {
            get {
                return this.SimBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.SimBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int PersuasionBonusAttribute {
            get {
                return this.PersuasionBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.PersuasionBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int RenownBonusAttribute {
            get {
                return this.RenownBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.RenownBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int MoraleBonusAttribute {
            get {
                return this.MoraleBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.MoraleBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int PartyMoraleBonusAttribute {
            get {
                return this.PartyMoraleBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.PartyMoraleBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int WageBonusAttribute {
            get {
                return this.WageBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.WageBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int PartySizeBonusAttribute {
            get {
                return this.PartySizeBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.PartySizeBonusAttributeDropdown.SelectedIndex = value;
            }
        }


        public int IncomeBonusAttribute {
            get {
                return this.IncomeBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.IncomeBonusAttributeDropdown.SelectedIndex = value;
            }
        }


        public int InfluenceBonusAttribute {
            get {
                return this.InfluenceBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.InfluenceBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int XpBonusAttribute {
            get {
                return this.XpBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.XpBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int PartyLeaderXPBonusAttribute {
            get {
                return this.PartyLeaderXPBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.PartyLeaderXPBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int CompanionBonusAttribute {
            get {
                return this.CompanionBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.CompanionBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int ReloadBonusAttribute {
            get {
                return this.ReloadBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.ReloadBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int HandlingBonusAttribute {
            get {
                return this.HandlingBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.HandlingBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int MovementBonusAttribute {
            get {
                return this.MovementBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.MovementBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int SmithingBonusAttribute {
            get {
                return this.SmithingBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.SmithingBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int AccuracyBonusAttribute {
            get {
                return this.AccuracyBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.AccuracyBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int DrawBonusAttribute {
            get {
                return this.DrawBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.DrawBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int StabilityBonusAttribute {
            get {
                return this.StabilityBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.StabilityBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int SliceChanceAttribute {
            get {
                return this.SliceAttributeDropdown.SelectedIndex;
            }
            set {
                this.SliceAttributeDropdown.SelectedIndex = value;
            }
        }

        public int CrushChanceAttribute {
            get {
                return this.CrushAttributeDropdown.SelectedIndex;
            }
            set {
                this.CrushAttributeDropdown.SelectedIndex = value;
            }
        }


        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
    }
}
