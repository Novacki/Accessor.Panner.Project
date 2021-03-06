import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormProviderComponent } from './pages/form-provider/form-provider.component';
import { FormLoginComponent } from './pages/form-login/form-login.component';
import { IndexComponent } from './pages/index/index.component';
import { HeaderComponent } from './components/header/header.component';
import { BottomComponent } from './components/bottom/bottom.component';
import { HomeContentComponent } from './components/home-content/home-content.component';
import { RouterModule } from '@angular/router';
import { routes } from './home.routes';
import { LoginComponent } from './components/login/login.component';
import { MatFormFieldModule } from '@angular/material/form-field';

import {ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ClientFormComponent } from './components/client-form/client-form.component';
import { ProviderFormComponent } from './components/provider-form/provider-form.component';
import { FormClientComponent } from './pages/form-client/form-client.component';
import { ChooseRegisterComponent } from './components/choose-register/choose-register.component';
import { ChooseComponent } from './pages/choose/choose.component';
import { SharedModule } from '../shared/shared.module';
import { AccessorDetailsComponent } from './components/accessor-details/accessor-details.component';
import { ClientService } from './services/client.service';
import { ProviderService } from './services/provider.service';
import { AccountService } from './services/account.service';



@NgModule({
  declarations: [FormLoginComponent, FormProviderComponent, IndexComponent, 
    HeaderComponent, BottomComponent, HomeContentComponent, LoginComponent, ClientFormComponent, ProviderFormComponent, FormClientComponent, ChooseRegisterComponent, ChooseComponent, AccessorDetailsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
    SharedModule
  ],
  exports:[],
  providers:[ClientService, ProviderService, AccountService ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class HomeModule { }
