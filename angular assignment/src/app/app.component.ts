//import required module
import { Component } from '@angular/core';

//declare component
@Component({
  selector: 'app-root',
  //building navigation template with router outlet
  template: `
  <style>
  nav{
    position:fixed;
    z-index:10;
    width:100%;
  }
  </style>
  <nav class='navbar navbar-expand navbar-light bg-light mb-3 px-3'>
    <a class='navbar-brand' routerLink='/blog'>{{selecttitle}}</a>
    <ul class='nav nav-pills'>
      <li><a class='nav-link' routerLink='/blog'>Blog List</a></li>
      <li><a class='nav-link' routerLink='/create'>Create Blog</a></li>
    </ul>
  </nav>
  <div class='container'>
    <router-outlet></router-outlet>
  </div>
  `
})

//exporting component
export class AppComponent {
  title = 'blogpost';
  selecttitle:string = 'Blog App';
}
