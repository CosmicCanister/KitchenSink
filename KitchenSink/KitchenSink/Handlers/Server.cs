using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenSink.Handlers
{
    internal class Server
    {



        public void GameEnd(RoundEndedEventArgs ev)
        {
            Exiled.API.Features.Server.FriendlyFire = true;


        }
        public void GameStart()
        {
            Exiled.API.Features.Server.FriendlyFire = false;
           Map.Broadcast(6, $"If you are playing a custom role, hit ` to check your abilities, alt to use them, and double tap alt to switch abilities", Broadcast.BroadcastFlags.Normal, true);


        }


    }
}
