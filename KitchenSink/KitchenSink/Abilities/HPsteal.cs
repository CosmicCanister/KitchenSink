using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;

namespace KitchenSink.Abilities
{
    public class HPsteal : PassiveAbility
    {
        public override string Name { get; set; } = "LifeSteal";
        public override string Description { get; set; } = "Kills give hp";

       

        protected override void AbilityAdded(Player player)
        {
            Exiled.Events.Handlers.Player.Dying += OnDying;
        }

        protected override void AbilityRemoved(Player player)
        {
            Exiled.Events.Handlers.Player.Dying -= OnDying;
        }

        private void OnDying(DyingEventArgs ev)
        {
            if (ev.Attacker == null || ev.Player == null)
                return;
            if (Check(ev.Attacker))
            {
                ev.Attacker.Heal(50);

            }
        }
    }
}