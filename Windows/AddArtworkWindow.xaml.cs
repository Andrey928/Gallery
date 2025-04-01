using gallery_mk4.Model;
using System;
using System.Windows;
using System.Linq;

namespace gallery_mk4.Windows
{
    public partial class AddArtworkWindow : Window
    {
        
       
        public Artwork NewArtwork { get; set; } = new Artwork();
        public System.Collections.IEnumerable Authors { get; set; }
        public System.Collections.IEnumerable Genres { get; set; }
        public System.Collections.IEnumerable Mediums { get; set; }
        public System.Collections.IEnumerable Exhibitions { get; set; }
        public System.Collections.IEnumerable Locations { get; set; }

        public AddArtworkWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    Authors = context.Author.ToList();
                    Genres = context.Genre.ToList();
                    Mediums = context.Medium.ToList();
                    Exhibitions = context.Exhibitions.ToList();
                    Locations = context.Location.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Валидация данных
            if (string.IsNullOrWhiteSpace(NewArtwork.Title))
            {
                MessageBox.Show("Введите название произведения!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (NewArtwork.YearCreated < 1000 || NewArtwork.YearCreated > DateTime.Now.Year + 1)
            {
                MessageBox.Show($"Год создания должен быть между 1000 и {DateTime.Now.Year + 1}!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (NewArtwork.AuthorID == 0 ||
                NewArtwork.GenreID == 0 ||
                NewArtwork.MediumID == 0 ||
                NewArtwork.ExhibitionID == 0 ||
                NewArtwork.LocationID == 0)
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    context.Artwork.Add(NewArtwork);
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