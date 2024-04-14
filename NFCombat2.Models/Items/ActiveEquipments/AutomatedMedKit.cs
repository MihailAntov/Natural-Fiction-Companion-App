
using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using static NFCombat2.Common.AppConstants.Messages;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class AutomatedMedKit : ActiveEquipment, IInventoryActiveItem, ICombatActiveItem, IHaveRolls
    {
        public AutomatedMedKit()
        {
            RollsResult = DiceCalculator.Calculate(3);
            Quantity = 1;
            IsConsumable = true;
            IsInvention = true;
        }
        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.MedKitRoll;
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            //Quantity--;
            var player = fight.Player;
            ReduceHarmfulEffects(player);
            
            var result = new List<ICombatResolution>() { new Heal(RollsResult) };
            foreach(var resolution in result)
            {
                fight.Effects.Enqueue(resolution);
            }

            //if(Quantity <= 0)
            //{
            //    fight.Player.Equipment.Remove(this);
            //}

            return result;
        }

        private void ReduceHarmfulEffects(Player.Player player)
        {
            if (player.Trauma > 0)
            {
                player.Trauma--;
            }

            if (player.Pathogens > 0)
            {
                player.Pathogens--;
            }

            if (player.Ionization > 0)
            {
                player.Ionization--;
            }
        }
        private void RestoreHealth(Player.Player player)
        {
            int starting = player.Health;
            int amount = RollsResult.Dice.Sum(d => d.DiceValue);
            player.Health += amount;
            
        }

        public ICombatResolution AffectPlayer(Player.Player player)
            //TODO : change return type to string, display effect with toast
        {
            Quantity--;
            ReduceHarmfulEffects(player);
            RestoreHealth(player); 
            if(Quantity <= 0)
            {
                player.Equipment.Remove(this);
            }

            return new Heal(RollsResult);
            
        }
    }
}
