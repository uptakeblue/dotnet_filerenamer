using FileRenamer.Model;
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
    public partial class FrmAuthorSelect : Form {
        public FrmAuthorSelect( ) {
            InitializeComponent( );
        }
        public Author Author { get; set; }

        private void btnOkay_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.OK;
            this.Author = AuthorOperations.Author_Get( (int)lstAuthor.SelectedValue );
            this.Close( );
        }

        public void PopulateAuthors( int authorId ) {
            var authors = AuthorOperations.Author_GetListKVP( );
            lstAuthor.DataSource = authors.FindAll( x => x.Key > 0 );
            if( authorId == 0 ) {
                lstAuthor.SelectedIndex = 0;
            } else {
                lstAuthor.SelectedValue = authorId;
            }
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
            this.Close( );
        }
    }
}
