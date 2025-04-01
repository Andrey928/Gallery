using gallery_mk4.Model;
using System;
using System.Windows;
using System.Windows.Input;

namespace gallery_mk4.Windows
{
    public partial class EditMediumWindow : Window
    {
        private readonly Medium _originalMedium;
        public Medium CurrentMedium { get; private set; }

        public EditMediumWindow(Medium mediumToEdit)
        {
            InitializeComponent();

            // Сохраняем оригинал и создаем копию для редактирования
            _originalMedium = mediumToEdit;
            CurrentMedium = new Medium
            {
                id = mediumToEdit.id,
                MediumName = mediumToEdit.MediumName,
                
            };

            DataContext = this;
            Loaded += (s, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentMedium.MediumName))
            {
                MessageBox.Show("Введите название техники!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var medium = context.Medium.Find(_originalMedium.id);
                    if (medium != null)
                    {
                        medium.MediumName = CurrentMedium.MediumName;
                        

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