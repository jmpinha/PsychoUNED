import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { TestsPageRoutingModule } from 'src/app/pages/tests/tests-routing.module';
import { IonicModule } from '@ionic/angular';
import { Answer } from 'src/app/models/Answer';
import { UtilsService } from '../Utils.service';

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
export class QuestionComponent implements OnInit {
  @Input() question = '';
  @Input() answers: Answer[] = [];
  @Input() isConfirmed = false;
  constructor(public utils: UtilsService) { }

  ngOnInit() {
  }

  onCheckboxChange(selectedIndex: number) {
    this.answers.forEach((item, index) => {
      item.checked = index === selectedIndex;
    });
  }
}
