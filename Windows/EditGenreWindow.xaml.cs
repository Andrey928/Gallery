using gallery_mk4.Model;
using System;
using System.Windows;

namespace gallery_mk4.Windows
{
    public partial class EditGenreWindow : Window
    {
        private readonly Genre _originalGenre;
        public Genre CurrentGenre { get; private set; }

        public EditGenreWindow(Genre genreToEdit)
        {
            InitializeComponent();

           
            _originalGenre = genreToEdit;
            CurrentGenre = new Genre
            {
                id = genreToEdit.id,
                GenreName = genreToEdit.GenreName,
               
            };

            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentGenre.GenreName))
            {
                MessageBox.Show("Введите название жанра!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var genre = context.Genre.Find(_originalGenre.id);
                    if (genre != null)
                    {
                        genre.GenreName = CurrentGenre.GenreName;
                       

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