using NFCombat2.Contracts;

namespace NFCombat2;

public partial class AppShell : Shell
{
	public AppShell(IPlayerService playerService)
	{
		InitializeComponent();
		BindingContext = playerService;
	}
}
