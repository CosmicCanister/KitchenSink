using Exiled.API.Features.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using UnityEngine;
using Exiled.API.Features;

namespace KitchenSink.Items
{

	[CustomItem(ItemType.KeycardCustomMetalCase)]
	public class FreemansCard: CustomKeycard
	{

		public override uint Id { get; set; } = 67;
		public override byte Rank { get; set; } = 32;
		public override string Name { get; set; } = "Freeman's Card";
		public override string Description { get; set; } = "Freeman's very own special card just for him!";
		public override float Weight { get; set; } = 0.5f;
		public override string KeycardLabel { get; set; } = "Freeman's Card";
		public override ItemType Type { get; set; } = ItemType.KeycardCustomMetalCase;

		public KeycardPermissions keycardPermissions { get; set; } = KeycardPermissions.Armory;

        public override Color32? KeycardLabelColor { get; set; } = Color.cyan;
        public override SpawnProperties SpawnProperties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void OnUsingItem(InteractingDoorEventArgs ev)
		{
			if (!Check(ev.Player.CurrentItem))
				return;
			if (ev.Door.Type == DoorType.NukeSurface)
			{
				ev.Door.IsOpen = true;
				ev.Door.Unlock();
				Log.Info("Nuke Opened");
			}
			if (ev.Door.Type == DoorType.ElevatorNuke)
			{
				ev.Door.IsOpen = true;
				ev.Door.Unlock();
				Warhead.IsKeycardActivated = true;
				Log.Info("Nuke Opened");
			}
			if (ev.Door.DoorLockType == DoorLockType.Warhead)
			{
				ev.Door.IsOpen = true;
				ev.Door.Unlock();
				Log.Info("Nuke Opened");
			}


		}

	}
}
