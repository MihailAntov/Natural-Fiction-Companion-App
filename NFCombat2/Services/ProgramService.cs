using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using NFCombat2.Models.Programs;
using Factory = NFCombat2.Models.Factories.ProgramFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Services
{
    class ProgramService : IProgramService
    {
        private readonly INameService _nameService;
        public ProgramService(INameService nameService)
        {
            _nameService = nameService;
        }
        public void GetKnownPrograms(Player player)
        {
            string programList = player.ProgramList;
            string[] strings = programList.Split("&");
            IList<Program> result = new List<Program>();
            foreach (string formula in strings)
            {
                var program = GetProgram(formula);
                if (program != null)
                {
                    result.Add(program);
                }
                
            }
            player.Programs = result;
        }



        //public ProgramType? GetProgramType(string programString)
        //{

        //    if (Enum.TryParse(typeof(ProgramType), programString, true, out var programType))
        //    {
        //        return (ProgramType)programType;
        //    }
        //    return null;

        //}

        public Program GetProgram(string programFormula)
        {
            if (Enum.TryParse(typeof(ProgramType), programFormula, true, out var programType))
            {
                return Factory.GetProgram((ProgramType)programType);
            }
            return null;
        }


        public void LearnNewProgram(Program program, Player player)
        {
            if(player.Programs.Any(p=> p.Formula == program.Formula))
            {
                return;
            }
            player.ProgramList += $"&{program.Formula}";
        }

        public IList<ProgramFormulaComponent> GetOperationTypes()
        {
            var result = new ProgramComponentType[] { ProgramComponentType.Send, ProgramComponentType.Receive }
            .Select(pc => new ProgramFormulaComponent()
            {
                Type = pc,
                Name = _nameService.ProgramComponentName(pc)
            }).ToList();
            return result;
        }

        public IList<ProgramFormulaComponent> GetSignalTypes()
        {
            var result = new ProgramComponentType[] { ProgramComponentType.Optimize, ProgramComponentType.Extend, ProgramComponentType.Direct }
            .Select(pc => new ProgramFormulaComponent()
            {
                Type = pc,
                Name = _nameService.ProgramComponentName(pc)
            }).ToList();
            return result;
        }

        public IList<ProgramFormulaComponent> GetParadigmTypes()
        {
            var result = new ProgramComponentType[] { ProgramComponentType.Analyze, ProgramComponentType.Unlock, ProgramComponentType.Fix, ProgramComponentType.Move }
            .Select(pc => new ProgramFormulaComponent()
            {
                Type = pc,
                Name = _nameService.ProgramComponentName(pc)
            }).ToList();
            return result;
        }
    }
}
