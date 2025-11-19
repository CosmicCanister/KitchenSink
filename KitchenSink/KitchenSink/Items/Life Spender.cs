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


    [CustomItem(ItemType.GunRevolver)]
    public class LifeSpender : CustomItem
    {


        public override uint Id { get; set; } = 10;
        public override string Name { get; set; } = "Life Spender";
        public override string Description { get; set; } = "Kill's you instantly when hitting an enemy, but does tons of damage";
        public override float Weight { get; set; } = 1.5f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 25,
                Location = SpawnLocationType.InsideHidLab,
            },


           },
        };




        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Hurting += OnHitting;
            Exiled.Events.Handlers.Player.Shooting -= OnUsingItem;


            base.SubscribeEvents();
        }

        /// <inheritdoc/>
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Hurting -= OnHitting;
            Exiled.Events.Handlers.Player.Shooting -= OnUsingItem;


            base.UnsubscribeEvents();
        }

        private void OnUsingItem(ShootingEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;
            ev.Player.ClearItems();



        }
        private void OnHitting(HurtingEventArgs ev)
        {

            if (!Check(ev.Attacker.CurrentItem))
                return;
            ev.Attacker.ClearItems();
            ev.Attacker.Vaporize();
            ev.Attacker.Kill(DamageType.Explosion);
            ev.Player.Hurt(1000f, DamageType.Unknown);
        }
    }
}
