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
                    if (down + velocidad * 1.5 > 0)
                        imgPersonaje.Margin = new Thickness(left, up + velocidad, right, down - velocidad);
                    break;
            }
            visitarPlanetas(left + 75, up + 75, right + 75, down + 75);

        }

        private void visitarPlanetas(int left, int up, int right, int down)
        {
            if (left > 120 && right > 960 && up > 40 && down > 340)
            {
                tempLabel.Text = "VENUS";
                MessageBoxResult resultado = MessageBox.Show("¿Quieres jugar en Venus?", "Bienvenido a Venus", MessageBoxButton.YesNo);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        tempLabel.Text = "JUGANDO EN VENUS";
                        break;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }
            }
            else if (left > 545 && right > 545 && up > 20 && down > 370)
            {
                tempLabel.Text = "TIERRA";
                MessageBoxResult resultado = MessageBox.Show("¿Quieres jugar en la Tierra?", "Bienvenido a La Tierra", MessageBoxButton.YesNo);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        tempLabel.Text = "JUGANDO EN LA TIERRA";
                        break;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }
            }
            else if (left > 1000 && right > 80 && up > 40 && down > 350)
            {
                tempLabel.Text = "URANO";
                MessageBoxResult resultado = MessageBox.Show("¿Quieres jugar en Urano  ?", "Bienvenido a Urano", MessageBoxButton.YesNo);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        tempLabel.Text = "JUGANDO EN URANO";
                        break;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }
            }
            else if (left > 70 && right > 1020 && up > 345 && down > 40)
            {
                tempLabel.Text = "MARTE";
                MessageBoxResult resultado = MessageBox.Show("¿Quieres jugar en Marte?", "Bienvenido a Marte", MessageBoxButton.YesNo);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        tempLabel.Text = "JUGANDO EN MARTE";
                        break;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }
            }
            else if (left > 1050 && right > 10 && up > 350 && down > 10)
            {
                tempLabel.Text = "EXIT";
                MessageBoxResult resultado = MessageBox.Show("¿Ya te quieres ir?", "Salida", MessageBoxButton.YesNo);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        App.Current.Shutdown();
                        break;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }
            }
            else {
                tempLabel.Text = "ESPACIO";
            }
        }

    }
}
