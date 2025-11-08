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
using UnityEngine;

namespace KitchenSink.Items
{
   
    [CustomItem(ItemType.KeycardCustomTaskForce)]
    public class NukeCard : CustomKeycard
    {
        
        public override uint Id { get; set; } = 5;
        public override byte Rank { get; set; } = 32;
        public override string Name { get; set; } = "NukeCard";
        public override string Description { get; set; } = "KeyCard Only Used to Activate the Nuke";
        public override float Weight { get; set; } = 0.5f;
        public override string KeycardLabel { get; set; } = "Nuke card";
        public override ItemType Type { get; set; } = ItemType.KeycardCustomTaskForce;

        public KeycardPermissions keycardPermissions { get; set; } = KeycardPermissions.AlphaWarhead;

        public override Color32? KeycardLabelColor { get; set; } = Color.red;

        public override SpawnProperties SpawnProperties { get; set; } =
        new SpawnProperties()
        {
            Limit = 1,
           DynamicSpawnPoints = new List<DynamicSpawnPoint>
           {
            new DynamicSpawnPoint()
            {
                Chance = 100,
                Location = SpawnLocationType.Inside330,
            },
      
           }, 

        };


        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.InteractingDoor += OnUsingItem;

            base.SubscribeEvents();
        }


        /// <inheritdoc/>
        protected override void UnsubscribeEvents()
        {

            Exiled.Events.Handlers.Player.InteractingDoor -= OnUsingItem;

            base.UnsubscribeEvents();
        }


        private void OnUsingItem(InteractingDoorEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;
            if (ev.Door.DoorLockType == DoorLockType.Warhead)
            {
                ev.Door.IsOpen = true;
            }


        }
    }
}
