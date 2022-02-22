import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaginatedDataGridComponent } from './paginated-data-grid.component';

describe('PaginatedDataGridComponent', () => {
  let component: PaginatedDataGridComponent;
  let fixture: ComponentFixture<PaginatedDataGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaginatedDataGridComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaginatedDataGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
