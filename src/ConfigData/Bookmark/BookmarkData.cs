﻿namespace daVinci.ConfigData.Bookmark
{
    #region Usings
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using leonardo.Resources;
    #endregion

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

        private string bmID;
        public string BookmarkID
        {
            get
            {
                return bmID;
            }
            set
            {
                if (bmID != value)
                {
                    bmID = value;
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

        private bool isDefault;
        public bool IsDefault
        {
            get
            {
                return isDefault;
            }
            set
            {
                if (isDefault != value)
                {
                    isDefault = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void CopyFrom(BookmarkData other)
        {
            BookmarkID = other.BookmarkID;
            BookmarkName = other.BookmarkName;
            BookmarkBelongsTo = other.BookmarkBelongsTo;
            BookmarkCreated = other.BookmarkCreated;
            BookmarkDescription = other.BookmarkDescription;
            BookmarkSelection = other.BookmarkSelection;
            isDefault = other.isDefault;
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

    public class BookmarkNameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is BookmarkData xappdata)
            {
                if (y is BookmarkData yappdata)
                {
                    return xappdata.BookmarkName.CompareTo(yappdata.BookmarkName);
                }
            }
            return 0;
        }
    }
}
