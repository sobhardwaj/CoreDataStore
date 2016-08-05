export class AppSettings {
  public static get ApiEndpoint(): string {
    // return 'http://localhost:5000/api/'; 
    return 'http://' + window.location.hostname + ':5000/api/';
  }
}
