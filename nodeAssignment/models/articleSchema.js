//const mongoose=require('mongoose')
const mongoose=require('./connection')
let articleSchema=new mongoose.Schema({
    title:{
        type:String,
        required:true
    },
    description:{
        type:String,
        
    },
    markdown:{
        type:String,
        required:false

    },
    createdDate:{
        type:Date,
        default:new Date()
    },
    slug:{
        type:String,
        required:true,
        unique:true
    },
    sanitizedHtml:{
        type:String,
        required:true
    }
})

module.exports=articleSchema