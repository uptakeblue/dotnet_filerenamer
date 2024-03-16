using FileRenamer.Model;
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

        const string _module = "AudiobookOperation";

        /// <summary>
        /// Returns a list of audiobooks for a specific author, retrieved by authorId
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public static List<Audiobook> Audiobook_GetListByAuthor( int authorId ) {
            var audiobookList= new List<Audiobook>();
            var conn = new MySqlConnection( );
            conn.ConnectionString = "server=localhost;uid=root;pwd=halibut;database=dbo;port=3306";

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
                    object[ ] datarow = { rdr[0], rdr[6], rdr[4], rdr[5], rdr[8], rdr[11] };
                    var audiobook = new Audiobook( datarow );
                    audiobookList.Add( audiobook );


                }
            }
            catch (Exception e) {
                MessageBox.Show( string.Format( "{0}.Audiobook_GetListByAuthor:\n{1}", _module, e.Message ) );
            }


            return audiobookList;
        }

        /// <summary>
        /// Returns a list of audiobooks for a specific author, retrieved by last, first names
        /// </summary>
        /// <param name="last"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public static List<Audiobook> Audiobook_GetListByAuthor( string last, string first) {
            var audiobookList = new List<Audiobook>( );
            return audiobookList;
        }

        public static Audiobook Audiobook_Get( int audiobookId ) {
            var audiobook = new Audiobook();
            return audiobook;
        }

        public static void Audiobook_Post(int authorId, string title, string yearSeries, decimal number ) {

        }

    }
}
