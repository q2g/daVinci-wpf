using daVinci.ConfigData.Connection;
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

namespace daVinci.Controls
{
    /// <summary>
    /// Interaktionslogik für ConnectionEditor.xaml
    /// </summary>
    public partial class ConnectionEditor : UserControl
    {
        public ConnectionEditor()
        {
            InitializeComponent();
        }
        #region ConnectionSelectionCommand - DP        
        public ICommand ConnectionSelectionCommand
        {
            get { return (ICommand)this.GetValue(ConnectionSelectionCommandProperty); }
            set { this.SetValue(ConnectionSelectionCommandProperty, value); }
        }

        public static readonly DependencyProperty ConnectionSelectionCommandProperty = DependencyProperty.Register(
         "ConnectionSelectionCommand", typeof(ICommand), typeof(ConnectionEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ConnectionNewCommand - DP        
        public ICommand ConnectionNewCommand
        {
            get { return (ICommand)this.GetValue(ConnectionNewCommandProperty); }
            set { this.SetValue(ConnectionNewCommandProperty, value); }
        }

        public static readonly DependencyProperty ConnectionNewCommandProperty = DependencyProperty.Register(
         "ConnectionNewCommand", typeof(ICommand), typeof(ConnectionEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ConnectionChangedCommand - DP        
        public ICommand ConnectionChangedCommand
        {
            get { return (ICommand)this.GetValue(ConnectionChangedCommandProperty); }
            set { this.SetValue(ConnectionChangedCommandProperty, value); }
        }

        public static readonly DependencyProperty ConnectionChangedCommandProperty = DependencyProperty.Register(
         "ConnectionChangedCommand", typeof(ICommand), typeof(ConnectionEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ConnectionDeleteCommand - DP        
        public ICommand ConnectionDeleteCommand
        {
            get { return (ICommand)this.GetValue(ConnectionDeleteCommandProperty); }
            set { this.SetValue(ConnectionDeleteCommandProperty, value); }
        }

        public static readonly DependencyProperty ConnectionDeleteCommandProperty = DependencyProperty.Register(
         "ConnectionDeleteCommand", typeof(ICommand), typeof(ConnectionEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region IsEditMode DP
        public bool IsEditMode
        {
            get { return (bool)this.GetValue(IsEditModeProperty); }
            set { this.SetValue(IsEditModeProperty, value); }
        }

        public static readonly DependencyProperty IsEditModeProperty = DependencyProperty.Register(
         "IsEditMode", typeof(bool), typeof(ConnectionEditor), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ConnectionToEdit DP
        public ConnectionData ConnectionToEdit
        {
            get { return (ConnectionData)this.GetValue(ConnectionToEditProperty); }
            set { this.SetValue(ConnectionToEditProperty, value); }
        }

        public static readonly DependencyProperty ConnectionToEditProperty = DependencyProperty.Register(
         "ConnectionToEdit", typeof(ConnectionData), typeof(ConnectionEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ShowDetail DP
        public bool ShowDetail
        {
            get { return (bool)this.GetValue(ShowDetailProperty); }
            set { this.SetValue(ShowDetailProperty, value); }
        }

        public static readonly DependencyProperty ShowDetailProperty = DependencyProperty.Register(
         "ShowDetail", typeof(bool), typeof(ConnectionEditor), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region SelectedConnection DP
        public ConnectionData SelectedConnection
        {
            get { return (ConnectionData)this.GetValue(SelectedConnectionProperty); }
            set { this.SetValue(SelectedConnectionProperty, value); }
        }

        public static readonly DependencyProperty SelectedConnectionProperty = DependencyProperty.Register(
         "SelectedConnection", typeof(ConnectionData), typeof(ConnectionEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Properties
        public IntPtr? Owner { get; set; }
        #endregion

        private bool isNewMode;
        private ConnectionData toEdit;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isNewMode)
            {
                isNewMode = false;
                IsEditMode = false;
                if (DataContext is ObservableCollection<ConnectionData> list)
                {
                    if (string.IsNullOrEmpty(toEdit.IDName) && toEdit.URI != null)
                    {
                        toEdit.IDName = toEdit.URI.ToString();
                    }

                    list.Add(toEdit);
                    if (ConnectionNewCommand != null)
                    {
                        ConnectionNewCommand.Execute(toEdit);
                    }
                }
                SelectedConnection = toEdit;

            }
            else
            {
                SelectedConnection.CopyFrom(ConnectionToEdit);
                ConnectionChangedCommand?.Execute(SelectedConnection);
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
            if (SetSelectedConnection(sender))
            {
                toEdit = new ConnectionData();
                toEdit.CopyFrom(SelectedConnection);
                ConnectionToEdit = toEdit;
                IsEditMode = true;
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            if (SetSelectedConnection(sender))
            {
                if (!ShowDetail)
                {
                    e.Handled = true;
                }
            }
        }

        private bool SetSelectedConnection(object senderControl)
        {
            if (senderControl is FrameworkElement sendercontrol)
            {
                if (sendercontrol.DataContext is ConnectionData bmdata)
                {
                    ConnectionToEdit = bmdata;
                    SelectedConnection = bmdata;
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
            SelectedConnection = null;
        }

        private void NewConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<ConnectionData> list)
            {
                isNewMode = true;
                toEdit = new ConnectionData();
                SelectedConnection = toEdit;
                ConnectionToEdit = toEdit;
                UriInput_TextChanged(UriInput, null);
                IsEditMode = true;
                ShowDetail = true;
            }
        }

        private void MenuDeleteItem_Click(object sender, RoutedEventArgs e)
        {

            if (sender is FrameworkElement source)
            {
                if (source.DataContext is ConnectionData data)
                {
                    RemoveConnection(data);
                }
            }
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CloseButton_Click(sender, new RoutedEventArgs());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SetSelectedConnection(sender);
            if (SelectedConnection != null)
            {
                RemoveConnection(SelectedConnection);
            }
        }

        private void DetailDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedConnection != null)
            {
                RemoveConnection(SelectedConnection);
            }
        }
        private void RemoveConnection(ConnectionData Connection)
        {
            if (LuiMessageBox.ShowDialog(string.Format("Do you realy want to remove the Connection'{0}'?", SelectedConnection.IDName), ownerPtr: Owner ?? null))
            {
                if (DataContext is ObservableCollection<ConnectionData> list)
                {
                    list.Remove(Connection);
                    ConnectionDeleteCommand?.Execute(Connection);
                    CancelButton_Click(this, new RoutedEventArgs());
                    ShowDetail = false;
                }
            }
            else
            {
                ConnectionDeleteCommand?.Execute(null);
            }
        }

        private void DetailEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedConnection != null)
            {
                toEdit = new ConnectionData();
                toEdit.CopyFrom(SelectedConnection);
                ConnectionToEdit = toEdit;
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

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SetSelectedConnection(sender))
            {
                if (!ShowDetail)
                {
                    e.Handled = true;
                }
            }
        }



        private void UriInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            OKButton.IsEnabled = !string.IsNullOrEmpty((sender as LuiInput).Text) && Uri.TryCreate((sender as LuiInput).Text, UriKind.Absolute, out var dummy);
        }
    }
}
