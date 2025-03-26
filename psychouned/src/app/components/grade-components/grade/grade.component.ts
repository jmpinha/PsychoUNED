import { CommonModule } from '@angular/common';
import { Component, input, Input } from '@angular/core';
import { IonicModule } from '@ionic/angular';

@Component({
  selector: 'grade',
  templateUrl: './grade.component.html',
  styleUrls: ['./grade.component.css'],

  imports: [
    CommonModule,
    IonicModule,
  ]
})
export class GradeComponent {

  successes = input<number>();
  mistakes = input<number>();
  notAnswered = input<number>();
  viewGrade = input<boolean>(false);
  grade = input<number>();

  constructor() { }

}
