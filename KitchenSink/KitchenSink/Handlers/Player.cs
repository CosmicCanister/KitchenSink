using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.CustomRoles;
using Exiled.CustomRoles.API.Features;
using MEC;
using Exiled.API.Features.Doors;
using Exiled.API.Enums;
using PlayerRoles;
using System.ComponentModel;
using PlayerEvent = Exiled.Events.Handlers.Player;
using InventorySystem.Items.Usables.Scp330;
using LabApi.Events.Arguments.PlayerEvents;
using Exiled.CustomItems.API.Features;
using UnityEngine;

namespace KitchenSink.Handlers
{
    internal class Player
    {

        public void OnPlayCon(JoinedEventArgs ev)
        {
            Log.Info("but bug Left");
            bool isActive = KitchenSinkPlugin.Instance.Config.JoinLeave;
            if (isActive)
            {
                Map.Broadcast(6, $"{ev.Player.Nickname} has joined the server", Broadcast.BroadcastFlags.Normal, true);
                


                Log.Info("Player Joined");


            }



        }

        public void InjureSCPSSCP035(HurtingEventArgs ev)
        {
            bool hasRole = false;
            CustomRole EscapeArtist = Roles.ClassDEscapeArtist.Get(71);
            foreach (Exiled.API.Features.Player p in EscapeArtist.TrackedPlayers)
            {
                if (ev.Attacker == p)
                {
                    hasRole = true;
                }
            }
            if (hasRole == false || ev.Player.Role.Team != Team.SCPs)
            {
                return;
            }
            ev.IsAllowed = false;


        }

        public void InjureSCP035SCPS(HurtingEventArgs ev)
        {
            bool hasRole = false;
            CustomRole EscapeArtist = Roles.ClassDEscapeArtist.Get(71);
            foreach (Exiled.API.Features.Player p in EscapeArtist.TrackedPlayers)
            {
                if (ev.Player == p)
                {
                    hasRole = true;
                }
            }
            if (hasRole == false || ev.Attacker.Role.Team != Team.SCPs)
            {
                return;
            }
            ev.IsAllowed = false;


        }
        public void OnPlayerLeave(LeftEventArgs leftEventArgs)
        {
            Log.Info("but bug Left");
            bool isActive = KitchenSinkPlugin.Instance.Config.JoinLeave;
            if (isActive)
            {

                Map.Broadcast(6, $"{leftEventArgs.Player.Nickname} has left the server", Broadcast.BroadcastFlags.Normal, true);

                Log.Info("Player Left");
            }

        }

        public void Scp330TPCANDY(PlayerInteractedScp330EventArgs ev)
        {
            System.Random newRand = new System.Random();
            if(newRand.Next(0,101) > 90)
            {
                CustomItem candy = CustomItem.Get(68);
                candy.Give(ev.Player);
            }
            if (newRand.Next(0, 101) > 80)
            {

                ev.Player.GiveCandy(CandyKindID.Pink, InventorySystem.Items.ItemAddReason.PickedUp);
            }

        }
        public void OnPlayerSpawn(SpawnedEventArgs leftEventArgs)
        {
            Timing.CallDelayed(2f, () =>
            {
                bool isActive = KitchenSinkPlugin.Instance.Config.JoinLeave;
                if (Server.ZombieRound)
                {

                    if(leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp079)
                    {
                        Timing.CallDelayed(0.5f, () =>
                        {
                            CustomRole zombie = Roles.SCP0081.Get(65);
                            var armory = Door.Get(DoorType.Scp106Secondary);
                            armory.IsOpen = true;
                            armory = Door.Get(DoorType.Scp106Primary);
                            armory.IsOpen = true;
                            armory = Door.Get(DoorType.Scp106Checkpoint);
                            armory.IsOpen = true;
                            zombie.AddRole(leftEventArgs.Player);

                        });
                    }
                    if (leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp049 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp079 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp096 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp106 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp173 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp3114 || leftEventArgs.Player.Role == PlayerRoles.RoleTypeId.Scp939)
                    {
                        Log.Info("ZombieRound");
                        Timing.CallDelayed(0.5f, () =>
                        {
                            CustomRole zombie = Roles.SCP0081.Get(65);
                            var armory = Door.Get(DoorType.Scp106Secondary);
                            armory.IsOpen = true;
                            armory = Door.Get(DoorType.Scp106Primary);
                            armory.IsOpen = true;
                            armory = Door.Get(DoorType.Scp106Checkpoint);
                            armory.IsOpen = true;
                            zombie.AddRole(leftEventArgs.Player);

                        });

                    }

                }

            });


        }




    }
}
