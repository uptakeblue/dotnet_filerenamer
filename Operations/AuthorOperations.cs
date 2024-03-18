using FileRenamer.Model;
using FileRenamer.Operations;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRenamer
{
    public static class AuthorOperations {

        static string _connectionString = GeneralOperations.GetConnectionString( );

        const string _module = "AuthorOperation";

        /// <summary>
        /// Returns a list of all authors
        /// </summary>
        /// <returns></returns>
        public static List<Author> Author_GetList() {
            var authorList = new List<Author>( );
            var conn = new MySqlConnection( );
            conn.ConnectionString = "server=localhost;uid=root;pwd=halibut;database=dbo;port=3306";

            try {

                conn.Open( );
                var cmd = conn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.author_Get_List";
                MySqlDataReader rdr = cmd.ExecuteReader( );
                while( rdr.Read( ) ) {
                    object[ ] datarow = { rdr[0], rdr[1], rdr[2] };
                    var author = new Author( datarow );
                    authorList.Add( author );
                }
            }
            catch( Exception e ) {
                MessageBox.Show( string.Format( "{0}.Author_GetList:\n{1}", _module, e.Message) );

            }
            return authorList;
        }

        public static List<KeyValuePair<int, string>> Author_GetListKVP( ) {
            var list = new List<KeyValuePair<int, string>>( );
            var allAuthors = Author_GetList( );
            if( allAuthors != null ) {
                list.Add( new KeyValuePair<int, string>( 0, "All Authors" ) );
                foreach( var author in allAuthors ) {
                    list.Add( new KeyValuePair<int, string>( author.AuthorId, author.NameReversed ) );
                }
            }
            return list;
        }


        public static Author Author_Get( int authorId ) {
            Author author = null;
            return author;
        }

        public static Author Author_Get( string last, string first ) {
            Author author = null;
            return author;
        }

        public static Author Author_Post( string last, string first ) {
            Author author = null;
            return author;
        }

    }
}
