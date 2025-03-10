import { Injectable } from '@angular/core';
import { GlobalsService } from './globals.service';

@Injectable({
    providedIn: 'root'
})
export class GradeService {

    constructor(private globals: GlobalsService) { }
    calculateGrade(answersSuccess: number, answerMistakes: number, totalAnswers: number, totalOptions: number): number {
        let result = 0;

        switch (totalOptions) {
            case 2:
                result = 1;
                break;
            case 3:
                result = 2;
                break;
            case 4:
                result = 3;
                break;
            default:
                result = 4;
        }
        return this.globals.roundUpTwoDecimals(((answersSuccess - answerMistakes / result) / totalAnswers) * 10);
    }
    calculateRemainingQuestion(answersSuccess: number, answerMistakes: number, totalAnswers: number): number {
        return totalAnswers - (answersSuccess + answerMistakes);
    }
}
