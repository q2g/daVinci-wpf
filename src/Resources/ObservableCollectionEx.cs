using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci_wpf.Resources
{
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        public void RaiseCollectionChanged()
        {
            OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Replace));
        }
    }
}
