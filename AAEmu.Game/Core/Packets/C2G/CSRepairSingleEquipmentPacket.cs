﻿using System.Collections.Generic;
using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Models.Game.Items;

namespace AAEmu.Game.Core.Packets.C2G
{
    public class CSRepairSingleEquipmentPacket : GamePacket
    {
        public CSRepairSingleEquipmentPacket() : base(CSOffsets.CSRepairSingleEquipmentPacket, 1)
        {
        }

        public override void Read(PacketStream stream)
        {
            //stream.ReadByte(); // not for version 1.2
            var slotType = (SlotType)stream.ReadByte();
            //stream.ReadByte(); // not for version 1.2
            var slot = stream.ReadByte();
            var autoUseAAPoint = stream.ReadBoolean();

            _log.Debug("RepairSingleEquipment, SlotType: {0}, Slot: {1}, AutoUseAAPoint: {2}", slotType, slot, autoUseAAPoint);

            var item = Connection.ActiveChar.Inventory.GetItem(slotType, slot);

            Connection.ActiveChar.DoRepair(new List<Item> { item });
        }
    }
}
