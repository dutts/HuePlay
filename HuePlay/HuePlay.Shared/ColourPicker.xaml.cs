using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HuePlay
{
    public sealed partial class ColourPicker : UserControl
    {
        public ColourPicker()
        {
            this.InitializeComponent();
        }

        private void PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var offset = e.GetCurrentPoint(this).Position.X / ActualWidth;
            PickerColour = new SolidColorBrush(grad.GradientStops.GetRelativeColor(offset));
        }

        public static readonly DependencyProperty PickerColourProperty =
            DependencyProperty.Register(
                "PickerColour", typeof(SolidColorBrush), typeof(ColourPicker), null);

        public SolidColorBrush PickerColour
        {
            get { return (SolidColorBrush)GetValue(PickerColourProperty); }
            set { SetValue(PickerColourProperty, value); }
        }
    }
}
