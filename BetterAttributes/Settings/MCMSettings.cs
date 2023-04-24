using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;

namespace BetterAttributes.Settings {

    internal class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettings {

        const string bonusesText = "{=BA_oPw9hh}Bonuses";

        const string enabledText = "{=BA_V8krxN}Enable";
        const string enabledDesText = "{=BA_sVRwEA}Should this bonus be applied.";

        const string playerOnlyText = "{=BA_vBH4P5}Player Only";
        const string playerOnlyDesText = "{=BA_5AKRK0}Should this bonus apply to all heroes, not just the player.";

        const string bonusText = "{=BA_8g0U40}Bonus";
        const string genericBonusText = "{=BA_3F0Jal}An increase multiplied by attribute level. (For example, a 2% (.02) bonus will be 20% at attribute level 10)";

        const string attributeText = "{BA_OUkZom}Attribute";
        const string genericAtrSelectText = "{=BA_N7DNB0}Select the attribute that this bonus should use";

        const string vigorText = "{=BA_Mf0D9r}Vigor";
        const string controlText = "{=BA_yXzbqm}Control";
        const string enduranceText = "{=BA_3xcrKW}Endurance";
        const string cunningText = "{=BA_v92Ex5}Cunning";
        const string socialText = "{=BA_YtXewV}Social";
        const string intelligenceText = "{=BA_i0FVps}Intelligence";


        const string meleeText = "{=BA_YdzGi4}Melee Damage Bonus";

