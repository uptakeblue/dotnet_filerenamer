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
            AudiobookOperation.Audiobook_Put( _audiobook );
            this.DialogResult = DialogResult.OK;
            this.Close( );

        }

        // functions
        public void PopulateForm( Audiobook audiobook ) {
            _audiobook = audiobook;
            txtAuthor.Text = audiobook.AuthornameReversed;
            txtTitle.Text = audiobook.Title;
            txtYearSeries.Text = audiobook.YearSeries;
            if( audiobook.Number > 0 ) {
                txtNumber.Text = ( (Decimal)audiobook.Number).ToString( "0.#" );
            }
            txtCreated.Text = audiobook.CreatedDate.ToString( "D" );
            if( audiobook.ReadDate != null ) {
                txtRead.Text = ( (DateTime)audiobook.ReadDate ).ToString( "D" );
                lblReadDate.Visible = true;
                txtRead.Visible = true;
            }

        }

    }
}

