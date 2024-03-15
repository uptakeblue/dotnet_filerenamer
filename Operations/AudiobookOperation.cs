using FileRenamer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Operations {
    public static class AudiobookOperation {

        /// <summary>
        /// Returns a list of audiobooks for a specific author, retrieved by authorId
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public static List<Audiobook> Audiobook_GetListByAuthor( int authorId ) {
            var audiobookList= new List<Audiobook>();
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

        public static void AudiobookPost(int authorId, string title, string yearSeries, decimal number ) {

        }

    }
}
