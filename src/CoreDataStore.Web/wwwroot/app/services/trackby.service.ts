import { Injectable } from '@angular/core';

import { IProperty } from '../interfaces';

@Injectable()
export class TrackByService {
  
  property(index:number, property: IProperty) {
    return property.id;
  }
  
}