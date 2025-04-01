using gallery_mk4.Model;
using System;
using System.Windows;
using System.Windows.Input;

namespace gallery_mk4.Windows
{
    public partial class EditLocationWindow : Window
    {
        private readonly Location _originalLocation;
        public Location CurrentLocation { get; private set; }

        public EditLocationWindow(Location locationToEdit)
        {
            InitializeComponent();

            // Сохраняем оригинал и создаем копию для редактирования
            _originalLocation = locationToEdit;
            CurrentLocation = new Location
            {
                id = locationToEdit.id,
                GalleryName = locationToEdit.GalleryName
            };

            DataContext = this;
            Loaded += (s, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentLocation.GalleryName))
            {
                MessageBox.Show("Название локации не может быть пустым!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var location = context.Location.Find(_originalLocation.id);
                    if (location != null)
                    {
                        location.GalleryName = CurrentLocation.GalleryName;
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