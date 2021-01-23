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
using ProgrammingPractice.Shared;

/// <summary>
///   2
///   ifailuhkqq
///   kkkk
///   3 10
///   
///   1
///   cdcd
///   5
/// </summary>

partial class SherlockAndAnagrams {

   // Complete the sherlockAndAnagrams function below.
   static int sherlockAndAnagrams( string s ) {

      //const int maxStringLength = 100;
      const int charsNumber = 'z' - 'a' + 1;
      int anagrams = 0;

      ulong[ ][ ] hashes = new ulong[ s.Length ][ ];
      for( int i = 0; i < s.Length; ++i ) 
         hashes[ i ] = new ulong[ s.Length - i ];


      for( int i = 0; i < s.Length; ++i ) {
         for( int j = i + 1; j < s.Length + 1; ++j ) {

            int[ ] chars = new int[ charsNumber ];
            for( int c = i; c < j; ++c )
               chars[ s[ c ]- 'a' ]++;

            ulong hash =( ulong )s.Length;
            for( int c = 0; c < charsNumber; ++c )
               hash = hash * ( ulong )s.Length + ( ulong )chars[ c ];
            hashes[ j - i - 1 ][ i ] = hash;
         }
      }

      // Find repeated hashes
      for( int i = 0; i < hashes.Length - 1; ++i )
         for( int j = 0; j < hashes[ i ].Length; ++j ){
            ulong hash = hashes[ i ][ j ];
            for( int h = j + 1; h < hashes[ i ].Length; ++h )
               if(( hash != 0 )&&( hash == hashes[ i ][ h ]))
                     ++anagrams;
         }

      return anagrams;
   }

   static void Main( string[ ] args ) {
      //TextWriter textWriter = new StreamWriter( @System.Environment.GetEnvironmentVariable( "OUTPUT_PATH" ), true );
      TextWriter textWriter = ConsoleWriter.GetConsoleStreamWriter( );

      int q = Convert.ToInt32( Console.ReadLine( ) );

      for( int qItr = 0; qItr < q; qItr++ ) {
         string s = Console.ReadLine( );

         int result = sherlockAndAnagrams( s );

         textWriter.WriteLine( result );
      }

      textWriter.Flush( );
      textWriter.Close( );
   }
}


