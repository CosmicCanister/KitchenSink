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
        public static bool ZombieRound { get; set; } = false;


        public void GameEnd(RoundEndedEventArgs ev)
        {
            Exiled.API.Features.Server.FriendlyFire = true;
            ZombieRound  = false;
        }
        public void GameStart()
        {
            Random rand  = new Random();

            int chanceForSCP008  = rand.Next(0, 101);
            Log.Info("Chance for Zombies " + chanceForSCP008);
            if(chanceForSCP008 < 21)
            {
                ZombieRound = true;
                Map.Broadcast(6, $"Zombie round, scps are infectious zombies, dont get infected!", Broadcast.BroadcastFlags.Normal, true);

            }
            Exiled.API.Features.Server.FriendlyFire = false;
            Map.Broadcast(6, $"If you are playing a custom role, hit ` to check your abilities, alt to use them, and double tap alt to switch abilities", Broadcast.BroadcastFlags.Normal, true);







        }

    }
}

