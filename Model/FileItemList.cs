using FileRenamer.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Model {
    public class FileItemList : List<FileItem> {

        private string _folderPath;

        public string FolderPath {
            get {
                return _folderPath;
            }
            set {
                _folderPath = value;
                this.Clear( );
                var di = new DirectoryInfo( _folderPath );
                if( di.Exists ) {
                    foreach( FileInfo f in di.GetFiles( "*.mp3" ) ) {
                        this.Add( new FileItem( ) {
                            SourceFilePath = f.FullName
                        } );
                    }
                }
                this.Sort( );
            }
        }


        public void GenerateTargetFiles( string fileBaseName ) {
            var numberFormat = this.Count > 100 ? "000" : "00";
            uint count = 1;
            foreach( var fileItem in this ) {
                fileItem.TargetFilePath =
                    string.IsNullOrEmpty( fileBaseName )
                    ? fileItem.SourceFilePath
                    : GeneralOperations.TargetFilename( _folderPath, fileBaseName, this.Count, count++, numberFormat );
            }
        }


    }
}
