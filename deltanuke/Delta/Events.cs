using System;
using System.Collections.Generic;
using LabApi.Events.Arguments.WarheadEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Wrappers;
using MEC;
using PlayerRoles;

namespace Delta
{
	public class Events : CustomEventsHandler
	{
		public override void OnServerRoundStarted()
		{
			Plugin.DeltaCor = Timing.RunCoroutine(this.StartDelta());
		}

		public override void OnWarheadStarting(WarheadStartingEventArgs ev)
		{
			if (ev.IsAutomatic || ev.Player == null)
			{
				return;
			}
			foreach (Player item in Player.List)
			{
				if (ev.Player.Role == item.Role && item.Role == RoleTypeId.Tutorial && Plugin.Status.Config.GOCDelta)
				{
					Warhead.Stop(null);
					if (!ev.WarheadState.InProgress)
					{
						Delta.Start();
					}
					else
					{
						Delta.Stop();
					}
				}
			}
		}

		private IEnumerator<float> StartDelta()
		{
			yield return Timing.WaitForSeconds(1f);
			bool started = false;
			while (!started)
			{
				if (Round.Duration.TotalMinutes >= Plugin.Status.Config.StartTime)
				{
					Delta.Start();
					started = true;
				}
				yield return Timing.WaitForSeconds(1f);
			}
		}
	}
}
