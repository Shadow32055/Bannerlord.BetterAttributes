using BetterAttributes.Custom;
using BetterAttributes.Settings;
using BetterCore.Utils;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterAttributes {
    public class SubModule : MBSubModuleBase {

		public static MCMSettings _settings;
		protected override void OnSubModuleLoad() {
			base.OnSubModuleLoad();

			Harmony h = new("Bannerlord.Shadow.BetterAttributes");

            //*** Manual patching reference
            //MethodInfo original = typeof(Hero).GetProperty("AddSkillXp").GetGetMethod();
            //MethodInfo postfix = typeof(XPPatch).GetMethod("AddSkillXp");
            //h.Patch(original, postfix: new HarmonyMethod(postfix));

            h.PatchAll();
		}

		protected override void OnGameStart(Game game, IGameStarter gameStarter) {
			base.OnGameStart(game, gameStarter);

			if (game.GameType is Campaign) {
				CampaignGameStarter? campaignGameStarter = gameStarter as CampaignGameStarter;

				if (campaignGameStarter != null) {
					campaignGameStarter.AddModel(new CustomDefaultPartyWageModel());
				}
			}
		}

		protected override void OnBeforeInitialModuleScreenSetAsRoot() {
			base.OnBeforeInitialModuleScreenSetAsRoot();

			string modName = base.GetType().Assembly.GetName().Name;

			Helper.SetModName(modName);
			if (MCMSettings.Instance is not null) {
				_settings = MCMSettings.Instance;
			} else {
				Logger.SendMessage("Failed to find settings instance!", Severity.High);
			}
		}
    }
}
