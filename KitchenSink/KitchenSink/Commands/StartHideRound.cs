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
    class StartHideRound : ICommand
    {
        public string Command => "HideRound";

        public string[] Aliases => new string[] { "hr" };

        public string Description => "if used before a round starts, it sets the next round to be a hide and seek round, (hr (true/false))";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if( bool.Parse(arguments.At(0)) == true)
            {
                response = "Hide round enabled";
                KitchenSink.Handlers.Server.HideRound = true;

                return true;
            }else
            {
                response = "Hide round has been disabled or still disabled";
                KitchenSink.Handlers.Server.HideRound = false;

                return false;
            }
           
        }
    }
}
