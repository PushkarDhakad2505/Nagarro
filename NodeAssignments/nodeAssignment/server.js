const express = require("express");
const mongoose=require("mongoose");
const articleRouter=require('./routes/articles.js');
const app=express();
const Article=require('./models/articles')
const methodOverride=require('method-override')
mongoose.connect('mongodb://localhost:27017/blog',{useNewUrlParser:true,useUnifiedTopology:true, useCreateIndex:true
});
app.set('view engine','ejs');


//testing start

const db=mongoose.connection;
db.on('error',(err)=>{
    console.log(err);
})
db.once('open',()=>{
    console.log("Database connection establish");
})

//testing ends


app.use(express.urlencoded({extended:false}));
app.use(methodOverride('_method'))
app.get('/',async (req,res)=>{

    const articles= await Article.find().sort({

   createdDate:'desc'});
    res.render('articles/index',{articles:articles})
})


app.use('/articles',articleRouter);

app.listen(5000);