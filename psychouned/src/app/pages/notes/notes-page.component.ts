import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MenuNames } from 'src/app/models/Names';

import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-notes',
  templateUrl: './notes-page.component.html',
  styleUrls: ['./notes-page.component.scss'],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule
  ],
})
export class NotesPageComponent {
  subjectsNames = MenuNames;
  constructor() { }

}
