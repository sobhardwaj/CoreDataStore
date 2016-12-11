import { Injectable } from '@angular/core';
import { Http, Response, Headers, URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/map';

import { AppSettings } from '../../appsettings';

@Injectable()
export class MapsService {

  constructor(private http: Http) {}

  public getMaps() {
    return this.http.get(`${AppSettings.ApiAttraction}Maps`)
      .map((res: Response) => res.json());
  };

  public getMapsId(id: string) {
    var headers = new Headers({ 'Accept': 'application/vnd.geo+json' });
    return this.http.get(`${AppSettings.ApiAttraction}Maps/${id}`, { headers: headers })
      .map((res: Response) => res.json());
  };

  public getMapsFeatures(id: string) {
    var headers = new Headers({ 'Accept': 'application/vnd.geo+json' });
    return this.http.get(`${AppSettings.ApiAttraction}Maps/${id}/features`, { headers: headers })
      .map((res: Response) => res.json());
  };
}
