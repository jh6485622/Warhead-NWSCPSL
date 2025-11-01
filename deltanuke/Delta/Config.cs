using System;
using System.ComponentModel;

namespace Delta
{
	public class Config
	{
		public bool IsEnabled { get; set; } = true;

		[Description("The time (in minutes) it takes for the warhead to activate.")]
		public float StartTime { get; set; } = 10f;

		[Description("The message that appears to all players when the warhead is activated.")]
		public string DeltaCassie { get; set; } = "By order of O5 command.Dead Man Delta sequence activated";

		[Description("GOC-Delta units could start Delta Nuke by Pressing Alpha Warhead ignition")]
		public bool GOCDelta { get; set; } = true;
	}
}
