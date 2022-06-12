using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace BetterAttributes {
	// Token: 0x020002E5 RID: 741
	public class CustomDefaultCharacterDevelopmentModel : DefaultCharacterDevelopmentModel {
		// Token: 0x06002CF5 RID: 11509 RVA: 0x000AE9E2 File Offset: 0x000ACBE2
		public CustomDefaultCharacterDevelopmentModel() {
			this.InitializeSkillsRequiredForLevel();
			this.InitializeXpRequiredForSkillLevel();
		}

		// Token: 0x06002CF6 RID: 11510 RVA: 0x000AEA14 File Offset: 0x000ACC14
		private void InitializeSkillsRequiredForLevel() {
			int num = 1000;
			int num2 = 1;
			this._skillsRequiredForLevel[0] = 0;
			this._skillsRequiredForLevel[1] = 1;
			for (int i = 2; i < this._skillsRequiredForLevel.Length; i++) {
				num2 += num;
				this._skillsRequiredForLevel[i] = num2;
				num += 1000 + num / 5;
			}
		}

		// Token: 0x06002CF7 RID: 11511 RVA: 0x000AEA67 File Offset: 0x000ACC67
		public override int SkillsRequiredForLevel(int level) {
			if (level > 62) {
				return int.MaxValue;
			}
			return this._skillsRequiredForLevel[level];
		}

		// Token: 0x06002CF8 RID: 11512 RVA: 0x000AEA7C File Offset: 0x000ACC7C
		public override int GetMaxSkillPoint() {
			return int.MaxValue;
		}

		// Token: 0x06002CF9 RID: 11513 RVA: 0x000AEA84 File Offset: 0x000ACC84
		private void InitializeXpRequiredForSkillLevel() {
			int num = 30;
			this._xpRequiredForSkillLevel[0] = num;
			for (int i = 1; i < 1024; i++) {
				num += 10 + i;
				this._xpRequiredForSkillLevel[i] = this._xpRequiredForSkillLevel[i - 1] + num;
			}
		}

		// Token: 0x06002CFA RID: 11514 RVA: 0x000AEAC8 File Offset: 0x000ACCC8
		public override int GetXpRequiredForSkillLevel(int skillLevel) {
			if (skillLevel <= 0) {
				return 0;
			}
			return this._xpRequiredForSkillLevel[skillLevel - 1];
		}

		// Token: 0x06002CFB RID: 11515 RVA: 0x000AEADC File Offset: 0x000ACCDC
		public override void GetSkillLevelChange(Hero hero, SkillObject skill, float skillXp, out int skillLevelChange) {
			skillLevelChange = 0;
			int skillValue = hero.GetSkillValue(skill);
			for (int i = 0; i < 1024; i++) {
				int num = skillValue + i;
				if (num < 1023) {
					if (skillXp < (float)this._xpRequiredForSkillLevel[num]) {
						break;
					}
					skillLevelChange++;
				}
			}
		}

		// Token: 0x06002CFC RID: 11516 RVA: 0x000AEB28 File Offset: 0x000ACD28
		public override int GetXpAmountForSkillLevelChange(Hero hero, SkillObject skill, int skillLevelChange) {
			int skillValue = hero.GetSkillValue(skill);
			return this._xpRequiredForSkillLevel[skillValue + skillLevelChange] - this._xpRequiredForSkillLevel[skillValue];
		}

		// Token: 0x06002CFD RID: 11517 RVA: 0x000AEB50 File Offset: 0x000ACD50
		public override void GetTraitLevelForTraitXp(Hero hero, TraitObject trait, int xpValue, out int traitLevel, out int clampedTraitXp) {
			clampedTraitXp = xpValue;
			int num = (trait.MinValue < -1) ? -6000 : ((trait.MinValue == -1) ? -2500 : 0);
			int num2 = (trait.MaxValue > 1) ? 6000 : ((trait.MaxValue == 1) ? 2500 : 0);
			if (xpValue > num2) {
				clampedTraitXp = num2;
			} else if (xpValue < num) {
				clampedTraitXp = num;
			}
			traitLevel = ((clampedTraitXp <= -4000) ? -2 : ((clampedTraitXp <= -1000) ? -1 : ((clampedTraitXp < 1000) ? 0 : ((clampedTraitXp < 4000) ? 1 : 2))));
			if (traitLevel < trait.MinValue) {
				traitLevel = trait.MinValue;
				return;
			}
			if (traitLevel > trait.MaxValue) {
				traitLevel = trait.MaxValue;
			}
		}

		// Token: 0x06002CFE RID: 11518 RVA: 0x000AEC19 File Offset: 0x000ACE19
		public override int GetTraitXpRequiredForTraitLevel(TraitObject trait, int traitLevel) {
			if (traitLevel < -1) {
				return -4000;
			}
			if (traitLevel == -1) {
				return -1000;
			}
			if (traitLevel == 0) {
				return 0;
			}
			if (traitLevel != 1) {
				return 4000;
			}
			return 1000;
		}

		// Token: 0x17000B58 RID: 2904
		// (get) Token: 0x06002CFF RID: 11519 RVA: 0x000AEC43 File Offset: 0x000ACE43
		public override int AttributePointsAtStart {
			get {
				return 15;
			}
		}

		// Token: 0x17000B59 RID: 2905
		// (get) Token: 0x06002D00 RID: 11520 RVA: 0x000AEC47 File Offset: 0x000ACE47
		public override int LevelsPerAttributePoint {
			get {
				return 4;
			}
		}

		// Token: 0x17000B5A RID: 2906
		// (get) Token: 0x06002D01 RID: 11521 RVA: 0x000AEC4A File Offset: 0x000ACE4A
		public override int FocusPointsPerLevel {
			get {
				return 1;
			}
		}

		// Token: 0x17000B5B RID: 2907
		// (get) Token: 0x06002D02 RID: 11522 RVA: 0x000AEC4D File Offset: 0x000ACE4D
		public override int FocusPointsAtStart {
			get {
				return 5;
			}
		}

		// Token: 0x17000B5C RID: 2908
		// (get) Token: 0x06002D03 RID: 11523 RVA: 0x000AEC50 File Offset: 0x000ACE50
		public override int FocusPointCostToOpenSkill {
			get {
				return 0;
			}
		}

		// Token: 0x06002D04 RID: 11524 RVA: 0x000AEC54 File Offset: 0x000ACE54
		public override void GetInitialSkillXpForCharacter(Hero hero, SkillObject skill, out int initialSkillXp) {
			int skillValue = hero.CharacterObject.GetSkillValue(skill);
			if (skillValue >= 1024) {
				initialSkillXp = this._xpRequiredForSkillLevel[1023];
				return;
			}
			if (skillValue <= 0) {
				initialSkillXp = 0;
				return;
			}
			initialSkillXp = this._xpRequiredForSkillLevel[skillValue];
		}

		// Token: 0x06002D05 RID: 11525 RVA: 0x000AEC97 File Offset: 0x000ACE97
		public override int GetDevelopmentPointNeededToChangeTrait(float traitValue) {
			return MathF.Round(MathF.Abs(traitValue));
		}

		// Token: 0x06002D06 RID: 11526 RVA: 0x000AECA4 File Offset: 0x000ACEA4
		public override ExplainedNumber CalculateLearningLimit(int attributeValue, int focusValue, TextObject attributeName, bool includeDescriptions = false) {
			ExplainedNumber result = new ExplainedNumber(0f, includeDescriptions, null);
			result.Add((float)((attributeValue - 1) * 10), attributeName, null);
			result.Add((float)(focusValue * 30), CustomDefaultCharacterDevelopmentModel._skillFocusText, null);
			result.LimitMin(0f);
			return result;
		}

		// Token: 0x06002D07 RID: 11527 RVA: 0x000AECF0 File Offset: 0x000ACEF0
		public override float CalculateLearningRate(Hero hero, SkillObject skill) {
			int level = hero.Level;
			int attributeValue = hero.GetAttributeValue(skill.CharacterAttribute);
			int focus = hero.HeroDeveloper.GetFocus(skill);
			int skillValue = hero.GetSkillValue(skill);
			return this.CalculateLearningRate(attributeValue, focus, skillValue, level, skill.CharacterAttribute.Name, false).ResultNumber;
		}

		// Token: 0x06002D08 RID: 11528 RVA: 0x000AED48 File Offset: 0x000ACF48
		public override ExplainedNumber CalculateLearningRate(int attributeValue, int focusValue, int skillValue, int characterLevel, TextObject attributeName, bool includeDescriptions = false) {
			ExplainedNumber result = new ExplainedNumber(1.25f, includeDescriptions, null);
			result.AddFactor(0.4f * (float)attributeValue, attributeName);
			result.AddFactor((float)focusValue * 1f, CustomDefaultCharacterDevelopmentModel._skillFocusText);
			int num = MathF.Round(this.CalculateLearningLimit(attributeValue, focusValue, null, false).ResultNumber);
			if (skillValue > num) {
				int num2 = skillValue - num;
				result.AddFactor(-1f - 0.1f * (float)num2, CustomDefaultCharacterDevelopmentModel._overLimitText);
			}
			result.LimitMin(0f);
			return result;
		}

		// Token: 0x04000EE0 RID: 3808
		private const int MaxCharacterLevels = 620;

		// Token: 0x04000EE1 RID: 3809
		private const int MaxAttributeLevel = 110;

		// Token: 0x04000EE2 RID: 3810
		private const int SkillPointsAtLevel1 = 10;

		// Token: 0x04000EE3 RID: 3811
		private const int SkillPointsGainNeededInitialValue = 1000;

		// Token: 0x04000EE4 RID: 3812
		private const int SkillPointsGainNeededIncreasePerLevel = 1000;

		// Token: 0x04000EE5 RID: 3813
		private readonly int[] _skillsRequiredForLevel = new int[63];

		// Token: 0x04000EE6 RID: 3814
		private const int FocusPointsPerLevelConst = 1;

		// Token: 0x04000EE7 RID: 3815
		private const int LevelsPerAttributePointConst = 4;

		// Token: 0x04000EE8 RID: 3816
		private const int FocusPointCostToOpenSkillConst = 0;

		// Token: 0x04000EE9 RID: 3817
		private const int FocusPointsAtStartConst = 5;

		// Token: 0x04000EEA RID: 3818
		private const int AttributePointsAtStartConst = 15;

		// Token: 0x04000EEB RID: 3819
		private const int MaxSkillLevels = 1024;

		// Token: 0x04000EEC RID: 3820
		private readonly int[] _xpRequiredForSkillLevel = new int[1024];

		// Token: 0x04000EED RID: 3821
		private const int XpRequirementForFirstLevel = 30;

		// Token: 0x04000EEE RID: 3822
		private const int MaxSkillPoint = 2147483647;

		// Token: 0x04000EEF RID: 3823
		private const float BaseLearningRate = 1.25f;

		// Token: 0x04000EF0 RID: 3824
		private const int traitThreshold1 = 1000;

		// Token: 0x04000EF1 RID: 3825
		private const int traitThreshold2 = 4000;

		// Token: 0x04000EF2 RID: 3826
		private const int traitMaxValue1 = 2500;

		// Token: 0x04000EF3 RID: 3827
		private const int traitMaxValue2 = 6000;

		// Token: 0x04000EF4 RID: 3828
		private static TextObject _attributeText = new TextObject("{=AT6v10NK}Attribute", null);

		// Token: 0x04000EF5 RID: 3829
		private static TextObject _skillFocusText = new TextObject("{=MRktqZwu}Skill Focus", null);

		// Token: 0x04000EF6 RID: 3830
		private static TextObject _overLimitText = new TextObject("{=bcA7ZuyO}Learning Limit Exceeded", null);
	}
}
