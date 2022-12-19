using Service_Strahovanu9.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Service_Strahovanu9
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
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
        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            string firstNameTB = FirstNameTb.Text.Trim();
            string lastNameTB = LastNameTb.Text.Trim();
            string patronomicTB = PatronomicTb.Text.Trim();
            string phone= Phone.Text.Trim();
            int old = Convert.ToInt32( Old.Text.Trim());
            
            if (!(login.Length > 0 && password.Length > 5))
            {
                MessageBox.Show("Не заполнен логин или пароль меньше 6 символов", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(password, @"[\!\@\$\%\#\^]"))
            {
                MessageBox.Show("необходим минимум один символ из набора: ! @ # $ % ^ ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(password, @"\d"))
            {
                MessageBox.Show("необходим минимум 1 цифра", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                User user = new User()
                {
                    Login = login,
                    Password = password,
                    IdRole = 2,
                    FirstName = firstNameTB,
                    LastName = lastNameTB,
                    Patronomic = patronomicTB,
                    Phone = phone,
                    Old = old,
                    IdStatus = 1

                };
                DbConnect.db.User.Add(user);
                DbConnect.db.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

      
    }
}
