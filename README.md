## MovieStreaming-Platform-NetChill
* This NetChill movie streaming application uses Angular 13, Asp.Net and MS SQL Server.
* It gives two types user access one for Admin and another for User 
* Admin - Can upload content and Revoke Subscription 
* User - User can access all steaming components like- watch movie, add-movie to userlist.

## Requirements 

1. Angular-cli **13**
2. Dotnet SDk 
3. MS SQL Server
4. Ide or Code editor(Recommnedation- 1. For Frontent - VS Code 
                                      2. For Backend - VS Studio 2019).

## Tech Stack Used 

### Frontend
* Angular
* HTML
* CSS , Bootstrap 5
* Typescript

### Backend
* Asp.net Core 3.1

### Frameworks used
* Angular (for frontend)
* Entity Core Framework (for communication with database )
* JWT framework (for auth)

### Backend Pakages Used
* AutoMapper (v 11.0.1)
* Microsoft.AspNetCore.Authentication.JwtBearer (v 3.1.27)
* Microsoft.AspNetCore.Cors (v 2.2.0)
* Microsoft.EntityFrameworkCore  (v 3.1.27)
* Microsoft.EntityFrameworkCore.Design  (v 3.1.27)
* Microsoft.EntityFrameworkCore.Relation  (v 3.1.27)
* Microsoft.EntityFrameworkCore.SqlServer (v 3.1.27)
* Microsoft.EntityFrameworkCore.Tools  (v 3.1.27)
* Microsoft.VisualStudio.Web.CodeGeneration.Design  (v 3.1.5)


###### Setup ###################################################################

### 1st Backend Setup  ###
1. Run Solution file:-  Navigate to 
                       Backend folder -> Project.API folder -> Project.API.sln (click on sln and open it in VS Studio 2019)

2. Change Connection String path in appsettings.json file [in VS studio ] Presentation Layer -> Project.API -> appsettings.json        (DefaultConnection:" ")
3. After creating connection string , run command in Pakage Manager Console -> update-database
4. In VS Studio in solution Explorer -> Right Click on sln file and Build
5. Now Run IIS Express. (It will redirect you on "http://localhost:3000/swagger/index.html")


### 2nd Frontend Setup

1. Open Backend folder in VS code (open intigrated terminal and install node modules by running command -> npm install)
********Note here system should have angular cli 13 version 

2. Now Run frontend (by running command -> ng serve )
******** Note you must run ng server only on "http://localhost:4200"

   ## Admin Credential ###################################################################
    ************************* Note [First upload movie by admin credential ] Becasue initilay database  does not contain any movie record .IMP<<>>

    # Admin 1
      EmailId : admin1@netchill.com
      Password : Admin@123

    # Admin 2
      EmailId : admin2@netchill.com
      Password : Admin@123

    ************* Note admin can Upload Movie **********************************

    ****  Note [In Poster and ContentPath provide open source link only ****IMP... you can copy movie poster link form google also] 
    
    ********** for Demo **************************

    Movie Name :            The Lie 
    Category :              Thriller [like horror, science fiction]
    Release Date :          any 
    Availability Date :     any 
    Description  :          any
    Isfeatures  :           True/false [By click on check box ]
    Poster [Link] :         https://static.rogerebert.com/uploads/movie/movie_poster/the-lie-2020/large_lie-poster.jpg
    ContentPath [Link] :    https://github.com/sandeepkumar37200/NetChill/blob/main/The%20Lie%20%E2%80%93%20Official%20Trailer.mp4?raw=true

    ********************************************** Some more poster and content path links 

    Movie Name : Awake 
    Poster [Link] : https://i2.wp.com/criticologos.com/wp-content/uploads/2021/05/Awake_Main_Vertical_RGB_SV20210430-4753-1yryttr.jpeg?w=729&ssl=1
    ContentPath [Link] : https://github.com/sandeepkumar37200/NetChill/blob/main/AWAKE%20_%20Official%20Trailer%20_%20Netflix.mp4?raw=true

    **********************************************
    Movie Name : The Hunt
    Poster [Link] : https://th.bing.com/th/id/R.9fe635ea33c2e3db86384c605757a222?rik=8WPv5Aic7KtlrQ&riu=http%3a%2f%2fwww.impawards.com%2f2014%2fposters%2fhaunt_ver2.jpg&ehk=LRLwKkrhu%2fhx0qfstKsMhSe90IGtazV1zweSDniaaTM%3d&risl=&pid=ImgRaw&r=0

    ContentPath [Link] : https://github.com/sandeepkumar37200/NetChill/blob/main/The%20Hunt%20-%20Official%20Trailer%20%5BHD%5D.mp4?raw=true

    **********************************************
    Movie Name : Run
    Poster [Link] : https://static.rogerebert.com/uploads/movie/movie_poster/run-2020/large_run-poster.jpg

    ContentPath [Link] : https://github.com/sandeepkumar37200/NetChill/blob/main/Run%20(2020%20Movie)%20Official%20Trailer%20%E2%80%93%20Sarah%20Paulson,%20Kiera%20Allen.mp4?raw=true

    **********************************************
    Movie Name : War
    Poster [Link] : https://movieseffect.net/wp-content/uploads/2019/10/War-Movie-Poster.jpeg

    ContentPath [Link] : https://github.com/sandeepkumar37200/NetChill/blob/main/WAR%20_%20Official%20Trailer%20_%20Hrithik%20Roshan,%20Tiger%20Shroff,%20Vaani%20Kapoor%20_%20Siddharth%20Anand%20_%20New%20Movie.mp4?raw=true

    **********************************************
    Movie Name : Gravity
    Poster [Link] : https://th.bing.com/th/id/R.a97244f8d0dd7daa9b5327c96ee6b33a?rik=XNTNeeBkz0wZ6w&riu=http%3a%2f%2fcdn.shopify.com%2fs%2ffiles%2f1%2f0037%2f8008%2f3782%2fproducts%2fgravity_advance_october_style_EB04724_B.jpg%3fv%3d1558003300&ehk=4txFlKkjmMUZs83a74BsPDJZU8A%2fYH79qmfhW%2bLUXmU%3d&risl=&pid=ImgRaw&r=0

    ContentPath [Link] : https://github.com/sandeepkumar37200/NetChill/blob/main/Gravity%20-%20Official%20Main%20Trailer%20%5B2K%20HD%5D.mp4?raw=true

    **********************************************
    Movie Name : Lion
    Poster [Link] : https://th.bing.com/th/id/OIP.ojj51SPoeFnMB1kJ9EBHdAHaLH?pid=ImgDet&rs=1
    ContentPath [Link] : https://github.com/sandeepkumar37200/NetChill/blob/main/Lion%20Official%20Trailer%201%20(2016)%20-%20Dev%20Patel%20Movie.mp4?raw=true

## In case of any issue 
* Contact Me : sandeep03@nagarro.com

