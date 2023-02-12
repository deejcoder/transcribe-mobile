using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Transcribe.Controls.Arguments;
using Transcribe.Controls.ViewModels;

namespace Transcribe.Controls;

public class NavigationBar : FlexLayout
{

    #region Properties

    //TODO: move this outside the navigation bar so it can be handled
    public ICommand MenuItemTappedCommand => new Command<MenuItemTappedEventArgs>(HandleMenuItemTapped);

    #region Bindable Properties

    public NavBarItemIndex SelectedMenuId
    {
        get => (NavBarItemIndex)base.GetValue(SelectedMenuIdProperty);
        set => base.SetValue(SelectedMenuIdProperty, value);
    }

    public ObservableCollection<NavBarItem> DataSource
    {
        get => (ObservableCollection<NavBarItem>)base.GetValue(DataSourceProperty);
        set => base.SetValue(DataSourceProperty, value);
    }


    public static BindableProperty DataSourceProperty = BindableProperty.Create(
        nameof(DataSource), 
        typeof(ObservableCollection<NavBarItem>), 
        typeof(NavigationBar), 
        null, 
        BindingMode.TwoWay, 
        propertyChanged: HandleDataSourcePropertyChanged);

    public static BindableProperty SelectedMenuIdProperty = BindableProperty.Create(
        nameof(SelectedMenuId),
        typeof(NavBarItemIndex),
        typeof(NavigationBar),
        NavBarItemIndex.None,
        BindingMode.TwoWay,
        propertyChanged: HandleSelectedMenuIdPropertyChanged);

    #endregion

    #endregion


    public NavigationBar()
	{
		this.FlowDirection = FlowDirection.LeftToRight;
		this.JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly;
        this.HorizontalOptions = LayoutOptions.FillAndExpand;
        this.VerticalOptions = LayoutOptions.FillAndExpand;
	}

    private static void HandleDataSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        NavigationBar view = (NavigationBar)bindable;
        view.DataSource = (ObservableCollection<NavBarItem>)newValue;
        view.BuildLayout(view, view.DataSource);
    }

    private static void HandleSelectedMenuIdPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        NavigationBar view = (NavigationBar)bindable;

        // update all items in the data source to either be selected, or not selected
        NavBarItemIndex selectedMenuId = (NavBarItemIndex)newValue;

        if (view.DataSource != null)
        {
            foreach(NavBarItem menuItem in view.DataSource)
            {
                menuItem.IsSelected = selectedMenuId == menuItem.Id;
            }
        }
    }

    public void BuildLayout(NavigationBar view, ObservableCollection<NavBarItem> menuItems)
    {
        if (menuItems == null) return;

        // add nav bar menu items for each item in the data source
        foreach(NavBarItem menuItem in menuItems)
        {
            NavigationBarItemView itemView = new()
            {
                BindingContext = menuItem,
                //itemView.SetBinding(NavigationBarItemView.MenuItemTappedCommandProperty, nameof(MenuItemTappedCommand));
                MenuItemTappedCommand = MenuItemTappedCommand
            };
            view.Children.Add(itemView);
        }
    }

    #region Event Listeners

    public void HandleMenuItemTapped(MenuItemTappedEventArgs args)
    {
        // update the selected menu item and do something (todo)
        if(args.Item != null)
        {
            SelectedMenuId = args.Item.Id;
        }
                  
    }

    #endregion

}