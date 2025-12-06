using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.CustomRoles.API.Features;
using MEC;
using PlayerRoles;
using Exiled.API.Enums;
using UnityEngine;
using System;

namespace KitchenSink.Abilities
{
    [CustomAbility]
    
    public class Teleportation : ActiveAbility
    {
        
        protected override void AbilityAdded(Player player)
        {
            SelectAbility(player);
            base.AbilityAdded(player);
        }


        public override float Duration { get; set; } = 1f;
        public override float Cooldown { get; set; } = 30f;
        public override string Name { get; set; } = "Teleportation";
        public override string Description { get; set; } = "Press alt to tp to a random area in the map";
        
        protected override void AbilityUsed(Player player)
        {
            player.Hurt(50f);

            player.RandomTeleport<Room>();
            base.AbilityUsed(player);

        }
    }



}
