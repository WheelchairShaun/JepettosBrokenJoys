using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;
using System;
using System.Windows.Controls;

namespace JepettosBrokenJoys
{
	public class JepettoPlugin : IPlugin
	{
		public string Name => "Jepetto's Broken Joys";

		public string Description => "A plug-in that tracks minions played and will be copied by Joymancer Jepetto";

		public string ButtonText => "No Options";

		public string Author => "WheelchairShaun";

		public Version Version => new Version(0, 3, 6);

		public MenuItem MenuItem => null;

		private BrokenJoys _plugin;

		public void OnButtonPress()
		{
			// Triggered when the user clicks your button in the plugin list

		}

		// Triggered upon startup and when the user ticks the plugin on
		public void OnLoad()
		{
			_plugin = new BrokenJoys();

			GameEvents.OnGameStart.Add(_plugin.OnGameStart);
			GameEvents.OnGameEnd.Add(_plugin.OnGameEnd);
			GameEvents.OnPlayerPlay.Add(_plugin.OnPlayerPlay);
			GameEvents.OnPlayerHandMouseOver.Add(_plugin.OnPlayerHandMouseOver);
			GameEvents.OnMouseOverOff.Add(_plugin.OnMouseOverOff);
		}

		public void OnUnload()
		{
			// Triggered when the user unticks the plugin, however, HDT does not completely unload the plugin.
			// see https://git.io/vxEcH
			_plugin.Dispose();
		}

		public void OnUpdate()
		{
			// called every ~100ms
		}

	}
}