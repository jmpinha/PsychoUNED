import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TestsPageRoutingModule } from '../tests-routing.module';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { addIcons } from 'ionicons';
import { checkmarkCircle, closeCircle } from 'ionicons/icons';
import { QuestionComponent } from "../../../shared/question/question.component";
import { Answer } from 'src/app/models/Answer';
import { QuestionsAnswer } from 'src/app/models/QuestionAnswer';
import { GlobalsService } from 'src/app/services/Globals.service';
import { GradeComponent } from 'src/app/shared/grade/grade.component';
import { GradeService } from 'src/app/services/Grade.service';

@Component({
  selector: 'app-tests',
  templateUrl: './tests.page.html',
  styleUrls: ['./tests.page.scss'],
  imports: [
    CommonModule,
    IonicModule,
    QuestionComponent,
    GradeComponent
  ],
})
export class TestsPage {

  questionMock = "1. El valor relacional:";
  answersMock: Answer[] = [
    {
      answer: "Se considera un motivo social universal, ya que necesitamos a los otros para entender el mundo que nos rodea.",
      checked: false
    },
    {
      answer: "Se considera un motivo social universal, ya que necesitamos a " +
        "los otros para sentir que lo que hacemos tiene relación con lo que conseguimos.",
      checked: false
    },
    {
      answer: "No se considera un motivo social universal.",
      checked: false,
      answerCorrect: true
    }
  ];

  question2Mock = "2. ¿Cuáles de los siguientes componentes forman parte de una "
    + " caja de Skinner para ratas según el vídeo sobre `Programas de reforzamiento`?:";
  answers2Mock: Answer[] = [
    {
      answer: "Se considera un motivo social universal, ya que necesitamos a los otros para entender el mundo que nos rodea.22",
      checked: false
    },
    {
      answer: "Se considera un motivo social universal, ya que necesitamos a " +
        "los otros para sentir que lo que hacemos tiene relación con lo que conseguimos.22",
      checked: false
    },
    {
      answer: "No se considera un motivo social universal.2",
      checked: false,
      answerCorrect: true
    }
  ];


  checkedButton= true;
  questionsAnswer: QuestionsAnswer[] = [
    { question: this.questionMock, answers: this.answersMock, isConfirmed: false, checked: false },
    { question: this.question2Mock, answers: this.answers2Mock, isConfirmed: false, checked: false }];
  correctedListAnswers = this.fillCorrectedAnswers();
  nQuestions = this.questionsAnswer.length;
  positionNow = 0;
  result?: boolean;
  totalOptions=this.questionsAnswer[0].answers.length;
  get currentQuestionAnswer(): QuestionsAnswer {
    return this.questionsAnswer[this.positionNow];
  }
  get successes(): number {
    return this.questionsAnswer.filter((item) => item.isSuccess===true).length;
  }
  get mistakes(): number {
    return this.questionsAnswer.filter((item) => item.isSuccess===false).length;
  }
  get notAnswered(): number {
    return this.questionsAnswer.filter((item) => item.checked !== true && item.isSuccess !== true).length;
  }
  resultadoNota = 0;
  constructor(private globalsService: GlobalsService,
    private gradeService:GradeService) {}


  onCheckboxChange(selectedIndex: number) {
    this.answersMock.forEach((item, index) => {
      item.checked = index === selectedIndex;
    });
  }
  confirmSelection() {
    if (this.currentQuestionAnswer.checked) {
      this.currentQuestionAnswer.isConfirmed = true;
      this.currentQuestionAnswer.isSuccess = this.result;
      
    } else {
      this.globalsService.showToast("Por favor, seleccione una respuesta");
    }
    
    this.resultadoNota=this.gradeService.calculateGrade(this.successes ?? 0, this.mistakes ?? 0, this.nQuestions ?? 0, this.totalOptions);
  }
  next() {
    this.positionNow++;
  }
  back() {
    this.positionNow--;
  }
  fillCorrectedAnswers(): boolean[] {
    let correctedAnswers: boolean[] = [];
    this.answersMock.forEach(() => {
      correctedAnswers.push(false);
    });

    return correctedAnswers;

  }
  changeChecked(checked: boolean) {
    this.currentQuestionAnswer.checked = checked;
  }
  changeResult($event?: boolean) {
    this.result = $event;
  }
}
