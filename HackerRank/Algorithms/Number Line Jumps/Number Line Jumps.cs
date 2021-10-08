using ProgrammingPractice.Shared;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

/*
 * You are choreographing a circus show with various animals. For one act, you are given two kangaroos on a number line ready to jump in the positive direction (i.e, toward positive infinity).

    The first kangaroo starts at location 

and moves at a rate of
meters per jump.
The second kangaroo starts at location
and moves at a rate of

    meters per jump.

You have to figure out a way to get both kangaroos at the same location at the same time as part of the show. If it is possible, return YES, otherwise return NO.

Example



After one jump, they are both at , (,

), so the answer is YES.

Function Description

Complete the function kangaroo in the editor below.

kangaroo has the following parameter(s):

    int x1, int v1: starting position and jump distance for kangaroo 1
    int x2, int v2: starting position and jump distance for kangaroo 2

Returns

    string: either YES or NO

Input Format

A single line of four space-separated integers denoting the respective values of
, , , and

.

Constraints

Sample Input 0

0 3 4 2

Sample Output 0

YES

Explanation 0

The two kangaroos jump through the following sequence of locations:

image

From the image, it is clear that the kangaroos meet at the same location (number
on the number line) after same number of jumps (

jumps), and we print YES.

Sample Input 1

0 2 5 3

Sample Output 1

NO

Explanation 1

The second kangaroo has a starting location that is ahead (further to the right) of the first kangaroo's starting location (i.e.,
). Because the second kangaroo moves at a faster rate (meaning ) and is already ahead of the first kangaroo, the first kangaroo will never be able to catch up. Thus, we print NO. 
  */

namespace HackerRank.Algorithms.Number_Line_Jumps {
   public class Number_Line_Jumps {

      public static string kangaroo( int x1, int v1, int x2, int v2 ) {

         float t = ( float )( x1 - x2 )/( v2 - v1 );

         return( 
            ( t > 0 )&&( Math.Abs( t - Math.Floor( t ) )< .0000001 )
               )
            ? "YES" 
            : "NO";
      }

      [Theory]
      [InlineData( @"Algorithms\Number Line Jumps\Number Line Jumps.YES.txt" )]
      [InlineData( @"Algorithms\Number Line Jumps\Number Line Jumps.NO.txt" )]
      [InlineData( @"Algorithms\Number Line Jumps\Number Line Jumps - Copy.NO.txt" )]
      static void Number_Line_Jumps_Test( string fileName ) {

         string expected = fileName.Split( '.' )[ 1 ];
         List<List<int>> res = TestCaller.GetData( fileName );
         string result = kangaroo( res[ 0 ][ 0 ], res[ 0 ][ 1 ], res[ 0 ][ 2 ], res[ 0 ][ 3 ]);
         Assert.Equal( expected, result );

      }

      static void Main( string[ ] args ) {


         //JourneyToMoonTest( );

         //      TextWriter textWriter = new StreamWriter( @System.Environment.GetEnvironmentVariable( "OUTPUT_PATH" ), true );
         //      TextWriter textWriter = new StreamWriter( "../../../HackerRank/Algorithms/TestFile.4527147.txt", true );
         TextWriter textWriter = ConsoleWriter.GetConsoleStreamWriter( );

         string[ ] np = Console.ReadLine( ).Split( ' ' );

         int n = Convert.ToInt32( np[ 0 ] );

         int p = Convert.ToInt32( np[ 1 ] );

         int[ ][ ] astronaut = new int[ p ][ ];

         for( int i = 0; i < p; i++ ) {
            astronaut[ i ] = Array.ConvertAll( Console.ReadLine( ).Split( ' ' ), astronautTemp => Convert.ToInt32( astronautTemp ) );
         }

//         ulong result = journeyToMoon( n, astronaut );

         //textWriter.WriteLine( result );

         textWriter.Flush( );
         textWriter.Close( );

      }

      //public static void Main( string[ ] args ) {
      //   TextWriter textWriter = new StreamWriter( @System.Environment.GetEnvironmentVariable( "OUTPUT_PATH" ), true );

      //   string[ ] firstMultipleInput = Console.ReadLine( ).TrimEnd( ).Split( ' ' );

      //   int x1 = Convert.ToInt32( firstMultipleInput[ 0 ] );

      //   int v1 = Convert.ToInt32( firstMultipleInput[ 1 ] );

      //   int x2 = Convert.ToInt32( firstMultipleInput[ 2 ] );

      //   int v2 = Convert.ToInt32( firstMultipleInput[ 3 ] );

      //   string result = Result.kangaroo( x1, v1, x2, v2 );

      //   textWriter.WriteLine( result );

      //   textWriter.Flush( );
      //   textWriter.Close( );
      //}

   }
}
