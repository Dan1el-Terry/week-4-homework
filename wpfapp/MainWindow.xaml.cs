using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfCircleDrag
{
    public partial class MainWindow : Window
    {
        private Ellipse? draggedEllipse = null;
        private Point dragStartPosition;
        private Point ellipseOffset;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddCircle_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();

            var circle = new Ellipse
            {
                Width = 80,
                Height = 80,
                Fill = new SolidColorBrush(Color.FromRgb(
                    (byte)rnd.Next(50, 220),
                    (byte)rnd.Next(50, 220),
                    (byte)rnd.Next(50, 220))),
                Stroke = Brushes.Black,
                StrokeThickness = 1.5,
                Cursor = Cursors.Hand
            };

            // Start near the top-left, but scattered a bit
            double left = 40 + rnd.NextDouble() * 300;
            double top = 40 + rnd.NextDouble() * 200;

            Canvas.SetLeft(circle, left);
            Canvas.SetTop(circle, top);

            // Attach drag events
            circle.MouseLeftButtonDown += Circle_MouseLeftButtonDown;

            canvas.Children.Add(circle);
        }

        private void Circle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Ellipse ellipse) return;

            draggedEllipse = ellipse;
            dragStartPosition = e.GetPosition(canvas);

            ellipseOffset = new Point(
                dragStartPosition.X - Canvas.GetLeft(ellipse),
                dragStartPosition.Y - Canvas.GetTop(ellipse));

            ellipse.CaptureMouse();
            e.Handled = true;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedEllipse == null || e.LeftButton != MouseButtonState.Pressed)
                return;

            var currentPos = e.GetPosition(canvas);

            Canvas.SetLeft(draggedEllipse, currentPos.X - ellipseOffset.X);
            Canvas.SetTop(draggedEllipse, currentPos.Y - ellipseOffset.Y);
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedEllipse != null)
            {
                draggedEllipse.ReleaseMouseCapture();
                draggedEllipse = null;
            }
        }
    }
}