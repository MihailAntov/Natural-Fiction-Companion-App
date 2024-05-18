

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

        public static Dictionary<ProgramType, string> BulgarianProgramNames = new Dictionary<ProgramType, string>
        {
            {ProgramType.ReceiveNOptimizeNMove, "+Приеми -Оптимизирай -Премести" },
            {ProgramType.ReceiveNOptimizeNFix, "+Приеми -Оптимизирай -Поправи" },
            {ProgramType.ReceiveNOptimizeNAnalyze, "+Приеми -Оптимизирай -Анализирай" },
            {ProgramType.ReceiveNOptimizeFix, "+Приеми -Оптимизирай +Поправи" },
            {ProgramType.ReceiveNExtendNFix, "+Приеми -Удължи -Поправи" },
            {ProgramType.ReceiveNDirectNMove, "+Приеми -Насочи -Премести" },
            {ProgramType.ReceiveNDirectNFix, "+Приеми -Насочи -Поправи" },
            {ProgramType.ReceiveDirectNMove, "+Приеми +Насочи -Премести" },
            {ProgramType.ReceiveDirectNFix, "+Приеми +Насочи -Поправи" },
            {ProgramType.ReceiveDirectNAnalyze, "+Приеми +Насочи -Анализирай" },
            {ProgramType.ReceiveDirectFix, "+Приеми +Насочи +Поправи" },
            {ProgramType.ReceiveExtendNMove, "+Приеми +Удължи -Премести" },
            {ProgramType.ReceiveExtendNFix, "+Приеми +Удължи -Поправи" },
            {ProgramType.ReceiveOptimizeNMove, "+Приеми +Оптимизирай -Премести" },
            {ProgramType.ReceiveOptimizeNFix, "+Приеми +Оптимизирай -Поправи" },
            {ProgramType.ReceiveOptimizeNAnalyze, "+Приеми +Оптимизирай -Анализирай" },
            {ProgramType.ReceiveOptimizeFix, "+Приеми +Оптимизирай +Поправи" },
            {ProgramType.SendDirectNUnlock, "+Изпрати +Насочи -Отключи" },
        };


    }
}
