using gallery_mk4.Model;
using System;
using System.Windows;

namespace gallery_mk4.Windows
{
    public partial class AddExhibitionWindow : Window
    {
        private readonly Exhibitions _newExhibition = new Exhibitions();

        public AddExhibitionWindow()
        {
            InitializeComponent();
            DataContext = this;
            _newExhibition.StartDate = DateTime.Today;
            _newExhibition.EndDate = DateTime.Today.AddMonths(1);
        }

        public Exhibitions NewExhibition => _newExhibition;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_newExhibition.Title))
            {
                MessageBox.Show("Введите название выставки!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_newExhibition.StartDate > _newExhibition.EndDate)
            {
                MessageBox.Show("Дата окончания должна быть после даты начала!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    context.Exhibitions.Add(_newExhibition);
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