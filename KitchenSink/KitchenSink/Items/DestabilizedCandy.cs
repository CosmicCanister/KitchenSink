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
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.CustomRoles.API.Features;
namespace KitchenSink.Items
{
    using Exiled.API.Features;
    using Exiled.API.Features.Roles;


    [CustomItem(ItemType.Painkillers)]
    public class DestabilizedCandy : CustomItem
    {


        public override uint Id { get; set; } = 68;
        public override string Name { get; set; } = "Destabalized Candy";
        public override string Description { get; set; } = "Unstable new candy prototype that gives you tha ability to teleport when hitting alt";
        public override float Weight { get; set; } = 1.5f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 0,

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
            CustomAbility teleport = CustomAbility.Get("Teleportation");
            teleport.AddAbility(ev.Player);
        }

    }
}
