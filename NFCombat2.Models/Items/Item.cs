

namespace NFCombat2.Models.Items
{
    public class Item
    {
        public bool IsInvention { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
