﻿using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}

