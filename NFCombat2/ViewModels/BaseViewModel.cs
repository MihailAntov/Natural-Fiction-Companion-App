

using NFCombat2.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected INameService _nameService;
        public BaseViewModel(INameService nameSerivce)
        {
            _nameService = nameSerivce;
            _nameService.PropertyChanged += OnLanguagePropertyChanged;
            UpdateLanguageSpecificProperties();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnLanguagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_nameService.Language))
            {
                UpdateLanguageSpecificProperties();
            }
        }

        public abstract void UpdateLanguageSpecificProperties();
        

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
