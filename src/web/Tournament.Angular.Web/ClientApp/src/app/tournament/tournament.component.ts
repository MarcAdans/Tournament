import { Component } from "@angular/core";
import { Tournament } from '../models/tournament.model';
import { Movie } from '../models/movie.model';
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
export class TournamentComponent{
  
  private champion: Movie;
  private vice: Movie;
  public tournament: Tournament;


  constructor(private readonly tournamentService: TournamentService,
    private readonly toastr: ToastrService,
    private readonly router: Router,
    private data: TournamentRequest) {

    

    if (!this.data.movies) {
      this.data.movies = [
        "tt3606756",
        "tt4881806",
        "tt5164214",
        "tt7784604",
        "tt4154756",
        "tt5463162",
        "tt3778644",
        "tt3501632",
      ];      
    }

    console.log(this.data.movies);

    this.tournamentService.Calculate(this.data).subscribe(result => {
      console.log(result);
      this.tournament = result;
    }, error => {
      console.error(error);
      this.toastr.error('Não nos abandone, deu ruim mas tente novamente.', 'Deu ruim...');
      });
  }


  //ngOnInit(): void {
  //  this.tournamentService.Calculate().subscribe(result => {
  //    this.tournament = result;
  //  }, error => {
  //    console.error(error);
  //    this.toastr.error('Não nos abandone, deu ruim mas tente novamente.', 'Deu ruim...');
  //    });

  //  console.log(this.tournament);

  //  if (!this.tournament) {
  //    this.back();
  //  }
  //}

  back() {
    this.router.navigate([""]);
  }
}
