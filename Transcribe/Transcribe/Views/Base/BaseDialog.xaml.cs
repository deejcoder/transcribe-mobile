namespace Transcribe.Views.Base;

public partial class BaseDialog : ContentView
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

    public double MaximumHeight
    {
        get => Application.Current.MainPage.Height / (1/4);
    }

    #endregion

    #endregion

    #region Bindable Property Initalizers

    public static BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(BaseDialog),
        null,
        BindingMode.OneWay,
        propertyChanged: HandleTitlePropertyChanged);

    public static BindableProperty ViewContentProperty = BindableProperty.Create(
        nameof(ViewContent),
        typeof(Layout),
        typeof(BaseDialog),
        null,
        BindingMode.OneWay,
        propertyChanged: HandleViewContentPropertyChanged);

    #endregion


    public BaseDialog()
	{
		InitializeComponent();
	}

    #region Bindable Property Methods

    private static void HandleTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BaseDialog view = (BaseDialog)bindable;
        view.Title = (string)newValue;
    }

    private static void HandleViewContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BaseDialog view = (BaseDialog)bindable;
        view.viewContent.Content = (Layout)newValue;
    }

    #endregion

}