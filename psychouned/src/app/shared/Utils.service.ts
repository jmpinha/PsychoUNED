import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilsService {

  constructor() { }

  public loadLetter(i: number): string {
    return `${String.fromCharCode(97 + i)})`
  }
}
