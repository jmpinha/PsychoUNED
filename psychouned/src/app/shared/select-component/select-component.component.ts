import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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

    @Input() optionForm = new FormControl();
    @Input() options: any = [];
    @Input() label = '';
    @Output() optionSelected= new EventEmitter<any>();
    constructor() { }
    changeOptions(event:any){
        this.optionSelected.emit(event.value);
    }
}
