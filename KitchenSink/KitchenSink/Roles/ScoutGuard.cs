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
    [CustomRole(RoleTypeId.FacilityGuard)]

    public class ClassGuard : CustomRole
    {

        public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;
        public override Vector3 Scale { get; set; } = new Vector3(1, 1f, 0.8f);
        public override float SpawnChance { get; set; } = 25f;
        public override uint Id { get; set; } = 66;
        public override int MaxHealth { get; set; } = 90;
        public override string Name { get; set; } = "Scout Guard";
        public override string Description { get; set; } = "Recon focused Guard, you have infinite stamina when wearing light armor";
        public override string CustomInfo { get; set; } = "Facility Guard Fast";
        public override List<string> Inventory { get; set; } = new List<string>()
        {
            $"{ItemType.KeycardGuard}",
            $"{ItemType.ArmorLight}",
            $"{ItemType.GunRevolver}",
            $"{ItemType.Radio}",


        };

        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Ammo44Cal, 18 }
        };

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            RoomSpawnPoints = new List<RoomSpawnPoint>
            {
             new RoomSpawnPoint()
             {

                Room = RoomType.EzCheckpointHallwayA,
                Chance = 50,
                Offset = new Vector3(0,2,0),
             },







              },
        };











        public override List<CustomAbility> CustomAbilities { get; set; } = new List<CustomAbility>()
        {
            new Scout()
            {
                Name = "Scout's Speed",
                Description = "Inf Stamina when using light or less armor",
            },
        };




    }
}
