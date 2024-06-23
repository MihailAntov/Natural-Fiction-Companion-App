

using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Equipments
{
    public class TacticalGlasses : Equipment, IModifyAccuracy
    {
        public TacticalGlasses()
        {
            Name = "Tactical glasses";
            Description = "Increases accuracy by one.";
        }

        public Task Modify(ICombatAction action, Fight fight)
        {
            if(action is PlayerRangedAttack attack)
            {
                if(attack.Accuracy > 0)
                {
                    attack.Accuracy--;
                }
            }
            return Task.CompletedTask;
        }
    }
}
