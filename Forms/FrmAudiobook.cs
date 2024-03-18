using FileRenamer.Model;
using FileRenamer.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRenamer.Forms {
    public partial class FrmAudiobook : Form {

        const string nullFormat = " ";
        const string dateFormat = "dddd, MMMM dd, yyyy";
        private Audiobook _audiobook;

        public FrmAudiobook( ) {
            InitializeComponent( );
        }

        // form event handlers
        private void FrmAudiobook_Load( object sender, EventArgs e ) {

        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
            this.Close( );

        }

        private void btnOkay_Click( object sender, EventArgs e ) {
            _audiobook.Title = txtTitle.Text;
            _audiobook.YearSeries = txtYearSeries.Text;
            _audiobook.Number = 0;
            if( !string.IsNullOrEmpty( txtNumber.Text ) ) {
                decimal num;
                if( Decimal.TryParse( txtNumber.Text, out num ) ) {
                    _audiobook.Number = num;
                }
            }
            _audiobook.CreatedDate = dtpCreatedDate.Value;
            //_audiobook.Author = new Author( ) { AuthorId = (int)cboAuthor.SelectedValue };
            if( dtpReadDate.Visible ) {
                _audiobook.ReadDate = dtpReadDate.Value;
            } else {
                _audiobook.ReadDate = null;
            }
            AudiobookOperation.Audiobook_Put( _audiobook );
            this.DialogResult = DialogResult.OK;
            this.Close( );

        }

        // functions
        public void PopulateForm( Audiobook audiobook ) {
            _audiobook = audiobook;
            cboAuthor.DataSource = AuthorOperations.Author_GetListKVP( );
            cboAuthor.SelectedValue = audiobook.AuthorId;
            txtTitle.Text = audiobook.Title;
            txtYearSeries.Text = audiobook.YearSeries;
            if( audiobook.Number > 0 ) {
                txtNumber.Text = ( (Decimal)audiobook.Number).ToString( "0.#" );
            }
            dtpCreatedDate.Value = audiobook.CreatedDate;

            if( audiobook.ReadDate != null && ( (DateTime)audiobook.ReadDate ).CompareTo( DateTime.MinValue ) > 0 ) {
                dtpReadDate.Value = (DateTime)audiobook.ReadDate;
                dtpReadDate.Visible = true;
            } else {
                dtpReadDate.Visible = false;
            }
            lblReadDate.Visible = dtpReadDate.Visible;

        }

    }
}

