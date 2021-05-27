//importing all the required modules
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IBlog } from './bloglist';

//injecting  the service at root
@Injectable({
  providedIn: 'root'
})

//export the service
export class BlogService {
  //url for http request
  private blogUrl:string ='api/blogs';

  //constructor with dependency injection
  constructor(private http: HttpClient) { }

  //returning observable 
  getBlogs(): Observable<IBlog[]> {
    return this.http.get<IBlog[]>(this.blogUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  //method getting data with id
  getBlog(id: number): Observable<IBlog>{ 
    const url = `${this.blogUrl}/${id}`;
    return this.http.get<IBlog>(url).pipe(
      tap(data => console.log('getBlog : '+ JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  //method for creating a blog
  createBlog(blog: IBlog): Observable<IBlog> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    blog.id = null;
    //returning observable
    return this.http.post<IBlog>(this.blogUrl, blog, { headers })
      .pipe(
        tap(data => console.log('createBlog: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  //updating blog
  updateBlog(blog: IBlog): Observable<IBlog> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url =`${this.blogUrl}/${blog.id}`;
    return this.http.put<IBlog>(url, blog, {headers})
      .pipe(
        tap(()=> console.log('updateBlog: '+blog.id)),
        map(()=>blog),
        catchError(this.handleError)
      );
  }

  //delete blog with id
  deleteBlog(id : number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.blogUrl}/${id}`;
    return this.http.delete<IBlog>(url, {headers})
      .pipe(
        tap(data => console.log('deleteProduct: '+ id)),
        catchError(this.handleError)
      );
  }
  //handling error
  handleError(err: HttpErrorResponse) {
    //variable to build error string
    let errorMessage: string = '';
    if(err.error instanceof ErrorEvent){
      errorMessage=`An error occured: ${err.error.message}`;
    }else{
      errorMessage=`Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
