import { Injectable } from '@angular/core';
import { HTTP_PROVIDERS, Http, Response, Headers, RequestOptions } from "@angular/http";
import 'rxjs/add/operator/map';
import { AppSettings } from '../../appsettings';

@Injectable()
export class DiagnosticsService {

  constructor(private http: Http) {}
  getDiagnostics() {
<<<<<<< HEAD
    return this.http.get(`${AppSettings.ApiEndpoint}Diagnostics`).map((res: Response) => res.json());
=======
    return this.http.get('api/Diagnostics').map((res: Response) => res.json());
>>>>>>> master
  }

}
