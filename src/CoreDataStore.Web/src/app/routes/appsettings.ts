export class AppSettings {

  public static get build(): string {
    return "local";
  }
  public static get ng2ENV(): string {
    return "Dev";
  }
  public static get ApiEndpoint(): string {
    return "/api/";
  }
  public static get ApiMaps(): string {
    return "http://informationcart.eastus2.cloudapp.azure.com:82/api/";
  }
  public static get ApiReports(): string {
    return "/api/reports";
  }
  public static get ApiAttraction(): string {
    return "/api/attraction";
  }
}