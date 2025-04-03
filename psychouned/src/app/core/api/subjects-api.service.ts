import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { SubjectDTO } from 'src/app/models/subjects.interface';

@Injectable({
  providedIn: 'root'
})
export class SubjectsApiService {

  url = 'http://localhost:5285/api'

  // subjectsLoading = signal(false);
  private http = inject(HttpClient);
  loadSubjects(course: number, semester: number) {
    return this.http.get<SubjectDTO[]>(`${this.url}/Subject/filter`, {
      params: {
        course,
        semester
      }
    }).pipe(
      map((items) =>items),
      catchError(error => {
        console.log('Error fetching', error)
        return throwError(() => new Error('No se pudieron cargar Asignaturas'))
      }
      )
    )
  }
}
