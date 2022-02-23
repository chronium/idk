import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerPageComponent } from './manager-page/manager-page.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ManagerPageComponent],
  imports: [CommonModule, SharedModule],
  exports: [ManagerPageComponent],
})
export class ManagerModule {}
