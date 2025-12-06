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
    [CustomRole(RoleTypeId.ClassD)]

    public class ClassDTank : CustomRole
    {

        public override RoleTypeId Role { get; set; } = RoleTypeId.ClassD;
        public override float SpawnChance { get; set; } = 25f;
        public override uint Id { get; set; } = 67;
        public override int MaxHealth { get; set; } = 200;
        public override string Name { get; set; } = "Class D Tank";
        public override string Description { get; set; } = "Stronger Class D, hit alt to use your sprint ability";
        public override string CustomInfo { get; set; } = "D Class Strong";
        public override List<string> Inventory { get; set; } = new List<string>()
        {
            $"{ItemType.Adrenaline}",
            $"{ItemType.ArmorLight}",
            $"{ItemType.KeycardZoneManager}",
            $"{ItemType.GrenadeFlash}",
        };


        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 2,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
             new DynamicSpawnPoint()
             {

                Location = SpawnLocationType.InsideLczCafe,
                Chance = 50,
             },





             new DynamicSpawnPoint()
             {

                Location = SpawnLocationType.InsideLczWc,
                Chance = 50,
             }

              },
        };











        public override List<CustomAbility> CustomAbilities { get; set; } = new List<CustomAbility>()
        {
            new Charge()
            {
                Name = "Charge",
                Description = "Gain A Quick Burst Of Speed",
            },
        };




    }
}
