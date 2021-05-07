const express = require("express");
const articleRouter=require('./routes/articles.js');
const app=express();
const methodOverride=require('method-override')

app.set('view engine','ejs');

app.use(express.urlencoded({extended:false}));
app.use(methodOverride('_method'))


app.use('/',articleRouter);

app.get('*',(req,res)=>{
    res.render(__dirname+'\\views\\articles\\error_404.ejs')
})

app.listen(5000);