using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;

using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class Wrench : Item, ICombatActiveItem
    {
        public Wrench()
        {
            base.Name = "Wrench";
            IsConsumable = true;
            IsConsumable = true;
        }

        public MessageType MessageType => MessageType.UseItemMessage;

        public string[] MessageArgs => new string[] { Name };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
