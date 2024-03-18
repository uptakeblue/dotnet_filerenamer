using FileRenamer.Forms;
using FileRenamer.Model;
using FileRenamer.Operations;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRenamer.Forms
{
    public partial class FrmMain : Form{
        private bool _dragging = false;
        private int _mouseDragX = 0;
        private int _mouseDragY = 0;

        private Settings _settings;
        private FileItemList _fileItemList = new FileItemList( );

        private Author _author = new Author( );
        private Audiobook _audiobook = new Audiobook( );

        //private List<Audiobook> _audiobooks;
        private List<Author> _allAuthors = AuthorOperations.Author_GetList();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load( object sender, EventArgs e ) {
            _settings = new Settings( );
            System.Drawing.Point l = _settings.Location;
            if( ( l.X < 0 ) || ( l.X > Screen.GetWorkingArea( this ).Width ) ) {
                l.X = 100;
            }
            if( ( l.Y < 0 ) || ( l.Y > Screen.GetWorkingArea( this ).Height ) ) {
                l.Y = 100;
            }
            this.Location = l;
            this.Size = _settings.Size;
            spltFiles.SplitterDistance = _settings.SplitterDistance;

            lblTitle.Parent = this;
            lblTitle.Location = new Point( ( this.Width - lblTitle.Width ) / 2, 4 );
            btnExit.Parent = this;
            btnExit.Location = new Point( this.Width - btnExit.Width - 5, 3 );

            var authors = new List<KeyValuePair<int, string>>( );
            foreach( var author in _allAuthors ) {
                authors.Add( author.KeyValuePair );
            }
            
            cboAuthor.DataSource = authors;
            if(_settings.AuthorId > 0 ) {
                cboAuthor.SelectedValue = _settings.AuthorId;
            }

            this.CancelButton = btnExit;

        }

        private void btnExit_Click( object sender, EventArgs e ) {
            _settings.Size = this.Size;
            _settings.Location = this.Location;
            _settings.SplitterDistance = spltFiles.SplitterDistance;
            _settings.AuthorId = (int)cboAuthor.SelectedValue;

            _settings.TabPageName = tabMain.SelectedTab.Name;
            _settings.Save( );
            this.Close( );

        }

        private void tabMain_SelectedIndexChanged( object sender, EventArgs e ) {
            if( tabMain.SelectedTab.Name == "tabFiles" ) {
                if( cboAuthor.SelectedIndex == -1 ) {
                    cboAuthor.SelectedIndex = 0;
                }
            }

        }

        private void FormMain_MouseDown( object sender, MouseEventArgs e ) {
            _dragging = true;
            _mouseDragX = Cursor.Position.X - this.Left;
            _mouseDragY = Cursor.Position.Y - this.Top;

        }

        private void FormMain_MouseMove( object sender, MouseEventArgs e ) {
            if( _dragging ) {
                var screen = Screen.PrimaryScreen.WorkingArea;
                var currentX = Cursor.Position.X;
                var currentY = Cursor.Position.Y;
                var newX = Math.Min( currentX - _mouseDragX, screen.Right - this.Width );
                var newY = Math.Min( currentY - _mouseDragY, screen.Bottom - this.Height );
                this.Location = new System.Drawing.Point( newX, newY );
            }

        }

        private void FormMain_MouseUp( object sender, MouseEventArgs e ) {
            _dragging = false;
        }

        private void cboAuthor_SelectedIndexChanged( object sender, EventArgs e ) {
            var authorId = (int)cboAuthor.SelectedValue;
            var audiobooks = AudiobookOperation.Audiobook_GetListByAuthor( authorId );
            var sortedAudiobooks = audiobooks.OrderBy( a => a.YearSeries).ThenBy(a=>a.Number).ThenBy(a=>a.Title).ToList();
            grdAudiobook.Rows.Clear( );

            foreach( var audiobook in sortedAudiobooks ) {
                grdAudiobook.Rows.Add( audiobook.valueArray );
            }

        }

        private void btnFolder_Click( object sender, EventArgs e ) {
            if( folderBrowser.ShowDialog( ) == DialogResult.OK ) {
                string folderPath = folderBrowser.SelectedPath;
                txtFolder.Text = folderPath;
                populateAudiobookControls( folderPath );
                _settings.Folder = folderPath;
                _settings.Save( );
                populateSourceFileList( folderPath );
                generateFileNames( );
            }

        }

        private void txtAudiobook_DoubleClick( object sender, EventArgs e ) {
            if( _audiobook.AudiobookId > 0 ) {
                editAudiobook( _audiobook );
            }
        }

        /// <summary>
        /// Open FrmAuthorSelect dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAuthor_DoubleClick( object sender, EventArgs e ) {
            var frmAuthorSelect = new FrmAuthorSelect( );
            frmAuthorSelect.PopulateAuthors( _author.AuthorId );
            if( frmAuthorSelect.ShowDialog( ) == DialogResult.OK ) {
                _author = frmAuthorSelect.Author;
                txtAuthor.Text = _author.Name;
                cboAuthor.SelectedValue = _author.AuthorId;
            }
            frmAuthorSelect = null;
        }

        private void btnGenerateName_Click( object sender, EventArgs e ) {
            generateFileNames( );
        }

        private void btnClear_Click( object sender, EventArgs e ) {
            _fileItemList.GenerateTargetFiles( string.Empty );
            lstRenamedFiles.DataSource = null;
            lstRenamedFiles.DisplayMember = "TargetFileName";
            lstRenamedFiles.DataSource = _fileItemList;
        }

        private void btnRename_Click( object sender, EventArgs e ) {
            if( lstRenamedFiles.Items.Count == lstSourceFiles.Items.Count ) {
                try {
                    // check folder name
                    var folder = new DirectoryInfo( txtFolder.Text );
                    if( folder.Name != "10 Minute Slices" ) {
                        throw new Exception( "Source folder must be named \"10 Minute Slices\"." );
                    }
                    // create author if it doesn't exist
                    if( ( _author.AuthorId <= 0 ) && ( MessageBox.Show( this, "The author does not exist.  Create new author?", "Author", MessageBoxButtons.YesNoCancel ) == DialogResult.Yes ) ) {
                        _author = AuthorOperations.Author_Post( _author.Last, _author.First );
                    };
                    if( _author.AuthorId > 0 ) {
                        // create audiobook if it doesn't exist
                        if( _audiobook.AudiobookId <= 0 ) {
                            _audiobook = AudiobookOperation.Audiobook_Post(_author.AuthorId, txtAudiobook.Text );
                        };
                        if( _audiobook.AuthorId.CompareTo( _author.AuthorId ) != 0 ) {
                            // if the audiobook has a different author, update it
                            _audiobook.AuthorId = _author.AuthorId;
                            AudiobookOperation.Audiobook_Put( _audiobook );
                            _audiobook = AudiobookOperation.Audiobook_Get( _audiobook.AudiobookId );
                        }
                        refreshData( );
                        populateAuthors( );
                        cboAuthor.SelectedValue = _author.AuthorId;
                        if( !backgroundWorker1.IsBusy ) {
                            this.Cursor = Cursors.WaitCursor;
                            pgbRename.Value = 0;
                            pgbRename.Visible = true;
                            pgbRename.Maximum = _fileItemList.Count;
                            backgroundWorker1.RunWorkerAsync( );
                        }

                    }
                }
                catch( Exception ex ) {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show( string.Format( "An error occurred:\n{0}", ex.Message ), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }


        }

        private void grdAudiobook_CellDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            if( ( e.RowIndex == -1 ) || ( e.RowIndex == grdAudiobook.Rows.Count - 1 ) )
                return;
            var audiobookId = (int)grdAudiobook.Rows[e.RowIndex].Cells[0].Value;
            var audiobook = AudiobookOperation.Audiobook_Get( audiobookId );
            editAudiobook( audiobook );
        }

        private void backgroundWorker1_DoWork( object sender, DoWorkEventArgs e ) {
            var worker = sender as BackgroundWorker;
            uint count = 1;
            foreach( var fileItem in _fileItemList ) {
                var tagInfo = new TagInfo( ) {
                    AlbumArtist =  _audiobook.Authorname,
                    Performer = _audiobook.AuthornameReversed,
                    Album = _audiobook.Display,
                    Genre = "Audiobook",
                    FilePath = fileItem.SourceFilePath,
                    TrackNumber = count++,
                    Title = new FileInfo( fileItem.TargetFilePath ).Name
                };
                GeneralOperations.SaveFile( tagInfo );
                if( ( File.Exists( fileItem.SourceFilePath ) ) && ( !File.Exists( fileItem.TargetFilePath ) ) ) {
                    File.Move( fileItem.SourceFilePath, fileItem.TargetFilePath );
                }
                worker.ReportProgress( 1 );
            }

        }
    }
}
