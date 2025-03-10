/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InitTestComponent } from './test-init.component';

describe('InitTestComponent', () => {
  let component: InitTestComponent;
  let fixture: ComponentFixture<InitTestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InitTestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InitTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
