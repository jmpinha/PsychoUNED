import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCheckboxChange, MatCheckboxModule } from '@angular/material/checkbox';
import { IonicModule } from '@ionic/angular';
import { QuestionsAnswer } from 'src/app/models/QuestionAnswer.interface';
import { GlobalsService } from 'src/app/services/globals.service';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'test-question',
  templateUrl: './test-question.component.html',
  styleUrls: ['./test-question.component.scss'],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MatCheckboxModule,
    MatIconModule
  ],
})
export class QuestionComponent {
  @Output() questionAnswerChange =  new EventEmitter<boolean>();
  @Output() result2 =  new EventEmitter<boolean|undefined>();
  @Input() numberQuestion=0;
  @Input() viewButton=false;
    @Input() questionAnswer :QuestionsAnswer= {
    question: '',
    answers: [],
    isConfirmed: false,
    checked: false
  };
  // @Input() acceptOneClick=false;
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
