using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.CustomRoles.API.Features;
using MEC;
using PlayerRoles;
using Exiled.API.Enums;
using UnityEngine;
using System.Collections.Generic;

namespace KitchenSink.Abilities
{
    [CustomAbility]
    public class Decaying : PassiveAbility
    {
        public override string Name { get; set; } = "Decay";
        public override string Description { get; set; } = "You are constantly dying";

        private CoroutineHandle decayCoroutine;

        protected override void AbilityAdded(Player player)
        {
            decayCoroutine = Timing.RunCoroutine(Decay(player));
        }

        protected override void AbilityRemoved(Player player)
        {
            Timing.KillCoroutines(decayCoroutine);
        }

        private IEnumerator<float> Decay(Player player)
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(15f);

                if (player == null || !player.IsAlive)
                    yield break;
                if(player.Health - 15 <= 0)
                {
                    player.Kill(DamageType.Bleeding);
                }
                player.Health -= 15;
            }
        }
    }
}