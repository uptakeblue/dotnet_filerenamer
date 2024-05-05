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
    public partial class FrmMain : Form {
        private void refreshData( ) {
            _allAuthors = AuthorOperations.Author_GetList( );
        }

        private void populateAudiobookControls( string folderPath ) {
            var folderpathInfo = GeneralOperations.GetFolderpathInfo( folderPath, _allAuthors );
            if( folderpathInfo.Audiobook.AudiobookId <=0 ) {
                AudiobookOperation.Audiobook_Post( folderpathInfo.Audiobook, lstRenamedFiles.Items.Count );
            }

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
            var authors = new List<KeyValuePair<int, string>>( );
            authors.Add( new KeyValuePair<int, string>( 0, "All Authors" ) );
            foreach( var author in _allAuthors ) {
                authors.Add( author.KeyValuePair );
            }
            cboAuthor.DataSource = authors;

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
                object sender = null;
                refreshData( );
                cboAuthor_SelectedIndexChanged( sender, new EventArgs( ) );
            }
            frmAudobook = null;
        }

    }
}
