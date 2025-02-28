﻿using AAEmu.Game.Models.Game.Gimmicks;
using AAEmu.Game.Models.Game.Units;

namespace AAEmu.Game.Models.Tasks.Gimmicks
{
    public abstract class GimmickTask : Task
    {
        protected BaseUnit _caster;
        protected Gimmick _owner;
        protected uint _skillId;

        protected GimmickTask(BaseUnit caster, Gimmick owner, uint skillId)
        {
            _caster = caster;
            _owner = owner;
            _skillId = skillId;
        }
    }
}
