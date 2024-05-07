using FileRenamer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using TagLib;
using FileRenamer.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Google.Protobuf.WellKnownTypes;


namespace FileRenamer.Operations {
    public static class GeneralOperations {

        const string _module = "GeneralOperations";

        public static string GetConnectionString( ) {
            string connectionStringName = ConfigurationManager.AppSettings["connectionstringName"];
            var connStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
            var connectionString = connStringSettings.ConnectionString;
            return connectionString;
        }

        public static FolderpathInfo GetFolderpathInfo( string folderPath, List<Author> authors ) {
            var fpi = new FolderpathInfo( ) { FolderPath = folderPath };
            try {
                if( fpi.Author.Last != string.Empty ) {
                    fpi.Author = AuthorOperations.Author_Get( fpi.Author.Last, fpi.Author.First);
                }
                if( fpi.Author.AuthorId > 0 ) {
                    var authorAudiobooks = AudiobookOperation.Audiobook_GetListByAuthor( fpi.Author.AuthorId );
                    var audiobook = authorAudiobooks.Find( x => x.Title == fpi.Audiobook.Title );
                    if( audiobook != null ) {
                        fpi.Audiobook.AudiobookId = audiobook.AudiobookId;
                        fpi.Audiobook.AuthorId = audiobook.AuthorId;
                    }
                }
            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.GetFolderpathInfo( folderPath, authors )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
            return fpi;
        }

        public static string TargetFilename( string folderPath, string fileBaseName, int count, uint fileNumber, string numberFormat ) {
            var di = new DirectoryInfo( folderPath );
            return string.Format( "{0}\\{1}_{2}_{3}.mp3", di.FullName, fileBaseName, count.ToString( ), fileNumber.ToString( numberFormat ) );
        }

        public static void SaveFile( TagInfo tagInfo ) {
            var firstYear = 2018;
            var yearString = DateTime.Now.Year == firstYear ? "" : string.Format( "{0}, ", DateTime.Now.Year );

            if( new FileInfo( tagInfo.FilePath ).Exists ) {
                var file = TagLib.File.Create( tagInfo.FilePath );
                file.Tag.Title = tagInfo.Title;
                file.Tag.Album = tagInfo.Album;
                file.Tag.Performers = tagInfo.Performers;
                file.Tag.AlbumArtists = tagInfo.AlbumArtists;
                file.Tag.Track = tagInfo.TrackNumber;
                file.Tag.Genres = tagInfo.Genres;
                file.Tag.Comment = string.Format(
                    "{0} Application, Copyright {2}{3} {1} Michael Rubin, All rights reserved",
                    System.Windows.Forms.Application.ProductName,
                    yearString,
                    firstYear,
                    ( (char)169 ).ToString( ) );
                file.Save( );
            } else {
                throw new Exception( string.Format( "Filepath {0} does not exist", tagInfo.FilePath ) );
            }
        }

        //logging
        public static void WriteToLogFile( string message ) {
            var logFilePath = string.Format( "{0}\\{1}", new DirectoryInfo( Path.GetDirectoryName( Application.ExecutablePath ) ).Parent.Parent.FullName, "logfile.txt" );
            using( StreamWriter w = System.IO.File.AppendText( logFilePath ) ) {
                w.WriteLine( string.Format( "{0}: {1}", DateTime.Now.ToString( "yyyyMMddHHmmss" ), message ) );
            }
        }

        // message dialog
        public static void ShowMessageDialog( string caption, string title, string detail ) {
            var frmMessage = new FrmMessage( caption, title, detail );
            frmMessage.ShowDialog( );

        }

    }
}