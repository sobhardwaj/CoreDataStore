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
        /// 
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
        public bool IsLinux { get { return OSPlatform == OSPlatform.Linux; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsMac { get { return OSPlatform == OSPlatform.OSX; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsWindows { get { return OSPlatform == OSPlatform.Windows; } }
    }
}