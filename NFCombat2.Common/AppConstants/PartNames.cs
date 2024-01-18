

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class PartNames
    {
        public static Dictionary<PartCategoryType, string> EnglishPartCategories = new Dictionary<PartCategoryType, string>
        {
            {PartCategoryType.ReactiveAgent, "Reactive Agent" },
            {PartCategoryType.ItemComponent, "Item Component" },
            {PartCategoryType.TransmitterNode, "Transmitter Node" },
            {PartCategoryType.CoreItemComponent, "Core Item Components" },
            {PartCategoryType.Tool, "Tools" },
        };

        public static Dictionary<PartType, string> EnglishParts = new Dictionary<PartType, string>
        {
            {PartType.FuelCell, "Fuel Cell" },
            {PartType.LiquidFuel, "Liquid Fuel" },
            {PartType.PlasmaCharge, "Plasma Charge" },
            {PartType.NuclearFuel, "Nuclear Fuel" },
            {PartType.ElectricDetail, "Electric Detail" },
            {PartType.TangentialComponent, "Tangential Component" },
            {PartType.AirProfile, "Air Profile" },
            {PartType.WeaponElement, "Weapon Element" },
            {PartType.SupportingConstruct, "Supporting Construct" },
            {PartType.Reductor, "Reductor" },
            {PartType.Connector, "Connector" },
            {PartType.Transformer, "Transformer" },
            {PartType.Compressor, "Compressor" },
            {PartType.Inhibitor, "Inhibitor" },
            {PartType.Trigger, "Trigger" },
            {PartType.ElectricalGenerator, "Electrical Generator" },
            {PartType.Engine, "Engine" },
            {PartType.Reactor, "Reactor" },
            {PartType.Reel, "Reel" },
            {PartType.Cutter, "Cutter" },
            {PartType.Electrode, "Electrode" },
            {PartType.BalisticMechanism, "Balistic Mechanism" },
            {PartType.Transmission, "Transmission" },
            {PartType.LaserMatrix, "Laser Matrix" },
            {PartType.Projector, "Projector" },
            {PartType.Detonator, "Detonator" },
        };
    }
}
