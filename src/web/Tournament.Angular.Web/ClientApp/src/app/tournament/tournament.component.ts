import { Component, OnInit } from "@angular/core";
import { Tournament } from '../models/tournament.model';
import { Movie } from '../models/movie.model';
import { Match } from '../models/match.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { MovieService } from "../services/movie.service";
import { TournamentService } from "../services/tournament.service";
import { TournamentRequest } from '../models/TournamentRequest.model';

@Component({
  selector: 'app-tournament',
  templateUrl: './tournament.component.html',
  styleUrls: ['./tournament.component.css']
})
export class TournamentComponent {
  public tournament: Tournament;

  constructor(private readonly tournamentService: TournamentService,
    private readonly toastr: ToastrService,
    private readonly router: Router,
    private data: TournamentRequest) {
  }

  ngOnInit(): void {
    if (!this.data.movies || this.data.movies.length == 0) {
      this.back();
      this.toastr.error('Você não selecionou nenhum item.', ':0');
    } else {
      this.tournamentService.Calculate(this.data).subscribe(result => {
        console.log(result);
        this.tournament = result;
      }, error => {
        console.error(error);
        this.toastr.error('Não nos abandone, deu ruim mas tente novamente.', 'Deu ruim...');
        this.back();
      });
    }

    //this.data.movies = [];
  }

  public getMovie(id: string): Movie {
    return this.tournament.movies.filter(m => m.id == id)[0];
  }

  getMatchWinner(match: Match): Movie {
    console.log(match);
    return this.getMovie(match.winnerId);
  }

  public get champion(): Movie {
    return this.getMovie(this.tournament.champion);
  }

  public get viceChampion(): Movie {
    return this.getMovie(this.tournament.viceChampion);
  }

  back() {
    this.router.navigate([""]);
  }
}
