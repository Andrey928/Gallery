using gallery_mk4.Model;
using System;
using System.Linq;
using System.Windows;

namespace gallery_mk4.Windows
{
    public partial class EditArtworkWindow : Window
    {
        public Artwork CurrentArtwork { get; set; }
        public System.Collections.IEnumerable Authors { get; set; }
        public System.Collections.IEnumerable Genres { get; set; }
        public System.Collections.IEnumerable Mediums { get; set; }
        public System.Collections.IEnumerable Exhibitions { get; set; }
        public System.Collections.IEnumerable Locations { get; set; }

        public EditArtworkWindow(Artwork artworkToEdit)
        {
            InitializeComponent();
            CurrentArtwork = artworkToEdit;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentArtwork.Title))
            {
                MessageBox.Show("Введите название произведения!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CurrentArtwork.YearCreated < 1000 || CurrentArtwork.YearCreated > DateTime.Now.Year + 1)
            {
                MessageBox.Show($"Год создания должен быть между 1000 и {DateTime.Now.Year + 1}!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var artwork = context.Artwork.Find(CurrentArtwork.id);
                    if (artwork != null)
                    {
                        artwork.Title = CurrentArtwork.Title;
                        artwork.AuthorID = CurrentArtwork.AuthorID;
                        artwork.YearCreated = CurrentArtwork.YearCreated;
                        artwork.GenreID = CurrentArtwork.GenreID;
                        artwork.MediumID = CurrentArtwork.MediumID;
                        artwork.ExhibitionID = CurrentArtwork.ExhibitionID;
                        artwork.LocationID = CurrentArtwork.LocationID;

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