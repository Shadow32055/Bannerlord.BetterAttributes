using HarmonyLib;
using BetterAttributes.Utils;
using BetterAttributes.Settings;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using BetterAttributes.Custom;

namespace BetterAttributes {
	public class SubModule : MBSubModuleBase {

		protected override void OnSubModuleLoad() {
			base.OnSubModuleLoad();

			Harmony h = new Harmony("Bannerlord.Shadow.BetterAttributes");

			//*** Manual patching reference
			//MethodInfo original = typeof(Hero).GetProperty("AddSkillXp").GetGetMethod();
			//MethodInfo postfix = typeof(XPPatch).GetMethod("AddSkillXp");
			//h.Patch(original, postfix: new HarmonyMethod(postfix));

			h.PatchAll();
		}

		protected override void OnGameStart(Game game, IGameStarter gameStarter) {
			base.OnGameStart(game, gameStarter);

			if (game.GameType is Campaign) {
				CampaignGameStarter campaignGameStarter = gameStarter as CampaignGameStarter;

				if (campaignGameStarter != null) {
					campaignGameStarter.AddModel(new CustomDefaultPartyWageModel());
				}
			}
		}

		protected override void OnBeforeInitialModuleScreenSetAsRoot() {
			base.OnBeforeInitialModuleScreenSetAsRoot();

			string modName = base.GetType().Assembly.GetName().Name;

			Helper.SetModName(modName);
			Helper.settings = SettingsManager.Instance;
		}
    }
}
