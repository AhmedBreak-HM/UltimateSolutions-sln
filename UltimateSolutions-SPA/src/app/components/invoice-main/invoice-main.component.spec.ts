import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceMainComponent } from './invoice-main.component';

describe('InvoiceMainComponent', () => {
  let component: InvoiceMainComponent;
  let fixture: ComponentFixture<InvoiceMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvoiceMainComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InvoiceMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
