//importing required modules
import { Injectable } from '@angular/core';
import {CanDeactivate} from '@angular/router';
import { Observable } from 'rxjs';
import { BlogEditComponent } from './blog-edit.component';

//inject guard
@Injectable({
  providedIn: 'root'
})

//export  guard
export class BlogEditGuard implements CanDeactivate<BlogEditComponent> {
  
  canDeactivate(
    component: BlogEditComponent): Observable<boolean> | Promise<boolean> | boolean {
      //check condition and show response
      if (component.blogForm.dirty) {
        const blogName = component.blogForm.get('title')?.value;
        return confirm(`Navigate away and lose all changes to ${blogName}`);
      }
      return true;
  }
  
}
