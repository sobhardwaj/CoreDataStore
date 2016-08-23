import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
//Grab everything with import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { IProperty } from '../../interfaces';

@Injectable()
export class DetailsService {

  _baseUrl: string = 'http://' + window.location.hostname + ':5000/';
  details: any; //IProperty[]; // cache for details

  constructor(private http: Http) {}

  getDetails(id): Observable < IProperty > {
    // console.log(borough,objectType);
    if (!(this.details && this.details[id])) {

      return this.http.get('api/LPCReport/' + id)
        .map((res: Response) => {
          if (!this.details) {
            this.details = {};
          }
          console.log(res.json());
          let p = res.json();
          this.details[id] = p;
          this.details[id].dateDesignated = Date.parse(p.dateDesignated);
          return this.details[id];
        })
        .catch(this.handleError);
    } else {
      //return cached data
      return this.createObservable(this.details[id]);
    }
  }

  updateProperty(property: IProperty): Observable<boolean> {
    console.log(property);
    let date = new Date(Date.parse(property.dateDesignated));
    property.dateDesignated = date.toISOString();
    return this.http.put('api/LPCReport/' + property.id.toString(), property)
      .map((res: Response) => {
        let response = res.json();
        console.log(response);
        return response;
      })
      .catch(this.handleError);
  }

  private createObservable(data: any): Observable < any > {
    return Observable.create((observer: Observer < any > ) => {
      observer.next(data);
      observer.complete();
    });
  }

  private handleError(error: any) {
    console.error(error);
    return Observable.throw((error.json && error.json().error) || 'Server error');
  }
}
