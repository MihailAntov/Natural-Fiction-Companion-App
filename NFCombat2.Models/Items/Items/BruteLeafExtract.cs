

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class BruteLeafExtract : Item, ICombatActiveItem
    {
        public BruteLeafExtract()
        {
            Name = "TODO";
            IsConsumable = true;
            Quantity = 1;
        }

        public bool UnavailableForRestOfCombat { get; set; }

        public MessageType MessageType => MessageType.UseItemMessage;

        public string[] MessageArgs => new string[1] { Name };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            Quantity--;
            if(Quantity == 0)
            {
                fight.Player.Items.Remove(this);
                fight.Player.ExtraItems.Remove(this);
            }

            var increase = new StrengthIncrease(fight.Player, 3);
            fight.Effects.Enqueue(increase);
            return new List<ICombatResolution>() { increase };  
        }
    }
}
