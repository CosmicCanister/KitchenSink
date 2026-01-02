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

    [CustomItem(ItemType.GunShotgun)]
    public class AutoShotgun : CustomWeapon
    {


        public override uint Id { get; set; } = 70;
        public override string Name { get; set; } = "Auto Shotgun";
        public override string Description { get; set; } = "Auto Shotgun";
        public override float Weight { get; set; } = 1.5f;

        public virtual bool FriendlyFire { get; set; } = false;

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.ChangedItem += disableEffect;
            Exiled.Events.Handlers.Player.ChangingItem += Onequipping;


            base.SubscribeEvents();
        }

        /// <inheritdoc/>
        protected override void UnsubscribeEvents()
        {

            Exiled.Events.Handlers.Player.ChangedItem -= disableEffect;
            Exiled.Events.Handlers.Player.ChangingItem -= Onequipping;


            base.UnsubscribeEvents();
        }


        private void Onequipping(ChangingItemEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;
            ev.Player.EnableEffect(EffectType.Scp1853, 100, -1, false );



        }
        private void disableEffect(ChangedItemEventArgs ev)
        {
            if (!Check(ev.OldItem))
                return;
            ev.Player.DisableEffect(EffectType.Scp1853);



        }
        public override byte ClipSize { get; set; } = 10;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 2,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 10,
                Location = SpawnLocationType.InsideIntercom,
            },

            new DynamicSpawnPoint()
            {
                Chance = 10,
                Location = SpawnLocationType.InsideLczArmory,
            },
            new DynamicSpawnPoint()
            {
                Chance = 5,
                Location = SpawnLocationType.InsideLczWc,
            },
            new DynamicSpawnPoint()
            {
                Chance = 10,
                Location = SpawnLocationType.Inside127Lab,
            },
           },
        };





    }
}
