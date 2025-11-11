using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.CustomRoles;
using Exiled.CustomRoles.API.Features;

namespace KitchenSink.Handlers
{
    internal class Player
    {

        public void OnPlayCon(JoinedEventArgs ev)
        {
            Log.Info("but bug Left");
            bool isActive = KitchenSinkPlugin.Instance.Config.JoinLeave;
            if (isActive)
            {
                Map.Broadcast(6, $"{ev.Player.Nickname} has joined the server", Broadcast.BroadcastFlags.Normal, true);


                Log.Info("Player Joined");


            }



        }


        public void OnPlayerLeave(LeftEventArgs leftEventArgs)
        {
            Log.Info("but bug Left");
            bool isActive = KitchenSinkPlugin.Instance.Config.JoinLeave;
            if (isActive)
            {

                Map.Broadcast(6, $"{leftEventArgs.Player.Nickname} has left the server", Broadcast.BroadcastFlags.Normal, true);

                Log.Info("Player Left");
            }

        }


        public void OnPlayerSpawn(SpawnedEventArgs leftEventArgs)
        {
            bool isActive = KitchenSinkPlugin.Instance.Config.JoinLeave;
            if (Server.chanceForSCP008 > 0 )
            {
                if (leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp049 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp079 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp096 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp106 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp173 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp3114 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp939)
                {
                    CustomRole zombie = Roles.SCP0081.Get(65);
                    zombie.AddRole(leftEventArgs.Player);

                }

            }

        }




    }
}
