import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagerPageComponent } from './manager/manager-page/manager-page.component';
import { LibraryPageComponent } from './shared/library-page/library-page.component';

const routes: Routes = [
  {
    path: 'lib',
    component: LibraryPageComponent,
  },
  {
    path: 'manager',
    component: ManagerPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
