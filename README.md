This repository provides the latest soure code for our Open Source Blog built using the .NET 4.8 Framework. This product is being built for Cylosoft Inc. by PJ D, Sebastian K, Thien N, and Cole M.

# Features

### Implemented
* CKEditor 4
* Microsoft Identity/Owin Authentication
* Admin Area
    * Create, Read, Update, and Delete (CRUD) Posts
* View posts marked as published on the home page
* View posts marked as deleted on the archive page
* Email verification (90% complete)
    
### Planned
* Gravatar API (Profile pictures)
* 3rd party sign ons (Microsoft, Google)
* Admin Area
..* Add a category/tag to a post
    ..* Manage users
    ..* Manage rights/roles
    ..* Manage blog settings
    ..* Manage individual account/profile settings
    ..* Approve and deny comments
    ..* CRUD categories and tags
    ..* Apply a new theme
* Normal user (logged in or not)
    ..* Comment on posts
    ..* Sort posts by tags
    ..* Search posts
    ..* View profiles of Editors/Admins
* Different roles
    ..* Admin - Full access
    ..* Editor - Full access to posts

# Installation

### 1. Source Code
This is the developer option. Use this if you are interested in seeing how things work or would like to implement your own functionality.

Environment:
* Visual Studio 2017 +
* .NET Framework 4.8 +
* Microsoft SQL Database through [Azure](https://azure.microsoft.com/en-us/)

Steps:
1. Clone repository
2. Open solution in Visual Studio 2017 +
3. Switch to solution view
4. Inside OpenSourceBlog edit the Web.config
    * Edit the connectionString="" to be your Azure database connection string
    * Edit **ALL** instances of `sdmay20.34@gmail.com` to be your gmail (for sending confirmation emails). Add your password as well.
5. Inside OpenSourceBlog.Test edit the App.config
    * Edit the connectionString="" to be your Azure database connection string
6. Build and run solution to load website in the browser
7. Click login in the top right
8. Username: `admin@gmail.com` Password: `Admin1@`