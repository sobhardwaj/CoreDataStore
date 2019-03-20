public static class Settings
{
    public static string ProjectName => "CoreDataStore";

    public static string SonarUrl => "http://sonar.navigatorglass.com:9000";

    public static string SonarKey => "584273597838fd75ab485e34b353101e0eeebdea";

    public static string SonarName => "CoreDataStore";

    public static string SonarExclude => "/d:sonar.exclusions=Program.cs,**/Formatters/*.cs";

     public static string SonarExcludeDuplications => "/d:sonar.cpd.exclusions=**/Templates/ExcelFormating.cs";
}

