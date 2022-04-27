import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { LoginComponent } from './login/login.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollectionCreateComponent } from './collections/collection-create/collection-create.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatListModule} from '@angular/material/list';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import {MatButton, MatButtonModule} from '@angular/material/button';
import {MatIcon, MatIconModule} from '@angular/material/icon';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTabsModule} from '@angular/material/tabs';
import { EditWordComponent } from './_dialogs/edit-word/edit-word.component';
import { CollectionsComponent } from './collections/collections.component';
import { CollectionListComponent } from './collections/collection-list/collection-list.component';
import { ToastrModule } from 'ngx-toastr';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { AdminPanelReviewsComponent } from './admin-panel/admin-panel-reviews/admin-panel-reviews.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent,
    RegisterComponent,
    TextInputComponent,
    LoginComponent,
    CollectionCreateComponent,
    EditWordComponent,
    CollectionsComponent,
    CollectionListComponent,
    AdminPanelComponent,
    AdminPanelReviewsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    MatFormFieldModule,
    MatInputModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatTabsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-right',
      maxOpened: 5,
      countDuplicates: true,
      preventDuplicates: true,
      resetTimeoutOnDuplicate: true,
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
