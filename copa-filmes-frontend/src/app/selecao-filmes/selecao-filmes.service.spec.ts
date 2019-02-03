import { TestBed } from '@angular/core/testing';

import { SelecaoFilmesService } from './selecao-filmes.service';

describe('SelecaoFilmesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SelecaoFilmesService = TestBed.get(SelecaoFilmesService);
    expect(service).toBeTruthy();
  });
});
