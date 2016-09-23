import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
//Grab everything with import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { IProperty } from '../../interfaces';

@Injectable()
export class PropertyDetailsService {

  _baseUrl: string = 'http://' + window.location.hostname + ':5000/';
  constructor(private http: Http) {}

  /*updateProperty(property: IProperty) : Observable<boolean> {
      return Observable.create((observer: Observer<boolean>) => {
          this.customers.forEach((cust: ICustomer, index: number) => {
             if (cust.id === customer.id) {
                 const state = this.filterStates(customer.state.abbreviation);
                 customer.state.abbreviation = state.abbreviation;
                 customer.state.name = state.name;
                 this.customers[index] = customer;
             }
          });
          observer.next(true);
          observer.complete();
      });
  }*/

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
