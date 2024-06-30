

using NFCombat2.Common.Enums;

namespace NFCombat2.Common.AppConstants
{
    public static class ProgramDescriptions
    {
        public static Dictionary<ProgramType, string> EnglishProgramDescriptions = new Dictionary<ProgramType, string>()
        {
            {ProgramType.ReceiveNOptimizeNMove, "One opponent can’t move on their next three turns. The program has no effect if the distance to the target is greater than 10 meters or less than 1 meter. Increase overload by 2." },
            {ProgramType.ReceiveNOptimizeNFix, "One opponent loses 2d of health this turn and an additional 1 on the next one. The program has no effect if the distance to the target is greater than 10 meters or less than 1 meter. Increase overload by 2." },
            {ProgramType.ReceiveNOptimizeNAnalyze, "Your next two shots are guaranteed to be critical hits. Increase overload by 2." },
            {ProgramType.ReceiveNOptimizeFix, "Restore 2d health this turn and an additional 1 on the next one. Increase overload by 2." },
            {ProgramType.ReceiveNExtendNFix, "One opponent loses 2d-1 health. The program has no effect if the distance to the target is greater than 0 meters. Increase overload by 1." },
            {ProgramType.ReceiveNDirectNMove, "All enemies cannot move on their next two turns. The program has no effect if the distance to any of the targets is greater than 10 meters or less than 1 meter. Increase overload by 1." },
            {ProgramType.ReceiveNDirectNFix, "All enemies lose 1d+3 health. The program has no effect if the distance to any of the targets is greater than 10 meters or less than 1 meter. Increase overload by 1." },
            {ProgramType.ReceiveDirectNMove, "One opponent cannot move on their next two turns. The program has no effect if the distance to the target is greater than 10 meters or less than 1 meter. Increase overload by 1." },
            {ProgramType.ReceiveDirectNFix, "One opponent loses 2d health. The program has no effect if the distance to the target is greater than 10 meters or less than 1 meter. Increase overload by 1." },
            {ProgramType.ReceiveDirectNAnalyze, "Your next shot is guaranteed to be a critical hit. Increase overload by 1." },
            {ProgramType.ReceiveDirectFix, "Restore 2d health. Increase overload by 1." },
            {ProgramType.ReceiveExtendNMove, "One opponent cannot move on their next two turns. The program has no effect if the distance to the target is less than 11 meters. Increase overload by 1." },
            {ProgramType.ReceiveExtendNFix, "One opponent loses 1d+1 health. The program has no effect if the distance to the target is less than 11 meters. Increase overload by 1." },
            {ProgramType.ReceiveOptimizeNMove, "One opponent cannot move on their next two turns. You can take an extra action this turn (move, use an item, shoot or attack). The program has no effect if the distance to the target is greater than 10 meters or less than 1 meter. Increase overload by 2." },
            {ProgramType.ReceiveOptimizeNFix, "One opponent loses 2d health. You can take an extra action this turn (move, use an item, shoot or attack). The program has no effect if the distance to the target is greater than 10 meters or less than 1 meter. Increase overload by 2." },
            {ProgramType.ReceiveOptimizeNAnalyze, "Your next shot is guaranteed to be a critical hit. You can take an extra action this turn (move, use an item, shoot or attack). Increase overload by 2." },
            {ProgramType.ReceiveOptimizeFix, "Restore 2d health. You can take an extra action this turn (move, use an item, shoot or attack). Increase overload by 2." },
            {ProgramType.SendDirectNUnlock, "Your multivector attack disrupts the maser's motherboard, blocking its effect." },
            {ProgramType.Manual, "Manually input your program components." }

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
            {ProgramType.SendDirectNUnlock, "Мултивекторната ти атака разстройва платката на мазера, блокирайки действието му." },
            {ProgramType.Manual, "Въведи ръчно компонентите на програмата си." },
        };
    }
}
