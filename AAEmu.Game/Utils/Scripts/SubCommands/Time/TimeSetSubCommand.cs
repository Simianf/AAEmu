﻿using System.Collections.Generic;
using System.Reactive.Linq;

using AAEmu.Game.Core.Managers;
using AAEmu.Game.Models.Game.Char;

namespace AAEmu.Game.Utils.Scripts.SubCommands.Time
{
    public class TimeSetSubCommand : SubCommandBase
    {
        public TimeSetSubCommand()
        {
            Title = "[Time Information]";
            Description = "Find out what time it is";
            CallPrefix = $"{CommandManager.CommandPrefix}time set";
            AddParameter(new NumericSubCommandParameter<int>("hour", "hour", true));
        }

        public override void Execute(ICharacter character, string triggerArgument, IDictionary<string, ParameterValue> parameters)
        {
            int hour = parameters["hour"];
            TimeManager.Instance.Set(hour);

            //TODO: There is much more potential information to show on this command.
            SendMessage(character, $"Current game time set: {hour}");
        }
    }
}
