import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCheckboxChange, MatCheckboxModule } from '@angular/material/checkbox';
import { TestsPageRoutingModule } from 'src/app/pages/tests/tests-routing.module';
import { IonicModule } from '@ionic/angular';
import { QuestionsAnswer } from 'src/app/models/QuestionAnswer';
import { GlobalsService } from 'src/app/services/Globals.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css'],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TestsPageRoutingModule,
    MatCheckboxModule
  ],
})
export class QuestionComponent {
  @Output() questionAnswerChange =  new EventEmitter<boolean>();
  @Output() result2 =  new EventEmitter<boolean|undefined>();
  @Input() questionAnswer :QuestionsAnswer= {
    question: '',
    answers: [],
    isConfirmed: false,
    checked: false
  };
  constructor(public utils: GlobalsService) { }


  onCheckboxChange(event:MatCheckboxChange ,selectedIndex: number, isCorrect?: boolean) {
    this.questionAnswer.answers.forEach((item, index) => {
      item.checked = index === selectedIndex;
    });
    this.questionAnswerChange.emit(event.checked);
    if (event.checked) {
      this.result2.emit(isCorrect??false);
    }else{
      this.result2.emit(undefined);
    }
  }
}
