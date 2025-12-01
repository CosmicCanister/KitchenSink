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
    using Exiled.CustomRoles.API.Features;

    [CustomItem(ItemType.SCP1344)]
    public class SCP035MASK : CustomItem
    {


        public override uint Id { get; set; } = 66;
        public override string Name { get; set; } = "Suspicious Mask";
        public override string Description { get; set; } = "Become an SCP";
        public override float Weight { get; set; } = 1.5f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 15,
                Location = SpawnLocationType.InsideHidLab,
            },
            new DynamicSpawnPoint()
            {
                Chance = 15,
                Location = SpawnLocationType.Inside049Armory,
            },
            new DynamicSpawnPoint()
            {
                Chance = 15,
                Location = SpawnLocationType.InsideLczWc,
            },
           },
        };




        protected override void SubscribeEvents()
        {


            Exiled.Events.Handlers.Player.UsedItem += UsingItem;
            base.SubscribeEvents();
        }

        /// <inheritdoc/>
        protected override void UnsubscribeEvents()
        {

            Exiled.Events.Handlers.Player.UsedItem -= UsingItem;

            base.UnsubscribeEvents();
        }
        private void UsingItem(UsedItemEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;


            ev.Item.Destroy();
            CustomRole SCP035MASK = Roles.SCP0081.Get(71);
            SCP035MASK.AddRole(ev.Player);


        }
    }
}
