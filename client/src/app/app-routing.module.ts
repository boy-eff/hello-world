import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollectionCreateComponent } from './collections/collection-create/collection-create.component';
import { CollectionEditComponent } from './collections/collection-edit/collection-edit.component';
import { CollectionsComponent } from './collections/collections.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { RegisterComponent } from './register/register.component';
import { UsersListComponent } from './users/users-list/users-list.component';

const routes: Routes = [
  {path: 'account/register', component: RegisterComponent},
  {path: 'account/login', component: LoginComponent},
  {path: 'collections', component: CollectionsComponent},
  {path: 'collections/:id', component: CollectionEditComponent},
  {path: 'account/edit', component: MemberEditComponent},
  {path: 'users', component: UsersListComponent},
  {path: '**', redirectTo: "/"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
