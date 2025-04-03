import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { MatInputModule } from '@angular/material/input';
import { Grade } from 'src/app/models/grade.interface';
import { MatIconModule } from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';import { GradeService } from 'src/app/core/services/Grade.service';
import { GlobalsService } from 'src/app/core/services/globals.service';
import { ThemeService } from 'src/app/core/services/theme.service';
import { InputComponentComponent } from 'src/app/shared/components/input-component/input-component.component';
import { SelectComponentComponent } from 'src/app/shared/components/select-component/select-component.component';

@Component({
    selector: 'grade-calculator',
    templateUrl: './gradeCalculator.component.html',
    styleUrls: ['./gradeCalculator.component.css'],
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        MatInputModule,
        MatSelectModule,
        MatIconModule,
        ReactiveFormsModule,
        InputComponentComponent,
        SelectComponentComponent
    ],
})
export class GradeCalculatorComponent {
    @Output() gradeOut = new EventEmitter<Grade>();
    resultGrade = 0;
    totalQuestionsForm = new FormControl(0, [Validators.required, Validators.min(10), Validators.max(50)]);
    totalOptionsForm = new FormControl(2);
    successesForm = new FormControl(0, [Validators.min(0), Validators.max(99)]);
    mistakesForm = new FormControl(0, [Validators.min(0), Validators.max(99)]);
    answersBlankForm = new FormControl(0, [Validators.min(0), Validators.max(99)]);
    options=[2,3,4,5]
    get totalOptions() {
        return Number(this.totalOptionsForm.value);
    }
    get totalQuestions() {
        return Number(this.totalQuestionsForm.value);
    }
    get successes() {
        return Number(this.successesForm.value) ?? undefined;
    }
    get mistakes() {
        return Number(this.mistakesForm.value) ?? undefined;
    }
    get answersBlank() {
        return Number(this.answersBlankForm.value);
    }
    constructor(private gradeService: GradeService,
        private globalsService: GlobalsService,
        private themeService: ThemeService
    ) { }

    submit() {
        if (this.totalQuestions) {
            this.changeValuesWith0();
            this.calculateGrade();
        } else if (this.validateQuestionsAndOptions(this.totalOptions, this.totalQuestions)) {
            this.globalsService.showToast('Se necesita un total de preguntas y de opciones');
        }
    }
    validateQuestionsAndOptions(totalOptions: number, totalQuestions: number): boolean {
        if (totalOptions !== 0 && totalQuestions !== 0) {
            return false;
        }

        return true;
    }
    correctedNegativeValues() {
        if (this.successes < 0) {
            this.successesForm.setValue(0);
        }
        if (this.mistakes < 0) {
            this.mistakesForm.setValue(0);
        }
        if (this.answersBlank < 0) {
            this.answersBlankForm.setValue(0);
        }
    }
    changeOptions(event: any) {
        this.totalOptionsForm.setValue(event);
    }
    changeQuestion(event: any) {
        this.totalQuestionsForm.setValue(event);
    }
    changeMistakes(event: any) {
        this.mistakesForm.setValue(event);
    }
    changeSuccess(event: any) {
        this.successesForm.setValue(event);
    }
    changeAnswerBlank(event: any) {
        this.answersBlankForm.setValue(event);
    }
    private changeValuesWith0() {
        if (!this.answersBlank || this.gradeService.calculateRemainingQuestion(this.successes ?? 0, this.mistakes ?? 0, this.totalQuestions) !== this.answersBlank) {
            this.answersBlankForm.setValue(this.gradeService.calculateRemainingQuestion(this.successes ?? 0, this.mistakes ?? 0, this.totalQuestions));
        }
        if (!this.mistakes) {
            this.mistakesForm.setValue(this.gradeService.calculateRemainingQuestion(this.successes ?? 0, this.answersBlank ?? 0, this.totalQuestions));
        }
        if (!this.successes) {
            this.successesForm.setValue(this.gradeService.calculateRemainingQuestion(this.mistakes ?? 0, this.answersBlank ?? 0, this.totalQuestions));
        }
    }
    private calculateGrade() {
        if (this.answersBlank >= 0 && this.mistakes >= 0 && this.successes >= 0) {
            this.resultGrade = this.gradeService.calculateGrade(this.successes ?? 0, this.mistakes ?? 0, this.totalQuestions ?? 0, this.totalOptions);
            let grade: Grade = {
                successes: this.successes ?? 0,
                mistakes: this.mistakes ?? 0,
                notAnswered: this.answersBlank ?? 0,
                grade: this.resultGrade
            };
            this.gradeOut.emit(grade);
        } else {
            this.correctedNegativeValues();
            this.globalsService.showToast('No puede haber mas preguntas que el total de preguntas');
        }
    }
}
