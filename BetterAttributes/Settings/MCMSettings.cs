using BetterAttributes.Localizations;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;

namespace BetterAttributes.Settings {

    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {


        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MeleeText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool MelDmgBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MeleeText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool MelDmgBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MeleeText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float MelDmgBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MeleeText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> MelDmgBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 1);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.RangeText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool RngDmgBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.RangeText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool RngDmgBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.RangeText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float RngDmgBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.RangeText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> RngDmgBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 2);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HealthText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool HealthBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HealthText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool HealthBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HealthText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float HealthBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HealthText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> HealthBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 3);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HealthRegenText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool HealthRegenBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HealthRegenText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool HealthRegenBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HealthRegenText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float HealthRegenBonus { get; set; } = .05f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HealthRegenText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> HealthRegenBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 1);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.StaggerText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool StaggerBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.StaggerText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool StaggerBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.StaggerText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float StaggerBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.StaggerText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> StaggerBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 3);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SimText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool SimBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SimText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool SimBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SimText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float SimBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SimText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> SimBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 4);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PersuasionText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool PersuasionBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PersuasionText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float PersuasionBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PersuasionText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> PersuasionBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 4);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.RenownText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool RenownBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.RenownText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool RenownBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.RenownText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float RenownBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.RenownText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> RenownBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 4);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MoralText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool MoraleBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MoralText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool MoraleBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MoralText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float MoraleBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MoralText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> MoraleBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 4);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PartyMoralText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool PartyMoraleBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PartyMoralText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool PartyMoraleBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PartyMoralText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float PartyMoraleBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PartyMoralText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> PartyMoraleBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 5);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.WageText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool WageBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.WageText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool WageBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.WageText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float WageBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.WageText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> WageBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 5);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SizeText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool PartySizeBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SizeText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool PartySizeBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SizeText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float PartySizeBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SizeText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> PartySizeBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 5);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.IncomeText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool IncomeBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.IncomeText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool IncomeBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.IncomeText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float IncomeBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.IncomeText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> IncomeBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 6);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.InfluenceText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool InfluenceBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.InfluenceText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool InfluenceBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.InfluenceText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float InfluenceBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.InfluenceText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> InfluenceBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 6);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.XpText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool XpBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.XpText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool XpBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.XpText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float XpBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.XpText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> XpBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 6);



        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PartyLeaderXPText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.partyLeaderXPHint)]
        public bool PartyLeaderXPBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PartyLeaderXPText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float PartyLeaderXPBonus { get; set; } = .025f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.PartyLeaderXPText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> PartyLeaderXPBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 6);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.CompanionText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool CompanionBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.CompanionText)]
        [SettingPropertyInteger(RefValues.BonusText, 0, 100, "0", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public int CompanionBonus { get; set; } = 1;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.CompanionText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> CompanionBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 5);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.ReloadText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool ReloadBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.ReloadText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool ReloadBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.ReloadText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float ReloadBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.ReloadText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> ReloadBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 1);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HandlingText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool HandlingBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HandlingText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool HandlingBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HandlingText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float HandlingBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.HandlingText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> HandlingBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 2);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MovementText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool MovementBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MovementText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool MovementBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MovementText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float MovementBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.MovementText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> MovementBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 2);




        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SmithingText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool SmithingBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SmithingText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 250f, "0", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public int SmithingBonus { get; set; } = 10;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SmithingText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> SmithingBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 3);



        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.AccuracyText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool AccuracyBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.AccuracyText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool AccuracyBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.AccuracyText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float AccuracyBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.AccuracyText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> AccuracyBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 2);



        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.DrawText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool DrawBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.DrawText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool DrawBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.DrawText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float DrawBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.DrawText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> DrawBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 1);



        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.StabilityText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool StabilityBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.StabilityText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool StabilityBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.StabilityText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float StabilityBonus { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.StabilityText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> StabilityBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 3);


        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SliceText)]
        [SettingPropertyBool(RefValues.EnabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = RefValues.EnabledHint)]
        public bool SliceChanceEnabled { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SliceText)]
        [SettingPropertyBool(RefValues.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerOnlyHint)]
        public bool SliceChancePlayerOnly { get; set; } = true;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SliceText)]
        [SettingPropertyFloatingInteger(RefValues.BonusText, 0f, 1f, "0.00%", Order = 0, RequireRestart = false, HintText = RefValues.BonusHint)]
        public float SliceChance { get; set; } = .02f;

        [SettingPropertyGroup(RefValues.BonusesText + "/" + RefValues.SliceText)]
        [SettingPropertyDropdown(RefValues.AttributeText, Order = 0, RequireRestart = false, HintText = RefValues.AttributeHint)]
        public Dropdown<string> SliceChanceAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            RefValues.NoneText,
            RefValues.VigorText,
            RefValues.ControlText,
            RefValues.EnduranceText,
            RefValues.CunningText,
            RefValues.SocialText,
            RefValues.IntelligenceText
        }, selectedIndex: 1);



        [SettingPropertyGroup(RefValues.MiscText)]
        [SettingPropertyBool(RefValues.MoreBonusText, Order = 0, RequireRestart = false, HintText = RefValues.MoreBonusHint)]
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
                return this.SliceChanceAttributeDropdown.SelectedIndex;
            }
            set {
                this.SliceChanceAttributeDropdown.SelectedIndex = value;
            }
        }


        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
