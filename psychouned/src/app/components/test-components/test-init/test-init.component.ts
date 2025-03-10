import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { TestsPageRoutingModule } from 'src/app/pages/tests/tests-routing.module';
import { IonicModule } from '@ionic/angular';
import { IonToggle } from '@ionic/angular/standalone';

@Component({
	selector: 'app-test-init',
	templateUrl: './test-init.component.html',
	styleUrls: ['./test-init.component.scss'],
	imports: [
		CommonModule,
		FormsModule,
		IonicModule,
		TestsPageRoutingModule,
		MatCheckboxModule,
		ReactiveFormsModule,
	],
})
export class InitTestComponent {

	@Output() oneTouchOut = new EventEmitter<boolean>();
	@Output() viewGradeOut = new EventEmitter<boolean>();
	@Output() viewAllQuestionsOut = new EventEmitter<boolean>();
	@Output() saveInit = new EventEmitter<boolean>();
	@Input() oneTouch = false;
	@Input() viewGrade = false;
	@Input() viewAllQuestions = false;
	get getLblOneTouch() {
		return this.oneTouch ? 'Responder en un toque' : 'Corregir con el botón'
	}
	get getLblViewGrade() {
		return this.viewGrade ? 'Mostrar la nota durante el test' : 'Ocultar la nota durante el test'
	}
	get getLblViewAllQuestions() {
		return this.viewAllQuestions ? 'Ver todas las preguntas' : 'Ver solo una pregunta'
	}
	constructor() { }
	changeOneTouch(event: any) {
		this.oneTouch = event.detail.checked;
		this.oneTouchOut.emit(this.oneTouch);
	}
	changeViewGrade(event: any) {
		this.viewGrade = event.detail.checked;
		this.viewGradeOut.emit(this.viewGrade);
	}
	changeViewAllQuestions(event: any) {
		this.viewAllQuestions = event.detail.checked;
		this.viewAllQuestionsOut.emit(this.viewAllQuestions);
	}
	onCheckboxChange(event: any) {
		this.saveInit.emit(event);
	}
}
