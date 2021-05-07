//const mongoose=require('mongoose')
const mongoose=require('./connection')
//defining schema for article
let articleSchema=new mongoose.Schema({
    title:{
        type:String,
        required:true
    },
    //contains category
    description:{
        type:String,
        
    },
    //contains content
    markdown:{
        type:String,
        required:false

    },
    //date on which article is created
    createdDate:{
        type:Date,
        default:new Date()
    },
    //name of title
    slug:{
        type:String,
        required:true,
        unique:true
    },
    //sanitized content taken from user in "content" textarea
    sanitizedHtml:{
        type:String,
        required:true
    }
})

module.exports=articleSchema