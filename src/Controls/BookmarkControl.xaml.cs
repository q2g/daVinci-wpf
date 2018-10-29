namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData.Bookmark;
    using leonardo.Controls;
    using leonardo.Resources;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interop;
    using WPFLocalizeExtension.Engine;
    #endregion

    /// <summary>
    /// Interaction logic for BookmarkControl.xaml
    /// </summary>
    public partial class BookmarkControl : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
        public BookmarkControl()
        {
            SearchAcceptCommand = new RelayCommand((o) =>
            {
                if (SearchedItems.Count == 1)
                {
                    if (BookmarkSelectionCommand != null)
                    {
                        BookmarkSelectionCommand.Execute(SearchedItems[0]);
                    }
                }
            });
            InitializeComponent();
        }
        public ObservableCollection<object> SearchedItems { get; set; }
        public ICommand SearchAcceptCommand { get; set; }
        #region BookmarkSelectionCommand - DP        
        public ICommand BookmarkSelectionCommand
        {
            get { return (ICommand)this.GetValue(BookmarkSelectionCommandProperty); }
            set { this.SetValue(BookmarkSelectionCommandProperty, value); }
        }

        public static readonly DependencyProperty BookmarkSelectionCommandProperty = DependencyProperty.Register(
         "BookmarkSelectionCommand", typeof(ICommand), typeof(BookmarkControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region BookmarkNewCommand - DP        
        public ICommand BookmarkNewCommand
        {
            get { return (ICommand)this.GetValue(BookmarkNewCommandProperty); }
            set { this.SetValue(BookmarkNewCommandProperty, value); }
        }

        public static readonly DependencyProperty BookmarkNewCommandProperty = DependencyProperty.Register(
         "BookmarkNewCommand", typeof(ICommand), typeof(BookmarkControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region BookmarkChangedCommand - DP        
        public ICommand BookmarkChangedCommand
        {
            get { return (ICommand)this.GetValue(BookmarkChangedCommandProperty); }
            set { this.SetValue(BookmarkChangedCommandProperty, value); }
        }

        public static readonly DependencyProperty BookmarkChangedCommandProperty = DependencyProperty.Register(
         "BookmarkChangedCommand", typeof(ICommand), typeof(BookmarkControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region BookmarkDeleteCommand - DP        
        public ICommand BookmarkDeleteCommand
        {
            get { return (ICommand)this.GetValue(BookmarkDeleteCommandProperty); }
            set { this.SetValue(BookmarkDeleteCommandProperty, value); }
        }

        public static readonly DependencyProperty BookmarkDeleteCommandProperty = DependencyProperty.Register(
         "BookmarkDeleteCommand", typeof(ICommand), typeof(BookmarkControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region IsEditMode DP
        public bool IsEditMode
        {
            get { return (bool)this.GetValue(IsEditModeProperty); }
            set { this.SetValue(IsEditModeProperty, value); }
        }

        public static readonly DependencyProperty IsEditModeProperty = DependencyProperty.Register(
         "IsEditMode", typeof(bool), typeof(BookmarkControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region BookmarkToEdit DP
        public BookmarkData BookmarkToEdit
        {
            get { return (BookmarkData)this.GetValue(BookmarkToEditProperty); }
            set { this.SetValue(BookmarkToEditProperty, value); }
        }

        public static readonly DependencyProperty BookmarkToEditProperty = DependencyProperty.Register(
         "BookmarkToEdit", typeof(BookmarkData), typeof(BookmarkControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ShowDetail DP
        public bool ShowDetail
        {
            get { return (bool)this.GetValue(ShowDetailProperty); }
            set { this.SetValue(ShowDetailProperty, value); }
        }

        public static readonly DependencyProperty ShowDetailProperty = DependencyProperty.Register(
         "ShowDetail", typeof(bool), typeof(BookmarkControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region SelectedBookmark DP
        public BookmarkData SelectedBookmark
        {
            get { return (BookmarkData)this.GetValue(SelectedBookmarkProperty); }
            set { this.SetValue(SelectedBookmarkProperty, value); }
        }

        public static readonly DependencyProperty SelectedBookmarkProperty = DependencyProperty.Register(
         "SelectedBookmark", typeof(BookmarkData), typeof(BookmarkControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Properties
        public IntPtr? Owner { get; set; }

        private string searchtext;
        public string SearchText
        {
            get { return searchtext; }
            set
            {
                if (searchtext != value)
                {
                    searchtext = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        private bool isNewMode;
        private BookmarkData toEdit;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isNewMode)
            {
                isNewMode = false;
                IsEditMode = false;
                if (DataContext is ObservableCollection<BookmarkData> list)
                {
                    list.Add(toEdit);
                    if (BookmarkNewCommand != null)
                    {
                        BookmarkNewCommand.Execute(toEdit);
                    }
                }
                SelectedBookmark = toEdit;
            }
            else
            {
                SelectedBookmark.CopyFrom(toEdit);
                BookmarkChangedCommand?.Execute(toEdit);
                IsEditMode = false;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (isNewMode)
                ShowDetail = false;
            toEdit = null;
            isNewMode = false;
            IsEditMode = false;
        }

        private void EditButton_MouseDown(object sender, RoutedEventArgs e)
        {
            if (SetSelectedBookmark(sender))
            {
                toEdit = new BookmarkData();
                toEdit.CopyFrom(SelectedBookmark);
                BookmarkToEdit = toEdit;
                IsEditMode = true;
                e.Handled = true;
            }
        }

        private void Info_MouseDown(object sender, RoutedEventArgs e)
        {
            if (SetSelectedBookmark(sender))
            {
                if (!ShowDetail)
                {
                    e.Handled = true;
                }
                e.Handled = true;
            }
        }

        private bool SetSelectedBookmark(object senderControl)
        {
            if (senderControl is FrameworkElement sendercontrol)
            {
                if (sendercontrol.DataContext is BookmarkData bmdata)
                {
                    SelectedBookmark = bmdata;
                    ShowDetail = true;
                    return true;
                }
            }
            return false;
        }

        private void Listbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CancelButton_Click(sender, e);
            ShowDetail = false;
            SelectedBookmark = null;
        }

        private void NewBookmarkButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<BookmarkData> list)
            {
                isNewMode = true;
                toEdit = new BookmarkData() { BookmarkCreated = DateTime.Now };
                SelectedBookmark = toEdit;
                BookmarkToEdit = toEdit;
                IsEditMode = true;
                ShowDetail = true;
            }
        }

        private void MenuDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement source)
            {
                if (source.DataContext is BookmarkData data)
                {
                    RemoveBookmark(data);
                }
            }
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CloseButton_Click(sender, new RoutedEventArgs());
        }

        private void DeleteButton_MouseDown(object sender, RoutedEventArgs e)
        {
            SetSelectedBookmark(sender);
            if (SelectedBookmark != null)
            {
                RemoveBookmark(SelectedBookmark);
            }
            e.Handled = true;
        }

        private void DetailDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBookmark != null)
            {
                RemoveBookmark(SelectedBookmark);
            }
        }
        private void RemoveBookmark(BookmarkData bookmark)
        {
            if (LuiMessageBox.ShowDialog(string.Format((string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_client:Hub_Confirm_Delete_Description", null, LocalizeDictionary.Instance.Culture)) ?? (string)(LocalizeDictionary.Instance.GetLocalizedObject("akquinet-sense-excel:SenseExcelRibbon:ConnectionEdit_DeleteBookmark", null, LocalizeDictionary.Instance.Culture))
                , SelectedBookmark.BookmarkName), ownerPtr: Owner ?? null))
            {
                if (DataContext is ObservableCollection<BookmarkData> list)
                {
                    list.Remove(bookmark);
                    BookmarkDeleteCommand?.Execute(bookmark);
                    CancelButton_Click(this, new RoutedEventArgs());
                    ShowDetail = false;
                }
            }
            else
            {
                BookmarkDeleteCommand?.Execute(null);
            }
        }

        private void DetailEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBookmark != null)
            {
                toEdit = new BookmarkData();
                toEdit.CopyFrom(SelectedBookmark);
                BookmarkToEdit = toEdit;
                IsEditMode = true;
            }
        }
    }
}
