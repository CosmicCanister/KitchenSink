using Exiled.API.Features.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using UnityEngine;
using Exiled.CustomRoles.API.Features.Interfaces;
using CustomPlayerEffects;

using Exiled.API.Features;
using KitchenSink.Abilities;

using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System.ComponentModel;
using PlayerEvent = Exiled.Events.Handlers.Player;
using KitchenSink.Items;


namespace KitchenSink.Roles
{
	[CustomRole(RoleTypeId.ChaosConscript)]

	public class JuggerNaught : CustomRole
	{

		public override RoleTypeId Role { get; set; } = RoleTypeId.ChaosConscript;
		public override uint Id { get; set; } = 72;
		public override int MaxHealth { get; set; } = 1500;
		public override string Name { get; set; } = "JuggerNaught";

		public override float SpawnChance { get; set; } = 0f;

		public override string Description { get; set; } = "Kill them";
		public override string CustomInfo { get; set; } = "Jug";
		public override List<string> Inventory { get; set; } = new List<string>()
		{



		};

		public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
		{
		};

		public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
		{

		};
		public override List<CustomAbility> CustomAbilities { get; set; } = new List<CustomAbility>()
		{

		};














	}
}
