

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class PortableSurgicalLaser : Equipment, IInventoryActiveItem, IHaveRolls
    {
        public PortableSurgicalLaser()
        {
            IsConsumable = true;
            Quantity = 1;
            IsInvention = true;
            DiceMessage = "Your portable surgical laser roll:";
            RollsResult = DiceCalculator.Calculate(2);
        }

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.SurgicalKitRoll;
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();
        public ICombatResolution AffectPlayer(Player.Player player)
        {
            //Quantity--;
            //if (Quantity <= 0)
            //{
            //    player.Equipment.Remove(this);
            //}
            player.Health += RollsResult.Dice.Sum(d => d.DiceValue);

            return new Heal(RollsResult);
        }
    }
}
