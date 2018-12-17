import { Component } from '@angular/core';
import { environment } from "../../environments/environment";
import { Movie } from '../models/movie.model';
import { TournamentRequest } from '../models/TournamentRequest.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { MovieService } from "../services/movie.service";
import { TournamentService } from "../services/tournament.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  private selectedMovies: string[] = [];

  public movies: Movie[];

  constructor(private readonly toastr: ToastrService,
    private readonly movieService: MovieService,
    private readonly tournamentService: TournamentService,
    private readonly router: Router,
    private data: TournamentRequest) {
    this.movieService.getMovies().subscribe(result => {
      this.movies = result;
    }, error => {
      console.error(error);
      this.toastr.error('Não nos abandone, deu ruim mas tente novamente.', 'Deu ruim...');
    });
  }

  public checkedState(event: MouseEvent, id) {
    var checkbox = event.target as HTMLInputElement;

    if (this.totalSelected >= 8) {
      checkbox.checked = false;
      this.toastr.info('O máximo de itens é apenas 8 filmes.', ':)');
    }

    if (checkbox.checked === true) {
      this.selectedMovies.push(id);
    } else if (this.totalSelected > 0) {
      const index = this.selectedMovies.indexOf(id, 0);
      if (index > -1) {
        this.selectedMovies.splice(index, 1);
      }
    }

    console.log(this.selectedMovies);
  }

  get buttonState() {
    return (this.totalSelected < 8);
  }

  get totalSelected() {
    return this.selectedMovies.length;
  }

  public calculateTournament() {
    this.data.movies = this.selectedMovies;

    this.router.navigate(["tournament/"]);
  }
}
