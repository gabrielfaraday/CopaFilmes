import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SelecaoFilmesComponent } from './selecao-filmes/selecao-filmes.component';
import { ResultadoFinalComponent } from './resultado-final/resultado-final.component';

@NgModule({
  declarations: [
    AppComponent,
    SelecaoFilmesComponent,
    ResultadoFinalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
