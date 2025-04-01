using gallery_mk4.Model;
using gallery_mk4.Windows;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace gallery_mk4.ViewModel
{
    public class GalleryViewModel : BaseViewModel
    {
        // Коллекции
        private ObservableCollection<Artwork> _artworks = new ObservableCollection<Artwork>();
        private ObservableCollection<Author> _authors = new ObservableCollection<Author>();
        private ObservableCollection<Exhibitions> _exhibitions = new ObservableCollection<Exhibitions>();
        private ObservableCollection<Genre> _genres = new ObservableCollection<Genre>();
        private ObservableCollection<Medium> _mediums = new ObservableCollection<Medium>();
        private ObservableCollection<Location> _locations = new ObservableCollection<Location>();
        private ObservableCollection<Staff> _staff = new ObservableCollection<Staff>();

        // Выбранные элементы
        private Artwork _selectedArtwork;
        private Author _selectedAuthor;
        private Exhibitions _selectedExhibition;
        private Genre _selectedGenre;
        private Medium _selectedMedium;
        private Location _selectedLocation;
        private Staff _selectedStaff;

        // Команды для Artwork
        public ICommand AddArtworkCommand { get; }
        public ICommand EditArtworkCommand { get; }
        public ICommand DeleteArtworkCommand { get; }

        // Команды для Author
        public ICommand AddAuthorCommand { get; }
        public ICommand EditAuthorCommand { get; }
        public ICommand DeleteAuthorCommand { get; }

        // Команды для Exhibition
        public ICommand AddExhibitionCommand { get; }
        public ICommand EditExhibitionCommand { get; }
        public ICommand DeleteExhibitionCommand { get; }

        // Команды для Genre
        public ICommand AddGenreCommand { get; }
        public ICommand EditGenreCommand { get; }
        public ICommand DeleteGenreCommand { get; }

        // Команды для Medium
        public ICommand AddMediumCommand { get; }
        public ICommand EditMediumCommand { get; }
        public ICommand DeleteMediumCommand { get; }

        // Команды для Location
        public ICommand AddLocationCommand { get; }
        public ICommand EditLocationCommand { get; }
        public ICommand DeleteLocationCommand { get; }

        // Команды для Staff
        public ICommand AddStaffCommand { get; }
        public ICommand EditStaffCommand { get; }
        public ICommand DeleteStaffCommand { get; }

        // Свойства коллекций
        public ObservableCollection<Artwork> Artworks { get => _artworks; set => SetPropertyChanged(ref _artworks, value); }
        public ObservableCollection<Author> Authors { get => _authors; set => SetPropertyChanged(ref _authors, value); }
        public ObservableCollection<Exhibitions> Exhibitions { get => _exhibitions; set => SetPropertyChanged(ref _exhibitions, value); }
        public ObservableCollection<Genre> Genres { get => _genres; set => SetPropertyChanged(ref _genres, value); }
        public ObservableCollection<Medium> Mediums { get => _mediums; set => SetPropertyChanged(ref _mediums, value); }
        public ObservableCollection<Location> Locations { get => _locations; set => SetPropertyChanged(ref _locations, value); }
        public ObservableCollection<Staff> Staff { get => _staff; set => SetPropertyChanged(ref _staff, value); }

        // Свойства выбранных элементов
        public Artwork SelectedArtwork { get => _selectedArtwork; set => SetPropertyChanged(ref _selectedArtwork, value); }
        public Author SelectedAuthor { get => _selectedAuthor; set => SetPropertyChanged(ref _selectedAuthor, value); }
        public Exhibitions SelectedExhibition { get => _selectedExhibition; set => SetPropertyChanged(ref _selectedExhibition, value); }
        public Genre SelectedGenre { get => _selectedGenre; set => SetPropertyChanged(ref _selectedGenre, value); }
        public Medium SelectedMedium { get => _selectedMedium; set => SetPropertyChanged(ref _selectedMedium, value); }
        public Location SelectedLocation { get => _selectedLocation; set => SetPropertyChanged(ref _selectedLocation, value); }
        public Staff SelectedStaff { get => _selectedStaff; set => SetPropertyChanged(ref _selectedStaff, value); }

        public GalleryViewModel()
        {
            // Инициализация команд
            AddArtworkCommand = new RelayCommand(OpenAddArtworkWindow);
            EditArtworkCommand = new RelayCommand(OpenEditArtworkWindow, CanEditArtwork);
            DeleteArtworkCommand = new RelayCommand(DeleteArtwork, CanEditArtwork);

            AddAuthorCommand = new RelayCommand(OpenAddAuthorWindow);
            EditAuthorCommand = new RelayCommand(OpenEditAuthorWindow, CanEditAuthor);
            DeleteAuthorCommand = new RelayCommand(DeleteAuthor, CanEditAuthor);

            AddExhibitionCommand = new RelayCommand(OpenAddExhibitionWindow);
            EditExhibitionCommand = new RelayCommand(OpenEditExhibitionWindow, CanEditExhibition);
            DeleteExhibitionCommand = new RelayCommand(DeleteExhibition, CanEditExhibition);

            AddGenreCommand = new RelayCommand(OpenAddGenreWindow);
            EditGenreCommand = new RelayCommand(OpenEditGenreWindow, CanEditGenre);
            DeleteGenreCommand = new RelayCommand(DeleteGenre, CanEditGenre);

            AddMediumCommand = new RelayCommand(OpenAddMediumWindow);
            EditMediumCommand = new RelayCommand(OpenEditMediumWindow, CanEditMedium);
            DeleteMediumCommand = new RelayCommand(DeleteMedium, CanEditMedium);

            AddLocationCommand = new RelayCommand(OpenAddLocationWindow);
            EditLocationCommand = new RelayCommand(OpenEditLocationWindow, CanEditLocation);
            DeleteLocationCommand = new RelayCommand(DeleteLocation, CanEditLocation);

            AddStaffCommand = new RelayCommand(OpenAddStaffWindow);
            EditStaffCommand = new RelayCommand(OpenEditStaffWindow, CanEditStaff);
            DeleteStaffCommand = new RelayCommand(DeleteStaff, CanEditStaff);

            LoadAllData();
        }

        #region Общие методы
        private void LoadAllData()
        {
            LoadArtworks();
            LoadAuthors();
            LoadExhibitions();
            LoadGenres();
            LoadMediums();
            LoadLocations();
            LoadStaff();
        }
        #endregion

        #region Artwork методы
        private bool CanEditArtwork(object obj) => SelectedArtwork != null;

        private void OpenAddArtworkWindow(object obj)
        {
            var window = new AddArtworkWindow();
            if (window.ShowDialog() == true) LoadArtworks();
        }

        private void OpenEditArtworkWindow(object obj)
        {
            if (SelectedArtwork == null) return;
            var window = new EditArtworkWindow(SelectedArtwork);
            if (window.ShowDialog() == true) LoadArtworks();
        }

        private void DeleteArtwork(object obj)
        {
            if (SelectedArtwork == null) return;

            if (MessageBox.Show("Удалить это произведение?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var artwork = context.Artwork.Find(SelectedArtwork.id);
                    if (artwork != null)
                    {
                        context.Artwork.Remove(artwork);
                        context.SaveChanges();
                        LoadArtworks();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void LoadArtworks()
        {
            Artworks.Clear();
            using (var context = new PictureGalleryEntities())
            {
                foreach (var item in context.Artwork
                    .Include(a => a.Author)
                    .Include(a => a.Exhibitions)
                    .Include(a => a.Genre)
                    .Include(a => a.Medium)
                    .Include(a => a.Location)
                    .ToList())
                {
                    Artworks.Add(item);
                }
            }
        }
        #endregion

        #region Author методы
        private bool CanEditAuthor(object obj) => SelectedAuthor != null;

        private void OpenAddAuthorWindow(object obj)
        {
            var window = new AddAuthorWindow();
            if (window.ShowDialog() == true) LoadAuthors();
        }

        private void OpenEditAuthorWindow(object obj)
        {
            if (SelectedAuthor == null) return;
            var window = new EditAuthorWindow(SelectedAuthor);
            if (window.ShowDialog() == true) LoadAuthors();
        }

        private void DeleteAuthor(object obj)
        {
            if (SelectedAuthor == null) return;

            if (MessageBox.Show("Удалить этого автора?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var author = context.Author.Find(SelectedAuthor.id);
                    if (author != null)
                    {
                        context.Author.Remove(author);
                        context.SaveChanges();
                        LoadAuthors();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void LoadAuthors()
        {
            Authors.Clear();
            using (var context = new PictureGalleryEntities())
            {
                foreach (var item in context.Author.ToList())
                {
                    Authors.Add(item);
                }
            }
        }
        #endregion

        #region Exhibition методы
        private bool CanEditExhibition(object obj) => SelectedExhibition != null;

        private void OpenAddExhibitionWindow(object obj)
        {
            var window = new AddExhibitionWindow();
            if (window.ShowDialog() == true) LoadExhibitions();
        }

        private void OpenEditExhibitionWindow(object obj)
        {
            if (SelectedExhibition == null) return;
            var window = new EditExhibitionWindow(SelectedExhibition);
            if (window.ShowDialog() == true) LoadExhibitions();
        }

        private void DeleteExhibition(object obj)
        {
            if (SelectedExhibition == null) return;

            if (MessageBox.Show("Удалить эту выставку?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var exhibition = context.Exhibitions.Find(SelectedExhibition.id);
                    if (exhibition != null)
                    {
                        context.Exhibitions.Remove(exhibition);
                        context.SaveChanges();
                        LoadExhibitions();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void LoadExhibitions()
        {
            Exhibitions.Clear();
            using (var context = new PictureGalleryEntities())
            {
                foreach (var item in context.Exhibitions.ToList())
                {
                    Exhibitions.Add(item);
                }
            }
        }
        #endregion

        #region Genre методы
        private bool CanEditGenre(object obj) => SelectedGenre != null;

        private void OpenAddGenreWindow(object obj)
        {
            var window = new AddGenreWindow();
            if (window.ShowDialog() == true) LoadGenres();
        }

        private void OpenEditGenreWindow(object obj)
        {
            if (SelectedGenre == null) return;
            var window = new EditGenreWindow(SelectedGenre);
            if (window.ShowDialog() == true) LoadGenres();
        }

        private void DeleteGenre(object obj)
        {
            if (SelectedGenre == null) return;

            if (MessageBox.Show("Удалить этот жанр?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var genre = context.Genre.Find(SelectedGenre.id);
                    if (genre != null)
                    {
                        context.Genre.Remove(genre);
                        context.SaveChanges();
                        LoadGenres();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void LoadGenres()
        {
            Genres.Clear();
            using (var context = new PictureGalleryEntities())
            {
                foreach (var item in context.Genre.ToList())
                {
                    Genres.Add(item);
                }
            }
        }
        #endregion

        #region Medium методы
        private bool CanEditMedium(object obj) => SelectedMedium != null;

        private void OpenAddMediumWindow(object obj)
        {
            var window = new AddMediumWindow();
            if (window.ShowDialog() == true) LoadMediums();
        }

        private void OpenEditMediumWindow(object obj)
        {
            if (SelectedMedium == null) return;
            var window = new EditMediumWindow(SelectedMedium);
            if (window.ShowDialog() == true) LoadMediums();
        }

        private void DeleteMedium(object obj)
        {
            if (SelectedMedium == null) return;

            if (MessageBox.Show("Удалить эту технику?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var medium = context.Medium.Find(SelectedMedium.id);
                    if (medium != null)
                    {
                        context.Medium.Remove(medium);
                        context.SaveChanges();
                        LoadMediums();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void LoadMediums()
        {
            Mediums.Clear();
            using (var context = new PictureGalleryEntities())
            {
                foreach (var item in context.Medium.ToList())
                {
                    Mediums.Add(item);
                }
            }
        }
        #endregion

        #region Location методы
        private bool CanEditLocation(object obj) => SelectedLocation != null;

        private void OpenAddLocationWindow(object obj)
        {
            var window = new AddLocationWindow();
            if (window.ShowDialog() == true) LoadLocations();
        }

        private void OpenEditLocationWindow(object obj)
        {
            if (SelectedLocation == null) return;
            var window = new EditLocationWindow(SelectedLocation);
            if (window.ShowDialog() == true) LoadLocations();
        }

        private void DeleteLocation(object obj)
        {
            if (SelectedLocation == null) return;

            if (MessageBox.Show("Удалить эту локацию?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var location = context.Location.Find(SelectedLocation.id);
                    if (location != null)
                    {
                        context.Location.Remove(location);
                        context.SaveChanges();
                        LoadLocations();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void LoadLocations()
        {
            Locations.Clear();
            using (var context = new PictureGalleryEntities())
            {
                foreach (var item in context.Location.ToList())
                {
                    Locations.Add(item);
                }
            }
        }
        #endregion

        #region Staff методы
        private bool CanEditStaff(object obj) => SelectedStaff != null;

        private void OpenAddStaffWindow(object obj)
        {
            var window = new AddStaffWindow();
            if (window.ShowDialog() == true) LoadStaff();
        }

        private void OpenEditStaffWindow(object obj)
        {
            if (SelectedStaff == null) return;
            var window = new EditStaffWindow(SelectedStaff);
            if (window.ShowDialog() == true) LoadStaff();
        }

        private void DeleteStaff(object obj)
        {
            if (SelectedStaff == null) return;

            if (MessageBox.Show("Удалить этого сотрудника?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes) return;

            try
            {
                using (var context = new PictureGalleryEntities())
                {
                    var staff = context.Staff.Find(SelectedStaff.id);
                    if (staff != null)
                    {
                        context.Staff.Remove(staff);
                        context.SaveChanges();
                        LoadStaff();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void LoadStaff()
        {
            Staff.Clear();
            using (var context = new PictureGalleryEntities())
            {
                foreach (var item in context.Staff.ToList())
                {
                    Staff.Add(item);
                }
            }
        }
        #endregion
    }
}