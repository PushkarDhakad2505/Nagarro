//importing required modules
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BlogService } from './blog.service';
import { IBlog } from './bloglist';

//declaring component
@Component({
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})

//exporting class
export class BlogComponent implements OnInit {
  //variables
  blogForm!: FormGroup;
  blog: IBlog;

  //constructor with dependency injection
  constructor(private formBuilder: FormBuilder,
              private blogService: BlogService,
              private router: Router) { }

  //initialize everything
  ngOnInit(): void {
    //build the form
    this.blogForm = this.formBuilder.group({
      title: ['',[Validators.required, Validators.minLength(3)]],
      categories: ['',[Validators.required, Validators.minLength(3)]],
      content: ['',[Validators.required, Validators.minLength(10)]]
    })
  }

  //save method to save data
  save(): void {
    //if form is valid save the data
    if(this.blogForm.valid){
      const data = {...this.blog, ...this.blogForm.value};

      this.blogService.createBlog(data)
        .subscribe({
          next: ()=> this.onSaveComplete(),
          error: err=> alert(err)
        });
    }
    else{
      alert('Please correct the Validation errors');
    }
  }

  //after save is complete do routing
  onSaveComplete(): void {
    this.blogForm.reset();
    this.router.navigate(['/blog']);
  }
}
