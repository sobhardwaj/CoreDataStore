import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
//Grab everything with import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { IProperty } from '../../interfaces';

@Injectable()
export class DetailsService {

  _baseUrl: string = 'http://' + window.location.hostname + ':5000/';
  details: any; //IProperty[]; // cache for details
  landmarks: any;

  constructor(private http: Http) {}

  getDetails(id): Observable < IProperty > {
    // console.log(borough,objectType);
    if (!(this.details && this.details[id])) {

      return this.http.get('api/LPCReport/' + id)
        .map((res: Response) => {
          if (!this.details) {
            this.details = {};
          }
          // console.log(res.json());
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

  getLandmarkProperties(lpcNumber): Observable < IProperty > {
    if (!(this.landmarks && this.landmarks[lpcNumber])) {
      let params = new URLSearchParams();
      params.set('LPCNumber', lpcNumber);
      return this.http.get('api/LPCReport/landmark/100/1', { search: params })
        .map((res: Response) => {
          if (!this.landmarks) {
            this.landmarks = {};
          }
          console.log(res);
          let p = res.json();
          this.landmarks[lpcNumber] = p;
          return this.landmarks[lpcNumber];
        })
        .catch(this.handleError);
    } else {
      //return cached data
      return this.createObservable(this.landmarks[lpcNumber]);
    }
  }

  updateProperty(property: IProperty): Observable<boolean> {
    console.log(property);
    let date = new Date(Date.parse(property.dateDesignated));
    property.dateDesignated = date.toISOString();
    return this.http.put('api/LPCReport/' + property.id.toString(), property)
      .map((res: Response) => {
        let response = res.json();
        // console.log(response);
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
    // console.error(error);
    let errorText = '';
    try {
      errorText = (error.json && error.json().error) || 'Server error';
    } catch (e) {
      errorText = 'Server error';
    }
    return Observable.throw(errorText);
  }
}
