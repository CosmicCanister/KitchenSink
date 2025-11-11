using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;

namespace KitchenSink.Abilities
{
    public class Zombieinfect : PassiveAbility
    {
        public override string Name { get; set; } = "ZombieInfect";
        public override string Description { get; set; } = "Infects people";
        
        public RoleTypeId ConvertToRole { get; set; } = RoleTypeId.Scp0492;

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
                Timing.CallDelayed(0.5f, () =>
                {
                    CustomRole zombie = Roles.SCP0081.Get(65);
                    zombie.AddRole(ev.Player);
                    
                });
            }
        }
    }
}