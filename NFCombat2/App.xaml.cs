using NFCombat2.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2;

public partial class App : Application
{
	public App(CharacterPageViewModel viewModel)
	{
		InitializeComponent();

		MainPage = new AppShell(viewModel);		
		//MainPage = new AppShell();
	}
}
