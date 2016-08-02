import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
//Grab everything with import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { IProperty } from '../../interfaces';

@Injectable()
export class ReferencesService {

  _baseUrl: string = 'http://' + window.location.hostname + ':5000/';
  properties: any; //IProperty[][][][]; // cache for borough/objecttype/page

  boroughs: string[];
  objectTypes: string[];
  /*    customers: ICustomer[];
      orders: IOrder[];
      states: IState[];
  */

  constructor(private http: Http) {}

  /*    
      getCustomers() : Observable<ICustomer[]> {
          if (!this.customers) {
              return this.http.get(this._baseUrl + 'customers.json')
                          .map((res: Response) => {
                              this.customers = res.json();
                              return this.customers;
                          })
                          .catch(this.handleError);
          }
          else {
              //return cached data
              return this.createObservable(this.customers);
          }
      }
      
      getCustomer(id: number) : Observable<ICustomer> {
          if (this.customers) {
              //filter using cached data
              return this.findCustomerObservable(id);
          } else {
              //Query the existing customers to find the target customer
              return Observable.create((observer: Observer<ICustomer>) => {
                      this.getCustomers().subscribe((customers: ICustomer[]) => {
                          this.customers = customers;                
                          const cust = this.filterCustomers(id);
                          observer.next(cust);
                          observer.complete();
                  })
              })
              .catch(this.handleError);
          }
      }

      getOrders(id: number) : Observable<IOrder[]> {
        return this.http.get(this._baseUrl + 'orders.json')
                  .map((res: Response) => {
                      this.orders = res.json();
                      return this.orders.filter((order: IOrder) => order.customerId === id);
                  })
                  .catch(this.handleError);               
      }
      
      updateCustomer(customer: ICustomer) : Observable<boolean> {
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
      }
          
      private findCustomerObservable(id: number) : Observable<ICustomer> {        
          return this.createObservable(this.filterCustomers(id));
      }
      
      private filterCustomers(id: number) : ICustomer {
          const custs = this.customers.filter((cust) => cust.id === id);
          return (custs.length) ? custs[0] : null;
      }
          
      private filterStates(stateAbbreviation: string) {
          const filteredStates = this.states.filter((state) => state.abbreviation === stateAbbreviation);
          return (filteredStates.length) ? filteredStates[0] : null;
      }
  */

  getReference(borough, objectType, pageNo): Observable < IProperty[] > {
    // console.log(borough,objectType);
    if (!(this.properties && this.properties[borough] &&
        this.properties[borough][objectType] &&
        this.properties[borough][objectType][pageNo])) {

      let params = new URLSearchParams();
      if (borough && borough !== '') {
        params['Borough'] = borough;
        params.set('Borough', borough);

      }
      if (objectType && objectType !== '') {
        params.set('ObjectType', objectType);
      }
      return this.http.get('api/LPCReport/10/' + pageNo, { search: params })
        .map((res: Response) => {
          // console.log(0);
          if (!this.properties) {
            this.properties = {};
            // this.properties[borough] = {};
          }
          // console.log(1);
          if (!this.properties[borough]) { this.properties[borough] = {}; }
          // console.log(2);
          if (!this.properties[borough][objectType]) { this.properties[borough][objectType] = {}; }
          this.properties[borough][objectType] = this.properties[borough][objectType] ?
            this.properties[borough][objectType] : { pageNo: [] };
          this.properties[borough][objectType][pageNo] = res.json()
            .map(p => {
              p.dateDesignated = Date.parse(p.dateDesignated);
              return p;
            });
          return this.properties[borough][objectType][pageNo];
        })
        .catch(this.handleError);
    } else {
      //return cached data
      return this.createObservable(this.properties[borough][objectType][pageNo]);
    }
  }

  getBoroughs(): Observable < string[] > {
    if (!this.boroughs) {
      return this.http.get('api/Reference/borough')
        .map((res: Response) => {
          this.boroughs = res.json();
          return this.boroughs;
        })
        .catch(this.handleError);
    } else {
      //return cached data
      return this.createObservable(this.boroughs);
    }
  }

  getObjectTypes(): Observable < string[] > {
    if (!this.objectTypes) {
      return this.http.get('api/Reference/objectType')
        .map((res: Response) => {
          this.objectTypes = res.json();
          return this.objectTypes;
        })
        .catch(this.handleError);
    } else {
      //return cached data
      return this.createObservable(this.objectTypes);
    }
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
