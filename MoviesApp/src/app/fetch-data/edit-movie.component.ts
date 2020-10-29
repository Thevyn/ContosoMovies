import { Component } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Movie } from "./fetch-data.component";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-edit-movie",
  templateUrl: "./edit-movie.component.html",
})
export class EditMovieComponent {
  movie: Movie;
  baseUrl = "https://localhost:8006/";

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.http
      .get<Movie>(this.baseUrl + "movie/edit-movie", {
        params: { id: this.route.snapshot.paramMap.get("id") },
      })
      .subscribe(
        (result) => {
          this.movie = result;
        },
        (error) => console.error(error)
      );
  }

  onChange(event) {
    const { name, value } = event.target;
    this.movie[name] = value;
  }

  onSubmit(event) {
    event.preventDefault();

    this.http
      .put<Movie>(this.baseUrl + "Movie/updateMovie", this.movie)
      .subscribe(
        () => {
          console.log("Movie updated successfully");
          this.router.navigate(["/"]);
        },
        (error) => console.error(error)
      );
  }
}
