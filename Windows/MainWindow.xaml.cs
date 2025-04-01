using gallery_mk4.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace gallery_mk4.Windows
{
    public partial class MainWindow : Window
    {
        private readonly GalleryViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new GalleryViewModel();
            DataContext = _viewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var tabControl = (TabControl)MainGrid.Children[0];
            var selectedTab = tabControl.SelectedItem as TabItem;

            switch (tabControl.SelectedIndex)
            {
                case 0: // Произведения
                    _viewModel.AddArtworkCommand.Execute(null);
                    break;
                case 1: // Авторы
                    _viewModel.AddAuthorCommand.Execute(null);
                    break;
                case 2: // Выставки
                    _viewModel.AddExhibitionCommand.Execute(null);
                    break;
                case 3: // Жанры
                    _viewModel.AddGenreCommand.Execute(null);
                    break;
                case 4: // Техника
                    _viewModel.AddMediumCommand.Execute(null);
                    break;
                case 5: // Сотрудники
                    _viewModel.AddStaffCommand.Execute(null);
                    break;
                case 6: // Локации
                    _viewModel.AddLocationCommand.Execute(null);
                    break;
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var tabControl = (TabControl)MainGrid.Children[0];

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    _viewModel.DeleteArtworkCommand.Execute(null);
                    break;
                case 1:
                    _viewModel.DeleteAuthorCommand.Execute(null);
                    break;
                case 2:
                    _viewModel.DeleteExhibitionCommand.Execute(null);
                    break;
                case 3:
                    _viewModel.DeleteGenreCommand.Execute(null);
                    break;
                case 4:
                    _viewModel.DeleteMediumCommand.Execute(null);
                    break;
                case 5:
                    _viewModel.DeleteStaffCommand.Execute(null);
                    break;
                case 6:
                    _viewModel.DeleteLocationCommand.Execute(null);
                    break;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var tabControl = (TabControl)MainGrid.Children[0];

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    _viewModel.EditArtworkCommand.Execute(null);
                    break;
                case 1:
                    _viewModel.EditAuthorCommand.Execute(null);
                    break;
                case 2:
                    _viewModel.EditExhibitionCommand.Execute(null);
                    break;
                case 3:
                    _viewModel.EditGenreCommand.Execute(null);
                    break;
                case 4:
                    _viewModel.EditMediumCommand.Execute(null);
                    break;
                case 5:
                    _viewModel.EditStaffCommand.Execute(null);
                    break;
                case 6:
                    _viewModel.EditLocationCommand.Execute(null);
                    break;
            }
        }
    }
}