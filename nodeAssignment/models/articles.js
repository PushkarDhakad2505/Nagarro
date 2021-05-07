//requiring mongoose for object modeling
const mongoose=require('mongoose')

const articleSchema=require('./articleSchema')

const validator =require('./Validator')
validator.validationFunction();
//exporting article schema
module.exports=mongoose.model('Article',articleSchema)