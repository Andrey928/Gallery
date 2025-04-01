using gallery_mk4.Model;
using System;
using System.Windows;

namespace gallery_mk4.Windows
{
    public partial class EditExhibitionWindow : Window
    {
        private readonly Exhibitions _originalExhibition;
        public Exhibitions CurrentExhibition { get; private set; }

        public EditExhibitionWindow(Exhibitions exhibitionToEdit)
        {
            InitializeComponent();

            // Сохраняем оригинал и создаем копию для редактирования
            _originalExhibition = exhibitionToEdit;
            CurrentExhibition = new Exhibitions
            {
                id = exhibitionToEdit.id,
                Title = exhibitionToEdit.Title,
                StartDate = exhibitionToEdit.StartDate,
                EndDate = exhibitionToEdit.EndDate
            };

            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentExhibition.Title))
            {
                MessageBox.Show("Введите название выставки!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CurrentExhibition.StartDate > CurrentExhibition.EndDate)
            {
                MessageBox.Show("Дата окончания должна быть после даты начала!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var exhibition = context.Exhibitions.Find(_originalExhibition.id);
                    if (exhibition != null)
                    {
                        exhibition.Title = CurrentExhibition.Title;
                        exhibition.StartDate = CurrentExhibition.StartDate;
                        exhibition.EndDate = CurrentExhibition.EndDate;

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