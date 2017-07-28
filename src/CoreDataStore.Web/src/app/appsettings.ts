export class AppSettings {

  public static get build(): string {
    return localStorage.getItem("build") || "local";
  }
  public static get buildId(): string {
    return localStorage.getItem("BuildId") || "1.0.0";
  }
  public static get ng2ENV(): string {
    return localStorage.getItem("ng2ENV") || "";
  }
  public static get ApiEndpoint(): string {
    return localStorage.getItem("ApiEndpoint") || "";
  }
  public static get ApiMaps(): string {
    return localStorage.getItem("ApiMaps") || "";
  }
  public static get ApiReports(): string {
    return "/api/reports";
  }
  public static get ApiAttraction(): string {
    return "/api/attraction";
  }
}