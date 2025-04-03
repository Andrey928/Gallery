using gallery_mk4.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace gallery_mk4.Windows
{
    public partial class EditStaffWindow : Window
    {
        private readonly Staff _originalStaff;
        public Staff CurrentStaff { get; private set; }

        public EditStaffWindow(Staff staffToEdit)
        {
            InitializeComponent();

            _originalStaff = staffToEdit;
            CurrentStaff = new Staff
            {
                id = staffToEdit.id,
                FIO = staffToEdit.FIO,
                Position = staffToEdit.Position,
                HireDate = staffToEdit.HireDate,
                Email = staffToEdit.Email,
                Phone = staffToEdit.Phone
            };

            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(CurrentStaff.FIO))
            {
                MessageBox.Show("Введите ФИО сотрудника!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(CurrentStaff.Position))
            {
                MessageBox.Show("Введите должность сотрудника!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (CurrentStaff.HireDate == default)
            {
                MessageBox.Show("Укажите дату приема на работу!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(CurrentStaff.Email))
            {
                MessageBox.Show("Введите email сотрудника!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidEmail(CurrentStaff.Email))
            {
                MessageBox.Show("Введите корректный email!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(CurrentStaff.Phone))
            {
                MessageBox.Show("Введите телефон сотрудника!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var staff = context.Staff.Find(_originalStaff.id);

                    staff.FIO = CurrentStaff.FIO;
                    staff.Position = CurrentStaff.Position;
                    staff.HireDate = CurrentStaff.HireDate;
                    staff.Email = CurrentStaff.Email;
                    staff.Phone = CurrentStaff.Phone;

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