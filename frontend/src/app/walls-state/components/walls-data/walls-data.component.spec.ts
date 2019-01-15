import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WallsDataComponent } from './walls-data.component';

describe('WallsDataComponent', () => {
  let component: WallsDataComponent;
  let fixture: ComponentFixture<WallsDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WallsDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WallsDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
