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
    [CustomItem(ItemType.Jailbird)]
    public class EyeLander : CustomItem
    {
        public override uint Id { get; set; } = 3;
        public override string Name { get; set; } = "EyeLander";
        public override string Description { get; set; } = "Weapon that makes you stronger when you get more kills";
        public override float Weight { get; set; } = 0.5f;
        public  EffectType effect = EffectType.Vitality;
        public int baseMaxHP;

        

            // Optionally sync with the client
        
        public static int Kills { get; set; } = 1;
        public override SpawnProperties SpawnProperties { get; set; } =
        new SpawnProperties()
        {
            Limit = 1,
           DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 100,
                Location = SpawnLocationType.InsideHidLab,
            },
            new DynamicSpawnPoint()
            {
                Chance = 100,
                Location = SpawnLocationType.InsideLczArmory,
            },

           },


        };
        

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Hurting += OnUsingItem;
            Exiled.Events.Handlers.Player.Died += KillingOther;

            Exiled.Events.Handlers.Player.PickingUpItem += PickingUpItem;
            Exiled.Events.Handlers.Player.DroppingItem += removeShield;
            Exiled.Events.Handlers.Player.ChangedItem += addShield;
            base.SubscribeEvents();
        }

        /// <inheritdoc/>
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Died -= KillingOther;

            Exiled.Events.Handlers.Player.Hurting -= OnUsingItem;
            Exiled.Events.Handlers.Player.ChangedItem -= addShield;
            Exiled.Events.Handlers.Player.PickingUpItem -= PickingUpItem;
            Exiled.Events.Handlers.Player.DroppingItem -= removeShield;
            base.UnsubscribeEvents();
        }
        private void PickingUpItem(PickingUpItemEventArgs ev)
        {

            if (!Check(ev.Pickup))
            {

                return;
            }

            Log.Info("Eyelander equuiped");
            baseMaxHP = (int)ev.Player.MaxHealth;


            ev.Player.MaxHealth += 50f + 25 * Kills;
        }
        private void OnUsingItem(HurtingEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;

            ev.Amount += 75 + Kills * 10;
           


        }

        private void KillingOther(DiedEventArgs ev)
        {
            if (!Check(ev.Attacker.CurrentItem))
                return;
            Kills += 1;
            Log.Info("Player killed");

            ev.Attacker.MaxHealth += 25 * Kills;
            ev.Player.Stamina += 100;
           
            ev.Attacker.Heal(25);


        }
        private void addShield(ChangedItemEventArgs ev)
        {
            


            
        
            

            //50f + 25 * Kills, 0f


        }










        private void removeShield(DroppingItemEventArgs ev)
        {
            if (!Check(ev.Item))
            {
                return;

            }

            Log.Info("Player dropped");

           // ev.Player.MaxHealth = 100;
            ev.Player.MaxHealth -= 50f + 25 * Kills;
        }


    }


}
