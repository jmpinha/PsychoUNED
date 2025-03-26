import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TestsPageComponent } from './tests-page.component';

describe('TestsPage', () => {
  let component: TestsPageComponent;
  let fixture: ComponentFixture<TestsPageComponent>;

  beforeEach(() => {
    fixture = TestBed.createComponent(TestsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
