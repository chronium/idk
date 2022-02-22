import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from './components/button/button.component';
import { HttpClientModule } from '@angular/common/http';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { PaginatedDataGridComponent } from './components/paginated-data-grid/paginated-data-grid.component';

@NgModule({
  declarations: [ButtonComponent, PaginatedDataGridComponent],
  imports: [CommonModule, HttpClientModule, AngularSvgIconModule.forRoot()],
  exports: [ButtonComponent, PaginatedDataGridComponent],
})
export class SharedModule {}
