﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Models.Game.Skills;
using AAEmu.Game.Models.Game.Skills.Effects;
using AAEmu.Game.Models.Game.Skills.Templates;

namespace AAEmu.Game.Core.Packets.C2G
{
    public class CSRemoveBuffPacket : GamePacket
    {
        public CSRemoveBuffPacket() : base(CSOffsets.CSRemoveBuffPacket, 1)
        {
        }

        public override void Read(PacketStream stream)
        {
            var objId = stream.ReadBc();
            var buffId = stream.ReadUInt32();
            var reason = stream.ReadByte();
            var mate = MateManager.Instance.GetActiveMate(Connection.ActiveChar.ObjId);

            if (mate?.ObjId == objId)
            {
                var mateEffect = mate.Buffs.GetEffectByIndex(buffId);
                if (mateEffect == null)
                    return;
                if (mateEffect.Template.Kind == BuffKind.Good)
                    mateEffect.Exit();
            }

            if (Connection.ActiveChar.ObjId != objId)
                return;
            var effect = Connection.ActiveChar.Buffs.GetEffectByIndex(buffId);
            if (effect == null)
                return;
            if (effect.Template.Kind == BuffKind.Good)
                effect.Exit();
        }
    }
}
