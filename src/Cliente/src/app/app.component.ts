import { Component, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { TransacaoService } from './transacao.service';
import { take } from 'rxjs';
import { Transacao } from './transacao.models';
import { CommonModule, CurrencyPipe, DatePipe } from '@angular/common';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressBarModule } from '@angular/material/progress-bar';

@Component({
  selector: 'app-root',
  imports: [CommonModule, MatTableModule, MatSnackBarModule, MatCardModule, MatButtonModule, MatProgressBarModule, DatePipe, CurrencyPipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  displayedColumns: string[] = ['tipo', 'data', 'valor', 'cpf', 'cartao', 'representante', 'nomeLoja'];
  dataSource: Transacao[] = [];

  selectedFile: File | null = null;
  uploading = false;

  constructor(
    private transacaoService: TransacaoService,
    private snackBar: MatSnackBar
  ) {}

  public ngOnInit(): void {
    this.transacaoService
        .buscarTransacoes()
        .pipe(take(1))
        .subscribe(transacoes => {
          this.dataSource = transacoes;
        });
  }

  public onFileSelected(event: Event): void {
    const target = event.target as HTMLInputElement;
    if (target.files && target.files.length > 0) {
      this.selectedFile = target.files[0];
    }
  }

  public uploadFile(): void {
    if (!this.selectedFile) return;

    this.uploading = true;

    this.transacaoService
        .uploadFile(this.selectedFile)
        .pipe(take(1))
        .subscribe({
          next: () => {
            this.uploading = false;
            this.snackBar.open('Upload realizado com sucesso!', 'Fechar', { duration: 3000 });
            this.selectedFile = null;

            this.transacaoService
                .buscarTransacoes()
                .pipe(take(1))
                .subscribe(transacoes => {
                  this.dataSource = transacoes;
                });
          },
          error: (error) => {
            this.uploading = false;
            this.snackBar.open('Erro no upload: ' + error.message, 'Fechar', { duration: 3000 });
          },
        });
  }
}
