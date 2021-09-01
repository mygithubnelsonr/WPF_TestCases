using PVS.MediaPlayer;
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
        private bool _isPlaying;
        private string _fullpath = "";
        private string _genre = "";
        private int _genreID = -1;
        private string _catalog = "";
        private int _catalogID = -1;
        private string _album = "";
        //private int _albumID = -1;
        private bool _isloaded = false;
        //private DispatcherTimer timerDuration;

        internal Player pvsPlayer;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            if (!Player.MFPresent) MessageBox.Show(Player.MFPresent_ResultString);

            CreatePlayer();
            InitializeComboGenres();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _isloaded = true;
        }

        private void CreatePlayer()
        {
            pvsPlayer = new Player();
            pvsPlayer.Audio.Volume = 0;

            // Add Player EventHandlers:
            // Add a player media start eventhandler to update the interface:
            pvsPlayer.Events.MediaStarted += MyPlayer_MediaStarted;
            // Add a player media end eventhandler to update the interface and playing 'next' media files (if autoPlayNext == true):
            pvsPlayer.Events.MediaEnded += MyPlayer_MediaEnded;
            // Add a media start- endposition changed event for the playing media (to update start/end textbox values):
            pvsPlayer.Events.MediaStartStopTimeChanged += MyPlayer_MediaStartStopTimeChanged;
            // Add a player media position eventhandler for showing position time strings (labels on both sides of the position slider):
            pvsPlayer.Events.MediaPositionChanged += MyPlayer_MediaPositionChanged;
            // Add a player pause and resume eventhandler (using same handler) to update the Pause button and text of display contextmenu:
            pvsPlayer.Events.MediaPausedChanged += MyPlayer_MediaPausedResumed;
            // Display audio volume and balance info beneath audio dials:
            pvsPlayer.Events.MediaAudioVolumeChanged += MyPlayer_MediaAudioVolumeChanged;
            pvsPlayer.Events.MediaAudioBalanceChanged += MyPlayer_MediaAudioBalanceChanged;
        }

        #region Event_Handler
        private void MyPlayer_MediaAudioBalanceChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MyPlayer_MediaAudioVolumeChanged(object sender, EventArgs e)
        {
            Debug.Print("MyPlayer_MediaAudioVolumeChanged");
        }

        private void MyPlayer_MediaPausedResumed(object sender, EventArgs e)
        {
            Debug.Print("MyPlayer_MediaPausedResumed");
        }

        private void MyPlayer_MediaPositionChanged(object sender, PositionEventArgs e)
        {
            TimeSpan fromStart = TimeSpan.FromTicks(e.FromStart);
            TimeSpan toStop = TimeSpan.FromTicks(e.ToStop);

            if (_userIsDraggingSlider == false && fromStart.TotalSeconds > 0)
            {
                sliderPosition.Value = fromStart.TotalSeconds;
                statusProgress.Text = fromStart.ToString(@"mm\:ss");
            }
        }

        private void MyPlayer_MediaStartStopTimeChanged(object sender, EventArgs e)
        {
            Debug.Print("MyPlayer_MediaStartStopTimeChanged");
        }

        private void MyPlayer_MediaEnded(object sender, EndedEventArgs e)
        {
            Debug.Print("MyPlayer_MediaEnded");

            switch (e.StopReason)
            {
                case StopReason.Finished:
                    if (true)
                    {
                        Dispatcher.BeginInvoke(new Action(() => Playback_PlayNext()));
                        Dispatcher.BeginInvoke(new Action(() => Play_Executed(this, null)));
                    }
                    else
                    {
                        //SetInterfaceOnMediaStop(true);
                    }
                    break;

                    //    case StopReason.AutoStop:
                    //        SetInterfaceOnMediaStop(false);
                    //        break;

                    //    case StopReason.UserStop:
                    //        SetInterfaceOnMediaStop(true);
                    //        StopAndPlay = false;
                    //        break;

                    //    case StopReason.Error:
                    //        SetInterfaceOnMediaStop(false);
                    //        ShowMediaEndedError(e);
                    //        if (Prefs.AutoPlayNext && Prefs.OnErrorPlayNext && (RepeatAll || RepeatShuffle || _mediaToPlay < Playlist.Count))
                    //        {
                    //            PlayNextMedia();
                    //        }
                    //        else SetInterfaceOnMediaStop(true);
                    //        break;
            }
        }

        private void MyPlayer_MediaStarted(object sender, EventArgs e)
        {
            Debug.Print("MyPlayer_MediaStarted");
        }
        #endregion

        private void InitializeComboGenres()
        {
            comboboxGenres.ItemsSource = GetData.GetGenres();
            comboboxGenres.SelectedIndex = 3;
            comboboxGenres.SelectedItem = 3;
        }

        private void MenuItemSetting_Click(object sender, RoutedEventArgs e)
        {
            //Settings settings = new Settings();
            //settings.ShowDialog();

            Playback_PlayNext();
        }

        private void comboboxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Playback_Stop();
            var comboboxitem = comboboxType.SelectedItem as ComboBoxItem;
            string selectedItem = comboboxitem.Content.ToString();
            DatagridContextmenuCreate(selectedItem);
        }

        private void comboboxGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Playback_Stop();
            var genre = (Genre)comboboxGenres.SelectedItem;
            _genre = genre.Name;
            _genreID = genre.ID;

            FillComboCatalog();
        }

        private void comboboxCatalogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Playback_Stop();
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
            Playback_Stop();
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
            if (_isloaded) pvsPlayer.Audio.Volume = (float)sliderVolume.Value;
        }

        private void sliderVolume_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var vol = (e.Delta > 0) ? 0.05 : -0.05;
            sliderVolume.Value += vol;
        }

        private void sliderPosition_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var part = sliderPosition.Maximum / 20;
            var pos = (e.Delta > 0) ? part : -part;

            sliderPosition.Value += pos;
            pvsPlayer.Position.FromStart = TimeSpan.FromSeconds(sliderPosition.Value);
        }

        private void sliderPosition_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            _userIsDraggingSlider = true;
        }

        private void sliderPosition_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds(sliderPosition.Value);
            pvsPlayer.Position.FromStart = t;
            Debug.Print($"{t}");
            _userIsDraggingSlider = false;
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        #region Datagrid Events

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.Print("datagrid_SelectionChanged");

            if (!_dataLoaded)
                return;

            _isPlaying = false;
            statusProgress.Text = @"00:00";
            statusDuration.Text = @"00:00";

            var row = datagrid.Items.IndexOf(datagrid.SelectedItem);

            textboxRowsSelected.Text = (row + 1).ToString();

            if (_isloaded && pvsPlayer.Playing)
            {
                Playback_Play();
            }
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
            _isPlaying = false;

            var currentItem = datagrid.SelectedIndex;

            if (currentItem + 1 < datagrid.Items.Count)
                datagrid.SelectedIndex = currentItem + 1;

        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (pvsPlayer != null) && (!String.IsNullOrEmpty(_fullpath));
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.Print("Play_Executed");
            Playback_Play();
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _isPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            pvsPlayer.Paused = !pvsPlayer.Paused;
            //timerDuration.Stop();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _isPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            pvsPlayer.Stop();
            _isPlaying = false;
        }

        #endregion

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    //if ((mediaPlayer.Source != null) && (mediaPlayer.NaturalDuration.HasTimeSpan) && (!_userIsDraggingSlider))
        //    //{
        //    //    sliderPosition.Minimum = 0;
        //    //    sliderPosition.Maximum = pvsPlayer.Audio.d .NaturalDuration.TimeSpan.TotalSeconds;
        //    //    sliderPosition.Value = pvsPlayer.Position;
        //    //    sliderPosition.TickFrequency = sliderPosition.Maximum / 10;
        //    //    statusDuration.Text = TimeSpan.FromSeconds(sliderPosition.Maximum).ToString(@"mm\:ss");

        //    //    progressBarPosition.Maximum = sliderPosition.Maximum;
        //    //}
        //}

        #region Methods

        private void FillComboCatalog()
        {
            var catalogs = GetData.GetCatalogs(_genre);
            comboboxCatalogs.ItemsSource = catalogs;
            comboboxCatalogs.SelectedIndex = 2;
            comboboxCatalogs.SelectedItem = 2;
        }

        private void FillComboAlbums()
        {
            var albums = GetData.GetAlbums(_genreID, _catalogID);
            comboboxAlbums.ItemsSource = albums;
            comboboxAlbums.SelectedIndex = 0;
            comboboxAlbums.SelectedItem = 0;
        }

        private void LoadData()
        {
            _dataLoaded = false;
            var songs = GetData.GetTitles(_genreID, _catalogID, _album);
            datagrid.ItemsSource = songs;
            datagrid.SelectedIndex = 0;
            datagrid.SelectedItem = 0;

            var item = datagrid.SelectedItem as vSong;
            _fullpath = $"{item.Path}\\{item.FileName}";

            textboxRowsSelected.Text = "1";
            _dataLoaded = true;
        }

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

        private void Playback_Play()
        {
            Debug.Print("Playback_Play");

            pvsPlayer.Play(_fullpath);

            sliderPosition.Maximum = pvsPlayer.Media.Duration.TotalSeconds;
            sliderPosition.TickFrequency = sliderPosition.Maximum / 10;
            progressBarPosition.Maximum = sliderPosition.Maximum;
            statusDuration.Text = TimeSpan.FromSeconds(sliderPosition.Maximum).ToString(@"mm\:ss");
            _isPlaying = true;
        }

        private void Playback_PlayNext()
        {
            Debug.Print("Playback_PlayNext");

            int nextindex = datagrid.SelectedIndex + 1;

            if (nextindex < datagrid.Items.Count)
            {
                datagrid.SelectedIndex = nextindex;
                datagrid.SelectedItem = nextindex;
            }
        }

        private void Playback_Stop()
        {
            if (_isloaded) pvsPlayer.Stop();
        }
    }
}
