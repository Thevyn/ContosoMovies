import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from '../fetch-movies/fetch-data.component';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
})
export class AddMovieComponent {
  movie: Movie = {
    name: '',
    director: '',
    releaseDate: '',
    cast: '',
    genre: '',
    description: '',
  };
  baseUrl = 'https://localhost:8006/';
  error = '';
  constructor(private http: HttpClient, private router: Router) {}

  onChange(event) {
    const { name, value } = event.target;
    this.movie[name] = value;
  }

  onSubmit(event) {
    event.preventDefault();

    this.http
      .post<Movie>(this.baseUrl + 'Movie/createMovie', this.movie)
      .subscribe(
        (result) => {
          if (result) {
            console.log('Movie created successfully');
            this.router.navigate(['/']);
            this.error = '';
          } else {
            console.log('Movie already exits');
            this.error = 'Movie already exits';
          }
        },
        (error) => console.error(error)
      );
  }
}
