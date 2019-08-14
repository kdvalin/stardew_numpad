using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace numpad_hotbar
{
	public class ModEntry : Mod
	{
		public override void Entry(IModHelper helper)
		{
			helper.Events.Input.ButtonPressed += this.OnButtonPressed;
		}


		/*********
        ** Private methods
        *********/
		/// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event data.</param>
		private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
		{			
			// ignore if player hasn't loaded a save yet
			if (!Context.IsWorldReady)
				return;
			//Array of triggers, in order of where the tool index goes
			SButton[] triggers = {SButton.NumPad1, SButton.NumPad2, SButton.NumPad3, SButton.NumPad4, SButton.NumPad5, 
				SButton.NumPad6, SButton.NumPad7, SButton.NumPad8, SButton.NumPad9, SButton.NumPad0, SButton.Subtract, SButton.Add};

			for (int i = 0; i < triggers.Length; ++i) {
				if (e.Button == triggers [i]) {
					Game1.player.CurrentToolIndex = i;
					return;
				}
			}
		}
	}
}