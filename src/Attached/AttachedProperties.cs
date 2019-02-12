namespace daVinci.Attached
{
    #region Usings
    using System.Windows;
    #endregion

    public static class AttachedProperties
    {
        #region HighlightSelected AP
        public static bool GetHighlightSelected(DependencyObject obj)
        {
            return (bool)obj.GetValue(HighlightSelectedProperty);
        }

        public static void SetHighlightSelected(DependencyObject obj, bool value)
        {
            obj.SetValue(HighlightSelectedProperty, value);
        }

        public static readonly DependencyProperty HighlightSelectedProperty =
            DependencyProperty.RegisterAttached(
                "HighlightSelected",
                typeof(bool),
                typeof(AttachedProperties),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.Inherits));
        #endregion
    }
}
