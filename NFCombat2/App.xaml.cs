using NFCombat2.Contracts;

namespace NFCombat2;

public partial class App : Application
{
	public App(IPlayerService playerService)
	{
		InitializeComponent();

		MainPage = new AppShell(playerService);
	}
}
