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
    class StartJuggerNaughtRound : ICommand
    {
        public string Command => "JuggerNaughtRound";

        public string[] Aliases => new string[] { "jr" };

        public string Description => "if used before a round starts, it sets the next round to be a Jugger Naught round, (JuggerNaughtRound (true/false))";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if( bool.Parse(arguments.At(0)) == true)
            {
                response = "JuggerNaughtRound enabled";
                KitchenSink.Handlers.Server.JuggerNaughtRound = true;

                return true;
            }else
            {
                response = "JuggerNaughtRound has been disabled or still disabled";
                KitchenSink.Handlers.Server.JuggerNaughtRound = false;

                return false;
            }
           
        }
    }
}
