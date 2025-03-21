import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AddDataPageComponent } from './add-data.page';

describe('AddDataPage', () => {
  let component: AddDataPageComponent;
  let fixture: ComponentFixture<AddDataPageComponent>;

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDataPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
