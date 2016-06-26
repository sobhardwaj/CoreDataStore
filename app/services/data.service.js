"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
//Grab everything with import 'rxjs/Rx';
var Observable_1 = require('rxjs/Observable');
require('rxjs/add/operator/map');
require('rxjs/add/operator/catch');
var DataService = (function () {
    /*    customers: ICustomer[];
        orders: IOrder[];
        states: IState[];
    */
    function DataService(http) {
        this.http = http;
        this._baseUrl = 'http://localhost:5000/';
    }
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
        
        getStates(): Observable<IState[]> {
            if (this.states) {
                return Observable.create((observer: Observer<IState[]>) => {
                    observer.next(this.states);
                    observer.complete();
                });
            } else {
                return this.http.get(this._baseUrl + 'states.json').map((response: Response) => {
                    this.states = response.json();
                    return this.states;
                })
                .catch(this.handleError);
            }
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
    DataService.prototype.getProperties = function () {
        var _this = this;
        if (!this.properties) {
            return this.http.get(this._baseUrl + 'api/LPCReport/99/1')
                .map(function (res) {
                _this.properties = res.json();
                return _this.properties;
            })
                .catch(this.handleError);
        }
        else {
            //return cached data
            return this.createObservable(this.properties);
        }
    };
    DataService.prototype.createObservable = function (data) {
        return Observable_1.Observable.create(function (observer) {
            observer.next(data);
            observer.complete();
        });
    };
    DataService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    DataService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], DataService);
    return DataService;
}());
exports.DataService = DataService;
//# sourceMappingURL=data.service.js.map