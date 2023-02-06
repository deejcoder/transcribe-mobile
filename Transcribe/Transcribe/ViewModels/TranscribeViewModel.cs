using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Transcribe.ApiClient.Client;
using Transcribe.Controls.ViewModels;
using Transcribe.ViewModels.Base;

namespace Transcribe.ViewModels
{
    public class TranscribeViewModel : BaseViewModel
    {

        #region Properties

        private BindingList<CardViewModel> _cards;
        public BindingList<CardViewModel> Cards
        {
            get => _cards;
            set => SetProperty(nameof(Cards), value, ref _cards);
        }

        private AudioRecorderService _recorder;
        public AudioRecorderService Recorder
        {
            get => _recorder;
            set => _recorder = value;
        }

        public bool Recording
        {
            get => this.Recorder != null; // todo: replace with recorder.isrecording
        }

        #endregion

        #region Commands
        #endregion

        public TranscribeViewModel() 
        {
            LoadCards();
        }

        public void LoadCards()
        {
            Cards = new BindingList<CardViewModel>();
            Cards.Add(new CardViewModel()
            {
                Title = "Transcribe Result",
                Date = DateTime.Now,
                Content = "Just a simple test to see what the cards look like!"
            });
        }


        public async void StartRecording()
        {
            if (this.Recorder == null)
            {
                this.Recorder = new AudioRecorderService()
                {
                    StopRecordingOnSilence = true,
                    StopRecordingAfterTimeout = true,
                    TotalAudioTimeout = TimeSpan.FromSeconds(30)
                };

                await Recorder.StartRecording();
                OnPropertyChanged(nameof(Recording));
            }
        }

        public async void StopRecording()
        {
            if (this.Recorder == null) return;
            await this.Recorder.StopRecording();

            try
            {
                // after recording send the recorded file to the api to transcribe it                
                if(this.Recorder.FilePath != null)
                {
                    
                    using Stream fs = this.Recorder.GetAudioFileStream();
                    TranscribeResponse response = await Transcribe.ApiClient.Features.Transcriber.Transcribe("de", fs);

                    // add the response to the card list, so the use can see it
                    Cards.Add(new CardViewModel()
                    {
                        Title = $"Transcribe Result ({response.Language})",
                        Date = DateTime.Now,
                        Content = response.Text
                    });

                    OnPropertyChanged(nameof(Cards));
                }
            }
            finally
            {
                this.Recorder = null;
                OnPropertyChanged(nameof(Recording));
            }
        }
        
    }
}
