namespace daVinci.Controls
{
    #region Usings
    using leonardo.Resources;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für DavinciList.xaml
    /// </summary>
    public partial class DavinciList : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region ctor
        public DavinciList()
        {
            EditCommand = new RelayCommand<object>((selecteditem) =>
            {
                if (CopyItemFunc != null)
                {
                    SelectedItem = CopyItemFunc(selecteditem);
                    IsEditMode = SelectedItem != null;
                    ShowDetail = SelectedItem != null;
                }
            });

            ShowDetailCommand = new RelayCommand<object>((selecteditem) =>
            {
                ShowDetail = true;
                SelectedItem = selecteditem;
            });
            CloseDetailCommand = new RelayCommand<object>((selecteditem) =>
            {
                ShowDetail = false;
                IsEditMode = false;
                SelectedItem = null;
            });
            AbortEditCommand = new RelayCommand<object>((selecteditem) =>
            {
                ShowDetail = false;
                IsEditMode = false;
                SelectedItem = null;
            });
            ItemClickedCommand = new RelayCommand<object>((selecteditem) =>
            {
                ShowDetail = false;
                IsEditMode = false;
                SelectedItem = selecteditem;
                ItemSelectionCommand?.Execute(selecteditem);
            });
            OKCommand = new RelayCommand(() =>
            {
                if (newmode)
                {
                    NewItemCommand?.Execute(SelectedItem);
                }
                else if (IsEditMode)
                {
                    ChangedItemCommand?.Execute(SelectedItem);
                }
                ShowDetail = false;
                IsEditMode = false;
                newmode = false;
            });
            DeleteItemClickCommand = new RelayCommand<object>((todelete) =>
            {
                DeleteItemCommand?.Execute(todelete);
            });
            AbortEditCommand = new RelayCommand(() =>
            {
                ShowDetail = false;
                IsEditMode = false;
                SelectedItem = null;
                newmode = false;
            });
            NewItemClickCommand = new RelayCommand(() =>
            {
                object newone = null;
                if (CreateItemFactory != null)
                {
                    newone = CreateItemFactory();
                    newmode = true;
                    SelectedItem = newone;
                }
                if (newone != null)
                {
                    if (EditContent != null)
                    {
                        ShowDetail = true;
                        IsEditMode = true;
                    }
                    else
                    {
                        OKCommand?.Execute(newone);
                    }

                    SelectedItem = newone;

                }
                else
                {
                    newmode = false;
                    ShowDetail = false;
                    IsEditMode = false;
                    SelectedItem = null;
                }
            });
            InitializeComponent();
            DataContext = this;
        }
        #endregion

