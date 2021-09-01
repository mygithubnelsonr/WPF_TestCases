using EF_Testcase.BLL;
using EF_Testcase.DAL;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace EF_Testcase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _dataLoaded = false;
        private bool _userIsDraggingSlider;
        private bool _mediaPlayerIsPlaying;
        private string _fullpath = "";

        private DispatcherTimer timerDuration;

        public MainWindow()
        {
            InitializeComponent();

            mediaPlayer.Volume = 0;
            timerDuration = new DispatcherTimer();
            timerDuration.Interval = TimeSpan.FromSeconds(1);
            timerDuration.Tick += timer_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGetSet.Datasource = DataGetSet.DataSourceEnum.Songs;
            LoadData();
            datagrid.SelectedIndex = 1;
            datagrid.ScrollIntoView(datagrid.SelectedItem);
            datagrid.Focus();
        }

        private void CopyDataRowCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.combobox.SelectedIndex == 0;
        }

        private void CopyDataRowExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var rowlist = (vSongs)datagrid.SelectedItem;

            string songFields = DataGetSet.GetSongFieldValuesByID(rowlist.ID);

            Clipboard.Clear();
            Clipboard.SetText(songFields);
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DatagridContextmenuCreate();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            DataGetSet.Datasource = DataGetSet.DataSourceEnum.Songs;

            var artoken = textboxQuery.Text.Split(',');

            LoadData(artoken[0], artoken[1]);

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

        #region Datagrid Events

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fullpath = "";

            _mediaPlayerIsPlaying = false;
            statusProgress.Text = @"00:00";
            statusDuration.Text = @"00:00";

            if (_dataLoaded == false)
                return;

            var count = datagrid.Items.Count;
            var row = datagrid.Items.IndexOf(datagrid.CurrentItem);

            if (DataGetSet.Datasource == DataGetSet.DataSourceEnum.Songs)
            {
                var rowlist = (vSongs)datagrid.SelectedItem;
                fullpath = $"{rowlist.Pfad}\\{rowlist.FileName}";
            }
            if (DataGetSet.Datasource == DataGetSet.DataSourceEnum.Playlist)
            {
                var rowlist = (vPlaylistSongs)datagrid.SelectedItem;
                fullpath = $"{rowlist.Pfad}\\{rowlist.FileName}";
            }

            mediaPlayer.Source = new Uri(fullpath);

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
            var rowlist = (vSongs)datagrid.SelectedItem;
            var titelID = rowlist.ID;
            var playlistID = 12;

            DataGetSet.AddSongToPlaylist(Convert.ToInt32(titelID), playlistID);
        }

        private void dgmenuitemCopyCell_Click(object sender, RoutedEventArgs e)
        {
            var cellInfo = datagrid.SelectedCells[0].Column;
            //var content = cellInfo.Column.GetCellContent(cellInfo.Item);

        }

        private void dgmenuitemCopyLine_Click(object sender, RoutedEventArgs e)
        {
            var rowlist = (vSongs)datagrid.SelectedItem;

            string songFields = DataGetSet.GetSongFieldValuesByID(rowlist.ID);

            Clipboard.Clear();
            Clipboard.SetText(songFields);
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
            mediaPlayer.Stop();
            _mediaPlayerIsPlaying = false;
            timerDuration.Stop();
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
            }
        }

        private void textboxSel_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int i = Convert.ToInt32(textboxSel.Text) + 1;
            //textboxSel.Text = i.ToString();
        }

        #region Methods
        private void LoadData()
        {
            _dataLoaded = false;
            DataGetSet.Datasource = DataGetSet.DataSourceEnum.Songs;

            var songs = DataGetSet.GetSongs("Annette", "VHS = Burning Boots 1998");
            datagrid.ItemsSource = songs;
            _dataLoaded = true;
        }

        private void FillDatagridByTabPlaylist(int playlistID)
        {
            var results = DataGetSet.GetPlaylistEntries(playlistID);
            if (results != null)
            {
                DataGetSet.Datasource = DataGetSet.DataSourceEnum.Playlist;
                datagrid.ItemsSource = results;
                _dataLoaded = true;

                if (datagrid.Items.Count > 1)
                    datagrid.SelectedIndex = 1;
            }
        }

        private void LoadData(string catalog, string album)
        {
            _dataLoaded = false;


            var songs = DataGetSet.GetSongs(catalog, album);
            datagrid.ItemsSource = songs;
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

        private void DatagridContextmenuCreate()
        {
            var comboboxitem = combobox.SelectedItem as ComboBoxItem;
            string selectedItem = comboboxitem.Content.ToString();
            Debug.Print(selectedItem);

            var context = new MyJukeboxEntities();
            var list = DataGetSet.GetPlaylists();

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

            if (selectedItem == "Audio")
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

            if (selectedItem == "Playlist")
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

        private void MenuItemSetting_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
    }
}
