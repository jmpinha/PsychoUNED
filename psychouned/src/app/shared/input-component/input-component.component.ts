import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { IonicModule } from '@ionic/angular';

@Component({
    selector: 'app-input-component',
    templateUrl: './input-component.component.html',
    styleUrls: ['./input-component.component.css'],

    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        MatInputModule,
        MatIconModule,
        ReactiveFormsModule
    ],
})
export class InputComponentComponent implements OnChanges {
    @Input() optionForm= new FormControl();
    @Input() label='';
    @Output() optionResponse= new EventEmitter<number>();;
    get option() {
        return Number(this.optionForm.value);
    }
    ngOnChanges(changes: SimpleChanges) {
        if (changes['optionsForm']) {
          console.log('Cambio detectado en mensaje:', changes['mensaje'].currentValue);
        }
      }
    constructor() { }

    validateNumber(event: any) {
        let value = event.target.value.replace(/[^0-9]/g, ''); // Elimina letras y caracteres no numéricos
        event.target.value = value;
        if (event.target.value[0] === '0') {
            event.target.value = value.slice(1);
        }
    }
    inputBlur(){
        if(this.option){
            this.optionResponse.emit(this.option);
        }
    }
}
