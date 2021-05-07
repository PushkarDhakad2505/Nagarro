const mongoose=require('mongoose')

const articleSchema=require('./articleSchema')

const validator =require('./Validator')
validator.validationFunction();

module.exports=mongoose.model('Article',articleSchema)