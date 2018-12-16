import { Movie } from '../models/movie.model';
import { Match } from '../models/match.model';

export class Tournament {
  matches?: ((Match)[] | null)[] | null;
  movies?: (Movie)[] | null;
  champion: string;
  viceChampion: string;
}
