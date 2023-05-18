using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool pvp = false;
        bool pvc = false;
        bool playerX = false;
        bool playerO = false;
        bool computerXTurn = false;
        bool computerOTurn = false;
        bool playerXTurn = false;
        bool playerOTurn = false;
        bool playerStarts = false;
        bool computerStarts = false;
        bool pressed = false;
        int computerMove;
        Random rnd = new Random();
        List<int> avaliableMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int> computerMoves = new List<int>();
        List<int> computerMovesAvaliable;
        int[,] game = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        
        private async Task computer_ButtonsAsync(int number)
        {
            await Task.Delay(500);
            switch (number)
            {
                case 1:
                    Window1Button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case 2:
                    Window2Button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case 3:
                    Window3Button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case 4:
                    Window4Button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case 5:
                    Window5Button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case 6:
                    Window6Button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case 7:
                    Window7Button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case 8:
                    Window8Button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case 9:
                    Window9Button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                default:
                    break;
            }
        }
        private void computer_Moves ()
        {
            if(computerStarts)
            {
                computerMovesAvaliable = new List<int> { 1, 3, 7, 9 };
                computerMove = computerMovesAvaliable[rnd.Next(0, 4)];
                computer_ButtonsAsync(computerMove);
                computerMoves.Append<int>(computerMove);
                computerMovesAvaliable.Remove(computerMove);                
            }
            else if (playerStarts)
            {
                if(Window5Button.Visibility == Visibility.Hidden)
                {
                    computer_ButtonsAsync(avaliableMoves[rnd.Next(0, avaliableMoves.Count)]);
                }
                else
                {
                    computer_ButtonsAsync(5);
                }                
            }
            if(!computerStarts && !playerStarts)
            {
                computer_ButtonsAsync(avaliableMoves[rnd.Next(0, avaliableMoves.Count)]);
            }
            computerStarts = false;
            playerStarts = false;
        }

        private void Window_NewGame()
        {
            Window1.Text = "";
            Window2.Text = "";
            Window3.Text = "";
            Window4.Text = "";
            Window5.Text = "";
            Window6.Text = "";
            Window7.Text = "";
            Window8.Text = "";
            Window9.Text = "";
            Window1.Visibility = Visibility.Hidden;
            Window2.Visibility = Visibility.Hidden;
            Window3.Visibility = Visibility.Hidden;
            Window4.Visibility = Visibility.Hidden;
            Window5.Visibility = Visibility.Hidden;
            Window6.Visibility = Visibility.Hidden;
            Window7.Visibility = Visibility.Hidden;
            Window8.Visibility = Visibility.Hidden;
            Window9.Visibility = Visibility.Hidden;
        }
        private void Buttons_Visible ()
        {
            Window1Button.Visibility = Visibility.Visible;
            Window2Button.Visibility = Visibility.Visible;
            Window3Button.Visibility = Visibility.Visible;
            Window4Button.Visibility = Visibility.Visible;
            Window5Button.Visibility = Visibility.Visible;
            Window6Button.Visibility = Visibility.Visible;
            Window7Button.Visibility = Visibility.Visible;
            Window8Button.Visibility = Visibility.Visible;
            Window9Button.Visibility = Visibility.Visible;
        }
        private void Buttons_Enabled()
        {
            Window1Button.IsEnabled = true;
            Window2Button.IsEnabled = true;
            Window3Button.IsEnabled = true;
            Window4Button.IsEnabled = true;
            Window5Button.IsEnabled = true;
            Window6Button.IsEnabled = true;
            Window7Button.IsEnabled = true;
            Window8Button.IsEnabled = true;
            Window9Button.IsEnabled = true;
        }
        private void Buttons_Disabled()
        {
            Window1Button.IsEnabled = false;
            Window2Button.IsEnabled = false;
            Window3Button.IsEnabled = false;
            Window4Button.IsEnabled = false;
            Window5Button.IsEnabled = false;
            Window6Button.IsEnabled = false;
            Window7Button.IsEnabled = false;
            Window8Button.IsEnabled = false;
            Window9Button.IsEnabled = false;
        }
        private void Buttons_DisOrEn()
        {
            if (computerXTurn || computerOTurn)
                Buttons_Disabled();
            else
                Buttons_Enabled();
        }
        private async Task Change_TurnAsync()
        {
            await Task.Delay(100);
            if (pvp)
            {
                if (playerXTurn)
                {
                    playerXTurn = false;
                    playerOTurn = true;
                    Turn.Text = "Player ◯ turn";
                }
                else if (playerOTurn)
                {
                    playerXTurn = true;
                    playerOTurn = false;
                    Turn.Text = "Player ✕ turn";
                }
            }
            else if (pvc)
            {
                if (playerX)
                {
                    if (playerXTurn)
                    {
                        playerXTurn = false;
                        computerOTurn = true;
                        Turn.Text = "Computer ◯ turn";
                        computer_Moves();
                    }
                    else if (computerOTurn)
                    {
                        playerXTurn = true;
                        computerOTurn = false;
                        Turn.Text = "Player ✕ turn";
                    }
                }
                else if (playerO)
                {
                    if (playerOTurn)
                    {
                        playerOTurn = false;
                        computerXTurn = true;
                        Turn.Text = "Computer ✕ turn";
                        computer_Moves();
                    }
                    else if (computerXTurn)
                    {
                        playerOTurn = true;
                        computerXTurn = false;
                        Turn.Text = "Player ◯ turn";
                    }
                }
                Buttons_DisOrEn();
            }
        }
        private int Fill_Window(Button button, TextBlock block)
        {
            button.Visibility = Visibility.Hidden;
            block.Visibility = Visibility.Visible;
            if (playerXTurn || computerXTurn)
            {
                block.Text = "✕";
                return 1;
            }
            else if (playerOTurn || computerOTurn)
            {
                block.Text = "◯";
                return 2;
            }
            else
                return 0;
        }
        private void Winning_Screen ()
        {
            if (playerXTurn)
            {
                Turn.Text = "Player ✕ won";
            }
            else if (playerOTurn)
            {
                Turn.Text = "Player ◯ won";
            }
            else if (computerXTurn)
            {
                Turn.Text = "Computer ✕ won";
            }
            else if (computerOTurn)
            {
                Turn.Text = "Computer ◯ won";
            }
            Buttons_Disabled();
        }

        private void Check_if_End()
        {
            if (((game[0, 0] != 0 && game[0, 1] != 0 && game[0, 2] != 0) && (game[0, 0] == game[0, 1] && game[0, 1] == game[0, 2])) || ((game[1, 0] != 0 && game[1, 1] != 0 && game[1, 2] != 0) && (game[1, 0] == game[1, 1] && game[1, 1] == game[1, 2])) || ((game[2, 0] != 0 && game[2, 1] != 0 && game[2, 2] != 0) && (game[2, 0] == game[2, 1] && game[2, 1] == game[2, 2])))
            {
                Winning_Screen();
            }
            else if (((game[0, 0] != 0 && game[1, 0] != 0 && game[2, 0] != 0) && (game[0, 0] == game[1, 0] && game[1, 0] == game[2, 0])) || ((game[0, 1] != 0 && game[1, 1] != 0 && game[2, 1] != 0) && (game[0, 1] == game[1, 1] && game[1, 1] == game[2, 1])) || ((game[0, 2] != 0 && game[1, 2] != 0 && game[2, 2] != 0) && (game[0, 2] == game[1, 2] && game[1, 2] == game[2, 2])))
            {
                Winning_Screen();
            }
            else if (((game[0, 0] != 0 && game[1, 1] != 0 && game[2, 2] != 0) && (game[0, 0] == game[1, 1] && game[1, 1] == game[2, 2])) || ((game[0, 2] != 0 && game[1, 1] != 0 && game[2, 0] != 0) && (game[0, 2] == game[1, 1] && game[1, 1] == game[2, 0])))
            {
                Winning_Screen();
            }
            else if (avaliableMoves.Count == 0)
            {
                Turn.Text = "Draw";
            }
            else
            {
                Change_TurnAsync();
            }
        }
        private bool Check_if_can_press (int n)
        {
            if(avaliableMoves.Contains(n))
            {
                avaliableMoves.Remove(n);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            pvp = false;
            pvc = false;
            playerX = false;
            playerO = false;
            computerXTurn = false;
            computerOTurn = false;
            playerXTurn = false;
            playerOTurn = false;
            playerStarts = false;
            computerStarts = false;
            Buttons_Visible();
            Buttons_Disabled();
            Window_NewGame();
            computerMove = 0;
            avaliableMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            game = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            PvPButton.Visibility = Visibility.Visible;
            PvCButton.Visibility = Visibility.Visible;            

            Turn.Visibility = Visibility.Hidden;
            XButton.Visibility = Visibility.Hidden;
            OButton.Visibility = Visibility.Hidden;
            PSButton.Visibility = Visibility.Hidden;
            CSButton.Visibility = Visibility.Hidden;
        }

        private void PvPButton_Click(object sender, RoutedEventArgs e)
        {
            Turn.Text = "Player ✕ turn";
            Turn.Visibility = Visibility.Visible;
            Buttons_Visible();
            Buttons_Enabled();
            playerXTurn = true;
            pvp = true;

            PvPButton.Visibility = Visibility.Hidden;
            PvCButton.Visibility = Visibility.Hidden;
        }

        private void PvCButton_Click(object sender, RoutedEventArgs e)
        {
            pvc = true;

            XButton.Visibility = Visibility.Visible;
            OButton.Visibility = Visibility.Visible;

            PvPButton.Visibility = Visibility.Hidden;
            PvCButton.Visibility = Visibility.Hidden;
        }

        private void XButton_Click(object sender, RoutedEventArgs e)
        {
            playerX = true;

            PSButton.Visibility = Visibility.Visible;
            CSButton.Visibility = Visibility.Visible;

            XButton.Visibility = Visibility.Hidden;
            OButton.Visibility = Visibility.Hidden;
        }

        private void OButton_Click(object sender, RoutedEventArgs e)
        {
            playerO = true;
            
            PSButton.Visibility = Visibility.Visible;
            CSButton.Visibility = Visibility.Visible;

            XButton.Visibility = Visibility.Hidden;
            OButton.Visibility = Visibility.Hidden;
        }

        private void PSButton_Click(object sender, RoutedEventArgs e)
        {
            if (playerX)
            {
                Turn.Text = "Player ✕ turn";
                Turn.Visibility = Visibility.Visible;
                playerXTurn = true;
            }
            else if (playerO)
            {
                Turn.Text = "Player ◯ turn";
                Turn.Visibility = Visibility.Visible;
                playerOTurn = true;
            }
            Buttons_Visible();
            Buttons_Enabled();
            playerStarts = true;

            PSButton.Visibility = Visibility.Hidden;
            CSButton.Visibility = Visibility.Hidden;
        }

        private async void CSButton_Click(object sender, RoutedEventArgs e)
        {
            
            Buttons_Visible();
            Turn.Visibility = Visibility.Visible;
            if (playerX)
            {
                computerOTurn = true;
                Turn.Text = "Computer ◯ turn";
            }
            else if (playerO)
            {
                computerXTurn = true;
                Turn.Text = "Computer ✕ turn";
            }
            Buttons_Disabled();
            computerStarts = true;
            computer_Moves();

            PSButton.Visibility = Visibility.Hidden;
            CSButton.Visibility = Visibility.Hidden;
        }

        private void Window1Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check_if_can_press(1))
            {
                Window1Button.Visibility = Visibility.Hidden;
                game[0, 0] = Fill_Window(Window1Button, Window1);
                Check_if_End();
            }
        }

        private void Window2Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check_if_can_press(2))
            {
                Window2Button.Visibility = Visibility.Hidden;
                game[0, 1] = Fill_Window(Window2Button, Window2);
                Check_if_End();
            }
        }

        private void Window3Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check_if_can_press(3))
            {
                Window3Button.Visibility = Visibility.Hidden;
                game[0, 2] = Fill_Window(Window3Button, Window3);
                Check_if_End();
            }
        }
        private void Window4Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check_if_can_press(4))
            {
                Window4Button.Visibility = Visibility.Hidden;
                game[1, 0] = Fill_Window(Window4Button, Window4);
                Check_if_End();
            }
        }

        private void Window5Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check_if_can_press(5))
            {
                Window5Button.Visibility = Visibility.Hidden;
                game[1, 1] = Fill_Window(Window5Button, Window5);
                Check_if_End();
            }
        }

        private void Window6Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check_if_can_press(6))
            {
                Window6Button.Visibility = Visibility.Hidden;
                game[1, 2] = Fill_Window(Window6Button, Window6);
                Check_if_End();
            }
        }

        private void Window7Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check_if_can_press(7))
            {
                Window7Button.Visibility = Visibility.Hidden;
                game[2, 0] = Fill_Window(Window7Button, Window7);
                Check_if_End();
            }
        }

        private void Window8Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check_if_can_press(8))
            {
                Window8Button.Visibility = Visibility.Hidden;
                game[2, 1] = Fill_Window(Window8Button, Window8);
                Check_if_End();
            }
        }

        private void Window9Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check_if_can_press(9))
            {
                Window9Button.Visibility = Visibility.Hidden;
                game[2, 2] = Fill_Window(Window9Button, Window9);
                Check_if_End();
            }
        }
    }
}
