namespace daVinci.Controls
{
    using daVinci.ConfigData.Hub;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #region Usings
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaction logic for UploadTemplateControl.xaml
    /// </summary>
    public partial class UploadTemplateControl : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
        #region CTOR
        public UploadTemplateControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties &Variables
        public List<TemplateData> Libraries { get; set; } = new List<TemplateData>();

        private string filename;
        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
                RaisePropertyChanged();
            }
        }

        private TemplateData selectedLibrary;
        public TemplateData SelectedLibrary
        {
            get
            {
                return selectedLibrary;
            }
            set
            {
                selectedLibrary = value;
                RaisePropertyChanged();
            }
        }
        private bool isOverwrite;
        public bool IsOverwrite
        {
            get
            {
                return isOverwrite;
            }
            set
            {
                isOverwrite = value;
                RaisePropertyChanged();
            }
        }
        private bool showOverrideWarning;
        public bool ShowOverrideWarning
        {
            get
            {
                return showOverrideWarning;
            }
            set
            {
                showOverrideWarning = value;
                RaisePropertyChanged();
            }
        }
        private bool saveTemplateCommandEnabled = true;
        public bool SaveTemplateCommandEnabled
        {
            get
            {
                return saveTemplateCommandEnabled;
            }
            set
            {
                saveTemplateCommandEnabled = value;
                RaisePropertyChanged();
            }
        }
        public ICommand SaveTemplateCommand { get; set; }

        private bool saveWorking;
        public bool SaveWorking
        {
            get
            {
                return saveWorking;
            }
            set
            {
                saveWorking = value;
                RaisePropertyChanged();
            }
        }
        public int SaveState
        {
            set
            {
                switch (value)
                {
                    case 0:
                        SaveFailed = false;
                        SaveFinished = false;
                        SaveWorking = false;
                        break;
                    case 1:
                        SaveFailed = false;
                        SaveFinished = false;
                        SaveWorking = true;
                        break;
                    case 2:
                        SaveFailed = true;
                        SaveFinished = false;
                        SaveWorking = false;
                        break;
                    case 3:
                        SaveFailed = false;
                        SaveFinished = true;
                        SaveWorking = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public int UploadState
        {
            set
            {
                switch (value)
                {
                    case 0:
                        UploadFailed = false;
                        UploadFinished = false;
                        UploadWorking = false;
                        break;
                    case 1:
                        UploadFailed = false;
                        UploadFinished = false;
                        UploadWorking = true;
                        break;
                    case 2:
                        UploadFailed = true;
                        UploadFinished = false;
                        UploadWorking = false;
                        break;
                    case 3:
                        UploadFailed = false;
                        UploadFinished = true;
                        UploadWorking = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private bool saveFailed;
        public bool SaveFailed
        {
            get
            {
                return saveFailed;
            }
            set
            {
                saveFailed = value;
                RaisePropertyChanged();
            }
        }
        private bool saveFinished;
        public bool SaveFinished
        {
            get
            {
                return saveFinished;
            }
            set
            {
                saveFinished = value;
                RaisePropertyChanged();
            }
        }

        private bool uploadWorking;
        public bool UploadWorking
        {
            get
            {
                return uploadWorking;
            }
            set
            {
                uploadWorking = value;
                RaisePropertyChanged();
            }
        }
        private bool uploadFailed;
        public bool UploadFailed
        {
            get
            {
                return uploadFailed;
            }
            set
            {
                uploadFailed = value;
                RaisePropertyChanged();
            }
        }
        private bool uploadFinished;
        public bool UploadFinished
        {
            get
            {
                return uploadFinished;
            }
            set
            {
                uploadFinished = value;
                RaisePropertyChanged();
            }
        }
    }
    #endregion
}
