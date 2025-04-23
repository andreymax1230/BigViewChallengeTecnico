import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpInterceptorFn, withInterceptors  } from '@angular/common/http';



// Client Http
import { provideHttpClient } from '@angular/common/http';
import { HeaderComponent } from './features/header/header.component';
import { InfouserComponent } from './features/infouser/infouser.component';
import { InfoproductComponent } from './features/infoproduct/infoproduct.component';

export const authorizationInterceptor: HttpInterceptorFn = (req, next) => {
  const token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJCaWdWaWV3IiwiaWF0IjoxNzQ1MjcyMjgyLCJleHAiOjE3NzY4MDgyNzEsImF1ZCI6Imh0dHBzOi8vd3d3LmJpZ3ZpZXcuY29tLmNvIiwic3ViIjoiYW5kcmV5QGJpZ3ZpZXcuY29tIiwiR2l2ZW5OYW1lIjoiQW5kcmV5IiwiU3VybmFtZSI6IlJvZHJpZ3VleiIsIkVtYWlsIjoiYW5kcmV5QGJpZ3ZpZXcuY29tIiwiUm9sZSI6IkRldiJ9.qdw59ACNu9YvFUlnMkFyjdgSDI43IXi4P2rn9aY2kEY"
  const requestWithAuthorization = req.clone({
    headers: req.headers.set('Authorization',`Bearer ${token}`),
  });
  return next(requestWithAuthorization);
};

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    InfouserComponent,
    InfoproductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [provideHttpClient(withInterceptors([authorizationInterceptor]))],
  bootstrap: [AppComponent]
})
export class AppModule { }


​