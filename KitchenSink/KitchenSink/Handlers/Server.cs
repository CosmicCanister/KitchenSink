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
        public static bool TeamFightRound { get; set; } = false;

        public static bool JuggerNaughtRound { get; set; } = false;
        public static bool HideRound { get; set; } = false;




        public void GameEnd(RoundEndedEventArgs ev)
        {
            Exiled.API.Features.Server.FriendlyFire = true;
            ZombieRound  = false;
            HideRound = false;
            JuggerNaughtRound = false;
            TeamFightRound = false;
        }
        public void GameStartFire()
        {


            Exiled.API.Features.Server.FriendlyFire = false;





        }
        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (Server.TeamFightRound || Server.HideRound)
            {
                ev.IsAllowed = false;

            }
        }
        public void GameStart()
        {
            ZombieRound = false;

            Random rand = new Random();

            int Custommatch = rand.Next(0, 101);

            int EventChooser = -1; 
            if(Custommatch < 11)
            {
                EventChooser = rand.Next(0, 4);
            }
            Log.Info("Chance for Zombies " + EventChooser);
            if (EventChooser == 0)
            {
                ZombieRound = true;
                Map.Broadcast(6, $"Zombie round, scps are infectious zombies, dont get infected!", Broadcast.BroadcastFlags.Normal, true);

            }
            Map.Broadcast(6, $"If you are playing a custom role, hit ` to check your abilities, alt to use them, and double tap alt to switch abilities", Broadcast.BroadcastFlags.Normal, true);

            
            Exiled.API.Features.Server.FriendlyFire = false;

            //Team fight match chance
            if(EventChooser == 1)
            {
                TeamFightRound = true;
                

            }
            if (EventChooser == 2)
            {
                TeamFightRound = true;


            }
            if (EventChooser == 3)
            {
                HideRound = true;


            }
        }
    }
}

