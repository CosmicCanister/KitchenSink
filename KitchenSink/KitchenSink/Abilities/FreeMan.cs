using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.CustomRoles.API.Features;
using MEC;
using PlayerRoles;
using Exiled.API.Enums;
using UnityEngine;
using Exiled.CustomItems.API.Features;

namespace KitchenSink.Abilities
{
    [CustomAbility]

    public class FreeMan : PassiveAbility
    {

        protected override void AbilityAdded(Player player)
        {
            Timing.CallDelayed(0.5f, () =>
            {

                CustomKeycard newcard = (CustomKeycard)CustomItem.Get(67);
                newcard.Give(player);
            });


        }



        public override string Name { get; set; } = "Freeman";
        public override string Description { get; set; } = "Gives you Freeman's card";
        protected override void AbilityRemoved(Player player)
        {
            
        }


    }



}
