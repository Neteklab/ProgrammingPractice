using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

using Xunit;
using ProgrammingPractice.Shared;



/// <summary>
/// The member states of the UN are planning to send
//people to the moon. They want them to be from different countries. You will be given a list of pairs of astronaut ID's. Each pair is made of astronauts from the same country. Determine how many pairs of astronauts from different countries they can choose from.
//Example

//There are astronauts numbered through . Astronauts grouped by country are and . There are pairs to choose from: and
//.
//Function Description
//Complete the journeyToMoon function in the editor below.
//journeyToMoon has the following parameter(s):
//    int n: an integer that denotes the number of astronauts
//    int astronaut[p] [2]: each element 
//is a
//    element array that represents the ID's of two astronauts from the same country
//Returns int: the number of valid pairs
//Input Format
//The first line contains two integers
//and , the number of astronauts and the number of pairs.
//Each of the next lines contains
//space-separated integers denoting astronaut ID's of two who share the same nationality.
//Constraints
//Sample Input 0
//5 3
//0 1
//2 3
//0 4
//Sample Output 0
//6
//Explanation 0
//Persons numbered
//belong to one country, and those numbered belong to another. The UN has
//ways of choosing a pair:
//Sample Input 1
//4 1
//0 2
//Sample Output 1
//5
//Explanation 1
//Persons numbered
//belong to the same country, but persons and don't share countries with anyone else. The UN has
//ways of choosing a pair:
/// </summary>


public class JourneyToMoon {

   static List<List<int>> GetCountryList( int[ ][ ] astronaut ) {
      var countryAstronauts = new List<List<int>>( astronaut.Length );

      // Arrange astronauts by countries
      for( int i = 0; i < astronaut.Length; i++ ) {
         int j = 0;
         bool countryExists = false;

         // Merge to existing
         while( !countryExists && j < countryAstronauts.Count ) {
            bool a0 = countryAstronauts[ j ].Contains( astronaut[ i ][ 0 ] );
            bool a1 = countryAstronauts[ j ].Contains( astronaut[ i ][ 1 ] );

            if( countryExists = ( a0 || a1 ) ) {

               // Duplicated pairs
               if( a0 && a1 )
                  break;

               bool firstAstronautFound = a0 && !a1;

               int remainedId = astronaut[ i ][ firstAstronautFound ? 1 : 0 ];
               countryAstronauts[ j ].Add( remainedId );

               // Look for second astronaut in the rest of list 
               int jj = countryAstronauts.Count - 1;
               while( ( jj > j ) && !countryAstronauts[ jj ].Contains( remainedId ) )
                  --jj;

               // Merge remained astronaut list
               if( jj > j ) {
                  for( int ii = 0; ii < countryAstronauts[ jj ].Count; ++ii )
                     if( !countryAstronauts[ j ].Contains( countryAstronauts[ jj ][ ii ] ) )
                        countryAstronauts[ j ].Add( countryAstronauts[ jj ][ ii ] );
                  countryAstronauts.RemoveAt( jj );
               }
            }
            ++j;
         }

         if( !countryExists )
            countryAstronauts.Add( new List<int>( ){
               astronaut[ i ][ 0 ],
               astronaut[ i ][ 1 ]
            } );
      }
      return countryAstronauts;
   }


   // Complete the journeyToMoon function below.
   static ulong journeyToMoon( int n, int[ ][ ] astronaut ) {

      var countryAstronauts = GetCountryList( astronaut );

      ulong Paired = ( ulong )countryAstronauts.Sum( k => k.Count );
      // Astronauts not belonging to any country
      ulong UnPaired = ( ulong )n - Paired;

      // Calculate pairs
      ulong Pairs = 0;
      if( countryAstronauts.Count >= 2 )
         for( int i = 0; i < countryAstronauts.Count - 1; i++ )
            for( int j = i + 1; j < countryAstronauts.Count; j++ )
               Pairs += ( ulong )( countryAstronauts[ i ].Count * countryAstronauts[ j ].Count );

      if( UnPaired > 0 ) {
         // Agregate unpaired with paired
         Pairs += Paired * UnPaired;

         // Agregate unpaired with themselves
         Pairs += ( UnPaired - 1 ) * UnPaired / 2;
      }

      return Pairs;
   }

   
   //[Fact]
   [Theory]
   [InlineData( "Algorithms/Journey to the Moon.4527147.txt")]
   [InlineData( "Algorithms/Journey to the Moon.3984.txt" )]
   [InlineData( "Algorithms/Journey to the Moon.11082889.txt" )]
   [InlineData( "Algorithms/Journey to the Moon.4999949998.txt" )]
   [InlineData( "Algorithms/Journey to the Moon.23.txt" )]
   static void JourneyToMoonTest( string fileName ) {

      ulong expected = ulong.Parse( fileName.Split( '.' )[ 1 ]);
      //string fileName = "Algorithms/Journey to the Moon.4527147.txt";
      const Int32 BufferSize = 128;
      int n;
      int[ ][ ] astronaut;

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
      ulong result = journeyToMoon( n, astronaut );
      Assert.Equal<ulong>( expected, result );
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

      ulong result = journeyToMoon( n, astronaut );

      textWriter.WriteLine( result );

      textWriter.Flush( );
      textWriter.Close( );
   }

}
