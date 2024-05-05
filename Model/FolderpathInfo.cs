using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Model {
    public class FolderpathInfo {

        private string _folderPath;

        public FolderpathInfo( ) {
            this.Author = new Author( );
            this.Audiobook = new Audiobook( );
        }
        public string FolderPath {
            get {
                return this._folderPath;
            }
            set {
                // check folder name
                var folder = new DirectoryInfo( value );
                if( folder.Name != "10 Minute Slices" ) {
                    throw new Exception( "Source folder must be named \"10 Minute Slices\"." );
                }
                this._folderPath = value;
                // find everything after Books\
                var infoPath = value.Split( new[ ] { "ooks\\" }, StringSplitOptions.RemoveEmptyEntries )[1];
                var fields = infoPath.Split( '\\' );
                string authorField = String.Empty;
                string titleInfoField = String.Empty;
                var audiobookTitle = string.Empty;
                string yearSeries = string.Empty;
                switch( fields.Length ) {
                    case 2:
                        // Albom, Mitch - The Five People You Meet in Heaven/10 Mnute Slices
                        if( fields[0].Contains( "-" )){
                            authorField = fields[0].Split( '-' )[0].Trim( );
                            titleInfoField = fields[0].Split( '-' )[1].Trim( );
                        }
                        break;
                    case 3:
                        // Baldacci, David/Robie 03 - Bullseye/10 Mnute Slices
                        authorField = fields[0];
                        titleInfoField = fields[1];
                        break;
                }
                if( authorField.Length > 0 && authorField.Contains( "," ) ) {
                    this.Author.Last = authorField.Split( ',' )[0].Trim( );
                    this.Author.First = authorField.Split( ',' )[1].Trim( );
                }
                if( titleInfoField.Length > 0 ) {
                    if( titleInfoField.Contains( "-" ) ) {
                        Audiobook.Title = titleInfoField.Split( '-' )[1].Trim( );
                        yearSeries = titleInfoField.Split( '-' )[0].Trim( );
                        if( yearSeries.Contains( " " ) ) {
                            var tokens = yearSeries.Split( ' ' );
                            decimal tmpDeci;
                            if( decimal.TryParse( tokens[tokens.Length - 1], out tmpDeci ) ) {
                                this.Audiobook.Number = tmpDeci;
                                tokens = tokens.Take( tokens.Length - 1 ).ToArray( );
                                this.Audiobook.YearSeries = string.Join( " ", tokens );
                            }
                        }
                        else{
                            Audiobook.YearSeries= yearSeries;
                        }

                    } else {
                        this.Audiobook.Title = titleInfoField;
                    }

                }
            }
        }

        public Author Author { get; set; }
        public Audiobook Audiobook { get; set; }

    }
}
