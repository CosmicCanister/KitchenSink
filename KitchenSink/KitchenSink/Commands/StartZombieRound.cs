using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.CustomRoles;
using Exiled.CustomRoles.API.Features;
using MEC;
using CommandSystem;

namespace KitchenSink.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class StartZombieRound : ICommand
    {
        public string Command => "ZombieRound";

        public string[] Aliases => new string[] { "zr", "scp008" };

        public string Description => "if used before a round starts, it sets the next round to be a zombie infection round, (ZombieRound (true/false))";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if( bool.Parse(arguments.At(0)) == true)
            {
                response = "zombie round enabled";
                KitchenSink.Handlers.Server.ZombieRound = true;

                return true;
            }else
            {
                response = "zombie round has been disabled or still disabled";
                KitchenSink.Handlers.Server.ZombieRound = false;

                return false;
            }
           
        }
    }
}
