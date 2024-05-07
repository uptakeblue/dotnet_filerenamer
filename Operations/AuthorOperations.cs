﻿using FileRenamer.Model;
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
        public static List<Author> Author_GetList( ) {
            var authorList = new List<Author>( );
            var conn = new MySqlConnection( );
            conn.ConnectionString = _connectionString;

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
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Author_GetList( )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
            return authorList;
        }

        public static List<KeyValuePair<int, string>> Author_GetListKVP( ) {
            var list = new List<KeyValuePair<int, string>>( );
            try {
                var allAuthors = Author_GetList( );
                if( allAuthors != null ) {
                    list.Add( new KeyValuePair<int, string>( 0, "All Authors" ) );
                    foreach( var author in allAuthors ) {
                        list.Add( new KeyValuePair<int, string>( author.AuthorId, author.NameReversed ) );
                    }
                }
            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Author_GetListKVP( )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
            return list;
        }


        public static Author Author_Get( int authorId ) {
            Author author = null;
            var conn = new MySqlConnection( );
            conn.ConnectionString = _connectionString;

            try {
                conn.Open( );
                var cmd = conn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.author_get";

                cmd.Parameters.AddWithValue( "@author_id", authorId );
                cmd.Parameters.AddWithValue( "@last", null );
                cmd.Parameters.AddWithValue( "@first", null );

                MySqlDataReader rdr = cmd.ExecuteReader( );
                while( rdr.Read( ) ) {
                    object[ ] datarow = { rdr[0], rdr[1], rdr[2] };
                    author = new Author( datarow );
                }
            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Author_Get( authorId )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
            return author;
        }

        public static Author Author_Get( string last, string first ) {
            Author author = null;
            var conn = new MySqlConnection( );
            conn.ConnectionString = _connectionString;

            try {
                conn.Open( );
                var cmd = conn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.author_get";

                cmd.Parameters.AddWithValue( "@author_id", null );
                cmd.Parameters.AddWithValue( "@last", last );
                cmd.Parameters.AddWithValue( "@first", first );

                MySqlDataReader rdr = cmd.ExecuteReader( );
                while( rdr.Read( ) ) {
                    object[ ] datarow = { rdr[0], rdr[1], rdr[2] };
                    author = new Author( datarow );
                }
            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Author_Get( last, first )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
            return author;
        }

        public static Author Author_Post( string last, string first ) {
            Author author = null;
            
            var conn = new MySqlConnection( );
            conn.ConnectionString = _connectionString;

            try {

                conn.Open( );
                var cmd = conn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.author_Post";

                cmd.Parameters.AddWithValue( "@last", last );
                cmd.Parameters.AddWithValue( "@first", first );
                cmd.Parameters.AddWithValue( "@note", null );

                cmd.Parameters.Add( "@author_id", MySqlDbType.Int32 );
                cmd.Parameters["@author_id"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery( );

                var authorId = (int)cmd.Parameters["@author_id"].Value;
                author = Author_Get( authorId );

            }
            catch( Exception ex ) {
                var caption = string.Format( "{0}.Author_Post( audiobookId )", _module );
                GeneralOperations.WriteToLogFile( string.Format( "Error in {0}: {1}", caption, ex.Message ) );
                GeneralOperations.ShowMessageDialog( "An Error Occurred", caption, ex.Message );
            }
            return author;
        }

    }
}
