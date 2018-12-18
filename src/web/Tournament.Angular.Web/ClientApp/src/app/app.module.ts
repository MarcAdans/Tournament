import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { TournamentComponent } from './tournament/tournament.component';

import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TournamentRequest } from './models/TournamentRequest.model';
import { MovieService } from './services/movie.service';
import { TournamentService } from './services/tournament.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TournamentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'tournament', component: TournamentComponent}
    ])
  ],
  providers: [TournamentRequest, MovieService, TournamentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
