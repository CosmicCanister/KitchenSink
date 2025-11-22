using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp079;
using Exiled.Events.Handlers;
using Interactables.Interobjects.DoorUtils;
using InventorySystem.Items.Firearms.Attachments;
using JetBrains.Annotations;
using MEC;
using UnityEngine;
using YamlDotNet.Serialization;
using Attachment = InventorySystem.Items.Firearms.Attachments.Components.Attachment;
using PlayerAPI = Exiled.API.Features.Player;
using PlayerEvent = Exiled.Events.Handlers.Player;

namespace KitchenSink.Items
{
    using Exiled.API.Features;
    using Exiled.API.Features.Roles;


    [CustomItem(ItemType.GrenadeFlash)]
    public class MakeExplodeNade : CustomGrenade
    {


        public override uint Id { get; set; } = 11;
        public override string Name { get; set; } = "MakePeopleExplode";
        public override string Description { get; set; } = "Makes people explode, its delayed by a couple seconds";
        public override float Weight { get; set; } = 1.5f;
        public override bool ExplodeOnCollision { get; set; } = true;
        public override float FuseTime { get; set; } = 2f;

        protected override void OnExploding(ExplodingGrenadeEventArgs ev)
        {
           
            
            foreach (Player p in ev.TargetsToAffect)
            {
                Timing.CallDelayed(10f, () =>
                {
                    p.Explode();
                });


            }
        }


        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 2,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 25,
                Location = SpawnLocationType.InsideLczArmory,
            },
            new DynamicSpawnPoint()
            {
                Chance = 20,
                Location = SpawnLocationType.InsideHczArmory,
            },

           },
        };



    }
}
