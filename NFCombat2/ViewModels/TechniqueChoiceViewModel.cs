using NFCombat2.Models.SpecOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.ViewModels
{
    public class TechniqueChoiceViewModel
    {
        private TaskCompletionSource<Technique> _taskCompletionSource;
        public TechniqueChoiceViewModel(List<TechniqueChoice> choices, TaskCompletionSource<Technique> taskCompetionSource)
        {
            ChoiceA = choices[0];
            ChoiceB = choices[1];
            ChooseCommand = new Command<TechniqueChoice>(Choose);
            _taskCompletionSource = taskCompetionSource;
        }

        public TechniqueChoice ChoiceA { get; set; }
        public TechniqueChoice ChoiceB { get; set; }
        public Command<TechniqueChoice> ChooseCommand { get; set; } 
        public void Choose(TechniqueChoice choice)
        {
            _taskCompletionSource.TrySetResult(choice.Technique);
        }
    }
}
