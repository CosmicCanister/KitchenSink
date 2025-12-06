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
	[CustomRole(RoleTypeId.Scientist)]

	public class GordonFreeman : CustomRole
	{

		public override RoleTypeId Role { get; set; } = RoleTypeId.Scientist;
		CustomKeycard newcard = FreemansCard.(67);
		public override uint Id { get; set; } = 4;
		public override int MaxHealth { get; set; } = 125;
		public override string Name { get; set; } = "Gordon Freeman";
		public override string Description { get; set; } = "Oh my God... we're doomed!";
		public override string CustomInfo { get; set; } = "Gordon Freeman";
		public override List<string> Inventory { get; set; } = new List<string>()
		{
			$"{ItemType.Radio}",
			$"{ItemType.ArmorLight}",
			$"{ItemType.Lantern}",
			$"{ItemType.SCP500}",
			$"{ItemType.Medkit}",
			$"{ItemType.}",
		};

		public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
		{
			{ AmmoType.Ammo12Gauge, 0}
		};

		public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
		{
			Limit = 1,
			RoomSpawnPoints = new List<RoomSpawnPoint>
			{
			 new RoomSpawnPoint()
			 {

				Room = RoomType.LczToilets,
				Chance = 15,
				Offset = new Vector3(0,2,0),
			 },







			  },
		};
		public override List<CustomAbility> CustomAbilities { get; set; } = new List<CustomAbility>()
		{
			new TestSubject()
			{
				Name = "Test Subject",
				Description = "Gives effects of SCP-207 For the durration of the round",
			},
		};













		
	}
}
