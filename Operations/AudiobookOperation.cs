using FileRenamer.Model;
using FileRenamer.Operations;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRenamer.Operations {
    public static class AudiobookOperation {

        private static string _connectionString = GeneralOperations.GetConnectionString( );

        const string _module = "AudiobookOperation";

        /// <summary>
        /// Returns a list of audiobooks for a specific author, retrieved by authorId
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public static List<Audiobook> Audiobook_GetListByAuthor( int authorId ) {
            var audiobookList = new List<Audiobook>( );
            var conn = new MySqlConnection( );
            conn.ConnectionString = _connectionString;

            try {

                conn.Open( );
                var cmd = conn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.audiobook_Get_ListByAuthor";

                cmd.Parameters.AddWithValue( "@author_id", authorId );
                cmd.Parameters.AddWithValue( "@last", null );
                cmd.Parameters.AddWithValue( "@first", null );

                MySqlDataReader rdr = cmd.ExecuteReader( );
                while( rdr.Read( ) ) {
                    object[ ] datarow = { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[10], rdr[11] };
                    var audiobook = new Audiobook( datarow );
                    audiobookList.Add( audiobook );


                }
            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Audiobook_GetListByAuthor( authorId )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
            return audiobookList;
        }


        public static Audiobook Audiobook_Get( int audiobookId ) {
            var audiobook = new Audiobook( );
            var conn = new MySqlConnection( );
            conn.ConnectionString = _connectionString;

            try {

                conn.Open( );
                var cmd = conn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.audiobook_Get";

                cmd.Parameters.AddWithValue( "@audiobook_id", audiobookId );
                cmd.Parameters.AddWithValue( "@title", null );

                MySqlDataReader rdr = cmd.ExecuteReader( );
                while( rdr.Read( ) ) {
                    object[ ] datarow = { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[10], rdr[11] };
                    audiobook = new Audiobook( datarow );
                }
            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Audiobook_Get( audiobookId )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
            return audiobook;
        }

        public static Audiobook Audiobook_Post( Audiobook audiobook, int fileCount  ) {
            var conn = new MySqlConnection( );
            conn.ConnectionString = _connectionString;

            try {

                conn.Open( );
                var cmd = conn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.audiobook_Post";

                cmd.Parameters.AddWithValue( "@author_id", audiobook.AuthorId );
                cmd.Parameters.AddWithValue( "@series", audiobook.Series );
                cmd.Parameters.AddWithValue( "@number", audiobook.Number );
                cmd.Parameters.AddWithValue( "@title", audiobook.Title );
                cmd.Parameters.AddWithValue( "@note", null );
                cmd.Parameters.AddWithValue( "@year_published", null );
                cmd.Parameters.AddWithValue( "@file_count", fileCount );
                cmd.Parameters.AddWithValue( "@read_date", null );

                cmd.Parameters.Add( "@audiobook_id", MySqlDbType.Int32 );
                cmd.Parameters["@audiobook_id"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery( );

                var audiobookId = (int)cmd.Parameters["@audiobook_id"].Value;
                audiobook.AudiobookId = audiobookId;

            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Audiobook_Post( audiobookId )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
            return audiobook;
        }

        public static void Audiobook_Put( Audiobook audiobook ) {
            var conn = new MySqlConnection( );
            conn.ConnectionString = _connectionString;

            try {

                conn.Open( );
                var cmd = conn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.audiobook_PutLimited";

                cmd.Parameters.AddWithValue( "@audiobook_id", audiobook.AudiobookId );
                cmd.Parameters.AddWithValue( "@author_id", audiobook.AuthorId );
                cmd.Parameters.AddWithValue( "@series", audiobook.Series );
                cmd.Parameters.AddWithValue( "@number", audiobook.Number );
                cmd.Parameters.AddWithValue( "@title", audiobook.Title );
                cmd.ExecuteNonQuery( );

            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Audiobook_Put( audiobook )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }

        }

    }
}