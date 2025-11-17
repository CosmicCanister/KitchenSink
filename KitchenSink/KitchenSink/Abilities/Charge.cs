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

    public class Charge : ActiveAbility
    {

        protected override void AbilityAdded(Player player)
        {
            SelectAbility(player);
            base.AbilityAdded(player);
        }


        public override float Duration { get; set; } = 6f;
        public override float Cooldown { get; set; } = 30f;
        public override string Name { get; set; } = "Charge";
        public override string Description { get; set; } = "Gives you unlimited stamina for a short time";
        protected override void AbilityUsed(Player player)
        {
            player.EnableEffect(EffectType.Scp207, 6f);
            base.AbilityUsed(player);

        }
    }



}
