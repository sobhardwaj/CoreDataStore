import { Injectable } from '@angular/core';
import { Http, Response } from "@angular/http";

import 'rxjs/add/operator/map';
import { AppSettings } from '../../../appsettings';

@Injectable()
export class DiagnosticsService {

  constructor(private http: Http) {}
  getDiagnostics() {
    return this.http.get(`${AppSettings.ApiEndpoint}Diagnostics`).map((res: Response) => res.json());
  }

  getUserRange(lat, lng) {
  	return this.http.post(`${AppSettings.ApiLocation}Location/api/Location/validate`,  {coords:{"latitude": lat, "longitude": lng}}).map((res: Response) => res.json());
  }

  getUserLocation(lat, lng) {
  	return this.http.post(`${AppSettings.ApiLocation}Location`, {coords:{"latitude": lat, "longitude": lng}}).map((res: Response) => res.json());
  }

}
