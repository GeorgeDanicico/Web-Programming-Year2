import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeleteDataComponent } from './delete-data/delete-data.component';
import { Service } from './genericservice.service';
import { InsertDataComponent } from './insert-data/insert-data.component';
import { MainPageComponent } from './main-page/main-page.component';
import { ShowComponent } from './show/show.component';
import { UpdateDataComponent } from './update-data/update-data.component';

const routes: Routes = [{
    path: '', component: MainPageComponent,
  },
  {
    path: 'insert', component: InsertDataComponent
  },
  {
    path: 'delete', component: DeleteDataComponent
  },
  {
    path: 'update', component: UpdateDataComponent
  },
  {
    path: 'show', component: ShowComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [Service]
})
export class AppRoutingModule { }
