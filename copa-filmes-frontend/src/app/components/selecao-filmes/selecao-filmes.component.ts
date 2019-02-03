import { Component, OnInit } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";

import { Filme } from 'src/app/models/filme';
import { CopaFilmesService } from 'src/app/services/copa-filmes.service';

@Component({
  selector: 'app-selecao-filmes',
  templateUrl: './selecao-filmes.component.html',
  styleUrls: ['./selecao-filmes.component.css']
})
export class SelecaoFilmesComponent implements OnInit {

  filmes: Filme[];
  totalSelecionado: number;

  constructor(private copaFilmesService: CopaFilmesService, private router: Router) { }

  ngOnInit() {
    this.totalSelecionado = 0;
    this.obterFilmes();
  }

  obterFilmes(): void {
    this.copaFilmesService.obterFilmes()
      .subscribe(filmes => this.filmes = filmes);
  }

  filmeSelecionado(filme: Filme, e: any): void {
    this.filmes.find(x => x.id === filme.id).selecionado = e.target.checked;
    this.totalSelecionado = this.obterFilmesSelecionados().length;
  }

  totalSelecionadoValido(): boolean {
    return this.totalSelecionado === 8;
  }

  gerarMeuCampeonato(): void {
    let filmesSelecionados: Filme[] = this.obterFilmesSelecionados();

    this.copaFilmesService.apurarResultado(filmesSelecionados)
      .subscribe(filmes => this.onGerarMeuCampeonatoComplete(filmes));
  }

  private obterFilmesSelecionados(): Filme[] {
    return this.filmes.filter(function (x) { return x.selecionado });
  }

  private onGerarMeuCampeonatoComplete(filmes: Filme[]): void {
    let navigationExtras: NavigationExtras = {
      queryParams: {
        "campeao": filmes[0].titulo,
        "vice": filmes[1].titulo
      }
    };
    this.router.navigate(["resultado-final"], navigationExtras);
  }
}