using FileRenamer.Model;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
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
