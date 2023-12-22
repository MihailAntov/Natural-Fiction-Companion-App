using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Fights
{
    public class VariantFight : Fight
    {
        public Variant Variant { get; set; }
        public VariantFight() : base()
        {
            
        }

        public override void SetUp()
        {
            base.SetUp();
            Variant.Apply(this);
        }
    }
}
