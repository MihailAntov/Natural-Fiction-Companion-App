

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class ProgramNames
    {
        public static Dictionary<ProgramType, string> EnglishProgramNames = new Dictionary<ProgramType, string>
        {
            {ProgramType.ReceiveNOptimizeNMove, "+Receive -Optimize -Move" },
            {ProgramType.ReceiveNOptimizeNFix, "+Receive -Optimize -Fix" },
            {ProgramType.ReceiveNOptimizeNAnalyze, "+Receive -Optimize -Analyze" },
            {ProgramType.ReceiveNOptimizeFix, "+Receive -Optimize +Fix" },
            {ProgramType.ReceiveNExtendNFix, "+Receive -Extend -Fix" },
            {ProgramType.ReceiveNDirectNMove, "+Receive -Direct -Move" },
            {ProgramType.ReceiveNDirectNFix, "+Receive -Direct -Fix" },
            {ProgramType.ReceiveDirectNMove, "+Receive +Direct -Move" },
            {ProgramType.ReceiveDirectNFix, "+Receive +Direct -Fix" },
            {ProgramType.ReceiveDirectNAnalyze, "+Receive +Direct -Analuze" },
            {ProgramType.ReceiveDirectFix, "+Receive +Direct +Fix" },
            {ProgramType.ReceiveExtendNMove, "+Receive +Extend -Move" },
            {ProgramType.ReceiveExtendNFix, "+Receive +Extend -Fix" },
            {ProgramType.ReceiveOptimizeNMove, "+Receive +Optimize -Move" },
            {ProgramType.ReceiveOptimizeNFix, "+Receive +Optimize -Fix" },
            {ProgramType.ReceiveOptimizeNAnalyze, "+Receive +Optimize -Analyze" },
            {ProgramType.ReceiveOptimizeFix, "+Receive +Optimize +Fix" },
            {ProgramType.SendDirectNUnlock, "+Send +Direct -Unlock" },
 
            
        };
    }
}
