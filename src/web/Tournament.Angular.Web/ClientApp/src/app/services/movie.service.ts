import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Movie } from "../models/movie.model";
import { environment } from "../../environments/environment";

@Injectable()
export class MovieService {
  constructor(private readonly http: HttpClient) { }

  public getMovies() {
    return this.http.get<Movie[]>(environment.getMovies);
  }
}
