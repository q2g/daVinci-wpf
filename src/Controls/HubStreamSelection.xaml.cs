namespace daVinci.Controls
{
    #region Usings
    using NLog;
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Controls;
    using System.Collections.ObjectModel; 
    #endregion
    /// <summary>
    /// Interaction logic for HubStreamSelection.xaml
    /// </summary>
    public partial class HubStreamSelection : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HubStreamSelection()
        {
            InitializeComponent();
        }

        #region SelectedPersonalItem - DP        
        internal object SelectedPersonalItem
        {
            get { return (object)this.GetValue(SelectedPersonalItemProperty); }
            set { this.SetValue(SelectedPersonalItemProperty, value); }
        }

        internal static readonly DependencyProperty SelectedPersonalItemProperty = DependencyProperty.Register(
         "SelectedPersonalItem", typeof(object), typeof(HubStreamSelection), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(SelectedPersonalItemChanged)));

        private static void SelectedPersonalItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is HubStreamSelection obj)
                {
                    if (e.NewValue != null)
                    {
                        obj.SelectedStreamItem = null;
                        obj.SelectedStream = e.NewValue;
                    }

                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
        #endregion

        #region SelectedStreamItem - DP        
        internal object SelectedStreamItem
        {
            get { return (object)this.GetValue(SelectedStreamItemProperty); }
            set { this.SetValue(SelectedStreamItemProperty, value); }
        }

        internal static readonly DependencyProperty SelectedStreamItemProperty = DependencyProperty.Register(
         "SelectedStreamItem", typeof(object), typeof(HubStreamSelection), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(SelectedStreamItemChanged)));

        private static void SelectedStreamItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is HubStreamSelection obj)
                {
                    if (e.NewValue != null)
                    {
                        obj.SelectedPersonalItem = null;
                        obj.SelectedStream = e.NewValue;
                    }

                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
        #endregion

        #region SelectedStream - DP        
        public object SelectedStream
        {
            get { return (object)this.GetValue(SelectedStreamProperty); }
            set { this.SetValue(SelectedStreamProperty, value); }
        }

        public static readonly DependencyProperty SelectedStreamProperty = DependencyProperty.Register(
         "SelectedStream", typeof(object), typeof(HubStreamSelection), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion


        #region Streams - DP        
        public ObservableCollection<object> Streams
        {
            get { return (ObservableCollection<object>)this.GetValue(StreamsProperty); }
            set { this.SetValue(StreamsProperty, value); }
        }

        public static readonly DependencyProperty StreamsProperty = DependencyProperty.Register(
         "Streams", typeof(ObservableCollection<object>), typeof(HubStreamSelection), new FrameworkPropertyMetadata(new ObservableCollection<object>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region PersonalStreams - DP        
        public ObservableCollection<object> PersonalStreams
        {
            get { return (ObservableCollection<object>)this.GetValue(PersonalStreamsProperty); }
            set { this.SetValue(PersonalStreamsProperty, value); }
        }

        public static readonly DependencyProperty PersonalStreamsProperty = DependencyProperty.Register(
         "PersonalStreams", typeof(ObservableCollection<object>), typeof(HubStreamSelection), new FrameworkPropertyMetadata(new ObservableCollection<object>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        //route Event to Parent
        private void ListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
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
