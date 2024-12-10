# ♡₊˚🦢💻LibraVerse - The Universe of books💻🦢・₊✧
Welcome to **LibraVerse**, your mindful book place application built on **ASP.NET Core MVC**! **LibraVerse** is a platform for managing books, reviews, articles, and events. It allows users to search for books, read and write reviews, cooments and stay informed about upcoming book-related events.

# 🤩📖 Features
🏬**Bookstore:** *Explore a wide range of books ready for purchase. Easily find your next favorite read.* <br>
📜**Articles:** *Engage with fascinating articles dedicated solely to book-related themes. Keep up with the latest and most exciting news in the literary world.* <br>
📣**Events:** *Uncover and join events designed for book enthusiasts. Enjoy discussions, signings, and meetups centered around your favorite books.* <br>
🧋+📚**Collections:** *Manage your reading adventure with custom collections. Track your "Want to Read", "Currently Reading", and "Read" books for a tailored bookshelf experience.* <br>
⭐⭐⭐⭐⭐**Reviews and Ratings:** *Express your opinions on books by writing reviews and giving ratings from 1 to 10. Help the community by guiding others to literary treasures.* <br>

## Enjoy reading with LibraVerse, where our goal is to make your reading experience relaxing, enjoyable, and uniquely comfortable!

# 👑Roles👑
## 👨🏻‍💻User👨🏻‍💻
Users possess the capability to browse through an extensive catalog of books, view detailed information about various bookstores along with their available inventory, read engaging articles, and discover upcoming events. Additionally, users can contribute to the community by adding comments to books, articles, or events. They are also empowered to compose comprehensive reviews and provide ratings for books, articles, and events. Moreover, users have the autonomy to delete or edit their comments and reviews. They can curate their personal reading journey by adding books to their "My Books" section, categorizing them as "Want To Read," "Currently Reading," or "Read."

## ✍🏼Publisher✍🏼
Publishers enjoy the same privileges as users, with the added authority to manage content more comprehensively. They can add new books, bookstores, articles, and events, as well as edit or delete existing entries. This expanded set of permissions allows publishers to maintain and enrich the content available to all users.

## 💸ADMIN💸
Admins hold the same permissions as publishers but with additional administrative capabilities within the "Actions" section. This unique section grants admins the ability to elevate users to the role of publisher or admin and to revoke such statuses when necessary. This ensures a robust and dynamic management structure, enabling the seamless promotion and demotion of users within the platform.

## 💀Unauthenticated users💀
They can see the Home page of the application, displaying the purpose of the platform.

## 🏛️ Project Structure 🏛️
-LibraVerse.Web: Web application, including controllers and views.
-LibraVerse.Data: Database context (configurations, data seeding, repository) and migrations.
-LibraVerse.Core: Core models and business logic, Services providing application functionality.
-LibraVerse.Tests: Tests for various application components (services).

# 👨🏻‍💻🦾💡 Technologies
- C#
- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- HTML
- CSS
- JavaScript
- NUnit

## 🧩Installation Requirements🧩
- 🌐  .NET 8.0 SDK or later
- 📶  SQL Server or another compatible database
- </> Visual Studio 2022 or later
  
### ✔️ Installation and Usage Instructions✔️ 
1. Clone the repository.
2. Database setup:
  - Create a new database in SQL Server.
  - Update the appsettings.json file with the correct database connection settings.
3. Apply migrations:
  - dotnet ef database update
    OR
  - Add-Migration InitialDbCreate (in Package Manager Console) after that Update-Database (in Package Manager Console)                              
4. Run the application
  - Open a browser and navigate to http://localhost:5000 to see the application in action.
    
# 🔰 License
This project is licensed under the MIT license - see the LICENSE.md file for details.
