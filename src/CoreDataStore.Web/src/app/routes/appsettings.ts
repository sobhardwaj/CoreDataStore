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
  public static get ApiAttraction(): string {
    return "http://informationcart.eastus2.cloudapp.azure.com:82/api/";
  }
}