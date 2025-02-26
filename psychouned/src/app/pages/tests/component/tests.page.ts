import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TestsPageRoutingModule } from '../tests-routing.module';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { addIcons } from 'ionicons';
import { checkmarkCircle, closeCircle } from 'ionicons/icons';
import { QuestionComponent } from "../../../shared/question/question.component";
import { Answer } from 'src/app/models/Answer';

@Component({
  selector: 'app-tests',
  templateUrl: './tests.page.html',
  styleUrls: ['./tests.page.scss'],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TestsPageRoutingModule,
    MatCheckboxModule,
    QuestionComponent
  ],
})
export class TestsPage implements OnInit {

  isConfirmed = false; // Variable para bloquear checkboxes y cambiar color
  question = "1. El valor relacional:";
  answers: Answer[] = [
    {
      aswer: "Se considera un motivo social universal, ya que necesitamos a los otros para entender el mundo que nos rodea.",
      checked: false
    },
    {
      aswer: "Se considera un motivo social universal, ya que necesitamos a " +
        "los otros para sentir que lo que hacemos tiene relación con lo que conseguimos.",
      checked: false
    },
    {
      aswer: "No se considera un motivo social universal.",
      checked: false,
      answerCorrect: true
    }
  ];
  constructor() {
    addIcons({ checkmarkCircle, closeCircle });
  }

  ngOnInit() {
  }

  onCheckboxChange(selectedIndex: number) {
    this.answers.forEach((item, index) => {
      item.checked = index === selectedIndex;
    });
  }
  confirmSelection() {
    if (this.answers.find(answer => answer.checked === true)) {

      this.isConfirmed = true;
      console.log(this.isConfirmed);
    }
  }
}
