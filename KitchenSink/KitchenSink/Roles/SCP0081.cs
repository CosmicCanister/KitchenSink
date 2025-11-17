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
using PlayerRoles;
using Exiled.API.Features;
using KitchenSink.Abilities;

using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System.ComponentModel;
using PlayerEvent = Exiled.Events.Handlers.Player;


namespace KitchenSink.Roles
{
    [CustomRole(RoleTypeId.Scp0492)]

    public class SCP0081 : CustomRole
    {

        public override RoleTypeId Role { get; set; } = RoleTypeId.Scp0492;

        public override uint Id { get; set; } = 65;
        public override int MaxHealth { get; set; } = 500;
        public override string Name { get; set; } = "SCP008-1";
        public override string Description { get; set; } = "Infectious Zombie";
        public override string CustomInfo { get; set; } = "Infectious Zombie";




        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 0,
            RoomSpawnPoints = new List<RoomSpawnPoint>
            {
             new RoomSpawnPoint()
             {

                Room = RoomType.EzCheckpointHallwayA,
                Chance = 0,
                Offset = new Vector3(0,2,0),
             },







              },
        };











        public override List<CustomAbility> CustomAbilities { get; set; } = new List<CustomAbility>()
        {
            new Charge()
            {
                Name = "Charge",
                Description = "Inf Stamina",
            },
            new Zombieinfect()
            {
                Name = "Zombie Infect",
                Description = "Infection",
            }
        };




    }
}
