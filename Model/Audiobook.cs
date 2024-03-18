using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Model {
    public class Audiobook {

        public Audiobook( object[ ] dataRow ) {
            this.AudiobookId = (int)dataRow[0];
            this.AuthorId = (int)dataRow[1];
            this._authorLast=(string)dataRow[2];
            this._authorFirst=(string)dataRow[3];

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

        public Audiobook( string title ) : this( ) {
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

        public Audiobook( ) {
            this.AuthorId = -1;
            this.AudiobookId = -1;
            this.Number = new Decimal( 0.0 );
            this.YearSeries = string.Empty;
        }
        public int AuthorId { get; set; }
        private string _authorLast {  get; set; }
        private string _authorFirst {  get; set; }
        public int AudiobookId { get; set; }
        public string Title { get; set; }
        public string YearSeries { get; set; }
        public Decimal? Number { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ReadDate { get; set; }

        public override string ToString( ) {
            return string.Format( "AudiobookId: {0}\nAuthorId: {1}\nTitle: {2}\nYearSeries: {3}\nNumber: {4}", this.AudiobookId, this.AuthorId, this.Title, this.YearSeries, this.Number );
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
                        display = ((Decimal)this.Number).ToString( "00.#" );
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
