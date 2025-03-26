import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SubjectsPage } from './subjects-page.component';

describe('SubjectsPage', () => {
  let component: SubjectsPage;
  let fixture: ComponentFixture<SubjectsPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(SubjectsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
