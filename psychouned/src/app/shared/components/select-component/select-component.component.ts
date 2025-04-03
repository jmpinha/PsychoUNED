import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, input } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { IonicModule } from '@ionic/angular';

@Component({
    selector: 'app-select-component',
    templateUrl: './select-component.component.html',
    styleUrls: ['./select-component.component.css'],
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        MatSelectModule,
        ReactiveFormsModule,
    ],
})
export class SelectComponentComponent {

     optionForm = input(new FormControl());
     options: any = input([]);
     label = input('');
    @Output() optionSelected= new EventEmitter<any>();
    constructor() { }
    changeOptions(event:any){
        this.optionSelected.emit(event.value);
    }
}
