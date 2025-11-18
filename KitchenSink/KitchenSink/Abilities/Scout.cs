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
            player.EnableEffect(EffectType.Scp207, -1f);
        }



        public override string Name { get; set; } = "Test Subject";
        public override string Description { get; set; } = "Has a constant speed boost, but there are drawbacks";
        protected override void AbilityRemoved(Player player)
        {
            player.DisableEffect(EffectType.Scp207);
        }


    }



}
