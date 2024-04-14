

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class ProgramDescriptions
    {
        public static Dictionary<ProgramType, string> EnglishProgramDescriptions = new Dictionary<ProgramType, string>()
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

        public static Dictionary<ProgramType, string> BulgarianProgramDescriptions = new Dictionary<ProgramType, string>()
        {
            {ProgramType.ReceiveNOptimizeNMove, "Един противник не може да се придвижва през следващите си три хода.\r\nПрограмата няма ефект, ако разстоянието до целта е по-голямо от 10 метра или по-малко от 1 метър.\r\nУвеличи степента на Претоварване с две нива.\r\n" },
            {ProgramType.ReceiveNOptimizeNFix, "Един противник губи 2 зара издръжливост в този ход и още 1 зар в следващия.\r\nПрограмата няма ефект, ако разстоянието до целта е по-голямо от 10 метра или по-малко от 1 метър.\r\nУвеличи степента на Претоварване с две нива.\r\n" },
            {ProgramType.ReceiveNOptimizeNAnalyze, "Следващите ти два изстрела с огнестрелно оръжие задължително уцелват и нанасят двойни щети на противника.\r\nУвеличи степента на Претоварване с две нива.\r\n" },
            {ProgramType.ReceiveNOptimizeFix, "Възстанови си до 2 зара издръжливост в този ход и още 1 зар в следващия. \r\nУвеличи степента на Претоварване с две нива.\r\n" },
            {ProgramType.ReceiveNExtendNFix, "Един противник губи 2 зара - 1 издръжливост.\r\nПрограмата няма ефект, ако разстоянието до целта е по-голямо от 0 метра.\r\nУвеличи степента на Претоварване с едно ниво.\r\n" },
            {ProgramType.ReceiveNDirectNMove, "Всички противници не могат да се придвижват през следващите си два хода.\r\nПрограмата няма ефект, ако разстоянието до някоя от целите е по-голямо от 10 метра или по-малко от 1 метър.\r\nУвеличи степента на Претоварване с едно ниво.\r\n" },
            {ProgramType.ReceiveNDirectNFix, "Всички противници губят 1 зар + 3 издръжливост.\r\nПрограмата няма ефект, ако разстоянието до целите е по-голямо от 10 метра или по-малко от 1 метър.\r\nУвеличи степента на Претоварване с едно ниво.\r\n" },
            {ProgramType.ReceiveDirectNMove, "Един противник не може да се придвижва през следващите си два хода.\r\nПрограмата няма ефект, ако разстоянието до целта е по-голямо от 10 метра или по-малко от 1 метър.\r\nУвеличи степента на Претоварване с едно ниво.\r\n" },
            {ProgramType.ReceiveDirectNFix, "Един противник губи 2 зара издръжливост.\r\nПрограмата няма ефект, ако разстоянието до целта е по-голямо от 10 метра или по-малко от 1 метър.\r\nУвеличи степента на Претоварване с едно ниво.\r\n" },
            {ProgramType.ReceiveDirectNAnalyze, "Следващият ти изстрел с огнестрелно оръжие задължително уцелва и нанася двойни щети на противника.\r\nУвеличи степента на Претоварване с едно ниво.\r\n" },
            {ProgramType.ReceiveDirectFix, "Възстанови си до 2 зара издръжливост.\r\nУвеличи степента на Претоварване с едно ниво.\r\n" },
            {ProgramType.ReceiveExtendNMove, "Един противник не може да се придвижва през следващите си два хода.\r\nПрограмата няма ефект, ако разстоянието до целта е по-малко от 11 метра.\r\nУвеличи степента на Претоварване с едно ниво.\r\n" },
            {ProgramType.ReceiveExtendNFix, "Един противник губи 1 зар + 1 издръжливост.\r\nПрограмата няма ефект, ако разстоянието до целта е по-малко от 11 метра.\r\nУвеличи степента на Претоварване с едно ниво.\r\n" },
            {ProgramType.ReceiveOptimizeNMove, "Един противник не може да скъсява дистанцията през следващите си два хода.\r\nСамият ти можеш да извършиш допълнително действие в този ход (придвижване, стрелба или атака).\r\nПрограмата няма ефект, ако разстоянието до целта е по-голямо от 10 метра или по-малко от 1 метър.\r\nУвеличи степента на Претоварване с две нива.\r\n" },
            {ProgramType.ReceiveOptimizeNFix, "Един противник губи 2 зара издръжливост.\r\nМожеш да извършиш допълнително действие в този ход (придвижване, стрелба или атака).\r\nПрограмата няма ефект, ако разстоянието до целта е по-голямо от 10 метра или по-малко от 1 метър.\r\nУвеличи степента на Претоварване с две нива.\r\n" },
            {ProgramType.ReceiveOptimizeNAnalyze, "Следващият ти изстрел с огнестрелно оръжие задължително уцелва и нанася двойни щети на противника.\r\nМожеш да извършиш допълнително действие в този ход (придвижване, стрелба или атака).\r\nУвеличи степента на Претоварване с две нива.\r\n" },
            {ProgramType.ReceiveOptimizeFix, "Възстанови си до 2 зара издръжливост.\r\nМожеш да извършиш допълнително действие в този ход (придвижване, стрелба или атака).\r\nУвеличи степента на Претоварване с две нива.\r\n" },
            {ProgramType.SendDirectNUnlock, "???" },
        };
    }
}
