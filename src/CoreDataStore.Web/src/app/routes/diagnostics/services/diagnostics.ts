import { Injectable } from '@angular/core';
import { Http, Response } from "@angular/http";

import 'rxjs/add/operator/map';
import { AppSettings } from '../../../appsettings';

@Injectable()
export class DiagnosticsService {
  location: any = {};

  constructor(private http: Http) {
    this.location = {
      street: "string",
      address: "string",
      borough: "string",
      neighborhood: "string",
      postalCode: "string",
      state: "string"
    }
  }
  getDiagnostics() {
    return this.http.get(`${AppSettings.ApiEndpoint}Diagnostics`).map((res: Response) => res.json());
  }

  getUserRange(coords) {
  	return this.http.post(`${AppSettings.ApiLocation}Location/api/Location/validate`,  {coords:coords, location:this.location}).map((res: Response) => res.json());
  }

  getUserLocation(coords) {
  	return this.http.post(`${AppSettings.ApiLocation}Location`, {coords:coords, location:this.location}).map((res: Response) => res.json());
  }

}
