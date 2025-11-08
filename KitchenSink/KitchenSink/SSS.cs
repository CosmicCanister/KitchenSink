using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using PlayerRoles.FirstPersonControl;
using PlayerRoles.FirstPersonControl.Thirdperson;
using PlayerRoles.FirstPersonControl.Thirdperson.Subcontrollers;
using PlayerRoles.FirstPersonControl.Thirdperson.Subcontrollers.OverlayAnims;
using UnityEngine;
using UserSettings.ServerSpecific;
using UserSettings.ServerSpecific.Examples;

namespace KitchenSink
{
    public class SSS
    {
        
        private SSKeybindSetting actionKey;

        public void Activate()
        {


            // Define a keybind
            actionKey = new SSKeybindSetting(
                null,
                "Charge",
                KeyCode.F,
                allowSpectatorTrigger: false,
                hint: "Press this key to activate Charge"
            );

            // Group them together
            var settings = new ServerSpecificSettingBase[]
            {
                new SSGroupHeader("Kitchen Sink Settings"),
                
                actionKey
            };

            // Register them with the server
            if (ServerSpecificSettingsSync.DefinedSettings == null)
                ServerSpecificSettingsSync.DefinedSettings = settings;
            else
                ServerSpecificSettingsSync.DefinedSettings = ServerSpecificSettingsSync.DefinedSettings.Concat(settings).ToArray();

            // Send to connected players
            ServerSpecificSettingsSync.SendToAll();

            // Listen for user input
            ServerSpecificSettingsSync.ServerOnSettingValueReceived += OnSettingChanged;
        }

        private void OnSettingChanged(ReferenceHub hub, ServerSpecificSettingBase setting)
        {
            if (hub == null || setting == null) return;

            if (setting.SettingId == actionKey.SettingId && setting is SSKeybindSetting kb && kb.SyncIsPressed)
            {
                // The player pressed the keybind
                Log.Info($"{hub.nicknameSync.MyNick} pressed the action key!");
            }

        }

        public void Deactivate()
        {
            ServerSpecificSettingsSync.ServerOnSettingValueReceived -= OnSettingChanged;
        }
    }

}
