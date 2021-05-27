//import all required modules
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { BlogData } from './blog-data';
import { BlogListComponent } from './blog-list.component';
import { BlogEditComponent } from './blog-edit.component';
import { BlogComponent } from './blog.component';
import { BlogDetailsComponent } from './blog-details.component';
import { BlogEditGuard } from './blog-edit.guard';

//defing ngmodule
@NgModule({
  //declare all components
  declarations: [
    BlogComponent,
    BlogListComponent,
    BlogDetailsComponent,
    BlogEditComponent
  ],
  //import external components
  imports: [
    SharedModule,
    ReactiveFormsModule,
    //initialize for mocking service http requests
    InMemoryWebApiModule.forRoot(BlogData),
    //perform routing
    RouterModule.forChild([
      { path: 'blog', component: BlogListComponent },
      { path: 'create', component: BlogComponent},
      { path: 'blogdetails/:id', component: BlogDetailsComponent },
      { path: 'blog/:id/edit', canDeactivate: [BlogEditGuard] , component: BlogEditComponent }
    ]),
  ]
})
export class BlogModule { }
