import { Component } from '@angular/core';
import { CnabService } from '../services/cnab.service';

@Component({
    selector: 'app-cnab',
    templateUrl: './cnab.component.html',
    styleUrls: ['./cnab.component.css']
})
export class CnabComponent {
    transacoes: any[] = [];
    selectedFile!: File;

    constructor(private cnabService: CnabService) { }

    // Quando o usu�rio seleciona um arquivo
    onFileSelected(event: any) {
        this.selectedFile = event.target.files[0];
    }

    // Enviar o arquivo para o backend
    uploadFile() {
        if (this.selectedFile) {
            this.cnabService.uploadArquivo(this.selectedFile).subscribe(() => {
                alert('Arquivo enviado com sucesso!');
                this.loadTransacoes(); // Recarrega os dados ap�s o envio
            });
        } else {
            alert('Selecione um arquivo primeiro.');
        }
    }

    // Carregar transa��es do banco
    loadTransacoes() {
        this.cnabService.getTransacoes().subscribe(data => {
            this.transacoes = data;
        });
    }

    // Carregar transa��es ao iniciar o componente
    ngOnInit() {
        this.loadTransacoes();
    }
}