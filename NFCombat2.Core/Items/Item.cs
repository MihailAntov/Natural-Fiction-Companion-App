using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items
{
    public abstract class Item : IMoveAction
    {
        public abstract string Label { get; set; }
        public abstract string Description { get; set; }

        public MessageType MessageType => MessageType.UseItemMessage;
        public abstract string[] MessageArgs { get; }

        public abstract IList<ICombatResolution> AddToCombatEffects(Fight fight);
    }
}