        #region Properties
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
        public ICommand SearchAcceptCommand { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public ICommand CloseDetailCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AbortEditCommand { get; set; }
        public ICommand ShowDetailCommand { get; set; }
        public ICommand NewItemClickCommand { get; set; }
        public ICommand DeleteItemClickCommand { get; set; }
        public ICommand OKCommand { get; set; }
        private bool newmode;
        private object itemToEdit;
        #endregion

        #region IsEditMode DP
        public bool IsEditMode
        {
            get { return (bool)this.GetValue(IsEditModeProperty); }
            set { this.SetValue(IsEditModeProperty, value); }
        }

        public static readonly DependencyProperty IsEditModeProperty = DependencyProperty.Register(
         "IsEditMode", typeof(bool), typeof(DavinciList), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion        

        #region ShowDetail DP
        public bool ShowDetail
        {
            get { return (bool)this.GetValue(ShowDetailProperty); }
            set { this.SetValue(ShowDetailProperty, value); }
        }

        public static readonly DependencyProperty ShowDetailProperty = DependencyProperty.Register(
         "ShowDetail", typeof(bool), typeof(DavinciList), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ShowEditIcon DP
        public bool ShowEditIcon
        {
            get { return (bool)this.GetValue(ShowEditIconProperty); }
            set { this.SetValue(ShowEditIconProperty, value); }
        }

        public static readonly DependencyProperty ShowEditIconProperty = DependencyProperty.Register(
         "ShowEditIcon", typeof(bool), typeof(DavinciList), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ShowInfoIcon DP
        public bool ShowInfoIcon
        {
            get { return (bool)this.GetValue(ShowInfoIconProperty); }
            set { this.SetValue(ShowInfoIconProperty, value); }
        }

        public static readonly DependencyProperty ShowInfoIconProperty = DependencyProperty.Register(
         "ShowInfoIcon", typeof(bool), typeof(DavinciList), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ShowDeleteIcon DP
        public bool ShowDeleteIcon
        {
            get { return (bool)this.GetValue(ShowDeleteIconProperty); }
            set { this.SetValue(ShowDeleteIconProperty, value); }
        }

        public static readonly DependencyProperty ShowDeleteIconProperty = DependencyProperty.Register(
         "ShowDeleteIcon", typeof(bool), typeof(DavinciList), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region AutoFocus DP
        public bool AutoFocus
        {
            get { return (bool)this.GetValue(AutoFocusProperty); }
            set { this.SetValue(AutoFocusProperty, value); }
        }

        public static readonly DependencyProperty AutoFocusProperty = DependencyProperty.Register(
         "AutoFocus", typeof(bool), typeof(DavinciList), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ItemSelectionCommand - DP        
        public ICommand ItemSelectionCommand
        {
            get { return (ICommand)this.GetValue(ItemSelectionCommandProperty); }
            set { this.SetValue(ItemSelectionCommandProperty, value); }
        }

        public static readonly DependencyProperty ItemSelectionCommandProperty = DependencyProperty.Register(
         "ItemSelectionCommand", typeof(ICommand), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region SelectedItem DP
        public object SelectedItem
        {
            get { return (object)this.GetValue(SelectedItemProperty); }
            set { this.SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
         "SelectedItem", typeof(object), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion        

        #region ListComparer - DP        
        public IComparer ListComparer
        {
            get { return (IComparer)this.GetValue(ListComparerProperty); }
            set { this.SetValue(ListComparerProperty, value); }
        }

        public static readonly DependencyProperty ListComparerProperty = DependencyProperty.Register(
         "ListComparer", typeof(IComparer), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ListFilter - DP        
        public ICollectionViewFilter ListFilter
        {
            get { return (ICollectionViewFilter)this.GetValue(ListFilterProperty); }
            set { this.SetValue(ListFilterProperty, value); }
        }

        public static readonly DependencyProperty ListFilterProperty = DependencyProperty.Register(
         "ListFilter", typeof(ICollectionViewFilter), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region SelectedItemName - DP        
        public string SelectedItemName
        {
            get { return (string)this.GetValue(SelectedItemNameProperty); }
            set { this.SetValue(SelectedItemNameProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemNameProperty = DependencyProperty.Register(
         "SelectedItemName", typeof(string), typeof(DavinciList), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ListHeader - DP        
        public string ListHeader
        {
            get { return (string)this.GetValue(ListHeaderProperty); }
            set { this.SetValue(ListHeaderProperty, value); }
        }

        public static readonly DependencyProperty ListHeaderProperty = DependencyProperty.Register(
         "ListHeader", typeof(string), typeof(DavinciList), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region AddItemText - DP        
        public string AddItemText
        {
            get { return (string)this.GetValue(AddItemTextProperty); }
            set { this.SetValue(AddItemTextProperty, value); }
        }

        public static readonly DependencyProperty AddItemTextProperty = DependencyProperty.Register(
         "AddItemText", typeof(string), typeof(DavinciList), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ItemsSource - DP        
        public object ItemsSource
        {
            get { return (object)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
         "ItemsSource", typeof(object), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region EditContent - DP        
        public FrameworkElement EditContent
        {
            get { return (FrameworkElement)this.GetValue(EditContentProperty); }
            set { this.SetValue(EditContentProperty, value); }
        }

        public static readonly DependencyProperty EditContentProperty = DependencyProperty.Register(
         "EditContent", typeof(FrameworkElement), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ListItemControlTemplate - DP        
        public object ListItemControlTemplate
        {
            get { return (object)this.GetValue(ListItemControlTemplateProperty); }
            set { this.SetValue(ListItemControlTemplateProperty, value); }
        }

        public static readonly DependencyProperty ListItemControlTemplateProperty = DependencyProperty.Register(
         "ListItemControlTemplate", typeof(object), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ItemToEdit - DP        
        public object ItemToEdit
        {
            get { return (object)this.GetValue(ItemToEditProperty); }
            set { this.SetValue(ItemToEditProperty, value); }
        }

        public static readonly DependencyProperty ItemToEditProperty = DependencyProperty.Register(
         "ItemToEdit", typeof(object), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region NewItemCommand - DP        
        public ICommand NewItemCommand
        {
            get { return (ICommand)this.GetValue(NewItemCommandProperty); }
            set { this.SetValue(NewItemCommandProperty, value); }
        }

        public static readonly DependencyProperty NewItemCommandProperty = DependencyProperty.Register(
         "NewItemCommand", typeof(ICommand), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ChangedItemCommand - DP        
        public ICommand ChangedItemCommand
        {
            get { return (ICommand)this.GetValue(ChangedItemCommandProperty); }
            set { this.SetValue(ChangedItemCommandProperty, value); }
        }

        public static readonly DependencyProperty ChangedItemCommandProperty = DependencyProperty.Register(
         "ChangedItemCommand", typeof(ICommand), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region DeleteItemCommand - DP        
        public ICommand DeleteItemCommand
        {
            get { return (ICommand)this.GetValue(DeleteItemCommandProperty); }
            set { this.SetValue(DeleteItemCommandProperty, value); }
        }

        public static readonly DependencyProperty DeleteItemCommandProperty = DependencyProperty.Register(
         "DeleteItemCommand", typeof(ICommand), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region CreateItemFactory - DP        
        public Func<object> CreateItemFactory
        {
            get { return (Func<object>)this.GetValue(CreateItemFactoryProperty); }
            set { this.SetValue(CreateItemFactoryProperty, value); }
        }

        public static readonly DependencyProperty CreateItemFactoryProperty = DependencyProperty.Register(
         "CreateItemFactory", typeof(Func<object>), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region CopyItemFunc - DP        
        public Func<object, object> CopyItemFunc
        {
            get { return (Func<object, object>)this.GetValue(CopyItemFuncProperty); }
            set { this.SetValue(CopyItemFuncProperty, value); }
        }

        public static readonly DependencyProperty CopyItemFuncProperty = DependencyProperty.Register(
         "CopyItemFunc", typeof(Func<object, object>), typeof(DavinciList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
