using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;

namespace KitchenSink.Abilities
{
    public class NuclearFailure : PassiveAbility
    {
        public override string Name { get; set; } = "NuclearFailure";
        public override string Description { get; set; } = "Your Death Starts the Nuke";



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
            Warhead.Start();
        }
    }
}