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

    public Layout ViewContent
    {
        get => (Layout)base.GetValue(ViewContentProperty);
        set => base.SetValue(ViewContentProperty, value);
    }

    #endregion

    #endregion

    #region Bindable Property Initalizers

    public static BindableProperty ViewContentProperty = BindableProperty.Create(
        nameof(ViewContent),
        typeof(Layout),
        typeof(BasePage),
        null,
        BindingMode.OneWay,
        propertyChanged: HandleViewContentPropertyChanged);

    #endregion


    public BasePage()
    {
        InitializeComponent();

        // TODO: move this somewhere better, and make nav bar togglable
        ObservableCollection<NavBarItem> navBarItems= new ObservableCollection<NavBarItem>();
        navBarItems.Add(new NavBarItem() { Id = NavBarItemIndex.Me, Icon = "grid_outline.svg", Label = "Me" });
        navBarItems.Add(new NavBarItem() { Id = NavBarItemIndex.Explore, Icon = "compass_outline.svg", Label = "Explore" });
        navBarItems.Add(new NavBarItem() { Id = NavBarItemIndex.Favourites, Icon = "heart_outline.svg", Label = "Favourites" });
        navBarItems.Add(new NavBarItem() { Id = NavBarItemIndex.Profile, Icon = "profile_outline.svg", Label = "Profile" });

        this.NavBarItems = navBarItems;
    }

    #region Bindable Property Changed Methods

    private static void HandleViewContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BasePage view = (BasePage)bindable;
        view.viewContent.Content = (Layout)newValue;
    }

    #endregion

}