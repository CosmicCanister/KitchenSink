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


    [CustomItem(ItemType.GrenadeHE)]
    public class StimNade : CustomGrenade
    {


        public override uint Id { get; set; } = 10;
        public override string Name { get; set; } = "StimNade";
        public override string Description { get; set; } = "Everyone hit by it will be given the effects of a stim";
        public override float Weight { get; set; } = 1.5f;
        public override bool ExplodeOnCollision { get; set; } = true;
        public override float FuseTime { get; set; } = 2f;

        protected override void OnExploding(ExplodingGrenadeEventArgs ev)
        {
            ev.IsAllowed = false;

            foreach(Player p in ev.TargetsToAffect)
            {
                p.EnableEffect(EffectType.Scp207, 6f);

            }
        }


        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 2,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 20,
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
