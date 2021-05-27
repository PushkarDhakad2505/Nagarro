//import the modules
import { Component, OnInit } from '@angular/core';
import { BlogService } from './blog.service';
import { IBlog } from './bloglist';

//decalring the component 
@Component({
  templateUrl: './blog-list.component.html',
  styleUrls: ['./blog-list.component.css']
})

//export the component class
export class BlogListComponent implements OnInit {
  //variables to hold data
  pageTitle: string = 'Blog List';
  blogs: IBlog[];

  //constructor with dependency injection
  constructor(private blogService: BlogService) { }

  //initialize the data
  ngOnInit(): void {
    //getting the data
    this.blogService.getBlogs().subscribe({
      next: blogs => this.blogs = blogs,
      error: err=> alert(err)
    });
  }

}
