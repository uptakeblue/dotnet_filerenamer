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

        private static string _connectionString = GeneralOperations.GetConnectionString();

        const string _module = "AudiobookOperation";

        /// <summary>
        /// Returns a list of audiobooks for a specific author, retrieved by authorId
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public static List<Audiobook> Audiobook_GetListByAuthor( int authorId ) {
            var audiobookList= new List<Audiobook>();
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
                    object[ ] datarow = { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[8], rdr[11] };
                    var audiobook = new Audiobook( datarow );
                    audiobookList.Add( audiobook );


                }
            }
            catch (Exception e) {
                MessageBox.Show( e.Message, string.Format( "{0}.Audiobook_GetListByAuthor( authorId )", _module) );
            }
            return audiobookList;
        }


        public static Audiobook Audiobook_Get( int audiobookId ) {
            var audiobook = new Audiobook();
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
                    object[ ] datarow = { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[8], rdr[11] };
                    audiobook = new Audiobook( datarow );
                }
            }
            catch( Exception e ) {
                MessageBox.Show( e.Message, string.Format( "{0}.Audiobook_Get(audiobookId)", _module));
            }
            return audiobook;
        }

        public static Audiobook Audiobook_Post(int authorId, string title ) {
            var audiobook = new Audiobook( );
            return audiobook;
        }

        public static Audiobook Audiobook_Put( int audiobookId, int authorId, string yearSeries, decimal number, string title ) {
            var conn = new MySqlConnection( );
            conn.ConnectionString = _connectionString;

            try {

                conn.Open( );
                var cmd = conn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.audiobook_PutLimited";

                cmd.Parameters.AddWithValue( "@audiobook_id", audiobookId );
                cmd.Parameters.AddWithValue( "@author_id", authorId );
                cmd.Parameters.AddWithValue( "@year_series", yearSeries );
                cmd.Parameters.AddWithValue( "@number", number );
                cmd.Parameters.AddWithValue( "@title", title );

                MySqlDataReader rdr = cmd.ExecuteReader( );
                while( rdr.Read( ) ) {
                    object[ ] datarow = { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[8], rdr[11] };
                    audiobook = new Audiobook( datarow );
                }
            }
            catch( Exception e ) {
                MessageBox.Show( e.Message, string.Format( "{0}.Audiobook_Get(audiobookId)", _module ) );
            }
            return audiobook;

        }

    }
}
