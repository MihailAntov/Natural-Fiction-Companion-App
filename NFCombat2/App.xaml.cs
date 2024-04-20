using NFCombat2.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();		
		//MainPage = new AppShell();
	}
}
