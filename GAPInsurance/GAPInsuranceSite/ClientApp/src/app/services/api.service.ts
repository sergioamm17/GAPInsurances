import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Insurance } from '../models/Insurance';
import { AuthenticationService } from '../services/authentication.service';

import { User } from '../models/User';

const apiUrl = "https://localhost:44364";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  currentUser: User;

  constructor(private http: HttpClient,
    private authenticationService: AuthenticationService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  getInsurances(): Observable<Insurance[]> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.currentUser.token}`
      })
    };

    return this.http.get<Insurance[]>(`${apiUrl}/api/insurance/`, httpOptions)
      .pipe(
        tap(insurances => { console.log('fetched insurances'); console.log(insurances); }),
        catchError(this.handleError('getInsurances', []))
      );
  }




  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
