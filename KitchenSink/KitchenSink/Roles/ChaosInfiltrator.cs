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


namespace KitchenSink.Roles
{
    [CustomRole(RoleTypeId.ChaosRifleman)]

    public class ChaosInfiltrator : CustomRole
    {

        public override RoleTypeId Role { get; set; } = RoleTypeId.ChaosRifleman;

        public override uint Id { get; set; } = 68;
        public override int MaxHealth { get; set; } = 100;
        public override string Name { get; set; } = "Chaos Infiltrator";
        public override string Description { get; set; } = "Fight off the Security Guards, secure civilian personnel";
        public override string CustomInfo { get; set; } = "Chaos Infiltrator";
        public override List<string> Inventory { get; set; } = new List<string>()
        {
            $"{ItemType.Adrenaline}",
            $"{ItemType.ArmorLight}",
            $"{ItemType.KeycardGuard}",
            $"{ItemType.GrenadeFlash}",
            $"{ItemType.GunShotgun}",
            $"{ItemType.Medkit}",
        };

        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Ammo12Gauge, 22 }
        };

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            RoomSpawnPoints = new List<RoomSpawnPoint>
            {
             new RoomSpawnPoint()
             {

                Room = RoomType.EzCafeteria,
                Chance = 5,
                Offset = new Vector3(0,2,0),
             },







              },
        };















    }
}
