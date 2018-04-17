using leonardo_wpf.Resources;
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

        private DateTime bmCreated;
        public DateTime BookmarkCreated
        {
            get
            {
                return bmCreated;
            }
            set
            {
                if (bmCreated != value)
                {
                    bmCreated = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string bmSelection;
        public string BookmarkSelection
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

        public void CopyFrom(BookmarkData other)
        {
            BookmarkName = other.BookmarkName;
            BookmarkBelongsTo = other.BookmarkBelongsTo;
            BookmarkCreated = other.BookmarkCreated;
            BookmarkDescription = other.BookmarkDescription;
            BookmarkSelection = other.BookmarkSelection;
        }
    }

    public class BookmarkDataFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is BookmarkData bmdata)
            {
                return ((bmdata.BookmarkName + "").ToLower().Contains(searchString.ToLower())
                    || (bmdata.BookmarkDescription + "").ToLower().Contains(searchString.ToLower())
                    || (bmdata.BookmarkCreated + "").ToLower().Contains(searchString.ToLower())
                    || (bmdata.BookmarkSelection + "").ToLower().Contains(searchString.ToLower())
                    || (bmdata.BookmarkBelongsTo + "").ToLower().Contains(searchString.ToLower())
                    );

            }
            return false;
        }
    }
}
