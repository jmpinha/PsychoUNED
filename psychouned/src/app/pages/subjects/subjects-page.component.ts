import { CommonModule } from '@angular/common';
import { Component, inject, signal, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Courses, Semester, SubjectsName } from 'src/app/models/names';
import { MatTabsModule } from '@angular/material/tabs';
import { IonicModule } from '@ionic/angular';
import { animate, style, transition, trigger } from '@angular/animations';
import { heartOutline } from 'ionicons/icons';
import { addIcons } from 'ionicons';
import { GlobalsService } from 'src/app/core/services/globals.service';
import { SubjectDTO } from 'src/app/models/subjects.interface';
import { SubjectsApiService } from 'src/app/core/api/subjects-api.service';
@Component({
  templateUrl: './subjects-page.component.html',
  styleUrls: ['./subjects-page.component.scss'],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MatTabsModule,
  ],
  animations: [
    trigger('translateTab', [
      transition(':enter', [
        style({ transform: 'translateX(-100%)' }),
        animate('250ms', style({ transform: 'translateX(0)' })),
      ]),
    ]),
  ],
})
export default class SubjectsPage implements OnInit {

  items = signal<SubjectDTO[]>([]);
  courses = [{ courseDescription: Courses.FIRST, course: 1 },
  { courseDescription: Courses.SECOND, course: 2 },
  { courseDescription: Courses.THIRD, course: 3 },
  { courseDescription: Courses.FOURTH, course: 4 }];
  semesters = [{ semesterDescription: Semester.FIRST, semester: 1 },
  { semesterDescription: Semester.SECOND, semester: 2 }];
  semesterSelected = 1;
  courseSelected = 1;
  subjectService = inject(SubjectsApiService);
  private globalsService = inject(GlobalsService);

  constructor() {
    addIcons({ heartOutline });
  }
  ngOnInit(): void {
    this.loadItems(this.courseSelected,this.semesterSelected)
  }

  showToast(word: string) {
    this.globalsService.showToast(word);
  }
  changeCourse(course: number) {
    this.courseSelected=course+1;
    console.log(this.semesterSelected,this.courseSelected);
    this.loadItems(this.courseSelected,this.semesterSelected);
  }
  changeSemester(semester: number) {
    this.semesterSelected=semester+1;
    console.log(this.semesterSelected,this.courseSelected);
    this.loadItems(this.courseSelected,this.semesterSelected);
  }
  loadItems(course: number, semester: number) {
    this.subjectService.loadSubjects(course, semester)?.subscribe({
      next: resp => {
        console.log(resp);
        this.items.set(resp);
      },
      error: (error) => {
        console.log(error);
        this.items.set([]);
      }
    })
  }
}
