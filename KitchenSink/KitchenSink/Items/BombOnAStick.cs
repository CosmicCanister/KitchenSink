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
    using Exiled.API.Features.Items;
    using Exiled.API.Features.Roles;


    [CustomItem(ItemType.Jailbird)]
    public class BombOnAStick : CustomItem
    {
        public override ItemType Type { get; set; } = ItemType.Jailbird;


        public override uint Id { get; set; } = 7;
        public override string Name { get; set; } = "Bomb on a Stick";
        public override string Description { get; set; } = "One hit goes boom";
        public override float Weight { get; set; } = 1.5f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1

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
           
            ev.Player.MaxHealth = 100000;
            ev.Player.Health = 100000;
            ExplosiveGrenade nofuse = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
            nofuse.FuseTime = 0.01F;
            nofuse.SpawnActive(ev.Player.Position);

            ev.Player.MaxHealth = 100;
            ev.Player.Health = 100;
            ev.Player.CurrentItem.Destroy();
        }
    }
}
