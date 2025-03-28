import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Transacao } from './transacao.models';

@Injectable({
  providedIn: 'root',
})
export class TransacaoService {
  private apiUrl: string;

  constructor(
      private http: HttpClient
  ) {
      this.apiUrl = `http://localhost:5159/api/transacao`;
  }

  public buscarTransacoes(): Observable<Transacao[]> {
      return this.http.get<Transacao[]>(`${ this.apiUrl }`);
  }

  public uploadFile(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('arquivo', file); // A API espera um `IFormFile`

    return this.http.post(`${this.apiUrl}/cnab`, formData).pipe(
      catchError(this.handleError) // Captura e trata erros da requisição
    );
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    console.error('Erro no upload:', error);
    return throwError(() => new Error(error.message || 'Erro desconhecido no upload.'));
  }
}
