using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenSink.Handlers
{
    
    internal class Server
    {
        public static bool ZombieRound { get; set; } = false;
        public static bool TeamFightRound { get; set; } = false;

        public static bool JuggerNaughtRound { get; set; } = false;
        public static bool HideRound { get; set; } = false;




        public void GameEnd(RoundEndedEventArgs ev)
        {
            Exiled.API.Features.Server.FriendlyFire = true;
            ZombieRound  = false;
            HideRound = false;
            JuggerNaughtRound = false;
            TeamFightRound = false;
        }
        public void GameStartFire()
        {


            Exiled.API.Features.Server.FriendlyFire = false;





        }
        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (Server.TeamFightRound || Server.HideRound)
            {
                ev.IsAllowed = false;

            }
        }
        public void GameStart()
        {
            ZombieRound = false;

            Random rand = new Random();

            int Custommatch = rand.Next(0, 101);

            int EventChooser = -1; 
            if(Custommatch < 11)
            {
                EventChooser = rand.Next(0, 4);
            }
            Log.Info("Chance for Zombies " + EventChooser);
            if (EventChooser == 0)
            {
                ZombieRound = true;
                Map.Broadcast(6, $"Zombie round, scps are infectious zombies, dont get infected!", Broadcast.BroadcastFlags.Normal, true);

            }
            Map.Broadcast(6, $"If you are playing a custom role, hit ` to check your abilities, alt to use them, and double tap alt to switch abilities", Broadcast.BroadcastFlags.Normal, true);

            
            Exiled.API.Features.Server.FriendlyFire = false;

            //Team fight match chance
            if(EventChooser == 1)
            {
                TeamFightRound = true;
                

            }
            if (EventChooser == 2)
            {
                TeamFightRound = true;


            }
            if (EventChooser == 3)
            {
                HideRound = true;


            }



            //TFA Round Code

            if (Server.TeamFightRound)
            {
                int iterator = 1;
                foreach (Exiled.API.Features.Player p in Exiled.API.Features.Player.List)
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
                int chance = newRand.Next(0, max + 1);
                int iterator = 0;
                bool scpSpawned = false;
                foreach (Exiled.API.Features.Player p in Exiled.API.Features.Player.List)
                {

                    if (iterator == chance && scpSpawned == false)
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
                        p.Teleport(RoomType.EzIntercom);
                        p.Broadcast(6, $"fight the juggernaught", Broadcast.BroadcastFlags.Normal, true);
                        iterator++;

                    }


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
                int chance = newRand.Next(0, max + 1);
                bool scpSpawned = false;
                int iterator = 0;
                foreach (Door p in Door.List)
                {
                    p.IsOpen = true;
                }

                foreach (Exiled.API.Features.Player p in Exiled.API.Features.Player.List)
                {

                    if (iterator == chance && scpSpawned == false)
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
                        p.MaxHealth = 1000;
                        p.Heal(1000);

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
                        iterator++;

                        p.Broadcast(6, $"escape the facility, run from seeker", Broadcast.BroadcastFlags.Normal, true);

                    }


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
                        p.MaxHealth = 1000;
                        p.Heal(1000);

                        p.Broadcast(6, $"kill everyone, hiders are in light", Broadcast.BroadcastFlags.Normal, true);
                        break;
                    }
                }
            }

        }
    }
}

