using daVinci_wpf.ConfigData.Bookmark;
using leonardo.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
         "SelectedApp", typeof(BookmarkData), typeof(BookmarkControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
                BookmarkView.BookmarkToEdit = toEdit;
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
                BookmarkView.BookmarkToEdit = toEdit;
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
                    if (LuiMessageBox.ShowDialog(string.Format((string)(LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_client:Hub_Confirm_Delete_Description", null, LocalizeDictionary.Instance.Culture)), data.BookmarkName)) == true)
                    {
                        if (DataContext is ObservableCollection<BookmarkData> list)
                        {
                            list.Remove(data);
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
            SetSelectedBookmark(sender);
            if (SelectedBookmark != null)
            {
                if (LuiMessageBox.ShowDialog(string.Format((string)(LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_client:Hub_Confirm_Delete_Description", null, LocalizeDictionary.Instance.Culture)), SelectedBookmark.BookmarkName)) == true)
                {
                    if (DataContext is ObservableCollection<BookmarkData> list)
                    {
                        list.Remove(SelectedBookmark);
                        CancelButton_Click(sender, e);
                        ShowDetail = false;
                    }
                }
            }
        }

        private void DetailDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBookmark != null)
            {
                if (LuiMessageBox.ShowDialog(string.Format((string)(LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_client:Hub_Confirm_Delete_Description", null, LocalizeDictionary.Instance.Culture)), SelectedBookmark.BookmarkName)) == true)
                {
                    if (DataContext is ObservableCollection<BookmarkData> list)
                    {
                        list.Remove(SelectedBookmark);
                        CancelButton_Click(sender, e);
                        ShowDetail = false;
                    }
                }
            }
        }

        private void DetailEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBookmark != null)
            {
                toEdit = new BookmarkData();
                toEdit.CopyFrom(SelectedBookmark);
                BookmarkView.BookmarkToEdit = toEdit;
                IsEditMode = true;
            }
        }


    }
}
