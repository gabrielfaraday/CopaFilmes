import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Filme } from './filme';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SelecaoFilmesService {

  constructor(private http: HttpClient) { }

  obterFilmes(): Observable<Filme[]> {
    return this.http.get<Filme[]>(environment.url_api_filmes)
      .pipe(
        catchError(this.handleError('getHeroes', []))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
