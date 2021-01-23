using ProgrammingPractice.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


/// <summary>
/// Given a time in
//-hour AM / PM format, convert it to military (24-hour) time.
//  Note: -12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
//- 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.
//Example
//Return '12:01:00'.
//    Return '00:01:00'.
//Function Description
//Complete the timeConversion function in the editor below. It should return a new string representing the input time in 24 hour format.
//timeConversion has the following parameter(s):
//    string s: a time in 
//    hour format
//Returns
//    string: the time in 
//    hour format
//Input Format
//A single string
//that represents a time in -hour clock format (i.e.: or
//).

//Constraints
//    All input times are valid
//Sample Input 0
//07:05:45PM
//Sample Output 0
//19:05:45
/// </summary>


class Solution {

   /*
    * Complete the timeConversion function below.
    */
   static string timeConversion( string s ){

      bool am = s[ 8 ]== 'A';
      int hh = int.Parse( s.Substring( 0, 2 ));

      if( hh == 12 )
         hh = 0;
      if( !am )
         hh += 12;

      StringBuilder res = new StringBuilder( 8 );
      if( hh < 10 )
         res.Append( "0" );
      res.Append( hh );
      res.Append( s.Substring( 2, 6 ));
      return res.ToString( );
   }

   static void Main( string[ ] args ) {
      //TextWriter tw = new StreamWriter( @System.Environment.GetEnvironmentVariable( "OUTPUT_PATH" ), true );
      TextWriter tw = ConsoleWriter.GetConsoleStreamWriter( );


      string s = Console.ReadLine( );

      string result = timeConversion( s );

      tw.WriteLine( result );

      tw.Flush( );
      tw.Close( );
   }
}
