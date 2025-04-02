import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { GradeComponent } from 'src/app/components/grade-components/grade/grade.component';
import { GradeCalculatorComponent } from 'src/app/components/grade-components/gradeCalculator/gradeCalculator.component';
import { Grade } from 'src/app/models/grade.interface';

@Component({
    templateUrl: './grades-page.component.html',
    styleUrls: ['./grades-page.component.css'],
    imports: [
        CommonModule,
        IonicModule,
        GradeCalculatorComponent,
        GradeComponent
    ],
})
export class GradesPageComponent {
    successes = 0;
    mistakes = 0;
    notAnswered = 0;
    grade = 0;
    constructor() { }

    calculateGrade(grade: Grade) {
        this.successes = grade.successes;
        this.mistakes = grade.mistakes;
        this.notAnswered = grade.notAnswered;
        this.grade = grade.grade ?? 0;
    }

}
