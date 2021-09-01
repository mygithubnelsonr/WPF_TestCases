using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using WPFMediaplayerDapper.DataAccess;

namespace WPFMediaplayerDapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private bool _dataLoaded = false;
        private bool _userIsDraggingSlider;
        private bool _mediaPlayerIsPlaying;
        private string _fullpath = "";
        private string _genre = "";
        private int _genreID = -1;
        private string _catalog = "";
        private int _catalogID = -1;
        private string _album = "";
        private int _albumID = -1;
        private DispatcherTimer timerDuration;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            InitializeComboGenres();

            mediaPlayer.Volume = 0;
            timerDuration = new DispatcherTimer();
            timerDuration.Interval = TimeSpan.FromSeconds(1);
            timerDuration.Stop();
            timerDuration.Tick += timer_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadData();
            //datagrid.SelectedIndex = 1;
            //datagrid.ScrollIntoView(datagrid.SelectedItem);
            //datagrid.Focus();
        }

        private void InitializeComboGenres()
        {
            comboboxGenres.ItemsSource = DataAccess.GetData.GetGenres();
        }

        private void MenuItemSetting_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void comboboxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboboxitem = comboboxType.SelectedItem as ComboBoxItem;
            string selectedItem = comboboxitem.Content.ToString();
            Debug.Print(selectedItem);
            DatagridContextmenuCreate(selectedItem);

        }

        private void comboboxGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var genre = (Genre)comboboxGenres.SelectedItem;
            _genre = genre.Name;
            _genreID = genre.ID;

            FillComboCatalog();
        }

        private void comboboxCatalogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var catalog = (Catalog)comboboxCatalogs.SelectedItem;

            if (catalog != null)
            {
                _catalog = catalog.Name;
                _catalogID = GetData.GetCatalogID(_catalog);

                FillComboAlbums();
            }
        }

        private void comboboxAlbums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var album = (Album)comboboxAlbums.SelectedItem;
            if (album != null)
            {
                _album = album.Name;
                LoadData();
            }
        }

        private void CopyDataRowCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.comboboxType.SelectedIndex == 0;
        }

        private void CopyDataRowExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var rowlist = (vSong)datagrid.SelectedItem;

            string songFields = GetData.GetSongFieldValuesByID(rowlist.ID);

            Clipboard.Clear();
            Clipboard.SetText(songFields);
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            ConnectionTools.Datasource = ConnectionTools.DataSourceEnum.Songs;

            LoadData();

            if (datagrid.Items.Count > 0)
            {
                datagrid.SelectedIndex = 6;
                datagrid.ScrollIntoView(datagrid.SelectedItem);
            }

            datagrid.Focus();
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = sliderVolume.Value;
        }

        private void sliderVolume_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var vol = (e.Delta > 0) ? 0.1 : -0.1;
            sliderVolume.Value += vol;
            mediaPlayer.Volume += vol;
        }

        private void sliderPosition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            statusProgress.Text = TimeSpan.FromSeconds(sliderPosition.Value).ToString(@"mm\:ss");
        }

        private void sliderPosition_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            _userIsDraggingSlider = true;
        }

        private void sliderPosition_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            _userIsDraggingSlider = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(sliderPosition.Value);
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void textboxRowsSelected_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        #region Datagrid Events

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fullpath = "";

            _mediaPlayerIsPlaying = false;
            statusProgress.Text = @"00:00";
            statusDuration.Text = @"00:00";

            var count = datagrid.Items.Count;
            var row = datagrid.Items.IndexOf(datagrid.CurrentItem);

            if (ConnectionTools.Datasource == ConnectionTools.DataSourceEnum.Songs)
            {
                var rowlist = (vSong)datagrid.SelectedItem;
                fullpath = $"{rowlist.Path}\\{rowlist.FileName}";
            }
            if (ConnectionTools.Datasource == ConnectionTools.DataSourceEnum.Playlist)
            {
                var rowlist = (vSong)datagrid.SelectedItem;
                fullpath = $"{rowlist.Path}\\{rowlist.FileName}";
            }

            mediaPlayer.Source = new Uri(fullpath);
            _mediaPlayerIsPlaying = true;
            _fullpath = fullpath;
        }

        private void DatagridContextMenuitemFileNew_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print("menuitemFileNew_Click");
        }

        private void DatagridContextMenuitemFileOpen_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print("menuitemFileOpen_Click");
        }

        private void contextmenuDatagridSendtoPlaylist_Click(object sender, RoutedEventArgs e)
        {
            var menuitem = sender as MenuItem;
            Debug.Print($"contextmenuDatagridSendtoPlaylist_Click: ID={menuitem.Tag}, Heder={menuitem.Header}");
        }

        private void contextmenuDatagridMovetoPlaylist_Click(object sender, RoutedEventArgs e)
        {
            var menuitem = sender as MenuItem;
            Debug.Print($"contextmenuDatagridMovetoPlaylist_Click: ID={menuitem.Tag}, Heder={menuitem.Header}");
        }


        private void dgmenuitemSendTo_Click(object sender, RoutedEventArgs e)
        {
            //var rowlist = (vSong)datagrid.SelectedItem;
            //var titelID = rowlist.ID;
            //var playlistID = 12;

            //DataGetSet.AddSongToPlaylist(Convert.ToInt32(titelID), playlistID);
        }

        private void dgmenuitemCopyCell_Click(object sender, RoutedEventArgs e)
        {
            var cellInfo = datagrid.SelectedCells[0].Column;
            //var content = cellInfo.Column.GetCellContent(cellInfo.Item);

        }

        private void dgmenuitemCopyLine_Click(object sender, RoutedEventArgs e)
        {
            //var rowlist = (vSongs)datagrid.SelectedItem;

            //string songFields = DataGetSet.GetSongFieldValuesByID(rowlist.ID);

            //Clipboard.Clear();
            //Clipboard.SetText(songFields);
        }

        #endregion

        #region MediaPlayer Elements
        private void mediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {

        }

        private void mediaplayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            _mediaPlayerIsPlaying = false;

            var currentItem = datagrid.SelectedIndex;

            if (currentItem + 1 < datagrid.Items.Count)
                datagrid.SelectedIndex = currentItem + 1;

        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (mediaPlayer != null) && (mediaPlayer.Source != null);
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            timerDuration.Start();
            mediaPlayer.Play();
            _mediaPlayerIsPlaying = true;
            statusDuration.Text = TimeSpan.FromSeconds(sliderPosition.Maximum).ToString(@"mm\:ss");
            sliderPosition.TickFrequency = sliderPosition.Maximum / 10;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mediaPlayer.Pause();
            timerDuration.Stop();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            timerDuration.Stop();
            mediaPlayer.Stop();
            _mediaPlayerIsPlaying = false;
        }

        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((mediaPlayer.Source != null) && (mediaPlayer.NaturalDuration.HasTimeSpan) && (!_userIsDraggingSlider))
            {
                sliderPosition.Minimum = 0;
                sliderPosition.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliderPosition.Value = mediaPlayer.Position.TotalSeconds;
                sliderPosition.TickFrequency = sliderPosition.Maximum / 10;
                statusDuration.Text = TimeSpan.FromSeconds(sliderPosition.Maximum).ToString(@"mm\:ss");

                progressBarPosition.Maximum = sliderPosition.Maximum;
            }
        }

        #region Methods

        private void FillComboCatalog()
        {
            var catalogs = GetData.GetCatalogs(_genre);
            comboboxCatalogs.ItemsSource = catalogs;
        }

        private void FillComboAlbums()
        {
            var albums = GetData.GetAlbums(_genreID, _catalogID);
            comboboxAlbums.ItemsSource = albums;
        }

        private void LoadData()
        {
            var songs = GetData.GetTitles(_genreID, _catalogID, _album);
            datagrid.ItemsSource = songs;
            datagrid.Columns[0].Visibility = Visibility.Hidden;
        }

        //private void LoadData(string catalog, string album)
        //{
        //    _dataLoaded = false;

        //    var songs = GetData.GetTitles(catalog, album);
        //    datagrid.ItemsSource = songs;
        //    _dataLoaded = true;
        //}

        #region walking through menu
        //
        //miSendto.Items.Add(miFilea);
        //MenuItem miOpen = new MenuItem();
        //miOpen.Header = "Open";
        //miOpen.Click += new RoutedEventHandler(this.menuitemFileOpen_Click);
        //miSendto.Items.Add(miOpen);
        //MenuItem miOpen1 = new MenuItem();
        //miOpen1.Header = "Recently Opened";
        //miOpen.Items.Add(miOpen1);
        //MenuItem miOpen1a = new MenuItem();
        //miOpen1a.Header = "Text.xaml";
        //miOpen1.Items.Add(miOpen1a);
        //contextmenu.Items.Add(miSendto);
        //datagrid.ContextMenu = contextmenu;
        #endregion

        private void DatagridContextmenuCreate(string type)
        {
            //var comboboxitem = comboboxType.SelectedItem as ComboBoxItem;
            //string selectedItem = comboboxitem.Content.ToString();
            //Debug.Print(selectedItem);

            var list = GetData.GetPlaylists();

            ContextMenu contextmenu = (ContextMenu)this.FindResource("contextmenuDatagrid");

            // add menu item to Mainmenu
            MenuItem miFile = new MenuItem();
            miFile.Header = "File";
            MenuItem miFileNew = new MenuItem();
            miFileNew.Header = "New";
            miFileNew.Click += new RoutedEventHandler(this.DatagridContextMenuitemFileNew_Click);
            miFile.Items.Add(miFileNew);

            contextmenu.Items.Add(miFile);

            // add menu items to existing menu
            MenuItem miSendto = (MenuItem)contextmenu.Items[0];
            miSendto.Items.Clear();

            if (type == "Audio")
            {
                miSendto.Header = "Send to";
                foreach (var playlist in list)
                {
                    MenuItem menuItem = new MenuItem();
                    menuItem.Header = playlist.Name;
                    menuItem.Tag = playlist.ID;
                    menuItem.Click += new RoutedEventHandler(this.contextmenuDatagridSendtoPlaylist_Click);
                    miSendto.Items.Add(menuItem);
                }

                // remove menuitem 'remove'
                MenuItem mi = (MenuItem)contextmenu.Items[1];
                Debug.Print(mi.Header.ToString());
                contextmenu.Items.Remove(mi);

                MenuItem miRemove = new MenuItem();
                miRemove.Header = "Remove";
                miRemove.Click += new RoutedEventHandler(this.contextmenuDatagridRemoveFromAudio_Click);
                contextmenu.Items.Insert(1, miRemove);
            }

            if (type == "Playlist")
            {
                miSendto.Header = "Move to";
                foreach (var playlist in list)
                {
                    MenuItem menuItem = new MenuItem();
                    menuItem.Header = playlist.Name;
                    menuItem.Tag = playlist.ID;
                    menuItem.Click += new RoutedEventHandler(this.contextmenuDatagridMovetoPlaylist_Click);
                    miSendto.Items.Add(menuItem);
                }

                // remove menuitem 'remove'
                MenuItem mi = (MenuItem)contextmenu.Items[1];
                Debug.Print(mi.Header.ToString());
                contextmenu.Items.Remove(mi);

                MenuItem miRemove = new MenuItem();
                miRemove.Header = "Remove";
                miRemove.Click += new RoutedEventHandler(this.contextmenuDatagridRemoveFromPlaylist_Click);
                contextmenu.Items.Insert(1, miRemove);
            }
        }

        private void contextmenuDatagridRemoveFromAudio_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print("contextmenuDatagridRemoveFromAudio_Click");
        }

        private void contextmenuDatagridRemoveFromPlaylist_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print("contextmenuDatagridRemoveFromPlaylist_Click");
        }

        #endregion

        private void FileOpen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("FileOpen_Click");
        }

        private void MenuItemTools_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool hasDataGridErrors()
        {
            var rowIndex = datagrid.SelectedIndex;

            DataGridRow row = (DataGridRow)datagrid.ItemContainerGenerator.ContainerFromIndex(rowIndex);

            if (row != null && Validation.GetHasError(row))
                return true;
            else
                return false;
        }

    }
}
