import { Component, Input } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";

@Component({
  selector: "app-movies",
  templateUrl: "./fetch-data.component.html",
})
export class FetchDataComponent {
  public movies: Movie[];
  baseUrl = "https://localhost:8006/";
  @Input() searchString: string;

  constructor(private http: HttpClient) {}

  getMovies() {
    this.http.get<Movie[]>(this.baseUrl + "movie").subscribe(
      (result) => {
        this.movies = result;
      },
      (error) => console.error(error)
    );
  }

  ngOnInit(): void {
    this.getMovies();
  }

  public onChange(event) {
    this.searchString = event.target.value;
  }

  onSearch() {
    let params = new HttpParams();
    params = params.append("searchString", this.searchString);
    this.http
      .get<Movie[]>(this.baseUrl + "movie", { params })
      .subscribe(
        (result) => {
          console.log(result);
          this.movies = result;
        },
        (error) => console.error(error)
      );
  }

  onGenreChange(event) {
    let params = new HttpParams();
    params = params.append("genre", event.target.value);
    this.http
      .get<Movie[]>(this.baseUrl + "movie/getMovieByGenre", { params })
      .subscribe(
        (result) => {
          console.log(result);
          this.movies = result;
        },
        (error) => console.error(error)
      );
  }

  onDelete(id: number) {
    this.http.delete(this.baseUrl + "movie/deleteById" + id).subscribe(
      () => {
        console.log("Movie deleted successfully");
        this.getMovies();
      },
      (error) => {
        console.log(error);
      }
    );
  }
}

export interface Movie {
  id?: number;
  name: string;
  director: string;
  releaseDate: string;
  cast: string;
  genre: string;
  description: string;
}
