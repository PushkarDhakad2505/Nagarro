let mongoose=require("mongoose");
mongoose.connect('mongodb://localhost:27017/blog',{useNewUrlParser:true,useUnifiedTopology:true, useCreateIndex:true
});

//if connection is made successfully it shows "Database connection establish"
//otherwise error
const db=mongoose.connection;
db.on('error',(err)=>{
    console.log(err);
})
db.once('open',()=>{
    console.log("Database connection establish");
})

//exporting updated (connection) mongoose

module.exports=mongoose