using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.CustomRoles.API.Features;
using MEC;
using PlayerRoles;
using Exiled.API.Enums;
using UnityEngine;
namespace KitchenSink.Abilities
{
    [CustomAbility]

    public class Decaying : PassiveAbility
    {
        public override string Name { get; set; } = "Decay";
        public override string Description { get; set; } = "You are constantly dying";
        public int IsActive { get; set; } = 1;



        protected override void AbilityAdded(Player player)
        {
            while (IsActive == 1)
            {
                Timing.CallDelayed(5f, () =>
                {
                    player.Health -= 10;

                });


            }

        }

        protected override void AbilityRemoved(Player player)
        {
            IsActive = 0;
            
        }
    }
}
