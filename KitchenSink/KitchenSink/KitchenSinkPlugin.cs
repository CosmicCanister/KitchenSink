using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using SuicideBomb = KitchenSink.Items.SuicideBomb;
using s914 = Exiled.Events.Handlers.Scp914;
using s049 = Exiled.Events.Handlers.Scp049;
using MEC;
using Exiled.CustomItems.API.Features;

using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
//the other handlers are for if I want to make events for scp events
namespace KitchenSink
{
    public class KitchenSinkPlugin : Plugin<Config>
    {
        public static KitchenSinkPlugin Instance { get; } = new KitchenSinkPlugin();

        public override string Name => "Kitchen Sink";
        public override string Author => "CosmicCanister, JimmyDogfsh";
        
        


        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Player player;
        private Handlers.Server server;
        private KitchenSinkPlugin() { }



        public override void OnEnabled()
        {
           
            CustomAbility.RegisterAbilities(false);

            CustomRole.RegisterRoles(false);
            CustomItem.RegisterItems();
            

            RegisterEvents();

        }

        public override void OnDisabled()
        {

            CustomAbility.RegisterAbilities(false);

            CustomRole.UnregisterRoles();
            CustomItem.UnregisterItems();

            UnRegisterEvents();
        }

        public void RegisterEvents()
        {



            player = new Handlers.Player();
            server = new Handlers.Server();
            Player.Left += player.OnPlayerLeave;
            Player.Joined += player.OnPlayCon;
            Player.Spawned += player.OnPlayerSpawn;
            Server.RoundEnded += server.GameEnd;
            Server.RoundStarted += server.GameStart;
            /*
                        Player.Left += player.OnPlayerLeave;
                        Player.Joined += player.OnPlayCon;

                        Player.UsedItem += player.OnPlayerUse;
                        if (KitchenSinkPlugin.Instance.Config.JoinLeave)
                        {
                            Log.Info("Join Leave is enabled!");
                        }

                        Server.RoundEnded += server.RoundFinish;
                        Server.RoundStarted += server.RoundBegin;
                        Server.RoundStarted += server.TestStart;


                        s914.UpgradingPlayer += server.Upgrading914;
                        s049.FinishingRecall += player.S0492Zombiedeath;
            */
        }

        public void UnRegisterEvents()
        {
            player = new Handlers.Player();
            server = new Handlers.Server();
            Player.Left -= player.OnPlayerLeave;
            Player.Joined -= player.OnPlayCon;
            Player.Spawned -= player.OnPlayerSpawn;

            Server.RoundEnded -= server.GameEnd;
            Server.RoundStarted -= server.GameStart;
            /*
             *             Player.UsedItem -= player.OnPlayerUse;
            Player.Left -= player.OnPlayerLeave;
            Player.Joined -= player.OnPlayCon;

            Server.RoundEnded -= server.RoundFinish;
            Server.RoundStarted -= server.RoundBegin;
            Server.RoundStarted -= server.TestStart;

            s914.UpgradingPlayer -= server.Upgrading914;
            s049.FinishingRecall -= player.S0492Zombiedeath;
             * 
             * 
             * 
             */



            player = null;
            server = null;
        }
    }
}
