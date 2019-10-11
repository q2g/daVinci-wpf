namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData;
    using daVinci.ConfigData.Hub;
    using leonardo.Controls;
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using WPFLocalizeExtension.Engine;
    #endregion

    /// <summary>
    /// Interaction logic for HubAppArea.xaml
    /// </summary>
    public partial class HubAppArea : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HubAppArea()
        {
            SearchAcceptCommand = new RelayCommand((o) =>
            {
                if (SearchedItems.Count == 1)
                {
                    if (AppSelectionCommand != null)
                    {
                        AppSelectionCommand.Execute(SearchedItems[0]);
                    }
                }
            });
            InitializeComponent();
        }
        public ObservableCollection<object> SearchedItems { get; set; }
        public ICommand SearchAcceptCommand { get; set; }
        public ICommand LoadTemplatesCommand { get; set; }

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

        #region AppToEdit DP
        public AppData AppToEdit
        {
            get { return (AppData)this.GetValue(AppToEditProperty); }
            set { this.SetValue(AppToEditProperty, value); }
        }

        public static readonly DependencyProperty AppToEditProperty = DependencyProperty.Register(
         "AppToEdit", typeof(AppData), typeof(HubAppArea), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
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

        #region HubData - DP
        public HubData HubData
        {
            get { return (HubData)this.GetValue(HubDataProperty); }
            set { this.SetValue(HubDataProperty, value); }
        }

        public static readonly DependencyProperty HubDataProperty = DependencyProperty.Register(
         "HubData", typeof(HubData), typeof(HubAppArea), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Owner DP
        public IntPtr? Owner
        {
            get { return (IntPtr?)this.GetValue(OwnerProperty); }
            set { this.SetValue(OwnerProperty, value); }
        }

        public static readonly DependencyProperty OwnerProperty = DependencyProperty.Register(
         "Owner", typeof(IntPtr?), typeof(HubAppArea), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
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
            AppToEdit = toEdit;
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
                AppToEdit = toEdit;
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
                    DeleteApp(data);
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
                DeleteApp(SelectedApp);
            }
        }

        private void DeleteApp(AppData appdata)
        {
            if (LuiMessageBox.ShowDialog(string.Format((string)(LocalizeDictionary.Instance.GetLocalizedObject("akquinet-sense-excel:SenseExcelRibbon:Hub_Confirm_Delete_Description", null, LocalizeDictionary.Instance.Culture)) ?? "Delete App {0}?", SelectedApp.AppName), ownerPtr: Owner ?? null))
            {
                if (DataContext is StreamData stream)
                {
                    stream.Apps.Remove(appdata);
                    ShowDetail = false;
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
