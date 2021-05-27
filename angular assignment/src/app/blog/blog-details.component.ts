//importing required modules
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from './blog.service';
import { IBlog } from './bloglist';

//declaring component
@Component({
  templateUrl: './blog-details.component.html',
  styleUrls: ['./blog-details.component.css']
})

export class BlogDetailsComponent implements OnInit {
  //initialising variables
  pageTitle: string = 'Blog Detail';
  blog: IBlog | undefined;

  //constructor with dependency injection
  constructor(private route:ActivatedRoute, private router: Router, private blogService: BlogService) { }

  // initialization 
  ngOnInit(): void {
    //getting id from route
    const id = Number(this.route.snapshot.paramMap.get('id'));
    //adding id to title
    this.pageTitle += ` : ${id}`;
    //getting data from blogservice
    this.blogService.getBlog(id).subscribe({
      next: blog => this.blog = blog,
      error: err=> alert(err)
    });
  }

  //on clicking backrender  blog list page
  onBack(): void {
    this.router.navigate(['/blog']);    
  }
}
