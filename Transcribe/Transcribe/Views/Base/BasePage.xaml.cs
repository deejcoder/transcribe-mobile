using System.Collections.ObjectModel;
using Transcribe.Controls.ViewModels;

namespace Transcribe.Views.Base;

public partial class BasePage : ContentPage
{
    #region Properties

    private ObservableCollection<NavBarItem> _navBarItems;
    public ObservableCollection<NavBarItem> NavBarItems
    {
        get => _navBarItems;
        set
        {
            _navBarItems = value;
            OnPropertyChanged(nameof(NavBarItems));
        }
    }

    #region Bindable Properties

    public bool TitleBarVisible
    {
        get => (bool)base.GetValue(TitleBarVisibleProperty);
        set => base.SetValue(TitleBarVisibleProperty, value);
    }

    public Layout ViewContent
    {
        get => (Layout)base.GetValue(ViewContentProperty);
        set => base.SetValue(ViewContentProperty, value);
    }

    public bool NavigationBarVisible
    {
        get => (bool)base.GetValue(NavigationBarVisibleProperty);
        set => base.SetValue(NavigationBarVisibleProperty, value);
    }

    #endregion

    #endregion

    #region Bindable Property Initalizers

    public static BindableProperty TitleBarVisibleProperty = BindableProperty.Create(
        nameof(ViewContent),
        typeof(bool),
        typeof(BasePage),
        false,
        BindingMode.OneWay,
        propertyChanged: HandleTitleBarVisiblePropertyChanged);

    public static BindableProperty ViewContentProperty = BindableProperty.Create(
        nameof(ViewContent),
        typeof(Layout),
        typeof(BasePage),
        null,
        BindingMode.OneWay,
        propertyChanged: HandleViewContentPropertyChanged);

    public static BindableProperty NavigationBarVisibleProperty = BindableProperty.Create(
        nameof(ViewContent),
        typeof(bool),
        typeof(BasePage),
        false,
        BindingMode.OneWay,
        propertyChanged: HandleNavigationBarVisiblePropertyChanged);

    #endregion


    public BasePage()
    {
        InitializeComponent();

        // TODO: move this somewhere better, and make nav bar togglable
        ObservableCollection<NavBarItem> navBarItems= new ObservableCollection<NavBarItem>();
        navBarItems.Add(new NavBarItem() { Id = NavBarItemIndex.MySpace, Icon = "grid_outline.svg", Label = "My Space" });
        navBarItems.Add(new NavBarItem() { Id = NavBarItemIndex.Explore, Icon = "compass_outline.svg", Label = "Explore" });
        navBarItems.Add(new NavBarItem() { Id = NavBarItemIndex.Saved, Icon = "heart_outline.svg", Label = "Saved" });
        navBarItems.Add(new NavBarItem() { Id = NavBarItemIndex.Profile, Icon = "profile_outline.svg", Label = "Profile" });

        this.NavBarItems = navBarItems;
    }

    #region Bindable Property Changed Methods

    private static void HandleTitleBarVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BasePage view = (BasePage)bindable;
        view.titleBar.IsVisible = (bool)newValue;
    }

    private static void HandleViewContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BasePage view = (BasePage)bindable;
        view.viewContent.Content = (Layout)newValue;
    }

    private static void HandleNavigationBarVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BasePage view = (BasePage)bindable;
        view.navBar.IsVisible = (bool)newValue;
    }


    #endregion

}