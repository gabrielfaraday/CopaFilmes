import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelecaoFilmesComponent } from './selecao-filmes.component';

describe('SelecaoFilmesComponent', () => {
  let component: SelecaoFilmesComponent;
  let fixture: ComponentFixture<SelecaoFilmesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelecaoFilmesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelecaoFilmesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
