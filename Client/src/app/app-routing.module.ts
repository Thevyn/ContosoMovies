import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FetchDataComponent } from './fetch-movies/fetch-data.component';
import { EditMovieComponent } from './fetch-movies/edit-movie.component';
import { AddMovieComponent } from './add-movie/add-movie.component';

const routes: Routes = [
  { path: '', component: FetchDataComponent, pathMatch: 'full' },
  { path: 'add-movie', component: AddMovieComponent },
  { path: 'edit-movie/:id', component: EditMovieComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
