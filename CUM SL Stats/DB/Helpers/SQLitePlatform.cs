using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;
using System.IO;

namespace SKYNET.DB.Helpers
{

#if __WIN32__
        using _SQLitePlatformTest = SQLite.Net.Platform.Win32.SQLitePlatformWin32;
#elif WINDOWS_PHONE
        using _SQLitePlatformTest = SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8;
#elif __WINRT__
        using _SQLitePlatformTest = SQLite.Net.Platform.WinRT.SQLitePlatformWinRT;
#elif __IOS__
        using _SQLitePlatformTest = SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS;
#elif __ANDROID__
        using _SQLitePlatformTest = SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid;
#elif __OSX__
        using _SQLitePlatformTest = SQLite.Net.Platform.OSX.SQLitePlatformOSX;
#else
    using _SQLitePlatform = SQLite.Net.Platform.Generic.SQLitePlatformGeneric;
#endif

    public class SQLitePlatform : _SQLitePlatform
    {

        public SQLitePlatform(string tempFolderPath = null, bool useWinSqlite = false)
        {
            SQLiteApi = new SQLiteApiWinRT(tempFolderPath, useWinSqlite);
            VolatileService = new VolatileServiceWinRT();
            StopwatchFactory = new StopwatchFactoryWinRT();
            ReflectionService = new ReflectionServiceWinRT();
        }

        public string DatabaseRootDirectory
        {
            get { return Path.Combine(Common.GetPath(), "Data"); }
        }

        public ISQLiteApi SQLiteApi { get; private set; }
        public IStopwatchFactory StopwatchFactory { get; private set; }
        public IReflectionService ReflectionService { get; private set; }
        public IVolatileService VolatileService { get; private set; }
    }
}
