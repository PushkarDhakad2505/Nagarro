const Article=require('./../models/articles')
//returning articles in sorted manner according to date
const getSortedArticles=async()=>{
    const articles= await Article.find().sort({createdDate:'desc'});
    return articles;
}
    
//returning new article
const createArticle=()=>{
    return new Article()
}

//returning article which match the id
const findArticleById=async(id)=>{
    let article=await Article.findById(id);
    return article;
}

//returning article which match the slug(title)
const findArticleOne=async(slug)=>{

   const article= await Article.findOne(slug)
   return article;
}

//deletion
const findArticleByIdAndDelete=async(id)=>{
    await Article.findByIdAndDelete(id);
}

//exporting all functions
module.exports.createArticle=createArticle;
module.exports.findArticleById=findArticleById;
module.exports.findArticleByIdAndDelete=findArticleByIdAndDelete;
module.exports.getSortedArticles=getSortedArticles;
module.exports.findArticleOne=findArticleOne;
