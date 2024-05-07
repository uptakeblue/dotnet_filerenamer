using FileRenamer.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FileRenamer.Model {
    public class Audiobook {

        static string _module = "Model.Audiobook";

        public Audiobook( ) {
            try {
                this.AuthorId = -1;
                this.AudiobookId = -1;
                this.Number = new Decimal( 0.0 );
                this.YearSeries = string.Empty;
                this.Series= string.Empty;
            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Constructor( )( )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
        }

        public Audiobook( object[ ] dataRow ) : this( ) {
            try {
                this.AudiobookId = (int)dataRow[0];
                this.AuthorId = (int)dataRow[1];
                this._authorLast = (string)dataRow[2];
                this._authorFirst = (string)dataRow[3];

                this.YearSeries = dataRow[4] != DBNull.Value ? (string)dataRow[4] : null;
                if( dataRow[5] != DBNull.Value ) {
                    this.Number = (decimal)dataRow[5];
                }
                this.Title = (string)dataRow[6];
                this.CreatedDate = (DateTime)dataRow[7];
                if( dataRow[8] != DBNull.Value ) {
                    this.ReadDate = (DateTime)dataRow[8];
                }
            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Constructor( dataRow )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
        }

        public Audiobook( string title ) : this( ) {
            try {
                if( !title.Contains( " - " ) ) {
                    this.Title = title;
                } else {
                    this.Title = title.Split( '-' )[1].Trim( );
                    var tokens = title.Split( '-' )[0].Trim( ).Split( ' ' );
                    // last token
                    decimal num1;
                    if( decimal.TryParse( tokens[tokens.Length - 1], out num1 ) ) {
                        //last token is numeric 
                        if( num1 < 100 ) {
                            // than 100: it's a number
                            this.Number = num1;
                        } else {
                            // greater than 100: a year
                            this.YearSeries = num1.ToString( "0.#" );
                        }
                    }
                    // remaining tokens
                    if( string.IsNullOrEmpty( this.YearSeries ) ) {
                        var sb = new StringBuilder( );
                        foreach( var token in tokens ) {
                            decimal num2;
                            if( !Decimal.TryParse( token, out num2 ) ) {
                                sb.Append( string.Format( "{0} ", token ) );
                            }
                        }
                        this.YearSeries = sb.ToString( ).Trim( );
                    }
                }
            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Constructor( title )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
        }

        public int AuthorId { get; set; }
        private string _authorLast { get; set; }
        private string _authorFirst { get; set; }
        public int AudiobookId { get; set; }
        public string Title { get; set; }
        public string Series{ get; set; }
        public string YearSeries { get; set; }
        public Decimal? Number { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ReadDate { get; set; }

        public override string ToString( ) {
            return string.Format( "AudiobookId: {0}, AuthorId: {1}, Title: {2}, YearSeries: {3}, Series: {4}, Number: {5}", this.AudiobookId, this.AuthorId, this.Title, this.YearSeries, this.Series, this.Number );
        }

        public object[ ] valueArray {
            get {
                return new object[ ] { AudiobookId, YearSeries, Number, Title, CreatedDate, ( ReadDate != null ) };
            }
        }

        public string Display {
            get {
                var display = string.Empty;
                if( this.Number > new Decimal( 0.0 ) ) {
                    display = ( (Decimal)this.Number ).ToString( "00.#" );
                    if( !string.IsNullOrEmpty( this.YearSeries ) ) {
                        display = string.Format( "{0} {1}", this.YearSeries, display );
                    }
                } else if( !string.IsNullOrEmpty( this.YearSeries ) ) {
                    display = this.YearSeries;
                    display = string.Format( "{0} - {1}", display, this.Title );
                }
                if( !string.IsNullOrEmpty( display ) ) {
                    display = string.Format( "{0} - {1}", display, this.Title );
                }
                if( string.IsNullOrEmpty( display ) ) {
                    display = this.Title;
                }
                return display;
            }
        }

        public string Authorname {
            get {
                return string.Format( "{0}{1}", string.IsNullOrEmpty( this._authorFirst ) ? "" : string.Format( "{0} ", this._authorLast ), this._authorLast );
            }
        }

        public string AuthornameReversed {
            get {
                return string.Format( "{0}{1}", this._authorLast, string.IsNullOrEmpty( this._authorFirst ) ? "" : string.Format( ", {0}", this._authorFirst ) );
            }
        }
    }
}