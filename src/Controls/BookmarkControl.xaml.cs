namespace daVinci.Controls
{
    #region Usings
    using System;
    using System.Windows;
    using leonardo.Controls;
    using System.Windows.Input;
    using System.Windows.Controls;
    using daVinci.ConfigData.Bookmark;
    using WPFLocalizeExtension.Engine;
    using System.Collections.ObjectModel;
    #endregion

    /// <summary>
    /// Interaction logic for BookmarkControl.xaml
    /// </summary>
    public partial class BookmarkControl : UserControl
    {
        public BookmarkControl()
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
                }
                SelectedBookmark = toEdit;

            }
            else
            {
                SelectedBookmark.CopyFrom(toEdit);
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
            if (SetSelectedBookmark(sender))
            {
                toEdit = new BookmarkData();
                toEdit.CopyFrom(SelectedBookmark);
                BookmarkToEdit = toEdit;
                IsEditMode = true;
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            if (SetSelectedBookmark(sender))
            {
                if (!ShowDetail)
                {
                    e.Handled = true;
                }
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
            CancelButton_Click(sender, e);
            ShowDetail = false;
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SetSelectedBookmark(sender);
            if (SelectedBookmark != null)
            {
                RemoveBookmark(SelectedBookmark);
            }
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
            if (System.Windows.MessageBox.Show(string.Format((string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_client:Hub_Confirm_Delete_Description", null, LocalizeDictionary.Instance.Culture)) ?? "Do you realy want to remove the Bookmark'{0}'?", SelectedBookmark.BookmarkName), "Delete Bookmark", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                if (DataContext is ObservableCollection<BookmarkData> list)
                {
                    list.Remove(bookmark);
                    CancelButton_Click(this, new RoutedEventArgs());
                    ShowDetail = false;
                }
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

        // route event to parent
        private void li_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is ListBox && !e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                {
                    RoutedEvent = UIElement.MouseWheelEvent,
                    Source = sender
                };
                if (sender is Control sendercontrol)
                {
                    if (sendercontrol.Parent is UIElement parent)
                    {
                        parent.RaiseEvent(eventArg);
                    }
                }
            }
        }
    }
}
