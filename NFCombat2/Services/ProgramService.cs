﻿using NFCombat2.Common.Enums;
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
            foreach (string s in strings)
            {
                var programType = GetProgramType(s);
                if (programType.HasValue)
                {
                    result.Add(GetProgram(programType.Value));
                }
                
            }
            player.Programs = result;
        }



        public ProgramType? GetProgramType(string programString)
        {
            
            if(Enum.TryParse(typeof(ProgramType), programString, true, out var programType))
            {
                return (ProgramType)programType;
            }
            return null;
            
        }

        public Program GetProgram(ProgramType programType)
        {
            return Factory.GetProgram(programType);
        }


        public void LearnNewProgram(Player player, Program program)
        {
            player.ProgramList += $"&{program.Formula}";
        }

        public IList<ProgramFormulaComponent> GetOperationTypes()
        {
            var result = new ProgramComponentType[] { ProgramComponentType.Send, ProgramComponentType.Receive }
            .Select(pc => new ProgramFormulaComponent()
            {
                Type = pc,
                Name = _nameService.ProgramComponentName(pc),
                Formula = pc.ToString()
            }).ToList();
            return result;
        }

        public IList<ProgramFormulaComponent> GetSignalTypes()
        {
            var result = new ProgramComponentType[] { ProgramComponentType.Optimize, ProgramComponentType.Extend, ProgramComponentType.Direct }
            .Select(pc => new ProgramFormulaComponent()
            {
                Type = pc,
                Name = _nameService.ProgramComponentName(pc),
                Formula = pc.ToString()
            }).ToList();
            return result;
        }

        public IList<ProgramFormulaComponent> GetParadigmTypes()
        {
            var result = new ProgramComponentType[] { ProgramComponentType.Analyze, ProgramComponentType.Unlock, ProgramComponentType.Fix, ProgramComponentType.Move }
            .Select(pc => new ProgramFormulaComponent()
            {
                Type = pc,
                Name = _nameService.ProgramComponentName(pc),
                Formula = pc.ToString()
            }).ToList();
            return result;
        }
    }
}