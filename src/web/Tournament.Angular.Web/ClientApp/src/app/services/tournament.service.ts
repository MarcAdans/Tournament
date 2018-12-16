import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TournamentRequest } from "../models/TournamentRequest.model";
import { Tournament } from "../models/Tournament.model";
import { environment } from "../../environments/environment";

@Injectable()
export class TournamentService {
  constructor(private readonly http: HttpClient) { }

  Calculate(torunamentRequest: TournamentRequest ) {
    var x = this.http.post<Tournament>(environment.getTournament, torunamentRequest);
    console.log(x);
    return x;
  }
}
