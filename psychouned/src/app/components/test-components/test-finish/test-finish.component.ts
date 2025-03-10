import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { IonicModule } from '@ionic/angular';
import { GradeComponent } from '../../grade-components/grade/grade.component';

@Component({
    selector: 'app-test-finish',
    templateUrl: './test-finish.component.html',
    styleUrls: ['./test-finish.component.scss'],

    imports: [
        CommonModule,
        IonicModule,
        GradeComponent
    ]
})
export class TestFinishComponent {

    constructor() { }


}
