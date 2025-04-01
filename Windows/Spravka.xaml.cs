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

namespace gallery_mk4.Windows
{
    /// <summary>
    /// Логика взаимодействия для Spravka.xaml
    /// </summary>
    public partial class Spravka : Window
    {
        public Spravka()
        {
            InitializeComponent();
            LoadFile();
        }

        public void LoadFile()
        {
            try
            {
                string filePath = @"E:\VS projects\gallery_mk4\bin\Debug\info.txt";
                string content = File.ReadAllText(filePath);
                txtContent.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка чтения файла: {ex.Message}");
            }
        }

        private void GoToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startupWindow = new StartWindow();
            startupWindow.Show();
            Close();
        }
    }
}
