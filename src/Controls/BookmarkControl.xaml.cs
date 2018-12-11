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
            InitializeComponent();
        }
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

        #region CreateItemFactory - DP        
        public Func<object> CreateItemFactory
        {
            get { return (Func<object>)this.GetValue(CreateItemFactoryProperty); }
            set { this.SetValue(CreateItemFactoryProperty, value); }
        }

        public static readonly DependencyProperty CreateItemFactoryProperty = DependencyProperty.Register(
         "CreateItemFactory", typeof(Func<object>), typeof(BookmarkControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region CopyItemFunc - DP        
        public Func<object, object> CopyItemFunc
        {
            get { return (Func<object, object>)this.GetValue(CopyItemFuncProperty); }
            set { this.SetValue(CopyItemFuncProperty, value); }
        }

        public static readonly DependencyProperty CopyItemFuncProperty = DependencyProperty.Register(
         "CopyItemFunc", typeof(Func<object, object>), typeof(BookmarkControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion       
    }
}
