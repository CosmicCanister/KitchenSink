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
        public void RemoveTPAbility(DiedEventArgs ev)
        {
            CustomAbility teleport = CustomAbility.Get("Teleportation");
            teleport.RemoveAbility(ev.Player);

        }

        public void Escaping(EscapedEventArgs ev)
        {
            if(Server.HideRound)
            {
                foreach (Exiled.API.Features.Player p in Exiled.API.Features.Player.List)
                {
                    if(p.Role == RoleTypeId.FacilityGuard)
                    {
                        p.Vaporize();
                    }
                }

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
                            leftEventArgs.Player.Role.Set(RoleTypeId.Scp049);
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
                

                //TFA Round Code

                if(Server.TeamFightRound)
                {
                    int iterator = 1;
                    foreach(Exiled.API.Features.Player p in Exiled.API.Features.Player.List)
                    {
                        Map.Broadcast(6, $"TDM, Last team standing wins", Broadcast.BroadcastFlags.Normal, true);

                        if (iterator % 2 == 0)
                        {
                            p.Role.Set(RoleTypeId.ClassD);
                            p.Teleport(RoomType.LczToilets);
                            p.ClearInventory();
                        }
                        else
                        {
                            p.Role.Set(RoleTypeId.Scientist);
                            p.Teleport(RoomType.LczCafe);
                            p.ClearInventory();
                        }

                        iterator++;
                    }    
                }

                //Juggernaught round

                if (Server.JuggerNaughtRound)
                {
                    
                    System.Random newRand = new System.Random();
                    int max = Exiled.API.Features.Player.List.Count;
                    int chance = newRand.Next(0,max);
                    bool scpSpawned = false;
                    foreach (Exiled.API.Features.Player p in Exiled.API.Features.Player.List)
                    {

                        if(chance == max)
                        {
                            scpSpawned = true;
                            p.Role.Set(RoleTypeId.ChaosRepressor);
                            p.ClearInventory();
                            p.AddItem(ItemType.ArmorHeavy);
                            p.AddItem(ItemType.GunLogicer);
                            p.AddItem(ItemType.SCP500);
                            p.AddItem(ItemType.SCP500);

                            p.AddItem(ItemType.SCP500);
                            p.Teleport(RoomType.EzCafeteria);
                            p.AddItem(ItemType.AntiSCP207);
                            p.AddItem(ItemType.GunSCP127);
                            p.AddAmmo(AmmoType.Nato762, 600);
                            p.Health = 1500;
                            p.Broadcast(6, $"You are the juggernaught", Broadcast.BroadcastFlags.Normal, true);

                        }
                        else
                        {
                            p.Role.Set(RoleTypeId.NtfPrivate);
                            p.Teleport(RoomType.EzCollapsedTunnel);
                            p.Broadcast(6, $"fight the juggernaught", Broadcast.BroadcastFlags.Normal, true);

                        }

                        chance++;
    
                    }
                    if (scpSpawned == false)
                    {
                        foreach (Exiled.API.Features.Player p in Exiled.API.Features.Player.List)
                        {

                            p.Role.Set(RoleTypeId.ChaosRepressor);
                            p.ClearInventory();
                            p.AddItem(ItemType.ArmorHeavy);
                            p.AddItem(ItemType.GunLogicer);
                            p.AddItem(ItemType.SCP500);
                            p.AddItem(ItemType.SCP500);

                            p.AddItem(ItemType.SCP500);
                            p.Teleport(RoomType.EzCafeteria);
                            p.AddItem(ItemType.AntiSCP207);
                            p.AddItem(ItemType.GunSCP127);
                            p.AddAmmo(AmmoType.Nato762, 600);
                            p.Health = 1500;
                            break;
                        }
                    }




                }

                if (Server.HideRound)
                {


                    System.Random newRand = new System.Random();
                    Map.CleanAllItems();
                    int lightsOut = newRand.Next(0, 2);
                    int max = Exiled.API.Features.Player.List.Count;
                    int chance = newRand.Next(0, max);
                    bool scpSpawned = false;
                    foreach (Door p in Door.List)
                    {
                        p.IsOpen = true;
                    }

                        foreach (Exiled.API.Features.Player p in Exiled.API.Features.Player.List)
                        {

                        if (chance == max)
                        {
                            scpSpawned = true;
                            p.Role.Set(RoleTypeId.FacilityGuard);
                            p.AddItem(ItemType.ArmorHeavy);
                            p.AddItem(ItemType.GunLogicer);
                            p.AddItem(ItemType.SCP500);
                            p.AddItem(ItemType.SCP500);
                            p.EnableEffect(EffectType.Scp1344);
                            p.AddItem(ItemType.SCP500);
                            p.Teleport(RoomType.HczArmory);
                            p.AddItem(ItemType.AntiSCP207);
                            p.AddItem(ItemType.GunSCP127);
                            p.AddAmmo(AmmoType.Nato762, 600);
                            p.Health = 1000;
                            p.Broadcast(6, $"kill everyone, hiders are in light", Broadcast.BroadcastFlags.Normal, true);
                        }
                        else
                        {
                            p.Role.Set(RoleTypeId.ClassD);
                            p.Teleport(RoomType.LczClassDSpawn);
                            p.AddItem(ItemType.GrenadeFlash);
                            p.AddItem(ItemType.GrenadeFlash);
                            p.AddItem(ItemType.GrenadeFlash);
                            p.AddItem(ItemType.SCP244a);
                            p.AddItem(ItemType.Medkit);
                            p.AddItem(ItemType.Medkit);

                            p.Broadcast(6, $"escape the facility, run from seeker", Broadcast.BroadcastFlags.Normal, true);

                        }

                        chance++;

                    }
                    if (scpSpawned == false)
                    {
                        foreach (Exiled.API.Features.Player p in Exiled.API.Features.Player.List)
                        {
                            p.Role.Set(RoleTypeId.FacilityGuard);
                            p.AddItem(ItemType.ArmorHeavy);
                            p.AddItem(ItemType.GunLogicer);
                            p.AddItem(ItemType.SCP500);
                            p.AddItem(ItemType.SCP500);
                            p.EnableEffect(EffectType.Scp1344);
                            p.AddItem(ItemType.SCP500);
                            p.Teleport(RoomType.HczArmory);
                            p.AddItem(ItemType.AntiSCP207);
                            p.AddItem(ItemType.GunSCP127);
                            p.AddAmmo(AmmoType.Nato762, 600);
                            p.Health = 1000;
                            p.Broadcast(6, $"kill everyone, hiders are in light", Broadcast.BroadcastFlags.Normal, true);
                            break;
                        }
                    }
                }
            });


        }




    }
}
