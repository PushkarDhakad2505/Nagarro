const express=require('express')
const Article=require('./../models/articles')
const router=express.Router()
const articleDB=require('../DataAccessLayer/articleDB')


router.get('/',async (req,res)=>{

    const articles= await articleDB.getSortedArticles();
    res.render('articles/index',{articles:articles })
})

router.get('/articles/new',(req,res)=>{
    res.render('articles/new',{article:articleDB.createArticle()})
})

router.get('/articles/edit/:id',async (req,res)=>{
    const article=await articleDB.findArticleById(req.params.id)
    res.render('articles/edit',{article: article})
})


router.get('/articles/:slug',async(req,res)=>{
    const article=await articleDB.findArticleOne({slug:req.params.slug})
    if(article==null) res.redirect('/');
    res.render('articles/show',{article: article})
})



router.post('/articles',async(req,res,next)=>{
    
    req.article=articleDB.createArticle();
    next()
 },saveArticleAndRedirect('new'))

router.put('/articles/:id',async(req,res,next)=>{
    
    req.article=await articleDB.findArticleById(req.params.id)
    next()
 },saveArticleAndRedirect('edit'))

 router.delete('/articles/:id',async (req,res)=>{
    articleDB.findArticleByIdAndDelete(req.params.id);
    res.redirect('/')
})

function saveArticleAndRedirect(path){
    return async (req,res)=>{
        let article =req.article
            article.title=req.body.title
            article.description=req.body.description
            article.markdown=req.body.markdown
      
            try{
                article=await article.save()
                res.redirect(`/articles/${article.slug}`)
            }
            catch(e){
                res.render(`articles/${path}`,{article: article})
            }
    }
}


module.exports=router