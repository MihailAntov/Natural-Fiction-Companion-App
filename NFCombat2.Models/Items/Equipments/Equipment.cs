namespace NFCombat2.Models.Items.Equipments
{
    public abstract class Equipment : Item
    {
        public bool IsCraftOnly { get; set; } = false;
    }
}
