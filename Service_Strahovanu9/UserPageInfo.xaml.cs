using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Service_Strahovanu9
{
    /// <summary>
    /// Логика взаимодействия для UserPageInfo.xaml
    /// </summary>
    public partial class UserPageInfo : Window
    {
        public UserPageInfo()
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

        }

        private void ChangeImageClick(object sender, RoutedEventArgs e)
        {
            string photo = Image();
            if (photo == null)
                return;

            Photo = File.ReadAllBytes(photo);
        }

        private string Image()
        {
            OpenFileDialog photo = new OpenFileDialog()
            {
                Filter = "фото|*.png;*.jpg;*.jpeg",
                DefaultExt = "фото|*.png;*.jpg;*.jpeg",
                CheckFileExists = true,
                Multiselect = false
            };
            if (photo.ShowDialog() == true)
                return photo.FileName;
            return null;
        }
        
    }
}
