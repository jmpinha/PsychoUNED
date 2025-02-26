import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MenuNames } from 'src/app/models/Names';

import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { NotesPageRoutingModule } from '../notes-routing.module';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.page.html',
  styleUrls: ['./notes.page.scss'],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    NotesPageRoutingModule
  ],
})
export class NotesPage {
  subjectsNames = MenuNames;
  constructor() { }

}
