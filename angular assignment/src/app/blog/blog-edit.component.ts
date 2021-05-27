//importing all  modules
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription} from 'rxjs';
import { BlogService } from './blog.service';
import { IBlog } from './bloglist';

//defining component
@Component({
  selector: 'app-blog-edit',
  templateUrl: './blog-edit.component.html',
  styleUrls: ['./blog-edit.component.css']
})

export class BlogEditComponent implements OnInit, OnDestroy {
  //defining variables
  pageTitle: string = 'Blog Edit';
  blogForm!: FormGroup;
  errorMessage!: string;
  blog!: IBlog;
  private sub!: Subscription;

  //constructor with dependency injection
  constructor(private formBuilder: FormBuilder,
              private route: ActivatedRoute,
              private router: Router,
              private blogService: BlogService) { }
 
  ngOnInit(): void {
    this.blogForm = this.formBuilder.group({
      //applying validators
      title: ['',[Validators.required, Validators.minLength(3)]],
      categories: ['',[Validators.required, Validators.minLength(3)]],
      content: ['',[Validators.required, Validators.minLength(50)]]
    });

    //getting  data
    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = Number(this.route.snapshot.paramMap.get('id'));
        this.getBlog(id);
      }
    );
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  // to get the method and display form
  getBlog(id: number): void {
    this.blogService.getBlog(id)
      .subscribe({
        next: (blog: IBlog)=> this.displayBlog(blog),
        error: err=> this.errorMessage = err
      });
  }

  //displaying the form with the data
  displayBlog(blog: IBlog): void {
    //reseting the form
    if(this.blogForm) {
      this.blogForm.reset();
    }

    //assining new values
    this.blog = blog;
    this.pageTitle = `Edit Product: ${this.blog.title}`;

    //patching values in field
    this.blogForm.patchValue({
      title: this.blog.title,
      categories: this.blog.categories,
      content: this.blog.content
    });
  }

  //save method for saving the data
  save(): void{
    //edit only when form is valid
    if(this.blogForm.valid){
      //update only when form is dirty
      if(this.blogForm.dirty){
        //get data 
        const data = {...this.blog, ...this.blogForm.value};
        //update data
        this.blogService.updateBlog(data)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = 'Please correct the validation errors';
    }
  }

  //routing after saving 
  onSaveComplete(): void {
    this.blogForm.reset();
    this.router.navigate(['/blog']);
  }

  //delete
  deleteBlog(): void {
    //confirm if really want to delete the blog
    if(confirm(`Really delete the blog: ${this.blog.title}`)){
      this.blogService.deleteBlog(this.blog.id)
        .subscribe({
          next: ()=>this.onSaveComplete(),
          error: err=> this.errorMessage =err
        });
    }
  }
}
