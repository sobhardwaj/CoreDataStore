public static class Settings
{
    public static string ProjectName => "CoreDataStore";

    public static string SonarUrl => "http://192.168.1.3:9000";

    //public static string SonarKey => "584273597838fd75ab485e34b353101e0eeebdea";
    public static string SonarKey => "2d9714fb99838954428a6a8b90ebddb59dea882a";

    public static string SonarName => "CoreDataStore";

    public static string SonarExclude => "/d:sonar.exclusions=**/wwwroot/**,**/typings/**,**/src/app/**,**/src/less/**,*.less,*.js,*.ts,Program.cs";

    public static string SonarExcludeDuplications => "/d:sonar.cpd.exclusions=**/Models/**,**/Repositories/**";

    public static string MyGetSource => "https://www.myget.org/F/coredatastore/api/v2/package";
}
