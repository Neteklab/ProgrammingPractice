using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProgrammingPractice.Shared {
   public class ConsoleWriter {
      public static StreamWriter GetConsoleStreamWriter( ) {

         StreamWriter sw = new StreamWriter( Console.OpenStandardOutput( ) );
         sw.AutoFlush = true;
         Console.SetOut( sw );
         return sw;


#pragma warning disable 162
         TextWriter textWriter = ConsoleWriter.GetConsoleStreamWriter( );
#pragma warning restore 162
      }
   }
}
