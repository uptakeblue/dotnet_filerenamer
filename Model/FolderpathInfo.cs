using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Model {
    public class FolderpathInfo {

        public FolderpathInfo( ) {
            this.Author = new Author( );
            this.Audiobook = new Audiobook( );
        }
        public string FilePath { get; set; }
        public Author Author { get; set; }
        public Audiobook Audiobook { get; set; }
    }
}
