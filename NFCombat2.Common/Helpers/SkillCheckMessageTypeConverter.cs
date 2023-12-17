using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Common.Helpers
{
    public static class SkillCheckMessageTypeConverter
    {
        public static MessageType GetMessageType(CheckType checkType)
        {
            switch (checkType)
            {
                default:
                case CheckType.None:
                    return MessageType.None;
                case CheckType.Rocks:
                    return MessageType.SkillCheckRocks;
                case CheckType.Door:
                    return MessageType.SkillCheckDoor;
                case CheckType.Panel:
                    return MessageType.SkillCheckPanel;
                case CheckType.River:
                    return MessageType.SkillCheckRiver;
                case CheckType.Swamp:
                    return MessageType.SkillCheckSwamp;
            }
        }
    }
}
