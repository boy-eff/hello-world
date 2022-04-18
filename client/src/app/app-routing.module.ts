import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollectionCreateComponent } from './collections/collection-create/collection-create.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'collections', component: CollectionCreateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
