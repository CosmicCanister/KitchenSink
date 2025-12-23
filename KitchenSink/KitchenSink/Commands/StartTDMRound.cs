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
    class StartTDMRound : ICommand
    {
        public string Command => "TDMRound";

        public string[] Aliases => new string[] { "tr"};

        public string Description => "if used before a round starts, it sets the next round to be a TDM Round, (TDMRound (true/false))";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if( bool.Parse(arguments.At(0)) == true)
            {
                response = "TDMRound enabled";
                KitchenSink.Handlers.Server.TeamFightRound = true;

                return true;
            }else
            {
                response = "TDMRound has been disabled or still disabled";
                KitchenSink.Handlers.Server.TeamFightRound = false;

                return false;
            }
           
        }
    }
}
