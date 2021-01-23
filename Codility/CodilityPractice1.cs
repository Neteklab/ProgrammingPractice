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
using System.Runtime.CompilerServices;

using ProgrammingPractice.Shared;


/// <summary>
/// 

//This is a demo task.

//Write a function:

//    class Solution { public int solution( int[ ] A ); }

//that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

//For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

//Given A = [1, 2, 3], the function should return 4.

//Given A = [−1, −3], the function should return 1.

//Write an efficient algorithm for the following assumptions:

//        N is an integer within the range [1..100,000];
//each element of array A is an integer within the range [−1,000,000..1,000,000].


/// </summary>
namespace CodeTests.Codility {
   // you can also use other imports, for example:
   // using System.Collections.Generic;

   // you can write to stdout for debugging purposes, e.g.
   // Console.WriteLine("this is a debug message");

   class Solution {
      public static int solution( int[ ] A ) {
         // write your code in C# 6.0 with .NET 4.5 (Mono)

         //         bool found = false;
         int result = 1;
         Array.Sort( A );
         int i = 0;

         // Move to the 1st positive
         while( ( A[ i ] < result ) && ( i < A.Length ) )
            ++i;
//         A.
         // Move through positive sequence row
         while(( A[ i ]== result )&&( i < A.Length )){
            if( A[ i ]> result )
               ++result;
            ++i;
         }

         return result;
      }


      static void Main( string[ ] args ) {
         //TextWriter textWriter = new StreamWriter( @System.Environment.GetEnvironmentVariable( "OUTPUT_PATH" ), true );
         TextWriter textWriter = ConsoleWriter.GetConsoleStreamWriter( );


         int[] a = Console.ReadLine( ).TrimEnd( ).Split( ' ' ).ToList( ).Select( aTemp => Convert.ToInt32( aTemp ) ).ToArray<int>( );

         //List<int> b = Console.ReadLine( ).TrimEnd( ).Split( ' ' ).ToList( ).Select( bTemp => Convert.ToInt32( bTemp ) ).ToList( );

         int result = solution( a );

         textWriter.WriteLine( String.Join( " ", result ) );

         textWriter.Flush( );
         textWriter.Close( );
      }
   }
}