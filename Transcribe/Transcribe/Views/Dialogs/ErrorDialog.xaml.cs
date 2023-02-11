using System.Text.RegularExpressions;
using Transcribe.Views.Base;

namespace Transcribe.Views.Dialogs;

public partial class ErrorDialog : BaseDialog
{

    #region Properties

    private Exception _reportedException;
	public Exception ReportedException
	{
		get => _reportedException;
		set
		{
			if (_reportedException != value)
			{
                _reportedException = value;
				OnPropertyChanged(nameof(ReportedException));
				OnPropertyChanged(nameof(ShortDescription));
                OnPropertyChanged(nameof(LongDescription));
            }
		}
	}

	private string _shortDescription = string.Empty;
	public string ShortDescription
	{
		get
		{
			if(string.IsNullOrWhiteSpace(_shortDescription))
			{
				if(ReportedException != null)
					_shortDescription = $"{PascalToSentenceCase(ReportedException.GetType().Name)} ({ReportedException.GetType().Namespace})";
            }

			return _shortDescription;
		}
	}

	private string _longDescription = string.Empty;
	public string LongDescription
	{
		get
		{
			if(string.IsNullOrWhiteSpace(_longDescription))
			{
				if(ReportedException != null)
				{
					_longDescription = ReportedException.Message;
				}
			}

			return _longDescription;
		}
	}

    #endregion


    public ErrorDialog()
	{
		InitializeComponent();
	}

	private string PascalToSentenceCase(string pascalCasedWords)
	{
		return Regex.Replace(pascalCasedWords, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}");
    }

    private void btnClose_Clicked(object sender, EventArgs e)
    {
		this.Navigation.PopModalAsync(animated: false);
    }
}