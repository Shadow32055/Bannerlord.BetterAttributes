using HarmonyLib;
using BetterAttributes.Utils;
using BetterAttributes.Settings;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes {
	public class SubModule : MBSubModuleBase {

		protected override void OnSubModuleLoad() {
			base.OnSubModuleLoad();
			
			new Harmony("Bannerlord.Shadow.BetterAttributes").PatchAll();
		}

		/*protected override void OnGameStart(Game g, IGameStarter ig) {
			base.OnGameStart(g, ig);
			//new Harmony("Bannerlord.Shadow.BetterAttributes").PatchAll();
			Helper.DisplayFriendlyMsg("Game Start");
			if (g.GameType is Campaign) {
				//ig.AddModel(new CustomDefaultCharacterDevelopmentModel());
			}
		}*/

		protected override void OnBeforeInitialModuleScreenSetAsRoot() {
			base.OnBeforeInitialModuleScreenSetAsRoot();

			string modName = base.GetType().Assembly.GetName().Name;

			Helper.SetModName(modName);
			Helper.settings = SettingsManager.Instance;
		}

		/*public override void OnGameEnd(Game g) {
		  	Helper.DisplayFriendlyMsg("Game End");
			var original = typeof(DefaultCharacterStatsModel).GetMethod("MaxHitpoints");

			//new Harmony("Bannerlord.Shadow.BetterAttributes").Unpatch(original, HarmonyPatchType.Postfix);
		}*/
	}
}
