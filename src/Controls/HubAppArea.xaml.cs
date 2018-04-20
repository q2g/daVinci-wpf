using daVinci.ConfigData;
using daVinci.ConfigData.Hub;
using leonardo.Controls;
using leonardo.Resources;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFLocalizeExtension.Engine;

namespace daVinci.Controls
{
    /// <summary>
    /// Interaction logic for HubAppArea.xaml
    /// </summary>
    public partial class HubAppArea : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HubAppArea()
        {
            InitializeComponent();
        }

        #region IsEditMode DP
        public bool IsEditMode
        {
            get { return (bool)this.GetValue(IsEditModeProperty); }
            set { this.SetValue(IsEditModeProperty, value); }
        }

        public static readonly DependencyProperty IsEditModeProperty = DependencyProperty.Register(
         "IsEditMode", typeof(bool), typeof(HubAppArea), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ShowDetail DP
        public bool ShowDetail
        {
            get { return (bool)this.GetValue(ShowDetailProperty); }
            set { this.SetValue(ShowDetailProperty, value); }
        }

        public static readonly DependencyProperty ShowDetailProperty = DependencyProperty.Register(
         "ShowDetail", typeof(bool), typeof(HubAppArea), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region SelectedApp DP
        public AppData SelectedApp
        {
            get { return (AppData)this.GetValue(SelectedAppProperty); }
            set { this.SetValue(SelectedAppProperty, value); }
        }

        public static readonly DependencyProperty SelectedAppProperty = DependencyProperty.Register(
         "SelectedApp", typeof(AppData), typeof(HubAppArea), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region LastSelectedAppID DP
        public string LastSelectedAppID
        {
            get { return (string)this.GetValue(LastSelectedAppIDProperty); }
            set { this.SetValue(LastSelectedAppIDProperty, value); }
        }

        public static readonly DependencyProperty LastSelectedAppIDProperty = DependencyProperty.Register(
         "LastSelectedAppID", typeof(string), typeof(HubAppArea), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region AppSelectionCommand - DP        
        public ICommand AppSelectionCommand
        {
            get { return (ICommand)this.GetValue(AppSelectionCommandProperty); }
            set { this.SetValue(AppSelectionCommandProperty, value); }
        }

        public static readonly DependencyProperty AppSelectionCommandProperty = DependencyProperty.Register(
         "AppSelectionCommand", typeof(ICommand), typeof(HubAppArea), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        private bool isNewMode;
        private AppData toEdit;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isNewMode)
            {
                isNewMode = false;
                IsEditMode = false;
                if (DataContext is StreamData stream)
                {
                    stream.Apps.Add(toEdit);
                }
                SelectedApp = toEdit;

            }
            else
            {
                SelectedApp.CopyFrom(toEdit);
                IsEditMode = false;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            toEdit = null;
            isNewMode = false;
            IsEditMode = false;

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            toEdit = new AppData();
            toEdit.CopyFrom(SelectedApp);
            AppView.AppToEdit = toEdit;
            IsEditMode = true;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (sender is FrameworkElement sendercontrol)
                {
                    if (sendercontrol.DataContext is AppData appdata)
                    {

                        if (!ShowDetail)
                        {
                            SelectedApp = appdata;
                            ShowDetail = true;
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void itemsControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CancelButton_Click(sender, e);
            ShowDetail = false;
            e.Handled = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CancelButton_Click(sender, e);
            ShowDetail = false;
            SelectedApp = null;
        }

        private void NewAppButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is StreamData stream)
            {
                isNewMode = true;
                toEdit = new AppData() { Created = DateTime.Now };
                SelectedApp = toEdit;
                AppView.AppToEdit = toEdit;
                IsEditMode = true;
                ShowDetail = true;
            }

        }

        private void MenuDeleteItem_Click(object sender, RoutedEventArgs e)
        {

            if (sender is FrameworkElement source)
            {
                if (source.DataContext is AppData data)
                {
                    if (LuiMessageBox.ShowDialog(string.Format((string)(LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_client:Hub_Confirm_Delete_Description", null, LocalizeDictionary.Instance.Culture)), data.AppName)) == true)
                    {
                        if (DataContext is StreamData stream)
                        {
                            stream.Apps.Remove(data);
                        }
                    }
                }
            }
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CloseButton_Click(sender, new RoutedEventArgs());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedApp != null)
            {
                if (LuiMessageBox.ShowDialog(string.Format((string)(LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_client:Hub_Confirm_Delete_Description", null, LocalizeDictionary.Instance.Culture)), SelectedApp.AppName)) == true)
                {
                    if (DataContext is StreamData stream)
                    {
                        stream.Apps.Remove(SelectedApp);
                    }
                }
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (sender is FrameworkElement sendercontrol)
                {
                    if (sendercontrol.DataContext is AppData appdata)
                    {
                        AppSelectionCommand?.Execute(appdata);
                    }
                }
            }
        }

        private void HubAppDataView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (sender is FrameworkElement sendercontrol)
                {
                    if (sendercontrol.DataContext is AppData appdata)
                    {
                        AppSelectionCommand?.Execute(appdata);
                    }
                }
            }
        }
    }
}
