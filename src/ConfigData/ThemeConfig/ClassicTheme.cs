namespace daVinci.ConfigData.ThemeConfig
{
    #region Usings
    using leonardo.Resources;
    using System.Windows.Media;
    #endregion

    public class ClassicTheme : BaseTheme
    {
        public ClassicTheme()
        {
            ThemeName = "Classic";
            BusyCircleSpinnerColor = new SolidColorBrush(Colors.White);
            BusyCircleRingColor = new SolidColorBrush(Colors.Black);
            HeaderBackground = new SolidColorBrush(LuiPalette.Colors.GRAYSCALE20);
            SidePaneBackground = new SolidColorBrush(LuiPalette.Colors.GRAYSCALE30);
            UserInfoPassedTickForGround = new SolidColorBrush(LuiPalette.Colors.GREEN);
            UserInfoFailedCrossForGround = new SolidColorBrush(LuiPalette.Colors.RED);
            UserInfoFailedCrossForGround = new SolidColorBrush(LuiPalette.Colors.GREEN);
            UserInfoProgressBarForeGround = new SolidColorBrush(Colors.White);
            UserInfoHeader1ForeGround = new SolidColorBrush(Colors.Black);
            UserInfoHeader2ForeGround = new SolidColorBrush(LuiPalette.Colors.GREEN);
            UserInfoBackGround = new SolidColorBrush(LuiPalette.Colors.GRAYSCALE95);
            UserInfoBlinkingBackGround = new SolidColorBrush(LuiPalette.Colors.ORANGE);
            UserInfoExpanderTickForeGround = new SolidColorBrush(Colors.Black);
            UserInfoBackGroundColorCode = "#F2F2F2";
            UserInfoBlinkingBackGroundColorCode = "#f8981d";
        }
    }
}
