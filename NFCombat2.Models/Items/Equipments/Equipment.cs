namespace NFCombat2.Models.Items.Equipments
{
    public abstract class Equipment : Item
    {
        public bool IsCraftOnly { get; set; } = false;
        public string Image { get; set; } = string.Empty;

    }
}
