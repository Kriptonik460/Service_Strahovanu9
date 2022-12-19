using Service_Strahovanu9.Resource;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Threading;

namespace Service_Strahovanu9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int ClientRoleId = 3;
        public const int EmployeeRoleId = 2;
        public const int MaxAuth = 3;
        int CountAuth;
        public static readonly TimeSpan DateAuth = new TimeSpan(0, 1, 0);
        public static User UserCustomer;
        public static User UserRole;
        DispatcherTimer Timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            DbConnect.db.User.Load();
            if (Properties.Settings.Default.Login != null)
                LoginTb.Text = Properties.Settings.Default.Login;
            if (Properties.Settings.Default.Password != null)
                PasswordTb.Text = Properties.Settings.Default.Password;
        }
        #region функционал
        private void MinBut2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }



        private void logotype_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }





        #endregion
        private void Avtor_Click(object sender, RoutedEventArgs e)
        {

            if (CountAuth < 3)
            {
                if (LoginTb.Text != "" || PasswordTb.Text != "")
                {
                    var user = DbConnect.db.User.ToList().Find(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Text.Trim());
                    if (user != null)
                    {
                        if (Checker.IsChecked == true)
                        {
                            Properties.Settings.Default.Login = LoginTb.Text.Trim();
                            Properties.Settings.Default.Password = PasswordTb.Text.Trim();
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.Login = "";
                            Properties.Settings.Default.Password = "";
                            Properties.Settings.Default.Save();
                        }
                        CountAuth = 0;

                        if (user.IdRole == ClientRoleId)
                        {
                            UserRole.Id = user.Id;

                            new MaunWin().Show();

                            Close();

                        }
                        if (user.IdRole == EmployeeRoleId || user.IdRole == 4 || user.IdRole == 1)
                        {
                            new MaunWin().Show();
                            Close();
                        }
                        UserCustomer = user;
                        UserRole = user;

                    }
                    else
                    {
                        CountAuth += 1;
                        Properties.Settings.Default.CountAuth = CountAuth;
                        MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Не заполнены поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Вы ввели 3 раза неправильный пароль\nВход заблокировани на 1 минуту", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                CountAuth = 0;
                Avtor.IsEnabled = false;
                Registr.IsEnabled = false;
                Timer.Interval = new TimeSpan(0, 1, 0);
                Timer.Tick += new EventHandler(isVisibleBTN);
                Timer.Start();
            }





        }
        private void isVisibleBTN(object sender, EventArgs e)
        {
            Avtor.IsEnabled = true;
            Registr.IsEnabled = true;
            Timer.Stop();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            new Registration().Show();
            Close();
        }
    }
}
