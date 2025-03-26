import { animate, style, transition, trigger } from '@angular/animations';
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, input,  OnInit, output, Output } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { IonicModule } from '@ionic/angular';
import { DateExams, Semester } from 'src/app/models/Names';

@Component({
    selector: 'test-select',
    templateUrl: './test-select.component.html',
    styleUrls: ['./test-select.component.scss'],
    imports: [
        CommonModule,
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
export class TestSelectComponent implements OnInit {
    subjectId = input.required<number>();
    examId = output<number>()
    years = [2024, 2023, 2022, 2021, 2020, 2019, 2018, 2017, 2016, 2015,];
    semesters = [{ semesterDescription: Semester.FIRST, semester: 1 },
    { semesterDescription: Semester.SECOND, semester: 2 }];
    dateExams = DateExams.exams;
    constructor() { }
    ngOnInit(): void {
        this.years.sort();
    }
    changeYear(event: any) {
        console.log(event);
    }
    selectDateExam() {
        this.examId.emit(1);
    }
}
