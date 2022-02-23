import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from './components/button/button.component';
import { HttpClientModule } from '@angular/common/http';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { PaginatedDataGridComponent } from './components/paginated-data-grid/paginated-data-grid.component';
import { LibraryPageComponent } from './library-page/library-page.component';
import { DividerComponent } from './components/divider/divider.component';
import { DividerContentComponent } from './components/divider-content/divider-content.component';

@NgModule({
  declarations: [
    ButtonComponent,
    PaginatedDataGridComponent,
    LibraryPageComponent,
    DividerComponent,
    DividerContentComponent,
  ],
  imports: [CommonModule, HttpClientModule, AngularSvgIconModule.forRoot()],
  exports: [
    ButtonComponent,
    PaginatedDataGridComponent,
    LibraryPageComponent,
    DividerComponent,
  ],
})
export class SharedModule {}
