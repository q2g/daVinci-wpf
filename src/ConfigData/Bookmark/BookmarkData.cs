using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci_wpf.ConfigData.Bookmark
{
    public class BookmarkData : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        private string bmName;
        public string BookmarkName
        {
            get
            {
                return bmName;
            }
            set
            {
                if (bmName != value)
                {
                    bmName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string bmDescription;
        public string BookmarkDescription
        {
            get
            {
                return bmDescription;
            }
            set
            {
                if (bmDescription != value)
                {
                    bmDescription = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string bmSelection;
        public string BookmarSelection
        {
            get
            {
                return bmSelection;
            }
            set
            {
                if (bmSelection != value)
                {
                    bmSelection = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string bmBelongsTo;
        public string BookmarkBelongsTo
        {
            get
            {
                return bmBelongsTo;
            }
            set
            {
                if (bmBelongsTo != value)
                {
                    bmBelongsTo = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
