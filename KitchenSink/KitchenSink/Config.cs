using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenSink
{
    public class Config : IConfig
    {
        [Description("This sets for if the plugin should be enabled or net")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("This sets for if joins and leaves will be announced")]
        public bool JoinLeave { get; set; } = true;
    }
}
