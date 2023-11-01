using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Items
{
    public class StrengthPotion : Consumable
    {
        public StrengthPotion()
        {
        }

        public override string Label { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string[] MessageArgs => throw new NotImplementedException();

        public override ICombatResolution AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
