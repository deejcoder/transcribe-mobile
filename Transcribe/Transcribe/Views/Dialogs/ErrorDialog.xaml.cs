using Transcribe.Views.Base;

namespace Transcribe.Views.Dialogs;

public partial class ErrorDialog : BaseDialog
{

    private string _errorDescription;
    public string ErrorDescription
    {
        get => _errorDescription;
        set
        {
            _errorDescription = value;
            OnPropertyChanged(nameof(ErrorDescription));
        }
    }

    private string _errorContent;
	public string ErrorContent
	{
		get => _errorContent;
		set
		{
			value ??= string.Empty;
			_errorContent = value;
			OnPropertyChanged(nameof(ErrorContent));
		}
	}

	public ErrorDialog()
	{
		InitializeComponent();
	}
}