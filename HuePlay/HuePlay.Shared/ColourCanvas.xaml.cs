using System.Diagnostics;
using Windows.ApplicationModel.Store;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.UI.Xaml.Media;

namespace HuePlay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColourCanvas : Page
    {
        public ColourCanvas()
        {
            this.InitializeComponent();
        }

        private void Grid_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var offset = e.GetCurrentPoint(this).Position.X / ActualWidth;
            PickerColour = new SolidColorBrush(grad.GradientStops.GetRelativeColor(offset));
        }

        public static readonly DependencyProperty PickerColourProperty =
            DependencyProperty.Register(
                "PickerColour", typeof (SolidColorBrush), typeof(ColourCanvas), null);

        public SolidColorBrush PickerColour
        {
            get { return (SolidColorBrush)GetValue(PickerColourProperty); }
            set { SetValue(PickerColourProperty, value); }
        }
    }
}
