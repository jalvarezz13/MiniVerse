using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
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
        private int tematica = 1; //TEMATICA: 1=UNIVERSO, 2=DRAGONBALL, 3=PACMAN, 4=MARIOBROS
        SoundPlayer musica = new SoundPlayer();

        public MainWindow()
        {
            InitializeComponent();
            musica.SoundLocation = Directory.GetCurrentDirectory() + "\\music\\Universo.wav";
            musica.Play();
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
            int pointsToWin = new Random().Next(3) + 2;
            int pointsToWinSpecial = new Random().Next(6) + 5;
            //PLANETA VENUS
            if (left > 120 && right > 960 && up > 40 && down > 340)
            {
                MessageBoxResult resultado;
                if (tematica == 1)
                {
                    resultado = MessageBox.Show("¿Quieres jugar en Venus y conseguir " + pointsToWin.ToString() + " puntos por descubrir su inédita atmosfera?", "Bienvenido a Venus", MessageBoxButton.YesNo);
                }
                else if (tematica == 2)
                {
                    resultado = MessageBox.Show("Hola, soy Goku ¿Me ayudas con este minijuego?\nSi lo haces, ganarás " + pointsToWin.ToString() + " puntos!", "Mensaje de Goku", MessageBoxButton.YesNo);
                }
                else if (tematica == 3)
                {
                    resultado = MessageBox.Show("Escapa del fantasma azul y el señor PacMan te regalará " + pointsToWin.ToString() + " PacPoints.", "Fantasma azul", MessageBoxButton.YesNo);
                }
                else
                {
                    resultado = MessageBox.Show("¿Quieres probar la seta gigante?\nMario te regalará " + pointsToWin.ToString() + " puntos si le ayudas a superar este reto.", "Champinión rojo", MessageBoxButton.YesNo);
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

                        cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && cd game1 && python3 game1.py");
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();

                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        check();
                        pbPuntos.Value = pbPuntos.Value + pointsToWin;
                        checkPB();
                        break;
                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }

            }

            // PLANETA TIERRA
            else if (left > 545 && right > 545 && up > 20 && down > 370)
            {
                MessageBoxResult resultado;
                if (tematica == 1)
                {
                    resultado = MessageBox.Show("¿Quieres jugar en la Tierra y conseguir " + pointsToWin.ToString() + " puntos por descubrir su naturaleza sorprendente?", "Bienvenido a La Tierra", MessageBoxButton.YesNo);
                }
                else if (tematica == 2)
                {
                    resultado = MessageBox.Show("¿Quieres ayudar a BuBu?\nSi lo haces, ganarás " + pointsToWin.ToString() + " puntos!", "Saludos de BuBu", MessageBoxButton.YesNo);
                }
                else if (tematica == 3)
                {
                    resultado = MessageBox.Show("Escapa del fantasma amarillo y el señor PacMan te regalará " + pointsToWin.ToString() + " PacPoints.", "Fantasma amarillo", MessageBoxButton.YesNo);
                }
                else
                {
                    resultado = MessageBox.Show("Como te descuides el fantasma te comerá, ¡juega para escapar!", "Fantasma comilón", MessageBoxButton.YesNo);
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

                        cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && cd game2 && python3 game2.py");
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();

                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        check();
                        pbPuntos.Value = pbPuntos.Value + pointsToWin;
                        checkPB();
                        break;

                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }

            }

            //PLANETA MARTE
            else if (left > 70 && right > 1020 && up > 345 && down > 40)
            {
                MessageBoxResult resultado;
                if (tematica == 1)
                {
                    resultado = MessageBox.Show("¿Quieres jugar en Marte y conseguir " + pointsToWin.ToString() + " puntos por descubrir sus paisajes rojizos?", "Bienvenido a Marte", MessageBoxButton.YesNo);
                }
                else if (tematica == 2)
                {
                    resultado = MessageBox.Show("¿Quieres ayudar a Krilin?\nSi lo haces, ganarás " + pointsToWin.ToString() + " puntos!", "Saludos de Krilin", MessageBoxButton.YesNo);
                }
                else if (tematica == 3)
                {
                    resultado = MessageBox.Show("¿Quieres ganar puntos con las cerezas? \nMr. PacMan te regalará " + pointsToWin.ToString() + " PacPoints.", "Las cerezas de PacMan", MessageBoxButton.YesNo);
                }
                else
                {
                    resultado = MessageBox.Show("¿Quieres ganar puntos con las monedas de Mario? \nMario te regalará " + pointsToWin.ToString() + " puntos si le ayudas a superar este reto.", "Mario Coins", MessageBoxButton.YesNo);
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
                        check();
                        pbPuntos.Value = pbPuntos.Value + pointsToWin;
                        checkPB();
                        break;

                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }

            }

            //PLANETA *ESPECIAL* URANO
            else if (left > 1000 && right > 80 && up > 40 && down > 350 && imgJuego4.Visibility == Visibility.Visible)
            {
                MessageBoxResult resultado;
                if (tematica == 1)
                {
                    resultado = MessageBox.Show("¿Quieres jugar en Urano y conseguir " + pointsToWinSpecial.ToString() + " puntos por descubrir sus anillos gigantes?", "Bienvenido a Urano", MessageBoxButton.YesNo);
                }
                else if (tematica == 2)
                {
                    resultado = MessageBox.Show("¿Quieres ayudar a Goku Super Sayan?\nSi lo haces, ganarás " + pointsToWinSpecial.ToString() + " puntos!", "Saludos de Goku Super Sayan", MessageBoxButton.YesNo);
                }
                else if (tematica == 3)
                {
                    resultado = MessageBox.Show("¿Quieres ganar puntos con la fresa? \nMr. PacMan te regalará " + pointsToWinSpecial.ToString() + " PacPoints.", "La fresa de PacMan", MessageBoxButton.YesNo);
                }
                else
                {
                    resultado = MessageBox.Show("¿Quieres probar el superpoder misterioso\nMario te regalará " + pointsToWinSpecial.ToString() + " puntos si le ayudas a superar este reto.", "Super Power UP", MessageBoxButton.YesNo);
                }

                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        //Se crea el proceso
                        Process cmd = new Process();
                        cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        switch (tematica)
                        {
                            //JUEGO ESPECIAL UNIVERSO
                            case 1:
                                cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && cd game4 && cd game4Universo && python3 SpaceInvaders.py");
                                cmd.StandardInput.Flush();
                                cmd.StandardInput.Close();
                                cmd.WaitForExit();

                                imgPersonaje.Margin = new Thickness(568, 308, 555, 112);

                                break;

                            //JUEGO ESPECIAL DRAGON BALL
                            case 2:
                                cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && cd game4 && cd game4DB && python3 Goku.py");
                                cmd.StandardInput.Flush();
                                cmd.StandardInput.Close();
                                cmd.WaitForExit();

                                imgPersonaje.Margin = new Thickness(568, 308, 555, 112);

                                break;

                            //JUEGO ESPECIAL PACMAN
                            case 3:
                                cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && cd game4 && cd game4PM && python3 PacMan.py");
                                cmd.StandardInput.Flush();
                                cmd.StandardInput.Close();
                                cmd.WaitForExit();

                                imgPersonaje.Margin = new Thickness(568, 308, 555, 112);

                                break;

                            //JUEGO ESPECIAL MARIO BROS
                            case 4:
                                cmd.StandardInput.WriteLine("cd .. && cd .. && cd games && cd game4 && cd game4MB && python3 main.py");
                                cmd.StandardInput.Flush();
                                cmd.StandardInput.Close();
                                cmd.WaitForExit();

                                imgPersonaje.Margin = new Thickness(568, 308, 555, 112);

                                break;
                        }

                        pbPuntos.Value = pbPuntos.Value + pointsToWinSpecial;
                        checkPB();
                        break;

                    case MessageBoxResult.No:
                        imgPersonaje.Margin = new Thickness(568, 308, 555, 112);
                        break;
                }
            }

            //SALIDA
            else if (left > 1050 && right > 10 && up > 350 && down > 10)
            {
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

            //LOBBY
            else { }
        }

        //CHECKEAR JUEGO ESPECIAL
        private void check()
        {
            if (imgJuego4.Visibility == Visibility.Hidden)
            {
                switch (tematica)
                {
                    //JUEGO ESPECIAL UNIVERSO
                    case 1:
                        MessageBox.Show("¡¡ ENHORABUENA !!\nHas desbloqueado un planeta oculto.", "MiniVerse", MessageBoxButton.OK);
                        break;

                    //JUEGO ESPECIAL DRAGON BALL
                    case 2:
                        MessageBox.Show("¡¡ ENHORABUENA !!\nHas desbloqueado un personaje oculto.", "MiniVerse", MessageBoxButton.OK);
                        break;

                    //JUEGO ESPECIAL PACMAN
                    case 3:
                        MessageBox.Show("¡¡ ENHORABUENA !!\nHas desbloqueado un juego oculto.", "MiniVerse", MessageBoxButton.OK);
                        break;

                    //JUEGO ESPECIAL MARIO BROS
                    case 4:
                        MessageBox.Show("¡¡ ENHORABUENA !!\nHas desbloqueado un objeto oculto.", "MiniVerse", MessageBoxButton.OK);
                        break;
                }
                imgJuego4.Visibility = Visibility.Visible;
            }
        }

        private void checkPB()
        {
            if (pbPuntos.Value >= 100)
            {
                MessageBox.Show("¡¡ ENHORABUENA !!\nHas conseguido la máxima puntuación.", "MiniVerse", MessageBoxButton.OK);
                pbPuntos.Foreground = Brushes.LightSkyBlue;
                //pbPuntos.Foreground = Brushes.Cyan;
                txtPuntuacion.Text = "JUEGO COMPLETADO";
            }
        }

        /*-------------------------------------- RECURSOS DE TEMATICAS  -----------------------------------------*/

        private void tematicaUniverso(object sender, RoutedEventArgs e)
        {
            tematica = 1;
            string rutaImagen = "images/Universo/";
            this.imgLogo.Source = new BitmapImage(new Uri(rutaImagen + "logoUniverso.png", UriKind.Relative));
            this.imgFondo.Source = new BitmapImage(new Uri(rutaImagen + "fondoUniverso.png", UriKind.Relative));
            this.imgPersonaje.Source = new BitmapImage(new Uri(rutaImagen + "naveUniverso.png", UriKind.Relative));
            this.imgJuego1.Source = new BitmapImage(new Uri(rutaImagen + "venus.png", UriKind.Relative));
            this.imgJuego2.Source = new BitmapImage(new Uri(rutaImagen + "marte.png", UriKind.Relative));
            this.imgJuego3.Source = new BitmapImage(new Uri(rutaImagen + "tierra.png", UriKind.Relative));
            this.imgJuego4.Source = new BitmapImage(new Uri(rutaImagen + "urano.png", UriKind.Relative));
            this.imgBanner.Source = new BitmapImage(new Uri(rutaImagen + "bannerUniverso.jpg", UriKind.Relative));
            this.imgSalir.Source = new BitmapImage(new Uri(rutaImagen + "salidaUniverso.png", UriKind.Relative));
            this.imgJuego4.Visibility = Visibility.Hidden;

            musica.SoundLocation = Directory.GetCurrentDirectory() + "\\music\\Universo.wav";
            musica.Play();
        }

        private void tematicaDragonBall(object sender, RoutedEventArgs e)
        {
            tematica = 2;
            string rutaImagen = "images/DragonBall/";
            this.imgLogo.Source = new BitmapImage(new Uri(rutaImagen + "logoDragonBall.png", UriKind.Relative));
            this.imgFondo.Source = new BitmapImage(new Uri(rutaImagen + "fondoDragonBall.png", UriKind.Relative));
            this.imgPersonaje.Source = new BitmapImage(new Uri(rutaImagen + "naveDragonBall.png", UriKind.Relative));
            this.imgJuego1.Source = new BitmapImage(new Uri(rutaImagen + "juego1DragonBall.png", UriKind.Relative));
            this.imgJuego2.Source = new BitmapImage(new Uri(rutaImagen + "juego2DragonBall.png", UriKind.Relative));
            this.imgJuego3.Source = new BitmapImage(new Uri(rutaImagen + "juego3DragonBall.png", UriKind.Relative));
            this.imgJuego4.Source = new BitmapImage(new Uri(rutaImagen + "juego4DragonBall.png", UriKind.Relative));
            this.imgBanner.Source = new BitmapImage(new Uri(rutaImagen + "bannerDragonBall.jpg", UriKind.Relative));
            this.imgSalir.Source = new BitmapImage(new Uri(rutaImagen + "salidaDragonBall.png", UriKind.Relative));
            this.imgJuego4.Visibility = Visibility.Hidden;

            musica.SoundLocation = Directory.GetCurrentDirectory() + "\\music\\DragonBall.wav";
            musica.Play();
        }

        private void tematicaPacMan(object sender, RoutedEventArgs e)
        {
            tematica = 3;
            string rutaImagen = "images/PacMan/";
            this.imgLogo.Source = new BitmapImage(new Uri(rutaImagen + "logoPacMan.png", UriKind.Relative));
            this.imgFondo.Source = new BitmapImage(new Uri(rutaImagen + "fondoPacMan.png", UriKind.Relative));
            this.imgPersonaje.Source = new BitmapImage(new Uri(rutaImagen + "navePacMan.png", UriKind.Relative));
            this.imgJuego1.Source = new BitmapImage(new Uri(rutaImagen + "juego1PacMan.png", UriKind.Relative));
            this.imgJuego2.Source = new BitmapImage(new Uri(rutaImagen + "juego2PacMan.png", UriKind.Relative));
            this.imgJuego3.Source = new BitmapImage(new Uri(rutaImagen + "juego3PacMan.png", UriKind.Relative));
            this.imgJuego4.Source = new BitmapImage(new Uri(rutaImagen + "juego4PacMan.png", UriKind.Relative));
            this.imgBanner.Source = new BitmapImage(new Uri(rutaImagen + "bannerPacMan.png", UriKind.Relative));
            this.imgSalir.Source = new BitmapImage(new Uri(rutaImagen + "salidaPacMan.png", UriKind.Relative));
            this.imgJuego4.Visibility = Visibility.Hidden;

            musica.SoundLocation = Directory.GetCurrentDirectory() + "\\music\\PacMan.wav";
            musica.Play();
        }

        private void tematicaMarioBros(object sender, RoutedEventArgs e)
        {
            tematica = 4;
            string rutaImagen = "images/MarioBros/";
            this.imgLogo.Source = new BitmapImage(new Uri(rutaImagen + "logoMarioBros.png", UriKind.Relative));
            this.imgFondo.Source = new BitmapImage(new Uri(rutaImagen + "fondoMarioBros.png", UriKind.Relative));
            this.imgPersonaje.Source = new BitmapImage(new Uri(rutaImagen + "naveMarioBros.png", UriKind.Relative));
            this.imgJuego1.Source = new BitmapImage(new Uri(rutaImagen + "juego1MarioBros.png", UriKind.Relative));
            this.imgJuego2.Source = new BitmapImage(new Uri(rutaImagen + "juego2MarioBros.png", UriKind.Relative));
            this.imgJuego3.Source = new BitmapImage(new Uri(rutaImagen + "juego3MarioBros.png", UriKind.Relative));
            this.imgJuego4.Source = new BitmapImage(new Uri(rutaImagen + "juego4MarioBros.png", UriKind.Relative));
            this.imgBanner.Source = new BitmapImage(new Uri(rutaImagen + "bannerMarioBros.jpg", UriKind.Relative));
            this.imgSalir.Source = new BitmapImage(new Uri(rutaImagen + "salidaMarioBros.png", UriKind.Relative));
            this.imgJuego4.Visibility = Visibility.Hidden;

            musica.SoundLocation = Directory.GetCurrentDirectory() + "\\music\\MarioBros.wav";
            musica.Play();
        }


    }



}
