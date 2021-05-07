const express=require('express')
const Article=require('./../models/articles')
const router=express.Router()
const articleDB=require('../DataAccessLayer/articleDB')

//used to render home page
router.get('/',async (req,res)=>{

    //getSortedArticles() will return sorted articles
    const articles= await articleDB.getSortedArticles();
    res.render('articles/index',{articles:articles })
})

//used to render page when user clicks on "create new button" 
router.get('/articles/new',(req,res)=>{
    res.render('articles/new',{article:articleDB.createArticle()})
})

//render a page to edit a article
router.get('/articles/edit/:id',async (req,res)=>{
    const article=await articleDB.findArticleById(req.params.id)
    res.render('articles/edit',{article: article})
})

//used to show a article 
router.get('/articles/:slug',async(req,res)=>{
    const article=await articleDB.findArticleOne({slug:req.params.slug})
    if(article==null) res.redirect('/');
    res.render('articles/show',{article: article})
})


//used to save a new article
router.post('/articles',async(req,res,next)=>{
    
    req.article=articleDB.createArticle();
    next()
 },saveArticleAndRedirect('new'))

 //used to save a edited article
router.put('/articles/:id',async(req,res,next)=>{
    
    req.article=await articleDB.findArticleById(req.params.id)
    next()
 },saveArticleAndRedirect('edit'))

 //used to delete a article
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