using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;

using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class Wrench : Item, ICombatActiveItem
    {
        public Wrench()
        {
            Name = "Wrench";
            IsConsumable = true;
        }

        public string Label => Name;

        public MessageType MessageType => MessageType.UseItemMessage;

        public string[] MessageArgs => new string[] { Label };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
