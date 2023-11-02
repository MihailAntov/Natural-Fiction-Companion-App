using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Items
{
    public class SaltPotion : Consumable
    {
        public SaltPotion()
        {
        }

        public override string Label { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string[] MessageArgs => throw new NotImplementedException();

        public override IEnumerable<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
