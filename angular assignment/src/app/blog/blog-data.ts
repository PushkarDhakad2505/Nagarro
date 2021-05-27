//importing required modules
import { InMemoryDbService } from "angular-in-memory-web-api";
import { IBlog } from "./bloglist";


// exporting class which implements inmemeorydbservice
export class BlogData implements InMemoryDbService{
    //implementing method createDb
    createDb(): {blogs: IBlog[]} {
        //creating an array of data
        const blogs: IBlog[] = [
            {
                id: 2,
                title: 'Python',
                categories: 'Learning, programming, Python',
                content: 'Python is an interpreted high-level general-purpose programming language. Python design philosophy emphasizes code readability with its notable use of significant indentation'
            },
            {
                id: 3,
                title: 'Java',
                categories: 'Learning, programming, Java',
                content: 'Java is a high-level, class-based, object-oriented programming language that is designed to have as few implementation dependencies as possible'
            }
        ];
        // returning data as object
        return {blogs};
    }
    
}