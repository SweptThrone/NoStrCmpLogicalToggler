namespace CmpLogicalToggle {
    internal class CmpLogicalToggler {
        static void Main() {
            Console.Write( "WARNING:  Explorer.exe and all of its windows will be closed.  Proceed? (y/n) >> " );
            string choice = ( Console.ReadLine() ?? "n" ).ToLower();

            if ( choice == "y" ) {
                object? currVal = Microsoft.Win32.Registry.GetValue( "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoStrCmpLogical", 0 );

                if ( currVal == null ) {
                    currVal = 0;
                }

                int intVal = ( int )currVal;

                if ( intVal == 1 ) {
                    Microsoft.Win32.Registry.SetValue( "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoStrCmpLogical", 0 );
                    Console.WriteLine( "NoStrCmpLogical has been turned OFF." );
                } else {
                    Microsoft.Win32.Registry.SetValue( "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoStrCmpLogical", 1 );
                    Console.WriteLine( "NoStrCmpLogical has been turned ON." );
                }

                System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcessesByName( "explorer" )[ 0 ];
                proc.Kill();
                if ( proc.MainModule != null ) {
                    string path = proc.MainModule.FileName;
                    System.Diagnostics.Process.Start( path );
                }
            }

            Console.WriteLine( "Have a nice day :)" );
            Console.ReadLine();
        }
    }
}
