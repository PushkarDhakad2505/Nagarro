// student object to store properties related to students
var Student={

    name :   "",
    email :  "",
    website :"",
    image :  "",
    gender : "",
    skills : ""

}

// add row function will be called when user click the button
// this function is kind of main function (program start from here) and gather data  related to student 
function AddRow(){

    var name=document.getElementById("nameBox").value;
    var email=document.getElementById("emailBox").value;
    var website=document.getElementById("websiteBox").value;
    var image=document.getElementById("imageBox").value;
    var gender=genderFun();//this function will return gender string
    var skills=skillsFun();//this function will return skills string

    //this function will return gender
    function genderFun (){
        if(document.getElementById("MaleRadio").checked)
            return "Male";
            
        else if(document.getElementById("femaleRadio").checked)
        return "Female";

        else
        return "";
    }
    //this function will return skills
    function skillsFun(){

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
    //below function is used to validate name,email,website,image,gender,skills
    //if they are not empty and provided correctly then function return true
    if(validateFunction(name,email,website,image,gender,skills)){
        var allinfo=name+"<br>"+gender+"<br>"+email+"<br>"+"<a href="+website+" target=_blank>"+website+"</a>"+"<br>"+skills;
        var imagePath=image;
        //below function is responsible for adding row in table
        addinfo(allinfo,imagePath);
        //below function is responsible for adding data of studentn into list
        addStudentIntoList(name,email,website,image,gender,skills);

    }
}
// function is responsible for adding data of studentn into student object
//and it is also responsible to add student data  into list
function addStudentIntoList(name,email,website,image,gender,skills){
    
    Student.email=email;
    Student.name=name;
    Student.skills=skills;
    Student.website=website;
    Student.image=image;
    Student.gender=gender;
    var  StudentsInfo=[];//list which contains student data
    StudentsInfo.push(Student);
}

//this function is responsible for adding data 
function addinfo (allinfo,imagepath)
{
    //here table with id "show" is selected and data is inserted
    var AddRown = document.getElementById('show');
    // data is inserted in first row
    var NewRow = AddRown.insertRow(1);
    //in coloumn 1 all info is added
    var cel1 = NewRow.insertCell(0);
    //in coloumn image is added
    var cel2 = NewRow.insertCell(1);
    cel1.innerHTML = allinfo;
    cel2.innerHTML="new Image";
    
    var imageInfo="<img src="+imagepath+" width =80px height=90px><img/>"
    cel2.innerHTML=imageInfo ;

}
 
//this function will validate name,email,website,image,gender,skills
function validateFunction(name,email,website,image,gender,skills){
    var flag=0;
    var str="";
    //validating name
    if(validateName(name)==false)
    {
        flag=1;
        str=str+"Name is Required \n";
    }
    var isEmailEntered=1;
    //validating email 
    if(validateEmail(email)==false)
    {
        flag=1;
        isEmailEntered=0;
        str=str+"Email is Required \n";
    }
    //varify only when email is entered
    if(varifyEmail(email)==false) 
    {
         if(isEmailEntered==1){
            flag=1;
            str=str+"Email is not correct \n";
         }
       
    }
    var isWebsiteEntered=1;
    //validating website
    if(validateWebsite(website)==false)
    {
        flag=1;
        isWebsiteEntered=0;
        str=str+"Website is Required \n";
    }
    //varify website only when it is entered
    if((varifyWebsite(website)==false)&&(isWebsiteEntered==1))
    {
        flag=1;
        str=str+"Unreached Website \n";
    }
    //validating image
    if(validateImage(image)==false)
    {
        flag=1;
        str=str+"Image is required\n";
    }
    //validating gender
    if(validateGender(gender==false))
    {
        flag=1;
        str=str+"Gender is required\n";
    }
    //validating skills
    if( validateskills(skills==false))
    {
        flag=1;
        str=str+"Skill is required\n";
    }
    if(flag==0){
        
        return true;
    }
    else {
            alert(str);
        
        return false;
    }
}

//defining validateName
function validateName(name){
    return(name)
}
//defining validateEmail                              
function validateEmail (email){
    return(email);
}
//defining validateEmail               
function varifyEmail (email){
    //using regular expression for validating email
    var reg = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
    return(reg.test(email));
}             
//defining validate website
function validateWebsite (website){
    return(website);
}
//defining validatewebsite   
function varifyWebsite (website)
{
    //using regular expression for validating website
    regexp = /^(ftp|http|https):\/\/[^ "]+$/; 
    return (regexp.test(website)) ;
}
//defining validateImage   
function validateImage (image){
    return(image);
}
//defining validateGender              
function validateGender (gender){
    return(gender);
}
//defining validateskills                 
function validateskills (skills){
    return(skills);
}
