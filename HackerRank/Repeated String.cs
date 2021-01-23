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

   // Complete the repeatedString function below.
   static long repeatedString( string s, long n ) {
      int sumString = 0;
      int sumRemainder = 0;
      int Remain = ( int )( n % s.Length );

      for( int i = 0; i < s.Length; ++i )
         if( s[ i ] == 'a' ) {
            ++sumString;
            if( i < Remain )
               ++sumRemainder;
         }
      return n / s.Length * sumString + sumRemainder;
   }

   static void Main( string[ ] args ) {
      TextWriter textWriter = new StreamWriter( @System.Environment.GetEnvironmentVariable( "OUTPUT_PATH" ), true );

      string s = Console.ReadLine( );

      long n = Convert.ToInt64( Console.ReadLine( ) );

      long result = repeatedString( s, n );

      textWriter.WriteLine( result );

      textWriter.Flush( );
      textWriter.Close( );
   }
}
