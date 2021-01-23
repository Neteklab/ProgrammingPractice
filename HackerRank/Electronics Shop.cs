using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{

   /*
    * Complete the getMoneySpent function below.
    */
   static int getMoneySpent( int[ ] keyboards, int[ ] drives, int b ){

      int s, sum = -1;
      foreach( int k in keyboards )
         foreach( int d in drives )
            if((( s =(  k +  d )) <= b )&&( s > sum ))
               sum = s;
      return sum;

      //Array.Sort( keyboards );
      //Array.Sort( drives );

      //int pk=0, 
      //   ik = Drop( keyboards, b );
      //int pd=0,
      //   id = Drop( drives, b );


   }

   // Drop items that costs more than budget
   private static int Drop( int[ ] items, int max ){
      int i = 0;
      while(( i < items.Length - 1 )&&( items[ i ]>= max ))
         ++i;
      return i;
   }

   static void Main(string[] args)
    {
      //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
      TextWriter textWriter = ConsoleWriter.GetConsoleStreamWriter( );

      string[ ] bnm = Console.ReadLine().Split(' ');

        int b = Convert.ToInt32(bnm[0]);

        int n = Convert.ToInt32(bnm[1]);

        int m = Convert.ToInt32(bnm[2]);

        int[] keyboards = Array.ConvertAll(Console.ReadLine().Split(' '), keyboardsTemp => Convert.ToInt32(keyboardsTemp))
        ;

        int[] drives = Array.ConvertAll(Console.ReadLine().Split(' '), drivesTemp => Convert.ToInt32(drivesTemp))
        ;
        /*
         * The maximum amount of money she can spend on a keyboard and USB drive, or -1 if she can't purchase both items
         */

        int moneySpent = getMoneySpent(keyboards, drives, b);

        textWriter.WriteLine(moneySpent);

        textWriter.Flush();
        textWriter.Close();
    }
}
