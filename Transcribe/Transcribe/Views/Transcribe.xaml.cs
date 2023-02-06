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
            }
            else
            {
                ViewModel.StopRecording();
            }
        }
    }
}