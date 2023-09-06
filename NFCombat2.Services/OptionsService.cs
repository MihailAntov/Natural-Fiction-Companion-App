

using NFCombat2.Common.Enums;
using NFCombat2.Models.Fights;
using NFCombat2.Services.Contracts;

namespace NFCombat2.Services
{
    public class OptionsService : IOptionsService
    {
        private readonly Fight fight;
        public OptionsService(Fight fight)
        {
            this.fight = fight;
        }
        public ICollection<MoveActionOptions> GetMoveOptions()
        {
            var options = new List<MoveActionOptions>();
            if(!fight.Enemies.Any(e=> e.Distance == 0))
            {
                options.Add(MoveActionOptions.GetCloser);
            }
            if (fight.Player.Consumables.Any())
            {
                options.Add(MoveActionOptions.UseItem);
            }
            
            return options;
        }

        public ICollection<StandardActionOptions> GetStandardActionOptions()
        {
            var options = new List<StandardActionOptions>();
            if(!fight.Enemies.Any(e=> e.Distance == 0))
            {
                options.Add(StandardActionOptions.RangedAttack);
            }
            else
            {
                options.Add(StandardActionOptions.MeleeAttack);
            }

            return options;
        }
    }
}
