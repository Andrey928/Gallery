using gallery_mk4.Model;
using System;
using System.Windows;

namespace gallery_mk4.Windows
{
    public partial class AddMediumWindow : Window
    {
        private readonly Medium _newMedium = new Medium();

        public AddMediumWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Medium NewMedium => _newMedium;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_newMedium.MediumName))
            {
                MessageBox.Show("Введите название техники!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    context.Medium.Add(_newMedium);
                    context.SaveChanges();
                    DialogResult = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}