        [SettingPropertyGroup(bonusesText + "/" + meleeText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool melDmgBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + meleeText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool melDmgBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + meleeText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float melDmgBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + meleeText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> melDmgBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 0);


        const string rangeText = "{=BA_qDobnE}Ranged Damage Bonus";

        [SettingPropertyGroup(bonusesText + "/" + rangeText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool rngDmgBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + rangeText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool rngDmgBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + rangeText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float rngDmgBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + rangeText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> rngDmgBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 1);


        const string healthText = "{=BA_naGmUB}Health (HP) Bonus";

        [SettingPropertyGroup(bonusesText + "/" + healthText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool healthBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + healthText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool healthBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + healthText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float healthBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + healthText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> healthBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 2);


        const string healthRegenText = "{=BA_naGmUg}Healing Rate Bonus";

        [SettingPropertyGroup(bonusesText + "/" + healthRegenText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool healthRegenBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + healthRegenText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool healthRegenBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + healthRegenText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float healthRegenBonus { get; set; } = .05f;

        [SettingPropertyGroup(bonusesText + "/" + healthRegenText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> healthRegenBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 0);


        const string staggerText = "{=BA_ZYM5T1}Stagger Interrupt Bonus";

        [SettingPropertyGroup(bonusesText + "/" + staggerText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool staggerBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + staggerText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool staggerBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + staggerText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float staggerBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + staggerText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> staggerBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 2);


        const string simText = "{=BA_7yzj1P}Simulation Advantage Bonus";

        [SettingPropertyGroup(bonusesText + "/" + simText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool simBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + simText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool simBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + simText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float simBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + simText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> simBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 3);


        const string persuasionText = "{=BA_zH5MWH}Persuasion Chance Bonus";

        [SettingPropertyGroup(bonusesText + "/" + persuasionText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool persuasionBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + persuasionText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float persuasionBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + persuasionText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> persuasionBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 3);


        const string renownText = "{=BA_z99bZB}Renown Bonus From Victories";

        [SettingPropertyGroup(bonusesText + "/" + renownText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool renownBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + renownText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool renownBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + renownText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float renownBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + renownText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> renownBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 3);


        const string moralText = "{=BA_GaAeaG}Morale Bonus From Victories";

        [SettingPropertyGroup(bonusesText + "/" + moralText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool moraleBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + moralText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool moraleBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + moralText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float moraleBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + moralText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> moraleBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 3);


        const string partyMoralText = "{=BA_WODJA5}Party Morale Bonus";

        [SettingPropertyGroup(bonusesText + "/" + partyMoralText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool partyMoraleBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + partyMoralText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool partyMoraleBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + partyMoralText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float partyMoraleBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + partyMoralText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> partyMoraleBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 4);


        const string wageText = "{=BA_6Eyxyw}Party Wage Reduction Bonus";

        [SettingPropertyGroup(bonusesText + "/" + wageText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool wageBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + wageText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool wageBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + wageText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float wageBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + wageText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> wageBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 4);


        const string sizeText = "{=BA_dka4CP}Party Size Bonus";

        [SettingPropertyGroup(bonusesText + "/" + sizeText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool partySizeBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + sizeText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool partySizeBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + sizeText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float partySizeBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + sizeText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> partySizeBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 4);



        const string incomeText = "{=BA_GINfAP}Gross Clan Income Bonus";

        [SettingPropertyGroup(bonusesText + "/" + incomeText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool incomeBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + incomeText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool incomeBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + incomeText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float incomeBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + incomeText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> incomeBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 5);


        const string influenceText = "{=BA_5bULNj}Influence Bonus From Victories";

        [SettingPropertyGroup(bonusesText + "/" + influenceText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool influenceBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + influenceText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool influenceBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + influenceText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float influenceBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + influenceText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> influenceBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 5);


        const string xpText = "{=BA_35dS0f}XP Bonus";

        [SettingPropertyGroup(bonusesText + "/" + xpText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool xpBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + xpText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool xpBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + xpText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float xpBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + xpText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> xpBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 5);


        const string partyLeaderXPText = "{=BA_354j0g}Party Leader XP From Assigned Party Roles";

        [SettingPropertyGroup(bonusesText + "/" + partyLeaderXPText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = "{=BA_346heg}Should the party leader be granted bonus xp from assigned party roles. For example, if your scout gains some xp in scouting how much of the xp should be granted to the party leader.")]
        public bool partyLeaderXPBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + partyLeaderXPText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float partyLeaderXPBonus { get; set; } = .025f;

        [SettingPropertyGroup(bonusesText + "/" + partyLeaderXPText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> partyLeaderXPBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 5);


        const string companionText = "{=BA_354j0f}Companion Limit Bonus";

        [SettingPropertyGroup(bonusesText + "/" + companionText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool companionBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + companionText)]
        [SettingPropertyInteger(bonusText, 0, 100, "0", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public int companionBonus { get; set; } = 1;

        [SettingPropertyGroup(bonusesText + "/" + companionText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> companionBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 4);


        const string reloadText = "{=BA_35dS78}Reload Speed Bonus";

        [SettingPropertyGroup(bonusesText + "/" + reloadText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool reloadBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + reloadText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool reloadBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + reloadText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float reloadBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + reloadText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> reloadBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 0);


        const string handlingText = "{=BA_35d5rt}Weapon Handling Bonus";

        [SettingPropertyGroup(bonusesText + "/" + handlingText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool handlingBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + handlingText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool handlingBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + handlingText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float handlingBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + handlingText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> handlingBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 1);


        const string movementText = "{=BA_hetS0f}Movement Speed Bonus";

        [SettingPropertyGroup(bonusesText + "/" + movementText)]
        [SettingPropertyBool(enabledText, Order = 0, RequireRestart = false, IsToggle = true, HintText = enabledDesText)]
        public bool movementBonusEnabled { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + movementText)]
        [SettingPropertyBool(playerOnlyText, Order = 0, RequireRestart = false, HintText = playerOnlyDesText)]
        public bool movementBonusPlayerOnly { get; set; } = true;

        [SettingPropertyGroup(bonusesText + "/" + movementText)]
        [SettingPropertyFloatingInteger(bonusText, 0f, 10f, "0.00%", Order = 0, RequireRestart = false, HintText = genericBonusText)]
        public float movementBonus { get; set; } = .02f;

        [SettingPropertyGroup(bonusesText + "/" + movementText)]
        [SettingPropertyDropdown(attributeText, Order = 0, RequireRestart = false, HintText = genericAtrSelectText)]
        public Dropdown<string> movementBonusAttributeDropdown { get; set; } = new Dropdown<string>(new string[] {
            vigorText,
            controlText,
            enduranceText,
            cunningText,
            socialText,
            intelligenceText
        }, selectedIndex: 1);


        [SettingPropertyGroup(attributeText)]
        [SettingPropertyInteger("{=BA_GU6Ibm}Levels Per Attribute Point", 1, 10, "0", Order = 0, RequireRestart = false, HintText = "{=BA_VhEAx3}How many levels you need to gain to get an attribute point.")]
        public int levelsPerAttributePoint { get; set; } = 3;

        [SettingPropertyGroup(attributeText)]
        [SettingPropertyInteger("{=BA_KAggxW}Max Attribute Level", 0, 100, "0", Order = 0, RequireRestart = false, HintText = "{=BA_TAtfSS}Maximum level for attributes.")]
        public int maxAttributeLevel { get; set; } = 10;

        [SettingPropertyGroup("Focus")]
        [SettingPropertyInteger("{=BA_S7nfeK}Focus Points Per Level", 0, 100, "0", Order = 0, RequireRestart = false, HintText = "{=BA_GtIuji}How many focus points per level.")]
        public int focusPointsPerLevel { get; set; } = 1;

        [SettingPropertyGroup("Focus")]
        [SettingPropertyInteger("{=BA_S7nfeK}Max Focus Points Per Skill", 0, 100, "0", Order = 0, RequireRestart = false, HintText = "{=BA_GtIutr}How many focus points that can be spent on a skill.")]
        public int maxFocusPointsPerSkill { get; set; } = 5;

        public int melDmgBonusAttribute {
            get {
                return this.melDmgBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.melDmgBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int rngDmgBonusAttribute {
            get {
                return this.rngDmgBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.rngDmgBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int healthBonusAttribute {
            get {
                return this.healthBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.healthBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int healthRegenBonusAttribute {
            get {
                return this.healthRegenBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.healthRegenBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int staggerBonusAttribute {
            get {
                return this.staggerBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.staggerBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int simBonusAttribute {
            get {
                return this.simBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.simBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int persuasionBonusAttribute {
            get {
                return this.persuasionBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.persuasionBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int renownBonusAttribute {
            get {
                return this.renownBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.renownBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int moraleBonusAttribute {
            get {
                return this.moraleBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.moraleBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int partyMoraleBonusAttribute {
            get {
                return this.partyMoraleBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.partyMoraleBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int wageBonusAttribute {
            get {
                return this.wageBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.wageBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int partySizeBonusAttribute {
            get {
                return this.partySizeBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.partySizeBonusAttributeDropdown.SelectedIndex = value;
            }
        }


        public int incomeBonusAttribute {
            get {
                return this.incomeBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.incomeBonusAttributeDropdown.SelectedIndex = value;
            }
        }


        public int influenceBonusAttribute {
            get {
                return this.influenceBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.influenceBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int xpBonusAttribute {
            get {
                return this.xpBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.xpBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int partyLeaderXPBonusAttribute {
            get {
                return this.partyLeaderXPBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.partyLeaderXPBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int companionBonusAttribute {
            get {
                return this.companionBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.companionBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int reloadBonusAttribute {
            get {
                return this.reloadBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.reloadBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int handlingBonusAttribute {
            get {
                return this.handlingBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.handlingBonusAttributeDropdown.SelectedIndex = value;
            }
        }

        public int movementBonusAttribute {
            get {
                return this.movementBonusAttributeDropdown.SelectedIndex;
            }
            set {
                this.movementBonusAttributeDropdown.SelectedIndex = value;
            }
        }



        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get; } = "Better Attributes";
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
