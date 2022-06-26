using HarmonyLib;
using BetterAttributes.Utils;
using BetterAttributes.Settings;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using BetterAttributes.Patches;
using BetterAttributes.Custom;

namespace BetterAttributes {
	public class SubModule : MBSubModuleBase {

		protected override void OnSubModuleLoad() {
			base.OnSubModuleLoad();
			
			new Harmony("Bannerlord.Shadow.BetterAttributes").PatchAll();
		}

		protected override void OnGameStart(Game game, IGameStarter gameStarter) {
			base.OnGameStart(game, gameStarter);

			//new Harmony("Bannerlord.Shadow.BetterAttributes").PatchAll();
			//Helper.DisplayFriendlyMsg("Game Start");
			if (game.GameType is Campaign) {
				CampaignGameStarter campaignGameStarter = gameStarter as CampaignGameStarter;

				if (campaignGameStarter != null) {
					campaignGameStarter.AddModel(new CustomDefaultPartyWageModel());
					campaignGameStarter.AddModel(new CustomDefaultCharacterDevelopmentModel());

					//ig.AddModel(new CustomDefaultCharacterDevelopmentModel());
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
