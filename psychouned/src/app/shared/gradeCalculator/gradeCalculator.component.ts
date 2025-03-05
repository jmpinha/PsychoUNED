import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroupDirective, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TestsPageRoutingModule } from 'src/app/pages/tests/tests-routing.module';
import { MatInputModule } from '@angular/material/input';
import { GlobalsService } from 'src/app/services/Globals.service';
import { Grade } from 'src/app/models/Grade';
import { GradeService } from 'src/app/services/Grade.service';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { InputComponentComponent } from '../input-component/input-component.component';
import {MatSelectModule} from '@angular/material/select';

@Component({
    selector: 'app-grade-calculator',
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
        InputComponentComponent
    ],
})
export class GradeCalculatorComponent {
    @Output() gradeOut = new EventEmitter<Grade>();
    resultGrade = 0;
    totalQuestionsForm = new FormControl(0, [Validators.required, Validators.min(10), Validators.max(50)]);
    totalOptionsForm = new FormControl(2, [Validators.required, Validators.min(2), Validators.max(5)]);
    successesForm = new FormControl(0, [Validators.min(0), Validators.max(99)]);
    mistakesForm = new FormControl(0, [Validators.min(0), Validators.max(99)]);
    answersBlankForm = new FormControl(0, [Validators.min(0), Validators.max(99)]);
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
        private globalsService: GlobalsService
    ) { }

    submit() {
        console.log('preguntas totales: ', this.totalQuestions);
        console.log('opciones totales: ', this.totalOptions);
        console.log('Aciertos: ', this.successes);
        console.log('Errores: ', this.mistakes);
        console.log('En blanco: ', this.answersBlank);

        if (this.validateOptions(this.totalOptions) && this.totalQuestions) {
            this.changeValuesWith0();
            this.calculateGrade();
        } else if (this.validateQuestionsAndOptions(this.totalOptions, this.totalQuestions)) {
            this.globalsService.showToast('Se necesita un total de preguntas y de opciones');
        } else if (!this.validateOptions(this.totalOptions)) {
            this.globalsService.showToast('El total de opciones debe ser entre 2 y 5');
        }
    }

    validateOptions(totalOptions: any): boolean {
        if (totalOptions >= 2 && totalOptions <= 5) {
            return true;
        }

        return false;
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
        console.log(this.totalQuestions)
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
