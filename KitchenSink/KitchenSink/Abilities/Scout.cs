
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

    public class Scout : PassiveAbility
    {

        protected override void AbilityAdded(Player player)
        {
            if (player.CurrentArmor.Type == ItemType.ArmorLight)
            {
                player.IsUsingStamina = false;

            }
            if (player.CurrentArmor.Type == ItemType.None)
            {
                player.IsUsingStamina = false;

            }
        }



        public override string Name { get; set; } = "Scout's Speed";
        public override string Description { get; set; } = "Gives you speed if you're wearing light or no armor";
        protected override void AbilityRemoved(Player player)
        {
            player.IsUsingStamina = true;
        }


    }



}
