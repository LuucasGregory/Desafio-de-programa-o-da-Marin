import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class CnabService {
    private apiUrl = 'http://localhost:5000/api/cnab'; // Ajuste conforme necessário

    constructor(private http: HttpClient) { }

    // Enviar o arquivo CNAB
    uploadArquivo(file: File): Observable<any> {
        const formData = new FormData();
        formData.append('arquivo', file);

        return this.http.post(${ this.apiUrl } / processar, formData);
    }

    // Buscar todas as transações
    getTransacoes(): Observable<any[]> {
        return this.http.get<any[]>(${ this.apiUrl } / transacoes);
    }
}
