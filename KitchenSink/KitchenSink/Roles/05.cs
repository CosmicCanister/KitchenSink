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
using Exiled.CustomRoles.API.Features.Interfaces;
using CustomPlayerEffects;

using Exiled.API.Features;
using KitchenSink.Abilities;

using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System.ComponentModel;
using PlayerEvent = Exiled.Events.Handlers.Player;


namespace KitchenSink.Roles
{
    [CustomRole(RoleTypeId.Scientist)]

    public class Council05 : CustomRole
    {

        public override RoleTypeId Role { get; set; } = RoleTypeId.Scientist;

        public override uint Id { get; set; } = 70;
        public override int MaxHealth { get; set; } = 150;
        public override string Name { get; set; } = "05 Council personnel";
        public override string Description { get; set; } = "Find guards to protect you, if you perish the site nuke activates";
        public override string CustomInfo { get; set; } = "05 Council";
        public override List<string> Inventory { get; set; } = new List<string>()
        {
            
            $"{ItemType.Adrenaline}",
            $"{ItemType.ArmorLight}",
            $"{ItemType.KeycardScientist}",
            $"{ItemType.GrenadeFlash}",
            $"{ItemType.ParticleDisruptor}",
            $"{ItemType.Medkit}",
        };

        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Ammo12Gauge, 22 }
        };

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            RoomSpawnPoints = new List<RoomSpawnPoint>
            {
             new RoomSpawnPoint()
             {

                Room = RoomType.EzCafeteria,
                Chance = 5,
                Offset = new Vector3(0,2,0),
             },







              },
        };



        protected override void SubscribeEvents()
        {
            PlayerEvent.Spawned += OnUsingItem;
            PlayerEvent.Died += OnDeath;

            base.SubscribeEvents();
        }


        /// <inheritdoc/>
        protected override void UnsubscribeEvents()
        {

            PlayerEvent.Spawned -= OnUsingItem;
            PlayerEvent.Died -= OnDeath;

            base.UnsubscribeEvents();
        }


        private void OnUsingItem(SpawnedEventArgs ev)
        {

            bool hasRole = false;
            CustomRole EscapeArtist = Roles.Council05.Get(Id);
            foreach (Player p in EscapeArtist.TrackedPlayers)
            {
                if (ev.Player.Nickname == p.Nickname)
                {
                    hasRole = true;
                }
            }

            if (hasRole == false)
                return;

            Cassie.Message($"Highly Important Personnel on site, if they die the site is set to self destruct");





        }

        private void OnDeath(DiedEventArgs ev)
        {
            bool hasRole = false;
            CustomRole EscapeArtist = Roles.Council05.Get(Id);
            foreach (Player p in EscapeArtist.TrackedPlayers)
            {
                if (ev.Player.Nickname == p.Nickname)
                {
                    hasRole = true;
                }
            }

            if (hasRole == false)
                return;
            Warhead.Start();





        }









    }
}
