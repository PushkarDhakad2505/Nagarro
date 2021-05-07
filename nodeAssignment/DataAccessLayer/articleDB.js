const Article=require('./../models/articles')

const getSortedArticles=async()=>{
    const articles= await Article.find().sort({createdDate:'desc'});
    return articles;
}
    
const createArticle=()=>{
    return new Article()
}

const findArticleById=async(id)=>{
    let article=await Article.findById(id);
    return article;
}


const findArticleOne=async(slug)=>{

   const article= await Article.findOne(slug)
   return article;
}


const findArticleByIdAndDelete=async(id)=>{
    await Article.findByIdAndDelete(id);
}



module.exports.createArticle=createArticle;
module.exports.findArticleById=findArticleById;
module.exports.findArticleByIdAndDelete=findArticleByIdAndDelete;
module.exports.getSortedArticles=getSortedArticles;
module.exports.findArticleOne=findArticleOne;
