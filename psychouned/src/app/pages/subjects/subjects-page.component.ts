import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Courses, Semester, SubjectsName } from 'src/app/models/Names';
import { MatTabsModule } from '@angular/material/tabs';
import { IonicModule } from '@ionic/angular';
import { animate, style, transition, trigger } from '@angular/animations';
import { GlobalsService } from 'src/app/services/globals.service';
import { heartOutline } from 'ionicons/icons';
import { addIcons } from 'ionicons';

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
export class SubjectsPage {

  items = [{ subject: SubjectsName.DATA_ANALYSIS, course: 1, semester: 1 },
  { subject: SubjectsName.PSYCHOBIOLOGY, course: 1, semester: 1 },
  { subject: SubjectsName.SOCIAL, course: 1, semester: 1 },
  { subject: SubjectsName.RESEARCH_FUNDAMENTALS, course: 1, semester: 1 },
  { subject: SubjectsName.MOTIVATION, course: 1, semester: 1 },

  { subject: SubjectsName.ATENTION, course: 1, semester: 2 },
  { subject: SubjectsName.PSYCHOBIOLOGY, course: 1, semester: 2 },
  { subject: SubjectsName.SOCIAL, course: 1, semester: 2 },
  { subject: SubjectsName.LEARNING, course: 1, semester: 2 },
  { subject: SubjectsName.EMOTION, course: 1, semester: 2 },
  ];
  courses = [{ courseDescription: Courses.FIRST, course: 1 },
  { courseDescription: Courses.SECOND, course: 2 },
  { courseDescription: Courses.THIRD, course: 3 },
  { courseDescription: Courses.FOURTH, course: 4 }];
  semesters = [{ semesterDescription: Semester.FIRST, semester: 1 },
  { semesterDescription: Semester.SECOND, semester: 2 }];
  semesterSelected = 1;
  courseSelected = 1;
  // filteredItems = this.items.filter(item => item.course === (this.courseSelected+1) && item.semester === (this.semesterSelected+1));
  get filteredItems() {
    return this.items.filter(
      item => item.course === this.courseSelected && item.semester === this.semesterSelected
    );
  }

  constructor(private globalsService: GlobalsService) {
      addIcons({ heartOutline});}

  showToast(word: string) {
    this.globalsService.showToast(word);
  }
  changeCourse(course: number) {
    this.courseSelected = course+1;
    console.log(this.courseSelected);
    console.log(this.filteredItems);
  }
  changeSemester(semester: number) {
    this.semesterSelected = semester+1;
    console.log(this.semesterSelected);
    console.log(this.filteredItems);
  }
}
