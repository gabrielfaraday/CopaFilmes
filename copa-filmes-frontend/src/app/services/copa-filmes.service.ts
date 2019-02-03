import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { Filme } from '../models/filme';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class CopaFilmesService {

  constructor(private http: HttpClient) { }

  obterFilmes(): Observable<Filme[]> {
    return this.http.get<Filme[]>(environment.url_api_filmes)
      .pipe(
        catchError(this.handleError('obterFilmes', []))
      );
  }

  apurarResultado(filmes: Filme[]): Observable<Filme[]> {
    return this.http.post<Filme[]>(environment.url_api_apuracao, filmes, httpOptions)
      .pipe(
        catchError(this.handleError('apurarResultado', []))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
