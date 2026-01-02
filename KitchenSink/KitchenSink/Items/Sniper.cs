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

namespace KitchenSink.Items
{
    using Exiled.API.Features;
    using Exiled.API.Features.Roles;
    using InventorySystem.Items.Firearms.Attachments;

    [CustomItem(ItemType.GunE11SR)]
    public class Sniper : CustomWeapon
    {

        public override float Damage { get; set; } = 1200;

        public override uint Id { get; set; } = 69;
        public override string Name { get; set; } = "Sniper";
        public override string Description { get; set; } = "One shot, one kill";
        public override float Weight { get; set; } = 1.5f;

        public virtual bool FriendlyFire { get; set; }


        public override byte ClipSize { get; set; } = 1;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 3,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 40,
                Location = SpawnLocationType.InsideIntercom,
            },

            new DynamicSpawnPoint()
            {
                Chance = 40,
                Location = SpawnLocationType.InsideLczArmory,
            },
            new DynamicSpawnPoint()
            {
                Chance = 5,
                Location = SpawnLocationType.InsideLczWc,
            },
            new DynamicSpawnPoint()
            {
                Chance = 40,
                Location = SpawnLocationType.Inside127Lab,
            },
           },
        };

        public override AttachmentName[] Attachments { get; set; } = new[]
        {
        AttachmentName.ExtendedBarrel,
        AttachmentName.ScopeSight,
         };



    }
}
