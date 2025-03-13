import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonContent, IonHeader, IonTitle, IonToolbar,IonButton } from '@ionic/angular/standalone';
import { InputComponentComponent } from 'src/app/components/common/input-component/input-component.component';

@Component({
  selector: 'app-add-data',
  templateUrl: './add-data.page.html',
  styleUrls: ['./add-data.page.scss'],
  standalone: true,
  imports: [IonContent, IonHeader, IonTitle, IonToolbar,IonButton, CommonModule, FormsModule,InputComponentComponent]
})
export class AddDataPage implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
