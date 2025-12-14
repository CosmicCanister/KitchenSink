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
using LabApi.Events.Arguments.PlayerEvents;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using InventorySystem.Items.Usables.Scp330;

//the other handlers are for if I want to make events for scp events
namespace KitchenSink
{
    public class KitchenSinkPlugin : Plugin<Config>
    {
        public static KitchenSinkPlugin Instance { get; } = new KitchenSinkPlugin();

        public override string Name => "Eyelander";
        public override string Author => "CosmicCanister, JimmyDogfsh";
        
        


        public override PluginPriority Priority { get; } = PluginPriority.Medium;


        private KitchenSinkPlugin() { }


         
        public override void OnEnabled()
        {
           

            CustomItem.RegisterItems();
            
            

        }

        public override void OnDisabled()
        {


            CustomItem.UnregisterItems();

        }

    }
}
