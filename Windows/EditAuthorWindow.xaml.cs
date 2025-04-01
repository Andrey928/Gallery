using gallery_mk4.Model;
using System;
using System.Windows;

namespace gallery_mk4.Windows
{
    public partial class EditAuthorWindow : Window
    {
        private readonly Author _originalAuthor;
        public Author CurrentAuthor { get; private set; }

        public EditAuthorWindow(Author authorToEdit)
        {
            InitializeComponent();

            // Сохраняем оригинал и создаем копию для редактирования
            _originalAuthor = authorToEdit;
            CurrentAuthor = new Author
            {
                id = authorToEdit.id,
                Name = authorToEdit.Name,
                BirthYear = authorToEdit.BirthYear,
                DeathYear = authorToEdit.DeathYear
            };

            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentAuthor.Name))
            {
                MessageBox.Show("Введите имя автора!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CurrentAuthor.BirthYear <= 0 || CurrentAuthor.BirthYear > DateTime.Now.Year)
            {
                MessageBox.Show($"Год рождения должен быть между 1 и {DateTime.Now.Year}!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CurrentAuthor.DeathYear.HasValue &&
                (CurrentAuthor.DeathYear <= CurrentAuthor.BirthYear || CurrentAuthor.DeathYear > DateTime.Now.Year))
            {
                MessageBox.Show($"Год смерти должен быть после года рождения и до {DateTime.Now.Year}!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var author = context.Author.Find(_originalAuthor.id);
                    if (author != null)
                    {
                        author.Name = CurrentAuthor.Name;
                        author.BirthYear = CurrentAuthor.BirthYear;
                        author.DeathYear = CurrentAuthor.DeathYear;

                        context.SaveChanges();
                        DialogResult = true;
                        Close();
                    }
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