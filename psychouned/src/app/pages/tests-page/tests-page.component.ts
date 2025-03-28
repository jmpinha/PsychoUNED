import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, signal } from '@angular/core';
import { QuestionComponent } from "../../components/test-components/test-question/test-question.component";
import { Answer } from 'src/app/models/Answer';
import { QuestionsAnswer } from 'src/app/models/QuestionAnswer.interface';
import { InitTestComponent } from 'src/app/components/test-components/test-init/test-init.component';
import { IonButton,IonFooter,IonItemDivider,IonItem,IonList,IonContent,IonTitle,IonMenuButton,IonButtons,IonToolbar,IonHeader} from '@ionic/angular/standalone';
import { GradeComponent } from 'src/app/components/grade-components/grade/grade.component';
import { TestSelectComponent } from 'src/app/components/test-components/test-select/test-select.component';
import { GlobalsService } from 'src/app/core/services/globals.service';
import { GradeService } from 'src/app/core/services/Grade.service';


@Component({
    templateUrl: './tests-page.component.html',
    styleUrls: ['./tests-page.component.scss'],
    imports: [
        CommonModule,
        IonButton,
        IonFooter,
        IonItemDivider,
        IonItem,
        IonList,
        IonTitle,
        IonContent,
        IonMenuButton,
        IonButtons,
        IonToolbar,
        IonHeader,
        QuestionComponent,
        GradeComponent,
        InitTestComponent,
        TestSelectComponent
    ],
})
export class TestsPageComponent {

    questionMock = "El valor relacional:";
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

    question2Mock = "¿Cuáles de los siguientes componentes forman parte de una "
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

subjectId=signal(0);
    oneTouch = false;
    viewGrade = false;
    viewAllQuestions = false;
    saveInit = false;
    testStarted = false;
    questionsAnswer: QuestionsAnswer[] = [
        { question: this.questionMock, answers: this.answersMock, isConfirmed: false, checked: false },
        { question: this.question2Mock, answers: this.answers2Mock, isConfirmed: false, checked: false }];
    correctedListAnswers = this.fillCorrectedAnswers();
    nQuestions = this.questionsAnswer.length;
    positionNow = 0;
    result?: boolean;
    totalOptions = this.questionsAnswer[0].answers.length;
    idExam=0;
    get currentQuestionAnswer(): QuestionsAnswer {
        return this.questionsAnswer[this.positionNow];
    }
    get successes(): number {
        return this.questionsAnswer.filter((item) => item.isSuccess === true).length;
    }
    get mistakes(): number {
        return this.questionsAnswer.filter((item) => item.isSuccess === false).length;
    }
    get notAnswered(): number {
        return this.questionsAnswer.filter((item) => item.checked !== true && item.isSuccess !== true).length;
    }
    resultadoNota = 0;
    constructor(private globalsService: GlobalsService,
        private gradeService: GradeService) { }


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

        this.resultadoNota = this.gradeService.calculateGrade(this.successes ?? 0, this.mistakes ?? 0, this.nQuestions ?? 0, this.totalOptions);

    }
    confirmSelectionWithIndex(i:number,result:boolean) {
        if (this.questionsAnswer[i].checked) {
            this.questionsAnswer[i].isConfirmed = true;
            this.questionsAnswer[i].isSuccess = result;

        } else {
            this.globalsService.showToast("Por favor, seleccione una respuesta");
        }

        this.resultadoNota = this.gradeService.calculateGrade(this.successes ?? 0, this.mistakes ?? 0, this.nQuestions ?? 0, this.totalOptions);

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
    changeCheckedAllQuestions(checked: boolean,index: number) {
        this.questionsAnswer[index].checked = checked;
    }
    changeResult($event?: boolean){
        this.result=$event;
        if (this.oneTouch) {
            this.confirmSelection();
        }
    }
    changeResultWithIndex( index:number,$event?: boolean) {
        if (this.oneTouch) {
            this.confirmSelectionWithIndex(index,$event??false);
        }
        this.questionsAnswer[index].result = $event;
    }
    changeOneTouch(event: boolean) {
        this.oneTouch = event;
    }
    changeViewGrade(event: boolean) {
        this.viewGrade = event;
    }
    changeViewAllQuestions(event: boolean) {
        this.viewAllQuestions = event;
    }
    changeSaveInit(event: boolean) {
        this.saveInit = event;
    }
    initTest() {
        console.log(this.oneTouch)
        console.log(this.viewGrade)
        console.log(this.viewAllQuestions)
        this.testStarted = true;
    }
    getExamId(event: number) {
        this.idExam=event;
    }
}
