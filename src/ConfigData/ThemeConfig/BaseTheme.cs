namespace daVinci.ConfigData.ThemeConfig
{
    using System.Collections.Generic;
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;
    #endregion


    public class BaseTheme : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Singleton
        private static BaseTheme instance;
        public static BaseTheme Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BaseTheme();
                    instance.CurrentTheme = AvailableThemes[0];
                }
                return instance;
            }
        }
        #endregion


        #region Properties
        private string themeName;
        public string ThemeName
        {
            get
            {
                return themeName;
            }
            set
            {
                if (themeName != value)
                {
                    themeName = value;
                    RaisePropertyChanged();
                }
            }
        }


        private BaseTheme currentTheme;
        public BaseTheme CurrentTheme
        {
            get
            {
                return currentTheme;
            }

            set
            {
                if (currentTheme != value)
                {
                    currentTheme = value;
                }
            }
        }
        private static List<BaseTheme> availableThemes;
        public static List<BaseTheme> AvailableThemes
        {
            get
            {
                if (availableThemes == null)
                {
                    availableThemes = new List<BaseTheme>()
                    {
                        new NewTheme(),
                        new ClassicTheme()
                    };
                }
                return availableThemes;
            }
        }


        public SolidColorBrush BusyCircleSpinnerColor { get; set; }
        public SolidColorBrush BusyCircleRingColor { get; set; }
        public SolidColorBrush HeaderBackground { get; set; }
        public SolidColorBrush SidePaneBackground { get; set; }
        public SolidColorBrush UserInfoPassedTickForGround { get; set; }
        public SolidColorBrush UserInfoFailedCrossForGround { get; set; }
        public SolidColorBrush UserInfoProgressBarForeGround { get; set; }
        public SolidColorBrush UserInfoProgressBarBackGround { get; set; }
        public SolidColorBrush UserInfoHeader1ForeGround { get; set; }
        public SolidColorBrush UserInfoHeader2ForeGround { get; set; }
        public SolidColorBrush UserInfoBackGround { get; set; }
        public SolidColorBrush UserInfoBlinkingBackGround { get; set; }
        public SolidColorBrush UserInfoExpanderTickForeGround { get; set; }
        public string UserInfoBackGroundColorCode { get; set; }
        public string UserInfoBlinkingBackGroundColorCode { get; set; }
        public SolidColorBrush UserInfoBorderBrush { get; set; }
        #endregion

    }
}