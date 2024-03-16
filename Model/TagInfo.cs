using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Model {
    public class TagInfo {

        public TagInfo( ) { }
        public TagInfo( string filePath )
            : this( ) {
            this.FilePath = filePath;
        }
        public string Title { get; set; }
        public string TrackTitle {
            get {
                return new FileInfo( this.FilePath ).Name.Replace( "_", " " );
            }
        }
        public string Performer { get; set; }
        public string AlbumArtist { get; set; }
        public string Album { get; set; }
        public uint TrackNumber { get; set; }
        public string Genre { get; set; }
        public string FilePath { get; set; }

        //////

        public string[ ] Performers { get { return new string[ ] { this.Performer }; } }
        public string[ ] AlbumArtists { get { return new string[ ] { this.AlbumArtist }; } }
        public string[ ] Genres { get { return new string[ ] { this.Genre }; } }
    }
}
