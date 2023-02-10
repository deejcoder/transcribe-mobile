using Microsoft.Maui.Controls;
using Transcribe.ViewModels;
using Transcribe.Views.Base;
using Transcribe.Views.Dialogs;

namespace Transcribe.Views;

public partial class Transcribe : BasePage
{

    #region Properties

    protected TranscribeViewModel ViewModel { get; set; }

    #region Bindable Properties
    #endregion

    #endregion

    #region Bindable Property Initalizers
    #endregion

    public Transcribe()
	{
		InitializeComponent();

		this.ViewModel = new TranscribeViewModel() { Navigation = Navigation };
        this.BindingContext = ViewModel;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            if (ViewModel != null)
            {
                if (!ViewModel.Recording)
                {
                    ViewModel.StartRecording();
                    this.recordButton.IsAnimationEnabled = true;
                    this.recordButton.RepeatCount = 100;
                }
                else
                {
                    ViewModel.StopRecording();
                    this.recordButton.RepeatCount = 1; // can't set this to zero?
                                                       //this.recordButton.IsAnimationEnabled = false;
                }
            }
        }
        catch(Exception ex)
        {
            //ContentPage page = new ContentPage();
            //page.Content = new ErrorDialog() { Title = "System Error", ErrorDescription = ex.Message, ErrorContent = ex.StackTrace };
            //Navigation.PushAsync(page, false);
        }
    }
}