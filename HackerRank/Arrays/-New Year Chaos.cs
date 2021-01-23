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

   // Complete the minimumBribes function below.
   static void minimumBribes( int[ ] q ) {
      bool h = false;
      int b = 0;

      for( int i = 0; !h &&( i < q.Length ); ++i ){
         int s = q[ i ] - i - 1;
         if( s > 2 )
            h = true;
         //else if( s > 0 )
         //   b += s;

         for( int j = GetMax( 0, q[ i ] - 2 ); j < i; j++ )
            if( q[ j ] > q[ i ] )
               b++;
      }

      Console.WriteLine( h ? "Too chaotic" : b.ToString( ));
   }

   public static int GetMax( int first, int second ) {
      return first > second ? first : second;
   }

   static void Main( string[ ] args ) {
      int t = Convert.ToInt32( Console.ReadLine( ) );

      for( int tItr = 0; tItr < t; tItr++ ) {
         int n = Convert.ToInt32( Console.ReadLine( ) );

         int[ ] q = Array.ConvertAll( Console.ReadLine( ).Split( ' ' ), qTemp => Convert.ToInt32( qTemp ) )
         ;
         minimumBribes( q );
      }
   }
}
