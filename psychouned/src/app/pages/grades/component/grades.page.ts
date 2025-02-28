import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GradeCalculatorComponent } from 'src/app/shared/gradeCalculator/gradeCalculator.component';
import { IonicModule } from '@ionic/angular';
import { GradeComponent } from 'src/app/shared/grade/grade.component';
import { Grade } from 'src/app/models/Grade';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.page.html',
  styleUrls: ['./grades.page.css'],
    imports: [
      CommonModule,
      IonicModule,
      GradeCalculatorComponent,
      GradeComponent
    ],
})
export class GradesPage {
  successes=0;
  mistakes=0;
  notAnswered=0;
  grade=0;
  constructor() { }

  calculateGrade(grade:Grade) {
    this.successes=grade.successes;
    this.mistakes=grade.mistakes;
    this.notAnswered=grade.notAnswered;
    this.grade=grade.grade??0;
  }

}
