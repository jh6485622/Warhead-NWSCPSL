using System;
using GameCore;
using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using MEC;
using UnityEngine;

namespace Delta
{
	public class Plugin : Plugin<Config>
	{
		public override string Name
		{
			get
			{
				return "Delta Warhead";
			}
		}

		public override string Description
		{
			get
			{
				return "Delta Warhead";
			}
		}

		public override string Author
		{
			get
			{
				return "JH Blur";
			}
		}

		public override System.Version Version
		{
			get
			{
				return new System.Version(1, 0);
			}
		}

		public override System.Version RequiredApiVersion
		{
			get
			{
				return new System.Version(LabApiProperties.CompiledVersion);
			}
		}

		public override void Enable()
		{
			CustomHandlersManager.RegisterEventsHandler<Events>(this._events);
			GameCore.Console.AddLog(this.Name + "Plugin Started", Color.blue, false, GameCore.Console.ConsoleLogType.Log);
			Plugin.Status = this;
		}

		public override void Disable()
		{
			CustomHandlersManager.UnregisterEventsHandler<Events>(this._events);
		}

		private readonly Events _events = new Events();

		public static CoroutineHandle DeltaCor;

		public static Plugin Status;

    }
}
