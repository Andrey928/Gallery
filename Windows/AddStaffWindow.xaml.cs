using gallery_mk4.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace gallery_mk4.Windows
{
    public partial class AddStaffWindow : Window
    {
        private readonly Staff _newStaff = new Staff();

        public AddStaffWindow()
        {
            InitializeComponent();
            DataContext = this;
            _newStaff.HireDate = DateTime.Today;
        }

        public Staff NewStaff => _newStaff;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(_newStaff.FIO))
            {
                MessageBox.Show("Введите ФИО сотрудника!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(_newStaff.Position))
            {
                MessageBox.Show("Введите должность сотрудника!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (_newStaff.HireDate == default)
            {
                MessageBox.Show("Укажите дату приема на работу!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            if (string.IsNullOrWhiteSpace(_newStaff.Email))
            {
                MessageBox.Show("Введите email сотрудника!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidEmail(_newStaff.Email))
            {
                MessageBox.Show("Введите корректный email!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            if (string.IsNullOrWhiteSpace(_newStaff.Phone))
            {
                MessageBox.Show("Введите телефон сотрудника!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    context.Staff.Add(_newStaff);
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

        private bool IsValidEmail(string email)
        {
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}