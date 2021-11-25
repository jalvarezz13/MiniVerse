using System;
using System.Collections.Generic;
using System.Diagnostics;
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
               // tempLabel.Text = "VENUS";
                MessageBoxResult resultado;
                if (imgFondo.Source == imgFondoDB.Source)
                {
                    resultado = MessageBox.Show("¿Quieres ayudar a Goku?", "Saludos de Goku", MessageBoxButton.YesNo);
                }
                else
                {
                    resultado = MessageBox.Show("¿Quieres jugar en Venus?", "Bienvenido a Venus", MessageBoxButton.YesNo);
                }
               
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && python3 game1.py");
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();

                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);

                      //  tempLabel.Text = "JUGANDO EN VENUS";
                        check();
                        break;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }

            }
            else if (left > 545 && right > 545 && up > 20 && down > 370)
            {
               // tempLabel.Text = "TIERRA";

                MessageBoxResult resultado;
                if (imgFondo.Source == imgFondoDB.Source)
                {
                    resultado = MessageBox.Show("¿Quieres ayudar a BuBu?", "Saludos de BuBu", MessageBoxButton.YesNo);
                }
                else
                {
                    resultado = MessageBox.Show("¿Quieres jugar en La Tierra?", "Bienvenido a La Tierra", MessageBoxButton.YesNo);
                }
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && python3 game2.py");
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();

                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                    //    tempLabel.Text = "JUGANDO EN LA TIERRA";
                        check();
                        break;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }
    
            }
            else if (left > 1000 && right > 80 && up > 40 && down > 350 && imgJuego4.Visibility == Visibility.Visible)
            {
              //  tempLabel.Text = "URANO";
                MessageBoxResult resultado;
                if (imgFondo.Source == imgFondoDB.Source)
                {
                    resultado = MessageBox.Show("¿Quieres ayudar a Goku Super Sayan?", "Saludos de Goku Super Sayan", MessageBoxButton.YesNo);
                }
                else
                {
                    resultado = MessageBox.Show("¿Quieres jugar en Urano?", "Bienvenido a Urano", MessageBoxButton.YesNo);
                }
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        if(imgFondo.Source == imgFondoDB.Source)
                        {
                            Process cmd = new Process();
                            cmd.StartInfo.FileName = "cmd.exe";
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardOutput = true;
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.Start();

                            cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && cd game4DB && python3 Goku.py");
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();
                            cmd.WaitForExit();

                            imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        }
                        else
                        {
                            Process cmd = new Process();
                            cmd.StartInfo.FileName = "cmd.exe";
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardOutput = true;
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.Start();

                            cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && cd game4Universo && python3 game4.py");
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();
                            cmd.WaitForExit();

                            imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                   //         tempLabel.Text = "JUGANDO EN URANO";
                        }

                        
                        break;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }
            }
            else if (left > 70 && right > 1020 && up > 345 && down > 40)
            {
              //  tempLabel.Text = "MARTE";
                MessageBoxResult resultado;
                if (imgFondo.Source == imgFondoDB.Source)
                {
                    resultado = MessageBox.Show("¿Quieres ayudar a Krilin?", "Saludos de Krilin", MessageBoxButton.YesNo);
                }
                else
                {
                    resultado = MessageBox.Show("¿Quieres jugar en Marte?", "Bienvenido a Marte", MessageBoxButton.YesNo);
                }
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && cd game3 && python3 game3.py");
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();

                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                   //     tempLabel.Text = "JUGANDO EN MARTE";
                        check();
                        break;;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }

            }
            else if (left > 1050 && right > 10 && up > 350 && down > 10)
            {
          //      tempLabel.Text = "EXIT";
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
             //   tempLabel.Text = "ESPACIO";
            }
        }

        private void check()
        {
            if(imgJuego4.Visibility == Visibility.Hidden)
            {
                if (this.imgFondo.Source == imgFondoDB.Source)
                {
                    MessageBoxResult resultado = MessageBox.Show("¡¡ ENHORABUENA !!\nHas desbloqueado un personaje oculto.", "MiniVerse", MessageBoxButton.OK);
                    imgJuego4.Visibility = Visibility.Visible;
                }
                else 
                {
                    MessageBoxResult resultado = MessageBox.Show("¡¡ ENHORABUENA !!\nHas desbloqueado un planeta oculto.", "MiniVerse", MessageBoxButton.OK);
                    imgJuego4.Visibility = Visibility.Visible;
                }
               
               
            }
        }

        private void tematicaDragonBall(object sender, RoutedEventArgs e)
        {
            this.imgFondo.Source = imgFondoDB.Source;
            this.imgJuego1.Source = imgGoku1.Source;
            this.imgJuego2.Source = imgGoku2.Source;
            this.imgJuego3.Source = imgGoku3.Source;
            this.imgJuego4.Source = imgGoku4.Source;
            this.imgBanner.Source = imgBannerDB.Source;
            this.imgJuego4.Visibility = Visibility.Hidden;

        }

        private void tematicaUniverso(object sender, RoutedEventArgs e)
        {
            this.imgFondo.Source = imgFondoUniverso.Source;
            this.imgJuego1.Source = imgVenus.Source;
            this.imgJuego2.Source = imgMarte.Source;
            this.imgJuego3.Source = imgTierra.Source;
            this.imgJuego4.Source = imgUrano.Source;
            this.imgBanner.Source = imgBannerUniverso.Source;
            this.imgJuego4.Visibility = Visibility.Hidden;

        }
    }
}
