using Microsoft.Win32;
using System.Diagnostics;

namespace CmpLogicalToggle {
    internal class CmpLogicalToggler {
        static void Main() {
            Console.Write( "WARNING:  Explorer.exe and all of its windows will be closed.  Proceed? (y/n) >> " );
            string choice = ( Console.ReadLine() ?? "n" ).ToLower();

            if ( choice == "y" ) {
                object? currVal = Registry.GetValue( "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoStrCmpLogical", 0 );

                if ( currVal == null ) {
                    currVal = 0;
                }

                int intVal = ( int )currVal;

                if ( intVal == 1 ) {
                    Registry.SetValue( "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoStrCmpLogical", 0 );
                    Console.WriteLine( "NoStrCmpLogical has been turned OFF." );
                } else {
                    Registry.SetValue( "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoStrCmpLogical", 1 );
                    Console.WriteLine( "NoStrCmpLogical has been turned ON." );
                }

                Process proc = Process.GetProcessesByName( "explorer" )[ 0 ];
                proc.Kill();
                if ( proc.MainModule != null ) {
                    string path = proc.MainModule.FileName;
                    Process.Start( path );
                }
            }

            Console.WriteLine( "Have a nice day :)" );
            Console.ReadLine();
        }
    }
}
