using gallery_mk4.Model;
using System;
using System.Windows;

namespace gallery_mk4.Windows
{
    public partial class AddAuthorWindow : Window
    {
        private readonly Author _newAuthor = new Author();

        public AddAuthorWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Author NewAuthor => _newAuthor;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_newAuthor.Name))
            {
                MessageBox.Show("Введите имя автора!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_newAuthor.BirthYear <= 0 || _newAuthor.BirthYear > DateTime.Now.Year)
            {
                MessageBox.Show($"Год рождения должен быть между 1 и {DateTime.Now.Year}!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_newAuthor.DeathYear.HasValue &&
                (_newAuthor.DeathYear <= _newAuthor.BirthYear || _newAuthor.DeathYear > DateTime.Now.Year))
            {
                MessageBox.Show($"Год смерти должен быть после года рождения и до {DateTime.Now.Year}!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    context.Author.Add(_newAuthor);
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