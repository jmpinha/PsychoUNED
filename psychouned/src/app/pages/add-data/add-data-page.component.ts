import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonContent, IonHeader, IonTitle, IonToolbar,IonButton } from '@ionic/angular/standalone';
import { InputComponentComponent } from 'src/app/components/common/input-component/input-component.component';

@Component({
  templateUrl: './add-data-page.component.html',
  styleUrls: ['./add-data-page.component.scss'],
  standalone: true,
  imports: [IonContent, IonHeader, IonTitle, IonToolbar,IonButton, CommonModule, FormsModule]
})
export class AddDataPageComponent {

  constructor() { }

}
