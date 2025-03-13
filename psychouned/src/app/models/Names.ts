export enum MenuNames {
    SUBJECTS = 'Asignaturas',
    TESTS = 'Tests',
    ADD_DATA = 'Añadir datos',
    NOTES = 'Apuntes',
    FORUM = 'Foro',
    GRADES = 'Calculadora de notas',
}

export enum Courses {
    FIRST = '1º',
    SECOND = '2º',
    THIRD = '3º',
    FOURTH = '4º',
}
export enum Semester {
    FIRST = '1º',
    SECOND = '2º',
}
export enum SubjectsName {
    RESEARCH_FUNDAMENTALS = 'Fundamentos de la investigación',
    PSYCHOBIOLOGY = 'Psicobiología',
    DATA_ANALYSIS = 'Análisis de datos',
    MOTIVATION = 'Psicología de la motivación',
    SOCIAL = 'Psicología social',


    EMOTION = 'Fundamentos de la emoción',
    ATENTION = 'Psicología de la atención',
    LEARNING = 'Psicología del aprendizaje',
    HISTORY = 'Historia de la psicología',
}
export interface PartialExamns{
    week: number;
    weekDescription: string;
}
export enum DateExamsEnum {
    FIRST_WEEK = 'Primera semana',
    SECOND_WEEK = 'Segunda semana',
    SEPTEMBER= 'Septiembre',
}
export class DateExams{
    static exams:PartialExamns[]=[
        {week:1,weekDescription:DateExamsEnum.FIRST_WEEK},
        {week:2,weekDescription:DateExamsEnum.SECOND_WEEK},
        {week:3,weekDescription:DateExamsEnum.SEPTEMBER},
    ]
}
