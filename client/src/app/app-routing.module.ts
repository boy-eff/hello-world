import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollectionChooseTranslationComponent } from './collections/collection-choose-translation/collection-choose-translation.component';
import { CollectionCreateComponent } from './collections/collection-create/collection-create.component';
import { CollectionEditComponent } from './collections/collection-edit/collection-edit.component';
import { CollectionTrainComponent } from './collections/collection-train/collection-train.component';
import { CollectionsComponent } from './collections/collections.component';
import { LoginComponent } from './login/login.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { RegisterComponent } from './register/register.component';
import { UsersListComponent } from './users/users-list/users-list.component';

const routes: Routes = [
  {path: 'account/register', component: RegisterComponent},
  {path: 'account/login', component: LoginComponent},
  {path: 'account/edit', component: MemberEditComponent},
  {path: 'collections', component: CollectionsComponent},
  {path: 'collections/:id', component: CollectionEditComponent},
  {path: 'collections/:id/train', component: CollectionTrainComponent},
  {path: 'collections/:id/train/choose', component: CollectionChooseTranslationComponent},
  {path: 'users', component: UsersListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
