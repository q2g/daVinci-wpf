namespace daVinci.ConfigData.ThemeConfig
{
    #region Usings
    using System.Windows.Media;
    #endregion


    public class NewTheme : BaseTheme
    {
        public NewTheme()
        {
            const string DarkGreen = "#61A729";
            const string LightGreen = "#AABF12";
            const string Orange = "#F8981D";
            const string Red = "#F05555";
            const string DarkerGray = "#333333";
            const string DarkGray = "#4D4D4D";

            ThemeName = "Default";
            BusyCircleSpinnerColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGreen));
            BusyCircleRingColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6D7538"));
            HeaderBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkerGray));
            SidePaneBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkGray));
            UserInfoPassedTickForGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGreen));
            UserInfoFailedCrossForGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Red));
            UserInfoProgressBarForeGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGreen));
            UserInfoHeader1ForeGround = new SolidColorBrush(Colors.White);
            UserInfoHeader2ForeGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGreen));
            UserInfoBackGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkGray));
            UserInfoBlinkingBackGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Orange));
            UserInfoExpanderTickForeGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGreen));
            UserInfoBackGroundColorCode = DarkGray;
            UserInfoBlinkingBackGroundColorCode = Orange;
        }

    }
}
