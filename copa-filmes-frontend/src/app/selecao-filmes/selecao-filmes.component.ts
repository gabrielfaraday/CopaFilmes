import { Component, OnInit } from '@angular/core';
import { SelecaoFilmesService } from './selecao-filmes.service';
import { Filme } from './filme';

@Component({
  selector: 'app-selecao-filmes',
  templateUrl: './selecao-filmes.component.html',
  styleUrls: ['./selecao-filmes.component.css']
})
export class SelecaoFilmesComponent implements OnInit {

  filmes: Filme[];

  constructor(private selecaoFilmesService: SelecaoFilmesService) { }

  ngOnInit() {
    this.obterFilmes();
  }

  obterFilmes(): void {
    this.selecaoFilmesService.obterFilmes()
      .subscribe(filmes => this.filmes = filmes);
  }

}
