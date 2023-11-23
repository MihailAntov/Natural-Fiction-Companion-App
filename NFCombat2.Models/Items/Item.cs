

using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items
{
    public class Item : IAddable
    {
        public int Id { get; set; }
        public bool IsInvention { get; set; } = false;
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; } = 1;
        public bool IsConsumable { get; set; } = false;
        public int Durability { get; set; } = 100;
    }
}
