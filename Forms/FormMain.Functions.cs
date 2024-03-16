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

namespace FileRenamer.Forms {
    public partial class FormMain : Form {
        private void refreshData( ) {
            _allAuthors = AuthorOperations.Author_GetList( );
            //_allAudiobooks = AudiobookOperations.Audiobook_GetList( );
            _allAuthors = AuthorOperations.Author_GetList( );
    }

        private void populateAudiobookControls( string folderPath ) {
            var folderpathInfo = GeneralOperations.GetFolderpathInfo( folderPath, _allAuthors );

            _author = folderpathInfo.Author;
            _audiobook = folderpathInfo.Audiobook;

            cboAuthor.SelectedValue = _author.AuthorId;

            txtAudiobook.Text = folderpathInfo.Audiobook.Title;
            txtAuthor.Text = folderpathInfo.Author.Name;

            if( folderpathInfo.Audiobook.AudiobookId > 0 ) {
                txtAudiobook.ReadOnly = true;
                txtAudiobook.BackColor = SystemColors.ControlLight;
            } else {
                txtAudiobook.ReadOnly = false;
                txtAudiobook.BackColor = SystemColors.Window;
            }

            string newFileName = txtAudiobook.Text;
            if( newFileName.Contains( "-" ) ) {
                var tokens = newFileName.Split( '-' );
                newFileName = tokens[tokens.Length - 1].Trim( );
            }
            StringBuilder sb = new StringBuilder( );
            char[ ] chars = newFileName.ToCharArray( );
            for( int i = 0; i < newFileName.Length; i++ ) {
                int charInt = chars[i];
                if( ( ( charInt >= 65 ) && ( charInt <= 90 ) ) ||
                    ( ( charInt >= 97 ) && ( charInt <= 122 ) ) )
                    sb.Append( newFileName.Substring( i, 1 ) );
                else if( charInt == 32 ) {
                    if( sb.Length > 0 ) sb.Append( "_" );
                }
            }
            if( sb.Length > 0 ) {
                txtRename.Text = sb.ToString( );
            }
        }


        private void populateSourceFileList( string folderPath ) {
            _fileItemList = new FileItemList( ) { FolderPath = folderPath };
            _fileItemList.GenerateTargetFiles( txtRename.Text );
            lstSourceFiles.DataSource = _fileItemList;
            lstRenamedFiles.DataSource = _fileItemList;
        }

        private void generateFileNames( ) {
            if( !string.IsNullOrEmpty( txtRename.Text ) ) {
                _fileItemList.GenerateTargetFiles( txtRename.Text );
                lstRenamedFiles.DataSource = null;
                lstRenamedFiles.DisplayMember = "TargetFileName";
                lstRenamedFiles.DataSource = _fileItemList;
            }
        }


        private void populateAuthors( ) {
            var authorsFiltered = _allAuthors.FindAll( x => x.AudiobookCount.Total > 0 );
            if( chkUnread.Checked ) {
                authorsFiltered = _allAuthors.FindAll( x => x.AudiobookCount.Unread > 0 );
            }
            if( chkCurrent.Checked ) {
                authorsFiltered = _allAuthors.FindAll( x => x.AudiobookCount.Current > 0 );
            }

            var authors = new List<KeyValuePair<int, string>>( );
            authors.Add( new KeyValuePair<int, string>( 0, "All Authors" ) );
            foreach( var author in authorsFiltered ) {
                authors.Add( author.KeyValuePair );
            }
            cboAuthor.DataSource = authors;

        }

        private void populateAudiobooks( ) {
            grdAudiobook.Rows.Clear( );

            var filteredBooks = _allAudiobooks;
            if( chkUnread.Checked )
                filteredBooks = filteredBooks.FindAll( x => x.IsUnRead == true );
            if( chkCurrent.Checked ) {
                filteredBooks = filteredBooks.FindAll( x => x.IsCurrent == true );
            } else {
                filteredBooks =
                ( cboAuthor.SelectedIndex == 0 ) || ( cboAuthor.SelectedItem == null )
                ? filteredBooks
                : filteredBooks.FindAll( x => x.Author.AuthorId == _author.AuthorId );
            }

            foreach( var audiobook in filteredBooks ) {
                audiobook.IsUseExtendedTitle = cboSeries.Checked;
            }

            filteredBooks.Sort( );

            foreach( var audiobook in filteredBooks ) {
                grdAudiobook.Rows.Add( audiobook.valueArray );
            }
            lblRowcount.Text = string.Format( "{0} row{1}", filteredBooks.Count, filteredBooks.Count == 1 ? "" : "s" );
        }

        /// <summary>
        /// Open FrmAudiobook dialog
        /// </summary>
        /// <param name="audiobook"></param>
        private void editAudiobook( Audiobook audiobook ) {
            var frmAudobook = new FrmAudiobook( );
            frmAudobook.PopulateForm( audiobook );
            var result = frmAudobook.ShowDialog( );
            if( result == DialogResult.OK ) {
                refreshData( );
                populateAudiobooks( );
            }
            frmAudobook = null;
        }

        private void grdAudiobook_CellContentClick( object sender, DataGridViewCellEventArgs e ) {
            if( ( e.ColumnIndex >= 4 ) && ( e.RowIndex < grdAudiobook.Rows.Count - 1 ) ) {
                var audiobookId = (int)grdAudiobook.Rows[e.RowIndex].Cells[0].Value;
                var audiobook = AudiobookOperations.Audiobook_Get( audiobookId );
                var chk = (DataGridViewCheckBoxCell)grdAudiobook.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if( e.ColumnIndex == 5 ) {
                    // read / unread
                    var isUnread = ( chk.Value.ToString( ) == (string)chk.TrueValue );
                    if( isUnread != audiobook.IsUnRead ) {
                        if( isUnread ) {
                            audiobook.ReadDate = DateTime.MinValue;
                        } else {
                            audiobook.ReadDate = DateTime.Now;
                        }
                        AudiobookOperations.Audiobook_Update( audiobook );
                        GeneralOperations.WriteToLogFile( string.Format( "Marked Audiobook \"{0}\" \"{1}\"", _audiobook.Title, ( isUnread ? "read" : "unread" ) ) );
                        refreshData( );
                    }
                }
                if( e.ColumnIndex == 4 ) {
                    // current / not current
                    var isCurrent = ( chk.Value.ToString( ) != (string)chk.TrueValue );
                    if( isCurrent != audiobook.IsCurrent ) {
                        audiobook.IsCurrent = isCurrent;
                        AudiobookOperations.Audiobook_Update( audiobook );
                        GeneralOperations.WriteToLogFile( string.Format( "Marked Audiobook \"{0}\" \"{1}\"", _audiobook.Title, ( isCurrent ? "current" : "not current" ) ) );
                        refreshData( );
                    }
                }
            }

        }
    }
}
