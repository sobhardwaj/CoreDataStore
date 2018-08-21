using System.Runtime.InteropServices;

namespace CoreDataStore.Web.Extensions
{
    /// <summary>
    ///
    /// </summary>
    public class PlatformHandler
    {
        static PlatformHandler()
        {

            var currentPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? OSPlatform.Windows
                : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                ? OSPlatform.OSX
                : OSPlatform.Linux;
            Platform = new Platform(currentPlatform);
        }

        /// <summary>
        ///
        /// </summary>
        public static Platform Platform { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class Platform
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Platform"/> class.
        /// </summary>
        /// <param name="platform"></param>
        public Platform(OSPlatform platform)
        {
            OSPlatform = platform;
        }

        /// <summary>
        ///
        /// </summary>
        public OSPlatform OSPlatform { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsLinux => OSPlatform == OSPlatform.Linux;

        /// <summary>
        ///
        /// </summary>
        public bool IsMac => OSPlatform == OSPlatform.OSX;

        /// <summary>
        ///
        /// </summary>
        public bool IsWindows => OSPlatform == OSPlatform.Windows;
    }
}