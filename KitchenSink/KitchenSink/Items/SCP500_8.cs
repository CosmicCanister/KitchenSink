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


    [CustomItem(ItemType.SCP500)]
    public class SCP500_8 : CustomItem
    {


        public override uint Id { get; set; } = 9;
        public override string Name { get; set; } = "SCP500-8";
        public override string Description { get; set; } = "Increases your max hp";
        public override float Weight { get; set; } = 1.5f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 2,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 100,
                Location = SpawnLocationType.Inside330,
            },
            new DynamicSpawnPoint()
            {
                Chance = 100,
                Location = SpawnLocationType.Inside079Armory,
            },

           },
        };




        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItemCompleted += OnUsingItem;
            base.SubscribeEvents();
        }

        /// <inheritdoc/>
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItemCompleted -= OnUsingItem;
         
            base.UnsubscribeEvents();
        }

        private void OnUsingItem(UsingItemCompletedEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;
          
            ev.Player.MaxHealth +=  65;
        }

    }
}
