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

class Solution {

   // Complete the minimumSwaps function below.
   static int minimumSwaps( int[ ] arr ){
      int n = 0;
      for( int i = 0; i < arr.Length - 1; i++ )
         if( arr[ i ]!= i + 1 ){
            ++n;
            int j = i + 1;
            while(( j < arr.Length )&&( arr[ j ]!= i + 1 ))
               j++;
            int t = arr[ i ];
            arr[ i ] = arr[ j ];
            arr[ j ] = t;
         }

      return n;
   }

   static void Main( string[ ] args ) {
      //TextWriter textWriter = new StreamWriter( @System.Environment.GetEnvironmentVariable( "OUTPUT_PATH" ), true );
      TextWriter textWriter = ConsoleWriter.GetConsoleStreamWriter( );

      int n = Convert.ToInt32( Console.ReadLine( ) );

      int[ ] arr = Array.ConvertAll( Console.ReadLine( ).Split( ' ' ), arrTemp => Convert.ToInt32( arrTemp ) )
      ;
      int res = minimumSwaps( arr );

      textWriter.WriteLine( res );

      textWriter.Flush( );
      textWriter.Close( );
   }
}
