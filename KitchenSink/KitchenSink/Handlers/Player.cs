using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
