import { Answer } from "./Answer";

export interface QuestionsAnswer {
    question: string;
    answers: Answer[];
    isConfirmed: boolean;
    checked: boolean;
    isSuccess?: boolean;
    result?: boolean;
}