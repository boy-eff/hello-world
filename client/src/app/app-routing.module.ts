import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollectionCreateComponent } from './collections/collection-create/collection-create.component';
import { CollectionsComponent } from './collections/collections.component';
import { LoginComponent } from './login/login.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { RegisterComponent } from './register/register.component';
import { UsersListComponent } from './users/users-list/users-list.component';

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'collections', component: CollectionsComponent},
  {path: 'members/edit', component: MemberEditComponent},
  {path: 'users', component: UsersListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
