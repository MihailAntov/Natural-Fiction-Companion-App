using static NFCombat2.Common.Enums.WorkCoefficient;
using static NFCombat2.Common.Enums.PartType;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NFCombat2.Models.Items.Parts
{
    public class PartBag : INotifyPropertyChanged
    {
        public List<PartCategory> Categories { get; set; } = new List<PartCategory>()
        {
            new PartCategory()
            {
                Name = "Reactive Agents",
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = A, PartType = ReactiveAgent, Quantity = 0},
                    new Part() {WorkCoefficient = B, PartType = ReactiveAgent, Quantity = 0},
                    new Part() {WorkCoefficient = C, PartType = ReactiveAgent, Quantity = 0},
                    new Part() {WorkCoefficient = D, PartType = ReactiveAgent, Quantity = 0},
                }
            },
            new PartCategory()
            {
                Name = "Components",
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = E, PartType = ItemComponent, Quantity = 0},
                    new Part() {WorkCoefficient = F, PartType = ItemComponent, Quantity = 0},
                    new Part() {WorkCoefficient = G, PartType = ItemComponent, Quantity = 0},
                    new Part() {WorkCoefficient = H, PartType = ItemComponent, Quantity = 0},
                    new Part() {WorkCoefficient = I, PartType = ItemComponent, Quantity = 0},
                }
            },
            new PartCategory()
            {
                Name = "Transmitter Nodes",
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = J, PartType = TransmitterNode, Quantity = 0},
                    new Part() {WorkCoefficient = K, PartType = TransmitterNode, Quantity = 0},
                    new Part() {WorkCoefficient = L, PartType = TransmitterNode, Quantity = 0},
                    new Part() {WorkCoefficient = M, PartType = TransmitterNode, Quantity = 0},
                    new Part() {WorkCoefficient = N, PartType = TransmitterNode, Quantity = 0},
                }
            },
            new PartCategory()
            {
                Name = "Core Components",
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = O, PartType = CoreItemComponent, Quantity = 0},
                    new Part() {WorkCoefficient = P, PartType = CoreItemComponent, Quantity = 0},
                    new Part() {WorkCoefficient = Q, PartType = CoreItemComponent, Quantity = 0},
                    new Part() {WorkCoefficient = R, PartType = CoreItemComponent, Quantity = 0},
                }
            },
            new PartCategory()
            {
                Name = "Tools",
                Parts = new List<Part>()
                {
                    new Part() {WorkCoefficient = S, PartType = Tool, Quantity = 0},
                    new Part() {WorkCoefficient = T, PartType = Tool, Quantity = 0},
                    new Part() {WorkCoefficient = U, PartType = Tool, Quantity = 0},
                    new Part() {WorkCoefficient = V, PartType = Tool, Quantity = 0},
                    new Part() {WorkCoefficient = W, PartType = Tool, Quantity = 0},
                    new Part() {WorkCoefficient = X, PartType = Tool, Quantity = 0},
                    new Part() {WorkCoefficient = Y, PartType = Tool, Quantity = 0},
                    new Part() {WorkCoefficient = Z, PartType = Tool, Quantity = 0},
                }
            }
        };
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
