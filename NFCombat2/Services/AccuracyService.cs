

using NFCombat2.Common.Enums;
using NFCombat2.Contracts;

namespace NFCombat2.Services
{
    public class AccuracyService : IAccuracyService
    {
        public int Hits(Accuracy accuracy, int roll)
        {
            int hitsAt = 0;
            int critsAt = 0;
            switch(accuracy)
            {
                case Accuracy.S:
                    hitsAt = 2;
                    critsAt = 5;
                    break;
                case Accuracy.A:
                    hitsAt = 2;
                    critsAt = 6;
                    break;
                case Accuracy.B:
                    hitsAt = 3;
                    critsAt = 6;
                    break;
                case Accuracy.C:
                    hitsAt = 3;
                    critsAt = 99;
                    break;
                case Accuracy.D:
                    hitsAt = 4;
                    critsAt = 99;
                    break;
                case Accuracy.E:
                    hitsAt = 5;
                    critsAt = 99;
                    break;
            }

            if(roll >= critsAt) { return 2; }
            if(roll >= hitsAt) { return 1; }
            return 0;
        }
    }
}
