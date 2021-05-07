const express = require("express");
const articleRouter=require('./routes/articles.js');
const app=express();
const methodOverride=require('method-override')

//using ejs view engine
app.set('view engine','ejs');

app.use(express.urlencoded({extended:false}));
//using methodOverride for delete request
app.use(methodOverride('_method'))


app.use('/',articleRouter);
//rnder error 404 page in case when url is wrong
app.get('*',(req,res)=>{
    res.render(__dirname+'\\views\\articles\\error_404.ejs')
})

app.listen(5000);