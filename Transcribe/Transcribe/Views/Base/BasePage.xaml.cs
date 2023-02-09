namespace Transcribe.Views.Base;

public partial class BasePage : ContentPage
{
    #region Properties

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
    }

    #region Bindable Property Changed Methods

    private static void HandleViewContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BasePage view = (BasePage)bindable;
        view.viewContent.Content = (Layout)newValue;
    }

    #endregion

    private void BackButton_Tapped(object sender, TappedEventArgs e)
    {

    }
}