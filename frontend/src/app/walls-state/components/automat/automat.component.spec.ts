import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AutomatComponent } from './automat.component';

describe('AutomatComponent', () => {
  let component: AutomatComponent;
  let fixture: ComponentFixture<AutomatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AutomatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AutomatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
