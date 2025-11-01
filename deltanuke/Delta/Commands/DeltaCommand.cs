using System;
using System.Linq;
using CommandSystem;
using InventorySystem.Items;
using InventorySystem.Items.Usables.Scp330;
using LabApi.Features.Wrappers;
using PlayerRoles;

namespace Delta.Commands
{
	// Token: 0x02000006 RID: 6
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class DeltaCommand : ICommand
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000022A1 File Offset: 0x000004A1
		public string Command
		{
			get
			{
				return "groupattackhelp";
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000022A8 File Offset: 0x000004A8
		public string[] Aliases
		{
			get
			{
				return new string[]
				{
					"HELP"
				};
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000022B8 File Offset: 0x000004B8
		public string Description
		{
			get
			{
				return "支援";
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000022C0 File Offset: 0x000004C0
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			Player player = Player.Get((sender as CommandSender).SenderId);
			bool result;
			if (player == null)
			{
				response = "失败";
				result = false;
			}
			else if (arguments.Count < 1)
			{
				response = "参数不足";
				result = false;
			}
			else
			{
				if (arguments.ElementAt(0) == "Delta")
				{
					Delta.Stop();
					Cassie.Message("GOC Summoned Delta attack force was attacking the site!", false, true, true, "");
					foreach (Player item in Player.List)
					{
						if (player.Role == RoleTypeId.Tutorial && (item.Role == RoleTypeId.Spectator || item.Role == RoleTypeId.FacilityGuard))
						{
							item.SetRole(RoleTypeId.Tutorial, RoleChangeReason.RemoteAdmin, RoleSpawnFlags.All);
							item.MaxArtificialHealth = 10000f;
							item.MaxHealth = 300f;
							item.Health = 300f;
							item.ClearInventory(true, true);
							item.AddItem(ItemType.KeycardO5, ItemAddReason.AdminCommand);
							item.AddItem(ItemType.SCP500, ItemAddReason.AdminCommand);
							item.AddItem(ItemType.SCP500, ItemAddReason.AdminCommand);
							item.AddItem(ItemType.ArmorHeavy, ItemAddReason.AdminCommand);
							item.AddItem(ItemType.SCP1344, ItemAddReason.AdminCommand);
							item.AddItem(ItemType.Jailbird, ItemAddReason.AdminCommand);
							item.AddItem(ItemType.SCP018, ItemAddReason.AdminCommand);
							item.GiveCandy(CandyKindID.Blue, ItemAddReason.AdminCommand);
							item.GiveCandy(CandyKindID.Rainbow, ItemAddReason.AdminCommand);
							item.MaxArtificialHealth = 250f;
							item.MaxHealth = 250f;
							item.CreateAhpProcess(item.MaxArtificialHealth, 500f, 0f, -1f, -1f, true);
						}
					}
				}
				response = "成功";
				result = true;
			}
			return result;
		}
	}
}
