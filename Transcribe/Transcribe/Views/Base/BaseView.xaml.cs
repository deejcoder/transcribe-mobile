namespace Transcribe.Views.Base;

public partial class BaseView : ContentView
{

    #region Properties

    #region Bindable Properties

    public string Title
    {
        get => (string)base.GetValue(TitleProperty);
        set => base.SetValue(TitleProperty, value);
    }

    public Layout ViewContent
    {
        get => (Layout)base.GetValue(ViewContentProperty);
        set => base.SetValue(ViewContentProperty, value);
    }

    #endregion

    #endregion

    #region Bindable Property Initalizers

    public static BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(BaseView),
        null,
        BindingMode.OneWay,
        propertyChanged: HandleTitlePropertyChanged);

    public static BindableProperty ViewContentProperty = BindableProperty.Create(
        nameof(ViewContent),
        typeof(Layout),
        typeof(BaseView),
        null,
        BindingMode.OneWay,
        propertyChanged: HandleViewContentPropertyChanged);

    #endregion


    public BaseView()
	{
		InitializeComponent();
    }

    #region Bindable Property Changed Methods

    private static void HandleTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BaseView view = (BaseView)bindable;
        view.Title = (string)newValue;
    }

    private static void HandleViewContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BaseView view = (BaseView)bindable;
        view.viewContent.Content = (Layout)newValue;
    }

    #endregion

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}