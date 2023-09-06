

using NFCombat2.Common.Enums;

namespace NFCombat2.Services.Contracts
{
    public interface IAccuracyService
    {
        public int Hits(Accuracy accuracy, int roll);
    }
}
