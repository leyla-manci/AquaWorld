# AquaWorld
.net mvc project- Aquaworld

***   
   structure : Model-View-Controller </br>
    AquaWorldContext:DbContext  : this class uses dbConnectString and AquaWorldInitializer as initializer</br>
    AquaWorldInitializer : DropCreateDatabaseIfModelChanges<AquaWorldContext>  : this initializer drops,creates and seeds db with dummy data in case modelchanges </br>
    User processes are done by IdentityDataContext: IdentityDbContext<IdentityUser> use identityConnection and IdentityInitializer. Also you can  find seed data for admin and user in scope of IdentityInitializer.
  

   
*** 
   <b>  Screen Shots </b> 
   </br>
   
<table><tr><td>
 <img src="https://github.com/leyla-manci/AquaWorld/blob/master/_screenshots/home_page.png">
* Home Page
 </td>
   </tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/AquaWorld/blob/master/_screenshots/admin_panel.png">
* Admin Panel
 </td>
</tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/AquaWorld/blob/master/_screenshots/fish_list_settings.png">
* fish list settings
 </td></tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/AquaWorld/blob/master/_screenshots/fish_detail_settings.png">
* fish detail settings
 </td>
 </tr>
<tr>
 <td>
  <img src="https://github.com/leyla-manci/AquaWorld/blob/master/_screenshots/category_settings.png">
* category settings
 </td></tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/AquaWorld/blob/master/_screenshots/user_settings.png">
* user settings
 </td>
 </tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/AquaWorld/blob/master/_screenshots/role_member_settings.png">
* role member settings
 </td></tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/AquaWorld/blob/master/_screenshots/db.png">
* db
 </td>
 </tr>
  <tr>
 <td>
  <img src="https://github.com/leyla-manci/AquaWorld/blob/master/_screenshots/db_connection_str.png">
* db connection string
 </td>
 <td>
  
 </td>
 </tr>
</table>


***
-Katkı Sunanlar---

* Leyla Akmancı | [leyla.manci@gmail.com](mailto:leyla.manci@gmail.com)
