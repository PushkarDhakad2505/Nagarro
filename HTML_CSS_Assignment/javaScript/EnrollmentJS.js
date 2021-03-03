function AddRow()
{
    var student = {
                    name:document.getElementById("nameBox").value
                    ,email:document.getElementById("emailBox").value
                    ,website:document.getElementById("websiteBox").value
                    ,image:document.getElementById("imageBox").value
                    ,gender:function()
                    {
                        if(document.getElementById("MaleRadio").checked)
                            return "Male";
                            
                        else if(document.getElementById("femaleRadio").checked)
                        return "Female";

                        else
                         return "";
                    } 
                    ,skills:function()
                    {
                        var Allskill="";
                        if(document.getElementById("JavaBox").checked)
                            {
                                Allskill=Allskill+"Java ";                                            
                            }
                        if(document.getElementById("HTMLBox").checked)
                            {
                                Allskill=Allskill+"HTML, ";
                            }
                            if(document.getElementById("CSSBox").checked)
                            {
                                Allskill=Allskill+"CSS, ";                                            
                            }
                            return Allskill;
                    }
                    ,addinfo:function(allinfo,imagepath)
                    {
                        var AddRown = document.getElementById('show');
                        var NewRow = AddRown.insertRow(1);
                        var size = 1;
                        var index = 0;
                        var cel1 = NewRow.insertCell(0);
                        var cel2 = NewRow.insertCell(1);
                        cel1.innerHTML = allinfo;
                        cel2.innerHTML="new Image";
                        
                        var imageInfo="<img src="+imagepath+" width =80px height=90px><img/>"
                        cel2.innerHTML=imageInfo ;
                        size++;
                        index++;
                        if(n>4){
                            document.getElementById("show").deleteRow(4);
                        }
                    }
                    ,validateName:function(name){return(name)}
                                    
                    ,validateEmail:function(email){return(email);}
                                    
                    ,varifyEmail:function(email)
                    {
                        var reg = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
                        return(reg.test(email));
                    }             
                    ,validateWebsite:function(website){return(website);}

                    ,varifyWebsite:function(website)
                    {
                        regexp = /^(?:(?:https?|ftp):\/\/)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/\S*)?$/; 
                        return (regexp.test(website)) ;
                    }
                    ,validateImage:function(image){return(image);}
                                   
                    ,validateGender:function(gender){ return(gender);}
                                    
                    ,validateskills:function(skills){return(skills);}
                }
                
    var allinfo=student.name+"<br>"+student.gender()+"<br>"+student.email+"<br>"+"<a href="+student.website+" target=_blank>"+student.website+"</a>"+"<br>"+student.skills();
    var imagePath=student.image;
    var flag=0;
    var str="";
    
    if(student.validateName(student.name)==false)
    {
        flag=1;
        str=str+"Name is Required \n";
    }
    var isEmailEntered=1;
    if(student.validateEmail(student.email)==false)
    {
        flag=1;
        isEmailEntered=0;
        str=str+"Email is Required \n";
    }
    if((student.varifyEmail(student.email)==false) && (isEmailEntered==1))
    {
        flag=1;
        str=str+"Email is not correct \n";
    }
    var isWebsiteEntered=1;
    if(student.validateWebsite(student.website)==false)
    {
        flag=1;
        isWebsiteEntered=0;
        str=str+"Website is Required \n";
    }
    if((student.varifyWebsite(student.website)==false)&&(isWebsiteEntered==1))
    {
        flag=1;
        str=str+"Unreached Website \n";
    }
    if(student.validateImage(student.image)==false)
    {
        flag=1;
        str=str+"Image is required\n";
    }
    if(student.validateGender(student.gender())==false)
    {
        flag=1;
        str=str+"Gender is required\n";
    }
    if( student.validateskills(student.skills())==false)
    {
        flag=1;
        str=str+"Skill is required\n";
    }
    if(flag==0)
        student.addinfo(allinfo,imagePath);
    else
        alert(str);
}