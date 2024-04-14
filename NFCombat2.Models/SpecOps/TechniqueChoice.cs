using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.SpecOps
{
    public class TechniqueChoice
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Technique Technique { get; set; }
        public TechniqueType Type {get; set;}
    }
}
