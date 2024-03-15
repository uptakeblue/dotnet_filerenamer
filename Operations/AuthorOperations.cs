using FileRenamer.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer
{
    public static class AuthorOperations {
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
            catch {

            }
            return authorList;
        }

        public static Author Author_Get( string last, string first ) {
            Author author = null;
            return author;
        }

        public static void AuthorPost( string last, string first ) {

        }

    }
}
