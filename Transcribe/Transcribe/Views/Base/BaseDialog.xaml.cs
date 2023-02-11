namespace Transcribe.Views.Base;

public partial class BaseDialog : ContentPage
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

    private static void HandleViewContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BaseDialog view = (BaseDialog)bindable;
        view.viewContent.Content = (Layout)newValue;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        this.dialogFrame.MaximumHeightRequest = height * 0.334;
        this.dialogFrame.MinimumHeightRequest = 100;
    }

    #endregion

}