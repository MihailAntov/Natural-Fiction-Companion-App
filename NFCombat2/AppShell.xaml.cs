﻿using NFCombat2.Contracts;
using NFCombat2.Pages;
using NFCombat2.ViewModels;

namespace NFCombat2;

public partial class AppShell : Shell
{
	public AppShell(CharacterPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}
