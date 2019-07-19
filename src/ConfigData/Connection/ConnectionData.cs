namespace daVinci.ConfigData.Connection
{
    #region Usings
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class ConnectionData : INotifyPropertyChanged
    {
        #region LoggerInit
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public enum ConnectionType
        {
            Local,
            Browser,
            Cookie,
            Header,
            NTLM,
            EnteredCredentials,
            NTLMOnly,
        }

        #region Varibales & Properties
        private bool ignoreCertError = true;
        public bool IgnoreCertError
        {
            get
            {
                return ignoreCertError;
            }
            set
            {
                if (value != ignoreCertError)
                {
                    ignoreCertError = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Uri uRI;
        public Uri URI
        {
            get
            {
                return uRI;
            }
            set
            {
                if (value != uRI)
                {
                    uRI = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FullUri));
                }
            }
        }

        private ConnectionType ctype;
        public ConnectionType Type
        {
            get
            {
                return ctype;
            }
            set
            {
                if (value != ctype)
                {
                    ctype = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string iDName;
        public string IDName
        {
            get
            {
                return iDName;
            }
            set
            {
                if (value != iDName)
                {
                    iDName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string headerCookieKey;
        public string HeaderCookieKey
        {
            get
            {
                return headerCookieKey;
            }
            set
            {
                if (value != headerCookieKey)
                {
                    headerCookieKey = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string headerCookieValue;
        public string HeaderCookieValue
        {
            get
            {
                return headerCookieValue;
            }
            set
            {
                if (value != headerCookieValue)
                {
                    headerCookieValue = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool extraSession = false;
        public bool ExtraSession
        {
            get
            {
                return extraSession;
            }
            set
            {
                if (value != extraSession)
                {
                    extraSession = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int selectedTypeIndex = 4;
        public int SelectedTypeIndex
        {
            get
            {
                return selectedTypeIndex;
            }
            set
            {
                if (value != selectedTypeIndex)
                {
                    selectedTypeIndex = value;
                    RaisePropertyChanged();
                    Type = ConnectionData.ConvertFromIndex(value);
                }
            }
        }

        private string virtualProxy;
        public string VirtualProxy
        {
            get
            {
                return virtualProxy;
            }
            set
            {
                if (value != virtualProxy)
                {
                    virtualProxy = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FullUri));
                }
            }
        }

        public string FullUri
        {
            get
            {
                string url = URI.ToString();
                if (url[url.Length - 1] != '/') url += '/';
                url += virtualProxy;
                if (url[url.Length - 1] != '/') url += '/';
                return url;
            }
        }
        #endregion

        #region  Methods
        public void CopyFrom(ConnectionData other)
        {
            CopyWithoutType(other);
            this.Type = other.Type;
            this.selectedTypeIndex = other.selectedTypeIndex;
        }
        public void CopyWithoutType(ConnectionData other)
        {
            this.ExtraSession = other.ExtraSession;
            this.HeaderCookieKey = other.HeaderCookieKey;
            this.HeaderCookieValue = other.headerCookieValue;
            this.IDName = other.IDName;
            this.virtualProxy = other.VirtualProxy;
            this.IgnoreCertError = other.IgnoreCertError;
            this.URI = other.URI;
        }
        public static ConnectionType ConvertFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return ConnectionType.Local;
                case 1:
                    return ConnectionType.NTLM;
                case 2:
                    return ConnectionType.EnteredCredentials;
                case 3:
                    return ConnectionType.Browser;
                default:
                    return ConnectionType.NTLM;
            }
        }
        public static int ConvertToIndex(ConnectionType conntype)
        {
            int retvalue = 1;
            switch (conntype)
            {
                case ConnectionType.Local:
                    retvalue = 0;
                    break;
                case ConnectionType.Browser:
                    retvalue = 3;
                    break;
                case ConnectionType.Cookie:
                    retvalue = 3;
                    break;
                case ConnectionType.Header:
                    retvalue = 3;
                    break;
                case ConnectionType.NTLM:
                    retvalue = 1;
                    break;
                case ConnectionType.EnteredCredentials:
                    retvalue = 2;
                    break;
                default:
                    retvalue = 1;
                    break;
            }
            return retvalue;
        }
        #endregion
    }

    public class ConnectionDataFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is ConnectionData bmdata)
            {
                return (
                    (bmdata.IDName + "").ToLower().Contains(searchString.ToLower())
                    || (bmdata.URI + "").ToLower().Contains(searchString.ToLower())
                    );
            }
            return false;
        }
    }
}
