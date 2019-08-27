namespace daVinci.ConfigData.Version
{
    #region Usings
    using System.Windows.Input;
    #endregion

    public class XllVersion
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int ID { get; set; }
        public string Room { get; set; }
        public string Releasenotes { get; set; }
        public string File { get; set; }
        public string XllBaseFileName { get; set; }
        public ICommand InstallCommand { get; set; }
    }
}
