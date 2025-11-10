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
        public static Random rand { get; set; } = new Random();
        public static int chanceForSCP008 { get; set; } = rand.Next(0, 101);



        public void GameEnd(RoundEndedEventArgs ev)
        {
            Exiled.API.Features.Server.FriendlyFire = true;

            chanceForSCP008 = 0;
        }
        public void GameStart()
        {
            Log.Info("Chance for Zombies " + Server.chanceForSCP008);
            chanceForSCP008 = rand.Next(0, 101);
            Exiled.API.Features.Server.FriendlyFire = false;
            Map.Broadcast(6, $"If you are playing a custom role, hit ` to check your abilities, alt to use them, and double tap alt to switch abilities", Broadcast.BroadcastFlags.Normal, true);







        }

    }
}

