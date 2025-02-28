import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TestsPageRoutingModule } from 'src/app/pages/tests/tests-routing.module';
import { MatInputModule } from '@angular/material/input';
import { GlobalsService } from 'src/app/services/Globals.service';
import { Grade } from 'src/app/models/Grade';
import { GradeService } from 'src/app/services/Grade.service';
@Component({
  selector: 'app-grade-calculator',
  templateUrl: './gradeCalculator.component.html',
  styleUrls: ['./gradeCalculator.component.css'],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MatInputModule,
    ReactiveFormsModule
  ],
})
export class GradeCalculatorComponent {
  @Output() gradeOut = new EventEmitter<Grade>();
  resultadoNota = 0;
  totalAnswersForm = new FormControl(0, [Validators.min(10), Validators.max(50)]);
  totalOptionsForm = new FormControl(0, [Validators.min(2), Validators.max(4)]);
  successesForm = new FormControl(0, [Validators.min(0), Validators.max(99)]);
  mistakesForm = new FormControl(0, [Validators.min(0), Validators.max(99)]);
  answersBlankForm = new FormControl(0, [Validators.min(0), Validators.max(99)]);
  get totalOptions() {
    return Number(this.totalOptionsForm.value);
  }
  get totalAnswers() {
    return Number(this.totalAnswersForm.value);
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
  constructor(private gradeService:GradeService) { }

  submit() {
    if (this.totalOptions && this.totalAnswers) {
      if (!this.answersBlank||this.gradeService.calculateRemainingQuestion(this.successes ?? 0, this.mistakes ?? 0, this.totalAnswers)!==this.answersBlank) {
        console.log('Calculando preguntas en blanco');
        this.answersBlankForm.setValue(this.gradeService.calculateRemainingQuestion(this.successes ?? 0, this.mistakes ?? 0, this.totalAnswers));
      }
      if (!this.mistakes) {
        this.mistakesForm.setValue(this.gradeService.calculateRemainingQuestion(this.successes ?? 0, this.answersBlank ?? 0, this.totalAnswers));
      }
      if (!this.successes) {
        this.successesForm.setValue(this.gradeService.calculateRemainingQuestion(this.mistakes ?? 0, this.answersBlank ?? 0, this.totalAnswers));
      }
      this.resultadoNota=this.gradeService.calculateGrade(this.successes ?? 0, this.mistakes ?? 0, this.totalAnswers ?? 0, this.totalOptions);
      let grade: Grade = {
        successes: this.successes ?? 0,
        mistakes: this.mistakes ?? 0,
        notAnswered: this.answersBlank ?? 0,
        grade: this.resultadoNota
      }
      this.gradeOut.emit(grade);
    }
  }
  validateNumber(event: any) {
    let value = event.target.value.replace(/[^0-9]/g, ''); // Elimina letras y caracteres no numéricos
    event.target.value = value;
    if(event.target.value[0]==='0'){
      event.target.value = value.slice(1);
    }
  }
}
