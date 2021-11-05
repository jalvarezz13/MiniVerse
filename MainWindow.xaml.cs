using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniVerse
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void moverPersonaje(object sender, KeyEventArgs e)
        {
            int left = (int)imgPersonaje.Margin.Left;
            int up = (int)imgPersonaje.Margin.Top;
            int right = (int)imgPersonaje.Margin.Right;
            int down = (int)imgPersonaje.Margin.Bottom;
            int velocidad = 15;

            switch (e.Key)
            {
                case Key.Left:
                    if (left - velocidad * 0.5 > 0)
                        imgPersonaje.Margin = new Thickness(left - velocidad, up, right + velocidad, down);
                    break;

                case Key.Up:
                    if (up + velocidad * 1.5 > 0)
                        imgPersonaje.Margin = new Thickness(left, up - velocidad, right, down + velocidad);
                    break;

                case Key.Right:
                    if (right - velocidad * 0.5 > 0)
                        imgPersonaje.Margin = new Thickness(left + velocidad, up, right - velocidad, down);
                    break;

                case Key.Down:
                    if (down - velocidad > 0)
                        imgPersonaje.Margin = new Thickness(left, up + velocidad, right, down - velocidad);
                    break;
            }
            Console.WriteLine("Estoy fuera");
            visitarPlanetas(left + 75, up + 75, right + 75, down + 75);

        }

        private void visitarPlanetas(int left, int up, int right, int down)
        {
            if (left > 150 && right - 75 > 675 && up > 50 && down > 335)
            {
                Console.WriteLine("estoy en venus");
            }

            else if (left > 925 && right > 150 && up > 350 && down > 30)
            {
                Console.WriteLine("Salir");
                //App.Current.Shutdown();
            }
        }
    }
}
