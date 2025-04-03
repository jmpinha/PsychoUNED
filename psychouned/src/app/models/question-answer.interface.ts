import { Answer } from 'src/app/models/Answer';


export interface QuestionsAnswer {
    question: string;
    answers: Answer[];
    isConfirmed: boolean;
    checked: boolean;
    isSuccess?: boolean;
    result?: boolean;
}
