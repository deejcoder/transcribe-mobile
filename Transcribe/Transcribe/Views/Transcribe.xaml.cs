using Microsoft.Maui.Controls;
using Transcribe.ViewModels;
using Transcribe.Views.Base;

namespace Transcribe.Views;

public partial class Transcribe : BasePage
{

    #region Properties

    protected TranscribeViewModel ViewModel { get; set; }

    #endregion

    public Transcribe()
	{
		InitializeComponent();

		this.ViewModel = new TranscribeViewModel();
        this.BindingContext = ViewModel;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if(ViewModel != null)
        {
            if(!ViewModel.Recording)
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
}