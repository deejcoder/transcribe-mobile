using Transcribe.ViewModels.Base;


namespace Transcribe.Controls.ViewModels
{
    public class CardViewModel : BaseViewModel
    {
        #region Properties
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(nameof(Title), value, ref _title);
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => SetProperty(nameof(Date), value, ref _date);
        }

        private string _content;
        public string Content
        {
            get => _content;
            set => SetProperty(nameof(Content), value, ref _content);
        }

        #endregion

        public CardViewModel() { }

    }
}
