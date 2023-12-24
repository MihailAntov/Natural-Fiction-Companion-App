

namespace NFCombat2.Models.Items.Parts
{
    public class PartCategory
    {
        public string Name { get; set; }
        public List<Part> Parts { get; set; } = new List<Part>();
    }
}
