using System.Collections.ObjectModel;
using System.Windows.Input;
using Transcribe.Controls.Arguments;
using Transcribe.Controls.ViewModels;

namespace Transcribe.Controls;

public partial class NavigationBarItemView : ContentView
{

    #region Properties

    public ICommand MenuItemTappedCommand
    {
        get => (ICommand)base.GetValue(MenuItemTappedCommandProperty);
        set => base.SetValue(MenuItemTappedCommandProperty, value);
    }


    public static BindableProperty MenuItemTappedCommandProperty = BindableProperty.Create(
        nameof(MenuItemTappedCommand),
        typeof(ICommand),
        typeof(NavigationBarItemView),
        null,
        BindingMode.TwoWay,
        propertyChanged: HandleMenuItemTappedCommandPropertyChanged);

    #endregion


    public NavigationBarItemView()
	{
		InitializeComponent();
	}

    private static void HandleMenuItemTappedCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        NavigationBarItemView view = (NavigationBarItemView)bindable;
        view.MenuItemTappedCommand = (ICommand)newValue;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if(this.MenuItemTappedCommand != null && this.BindingContext is NavBarItem item)
            this.MenuItemTappedCommand.Execute(new MenuItemTappedEventArgs() { Item = item });
    }
}