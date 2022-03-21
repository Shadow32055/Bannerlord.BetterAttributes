using System;
using System.IO;
using System.Xml;
using System.Text;
using TaleWorlds.Library;
using BetterAttributes.Utils;
using System.Xml.Serialization;
using MCM.Abstractions.Settings.Base.Global;

namespace BetterAttributes.Settings {
	public class SettingsManager {

		private static ISettings instance;
		private static readonly string path = BasePath.Name + "Modules/" + Helper.modName + "/config.xml";
		private static readonly FileInfo configFile = new FileInfo(path);

		//Debuging purposes only
		private static bool useMCM = true;

		public static ISettings Instance {
			get {
				if (useMCM) {
					try {
						ISettings modSettings = GlobalSettings<MCMSettings>.Instance;
						SettingsManager.instance = modSettings ?? SettingsManager.instance;
					} catch (Exception e) {
						Helper.DisplayWarningMsg("Error using MCM for " + Helper.modName);
						Helper.WriteToLog("MCM use error: " + e);
					}
				}

				if (SettingsManager.instance == null) {
					Helper.WriteToLog("No MCM.");

					XmlSerializer serial = new XmlSerializer(typeof(DefaultSettings));

					if (configFile.Exists) {
						try {

							using (StreamReader stream = configFile.OpenText()) {
								SettingsManager.instance = (serial.Deserialize(stream) as DefaultSettings);
							}

							Helper.WriteToLog("Using pre-existing config file.");

							return SettingsManager.instance;
						} catch (Exception e) {
							Helper.DisplayWarningMsg("Error loading " + Helper.modName + " config!");
							Helper.WriteToLog("Failed to load config because: " + e);
						}
					}

					// If instance is still null set default settings and attempt to create a config file.
					if (SettingsManager.instance == null) {
						SettingsManager.instance = new DefaultSettings();

						try {
							WriteXmlFile(serial, configFile, SettingsManager.Instance);
							Helper.DisplayWarningMsg("Generated new config file for " + Helper.modName + ". Please re-configure.");

						} catch (Exception e) {
							Helper.DisplayWarningMsg("Error writing " + Helper.modName + " config!");
							Helper.WriteToLog("Failed to write config because: " + e);
						}
					}
				}

				return SettingsManager.instance;
			}
		}

		public static void WriteXmlFile(XmlSerializer serial, FileInfo file, object o) {
			using (FileStream stream = file.Open(FileMode.Create)) {
				XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8) {
					Formatting = Formatting.Indented,
					Indentation = 4
				};
				serial.Serialize(writer, o);
			}
		}
	}
}
