//importing required modules
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { BlogModule } from './blog/blog.module';

//declaring ngmodule
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    //defining wildcard routing
    RouterModule.forRoot([
      { path: '**', redirectTo: '/blog', pathMatch: 'full' }
    ]),
    BlogModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
