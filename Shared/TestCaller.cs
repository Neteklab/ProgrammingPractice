using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared {
   public class TestCaller {

      public static bool Run( string fileName, Func<int[ ][ ], bool> AssertFunc ) {

         ulong expected = ulong.Parse( fileName.Split( '.' )[ 1 ] );
         //string fileName = "Algorithms/Journey to the Moon.4527147.txt";
         const Int32 BufferSize = 128;
         int n;
         int[ ][ ] astronaut, Data;

         using( var fileStream = File.OpenRead( fileName ) )
         using( var streamReader = new StreamReader( fileStream, Encoding.UTF8, true, BufferSize ) ) {
            string[ ] np = streamReader.ReadLine( ).Split( ' ' );
            n = Convert.ToInt32( np[ 0 ] );
            int p = Convert.ToInt32( np[ 1 ] );
            astronaut = new int[ p ][ ];
            for( int i = 0; i < p; i++ ) {
               astronaut[ i ] = Array.ConvertAll(
                  streamReader.ReadLine( ).Split( ' ' ),
                  astronautTemp => Convert.ToInt32( astronautTemp ) );
            }
         }
         
         //ulong result = journeyToMoon( n, astronaut );
         Data = astronaut;
         return AssertFunc( Data );
         //Assert.Equal<ulong>( expected, result );
      }



      public static List<List<int>> GetData( string fileName ) {

         List < List<int> > res = new List<List<int>>( );

         const Int32 BufferSize = 128;
         int n;

         using( var fileStream = File.OpenRead( fileName ) )
         using( var streamReader = new StreamReader( fileStream, Encoding.UTF8, true, BufferSize ) ) {
            while( !streamReader.EndOfStream )
               res.Add( new List<int>( 
                  streamReader.ReadLine( ).Split( ' ' ).Select( s => Convert.ToInt32( s ))));
         }

         return res;
      }

   }
}
