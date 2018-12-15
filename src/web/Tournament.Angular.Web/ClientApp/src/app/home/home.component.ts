import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public totalSelected = 0;
  public movies: Movie[];

  constructor(http: HttpClient) {
    http.get<Movie[]>('https://copadosfilmes.azurewebsites.net/api/filmes').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  }

  public UpdateTotal(item) {
    if (item) {
      this.totalSelected++;
    }
    else {
      this.totalSelected--;
    }
  }
}

interface Movie {
  id: string;
  titulo: string;
  ano: number;
  nota: number;
}

