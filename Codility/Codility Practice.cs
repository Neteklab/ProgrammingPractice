using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

partial class Solution0
{
    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        //const int N = 100000;
        //int[] = 

        int curValue = 1;
        while( checkValueExists( curValue, A )&&( curValue < A.Length ))
            ++curValue;
        return curValue ;
    }

    private bool checkValueExists( int v, int[] A) {
        //bool res = false;
        int i = 0;
        while(( A[ i ]!= v )&&( i < A.Length ))
            ++i;
        return( A[ i ] == v );
    }
}
