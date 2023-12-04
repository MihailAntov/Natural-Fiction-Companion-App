

using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Player;

namespace NFCombat2.ViewModels
{
    public class WeaponModificationViewModel
    {
        private readonly IOptionsService _optionsService;
        private readonly WeaponModification _modification;
        private readonly IPlayerService _playerService;
        private TaskCompletionSource<bool> _taskCompletionSource;
        public Command AttachToCommand { get; set; }
        public WeaponModificationViewModel(
            WeaponModification modification, 
            IOptionsService optionsService, 
            IPlayerService playerService,
            TaskCompletionSource<bool> taskCompletionSource)
        {
            _modification = modification;
            _optionsService = optionsService;
            _playerService = playerService;
            _taskCompletionSource = taskCompletionSource;
            AttachToCommand = new Command<AttachedTo>(AttachTo);
        }

        public ICollection<IModificationOption> Options => GetOptions();
        private ICollection<IModificationOption> GetOptions()
        {
            return _optionsService.GetModificationOptions(_modification);
        }

        public void AttachTo(AttachedTo toBeAttachedTo)
        {

            //todo : decide if equipping should happen here or in player service;
            _taskCompletionSource.SetResult(true);
        }

        public void Cancel()
        {
            _taskCompletionSource.TrySetResult(false);
        }

    }
}
