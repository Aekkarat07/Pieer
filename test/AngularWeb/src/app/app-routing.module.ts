import { NgModule } from '@angular/core'; //import คือการเลือกไลบารีมาใช้ที่ป็นตัวระบุเส้นทาง
import { CommonModule } from '@angular/common';
import { RouterModule,Routes } from'@angular/router';

import { HomeComponent } from'./home/home.component';
const routes : Routes=[
{path: '',redirectTo:'/home',pathMatch:'full'},
{path: 'home',component:HomeComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports : [RouterModule]
})
export class AppRoutingModule { }
