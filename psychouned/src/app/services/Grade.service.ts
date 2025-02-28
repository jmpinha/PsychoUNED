import { Injectable } from '@angular/core';
import { GlobalsService } from './Globals.service';

@Injectable({
  providedIn: 'root'
})
export class GradeService {

  constructor(private globals: GlobalsService) { }
  calculateGrade(answersSuccess: number, answerMistakes: number, totalAnswers: number, totalOptions:number): number {
    let result = totalOptions===2?1:totalOptions===3?2:3;
    return  this.globals.roundUpTwoDecimals(((answersSuccess - answerMistakes/result)/totalAnswers)*10);
  }
  calculateRemainingQuestion(answersSuccess: number, answerMistakes: number, totalAnswers: number): number {
    console.log(answersSuccess, answerMistakes, totalAnswers);
    return totalAnswers- (answersSuccess + answerMistakes);
  }
}
