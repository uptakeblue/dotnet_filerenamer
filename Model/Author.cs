using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRenamer.Model {

    public class Author {

        static string _module = "Model.Author";
        public Author( ) {
            this.AuthorId = -1;
        }
        public Author( object[] dataRow ) {
            try {
                this.AuthorId = (int)dataRow[0];
                this.Last = (string)dataRow[1];
                this.First = (string)dataRow[2];
            }
            catch( Exception ex ) {
                MessageBox.Show( ex.Message, string.Format( "Error in {0}.Constructor(dataRow)", _module ) );
            }
        }

        public int AuthorId { get; set; }
        public string Last { get; set; }
        public string First { get; set; }

        public string NameReversed {
            get {
                return string.Format( "{0}{1}", this.Last, string.IsNullOrEmpty( this.First ) ? "" : string.Format( ", {0}", this.First ) );
            }
        }
        public string Name {
            get {
                return string.Format( "{0}{1}", string.IsNullOrEmpty( this.First ) ? "" : string.Format( "{0} ", this.First ), this.Last );
            }
        }

        public KeyValuePair<int, string> KeyValuePair {
            get {
                return new KeyValuePair<int, string>( AuthorId, NameReversed );
            }
        }
        public override string ToString( ) {
            return string.Format( "AuthorId: {0}, Last: {1}, First: {2}", this.AuthorId, this.Last, this.First );
        }

    }
}
