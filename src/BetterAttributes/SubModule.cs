using HarmonyLib;
using BetterAttributes.Utils;
using BetterAttributes.Settings;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Core;
using TaleWorlds.CampaignSystem;

namespace BetterAttributes {
	public class SubModule : MBSubModuleBase {

		protected override void OnSubModuleLoad() {
			base.OnSubModuleLoad();

			//new Harmony("Bannerlord.Shadow.BetterAttributes").PatchAll();
		}

		protected override void OnGameStart(Game g, IGameStarter ig) {
			base.OnGameStart(g, ig);
			new Harmony("Bannerlord.Shadow.BetterAttributes").PatchAll();

			if (g.GameType is Campaign) {
				//ig.AddModel(new CustomDefaultCharacterDevelopmentModel());
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
