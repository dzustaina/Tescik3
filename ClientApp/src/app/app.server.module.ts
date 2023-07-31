import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
import { AppRoutingModule } from './app-routing.module';
import { UserComponent } from './user/user.component';
import { Routes } from '@angular/router';
import { RegistrationComponent } from './user/registration/registration.component';


@NgModule({
    imports: [AppModule,AppRoutingModule, ServerModule],
    bootstrap: [AppComponent]
})
export class AppServerModule { }
