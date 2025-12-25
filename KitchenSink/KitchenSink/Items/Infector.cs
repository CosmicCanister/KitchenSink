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


    [CustomItem(ItemType.GunLogicer)]
    public class Infector : CustomItem
    {


        public override uint Id { get; set; } = 69;
        public override string Name { get; set; } = "Infector";
        public override string Description { get; set; } = "Killing people has a chance to turn them into your team";
        public override float Weight { get; set; } = 1.5f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 10,
                Location = SpawnLocationType.InsideIntercom,
            },


           },
        };




        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Died += KillingOther;


            base.SubscribeEvents();
        }

        /// <inheritdoc/>
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Died -= KillingOther;



            base.UnsubscribeEvents();
        }


        private void KillingOther(DiedEventArgs ev)
        {
            if (!Check(ev.Attacker.CurrentItem))
                return;


            Random newRand = new Random();
            if(newRand.Next(0,101) < 16)
            {
                ev.Player.Role.Set(ev.Attacker.Role);
                ev.Player.Position = ev.Attacker.Position;
                
            }


        }
    }
}
