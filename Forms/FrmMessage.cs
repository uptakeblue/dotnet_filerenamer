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
    public partial class FrmMessage : Form {
        public FrmMessage( ) {
            InitializeComponent( );
        }

        public FrmMessage( string caption, string title, string detail ) : this( ) {
            this.Caption = caption;
            this.Title = title;
            this.Detail = detail;
        }

        public string Caption {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public string Title {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        public string Detail {
            get { return lblDetail.Text; }
            set { lblDetail.Text = value; }
        }

        private void btnClose_Click( object sender, EventArgs e ) {
            var settings = new Settings( );
            settings.MessageDialogLocation = this.Location;
            settings.Save();
            this.Close( );
        }

        private void FrmMessage_Load( object sender, EventArgs e ) {
            var settings = new Settings( );
            Point l = settings.MessageDialogLocation;
            if( ( l.X < 0 ) || ( l.X > Screen.GetWorkingArea( this ).Width ) ) {
                l.X = 100;
            }
            if( ( l.Y < 0 ) || ( l.Y > Screen.GetWorkingArea( this ).Height ) ) {
                l.Y = 100;
            }
            this.Location = l;

        }
    }
}
