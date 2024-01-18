using static NFCombat2.Common.Enums.WorkCoefficient;
using static NFCombat2.Common.Enums.PartType;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Items.Parts
{
    public class PartBag : INotifyPropertyChanged
    {
        public List<PartCategory> Categories { get; set; } = new List<PartCategory>()
        {
            new PartCategory()
            {
                PartCategoryType = PartCategoryType.ReactiveAgent,
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = A, PartType = FuelCell, Quantity = 0},
                    new Part() {WorkCoefficient = B, PartType = LiquidFuel, Quantity = 0},
                    new Part() {WorkCoefficient = C, PartType = PlasmaCharge, Quantity = 0},
                    new Part() {WorkCoefficient = D, PartType = NuclearFuel, Quantity = 0},
                }
            },
            new PartCategory()
            {
                PartCategoryType = PartCategoryType.ItemComponent,
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = E, PartType = ElectricDetail, Quantity = 0},
                    new Part() {WorkCoefficient = F, PartType = TangentialComponent, Quantity = 0},
                    new Part() {WorkCoefficient = G, PartType = AirProfile, Quantity = 0},
                    new Part() {WorkCoefficient = H, PartType = WeaponElement, Quantity = 0},
                    new Part() {WorkCoefficient = I, PartType = SupportingConstruct, Quantity = 0},
                }
            },
            new PartCategory()
            {
                PartCategoryType = PartCategoryType.TransmitterNode,
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = J, PartType = Reductor, Quantity = 0},
                    new Part() {WorkCoefficient = K, PartType = Connector, Quantity = 0},
                    new Part() {WorkCoefficient = L, PartType = Transformer, Quantity = 0},
                    new Part() {WorkCoefficient = M, PartType = Compressor, Quantity = 0},
                    new Part() {WorkCoefficient = N, PartType = Inhibitor, Quantity = 0},
                }
            },
            new PartCategory()
            {
                PartCategoryType = PartCategoryType.CoreItemComponent,
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = O, PartType = PartType.Trigger, Quantity = 0},
                    new Part() {WorkCoefficient = P, PartType = ElectricalGenerator, Quantity = 0},
                    new Part() {WorkCoefficient = Q, PartType = Engine, Quantity = 0},
                    new Part() {WorkCoefficient = R, PartType = Reactor, Quantity = 0},
                }
            },
            new PartCategory()
            {
                PartCategoryType = PartCategoryType.Tool,
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = S, PartType = Reel, Quantity = 0},
                    new Part() {WorkCoefficient = T, PartType = Cutter, Quantity = 0},
                    new Part() {WorkCoefficient = U, PartType = Electrode, Quantity = 0},
                    new Part() {WorkCoefficient = V, PartType = BalisticMechanism, Quantity = 0},
                    new Part() {WorkCoefficient = W, PartType = Transmission, Quantity = 0},
                    new Part() {WorkCoefficient = X, PartType = LaserMatrix, Quantity = 0},
                    new Part() {WorkCoefficient = Y, PartType = Projector, Quantity = 0},
                    new Part() {WorkCoefficient = Z, PartType = Detonator, Quantity = 0},
                }
            }
        };
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
