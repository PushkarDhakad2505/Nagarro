let mongoose=require("mongoose");
mongoose.connect('mongodb://localhost:27017/blog',{useNewUrlParser:true,useUnifiedTopology:true, useCreateIndex:true
});


//testing start

const db=mongoose.connection;
db.on('error',(err)=>{
    console.log(err);
})
db.once('open',()=>{
    console.log("Database connection establish");
})

//testing ends

module.exports=mongoose