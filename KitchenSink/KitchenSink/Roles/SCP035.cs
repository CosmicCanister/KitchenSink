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
namespace KitchenSink.Items
{
    [CustomRole(RoleTypeId.Scp049)]

    public class SCP035 : CustomRole
    {
        public override uint Id { get; set; } = 71;
        public override int MaxHealth { get; set; } = 500;
        public override bool KeepInventoryOnSpawn { get; set; } = true;
        public RoleTypeId VisibleRole { get; set; } = RoleTypeId.Scp049;
        public override RoleTypeId Role { get; set; } = RoleTypeId.Tutorial;
        public override string Name { get; set; } = "Scp 035";

        public override string Description { get; set; } = "Help the scps, kill all humans, Keep Healing";

        public override string CustomInfo { get; set; } = "Human SCP";
        public override float SpawnChance { get; set; } = 0;
        public override bool RemovalKillsPlayer { get; set; } = true;

        public override bool IgnoreSpawnSystem { get; set; } = false;


        public override List<CustomAbility> CustomAbilities { get; set; } = new List<CustomAbility>()
        {
            new Decaying()
            {
                Name = "Decaying",
                Description = "You are decaying, find HP",
            },

        };
    }
}
