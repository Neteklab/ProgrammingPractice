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

class Solution{
    
    //static int Jumps = 0;
    static int[] Clouds;
    
    // Complete the jumpingOnClouds function below.
    static int jumpingOnClouds(int[] c){

        int cur = 0, j=0;
        while( cur < c.Length - 1 ){
            cur +=(( cur < c.Length - 2 )&&( c[ cur + 2 ] == 0 ))? 2 : 1;
            ++j;
        }
        return j;

        Clouds = c;
        return TraverseJumps( 0 );
    }

    private static int TraverseJumps( int cur ) {
        int step1 = 0, step2 = 0;
        if (Clouds[cur + 1] == 0)
            step1 = TraverseJumps(cur + 1);
        if (Clouds[cur + 2] == 0)
            step2 = TraverseJumps(cur + 2);
        return( step1 > step2 )? step1 : step2;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = ConsoleWriter.GetConsoleStreamWriter( ); //new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
        int result = jumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

