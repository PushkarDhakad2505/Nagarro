function validationFunction(){   
    const articleSchema=require('./articleSchema')
    const marked =require('marked')
    const slugify =require('slugify')
    const createDomPurify=require('dompurify');
    const{JSDOM}=require('jsdom')
    const dompurify=createDomPurify(new JSDOM().window)
    //setting validations and restriction on title and content 
    articleSchema.pre('validate',function(next){
        if(this.title){
            this.slug=slugify(this.title,{lower:true,strict:true
            })
        }
    
        if(this.markdown){
            this.sanitizedHtml=dompurify.sanitize( marked(this.markdown))
        }
        next()
    })
    
}

module.exports.validationFunction=validationFunction