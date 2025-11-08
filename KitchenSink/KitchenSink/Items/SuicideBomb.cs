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


    [CustomItem(ItemType.SCP1576)]
    public class SuicideBomb : CustomItem
    {

        public override ItemType Type { get; set; } = ItemType.SCP1576;

        public override uint Id { get; set; } = 2;
        public override string Name { get; set; } = "Vest Bomb";
        public override string Description { get; set; } = "Good Luck Soldier";
        public override float Weight { get; set; } = 1.5f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 2

        };




        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItem += OnUsingItem;
            base.SubscribeEvents();
        }

        /// <inheritdoc/>
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItem -= OnUsingItem;
            base.UnsubscribeEvents();
        }

        private void OnUsingItem(UsingItemEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;
            ev.Item.Destroy();
            ev.Player.PlaceBlood(ev.Player.Position);
            ev.Player.Explode(ProjectileType.FragGrenade,null);
        }
    }
}
