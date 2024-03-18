using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Model {
    public class FileItem : IComparable {

        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string TargetFileName {
            get {
                return new FileInfo( this.TargetFilePath ).Name;
            }
        }
        public string SourceFileName {
            get {
                return new FileInfo( this.SourceFilePath ).Name;
            }
        }

        public int CompareTo( object obj ) {
            var fileItem = (FileItem)obj;
            return string.IsNullOrEmpty( fileItem.TargetFilePath )
                ? this.SourceFileName.CompareTo( fileItem.SourceFileName )
                : this.TargetFileName.CompareTo( fileItem.TargetFileName );
        }
    }
}
