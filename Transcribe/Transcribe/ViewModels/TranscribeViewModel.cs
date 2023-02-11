using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Transcribe.ApiClient.Client;
using Transcribe.Controls.ViewModels;
using Transcribe.ViewModels.Base;
using Transcribe.Views.Dialogs;

namespace Transcribe.ViewModels
{
    public class TranscribeViewModel : BaseViewModel
    {

        #region Properties

        private ObservableCollection<CardViewModel> _cards;
        public ObservableCollection<CardViewModel> Cards
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

        private bool _recording = false;
        public bool Recording
        {
            get => _recording;
            set => SetProperty(nameof(Recording), value, ref _recording);
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
            Cards = new ObservableCollection<CardViewModel>();
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
                // start the recorder if it hasn't already been started
                this.Recorder = new AudioRecorderService()
                {
                    StopRecordingOnSilence = true,
                    StopRecordingAfterTimeout = true,
                    TotalAudioTimeout = TimeSpan.FromSeconds(5)
                };

                await Recorder.StartRecording();
                Recording = true;
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
                }
            }
            catch (Exception ex)
            {
                ErrorDialog page = new ErrorDialog() { Title = "Application Error", ReportedException = ex };
                await Navigation.PushModalAsync((Page)page, false);
            }
            finally
            {
                this.Recorder = null;
                Recording = false;
            }
        }
        
    }
}
