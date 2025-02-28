import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { IonicModule } from '@ionic/angular';

@Component({
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrls: ['./grade.component.css'],

  imports: [
    CommonModule,
    IonicModule,
  ]
})
export class GradeComponent {

  @Input() successes =0;
  @Input() mistakes =0;
  @Input() notAnswered =0;
  @Input() grade =0;
  constructor() { }

}
