"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var environment_1 = require("../../environments/environment");
var TournamentService = /** @class */ (function () {
    function TournamentService(http) {
        this.http = http;
        this.request = new TournamentRequest();
    }
    TournamentService.prototype.saveSelectedMovies = function (movies) {
        this.request.movies = movies;
        console.log(movies);
    };
    TournamentService.prototype.Calculate = function () {
        this.request.movies.push("tt3606756");
        console.log(this.request.movies);
        return this.http.post(environment_1.environment.getTournament, this.request);
    };
    return TournamentService;
}());
exports.TournamentService = TournamentService;
var TournamentRequest = /** @class */ (function () {
    function TournamentRequest() {
        this.movies = [];
    }
    return TournamentRequest;
}());
//# sourceMappingURL=tournament.service.js.map