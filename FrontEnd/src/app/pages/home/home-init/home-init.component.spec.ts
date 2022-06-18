import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeInitComponent } from './home-init.component';

describe('HomeInitComponent', () => {
  let component: HomeInitComponent;
  let fixture: ComponentFixture<HomeInitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeInitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeInitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
