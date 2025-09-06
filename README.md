# 🎓 Course Management System (Console App)

A clean, interactive **C#/.NET** console application for managing **Students**, **Instructors**, **Courses**, **Categories**, and **Enrollments** with **Entity Framework Core** (SQL Server LocalDB).
It demonstrates real-world CRUD, **1-N** and **N-N** relationships (via a join entity), and **LINQ-based reports** — all through a structured, friendly terminal UI. 

---

## 📝 Description

This project is a modular console app that simulates a mini learning platform back office. It covers the full flow:

- Create **Categories** ➜ add **Instructors** ➜ add **Courses** ➜ manage **Students** ➜ **Enroll** students ➜ generate **Reports** — with consistent menus, validation helpers, and a reusable reporting printer. 

---

## ✨ Features

- ➕ **CRUD** for Students, Instructors, Categories, and Courses  
- 🧾 **Enroll students** into courses (prevents duplicate enrollments)  
- 📊 **Reports**:  
  - Courses with their instructors  
  - Enrollment count per course  
  - Students with their courses  
  - Course (by ID) with enrolled students  
  - Top 3 courses by enrollments  
- 🔎 **Query helper**: Get courses under a specific price (service-level)  
- 🧱 **Separation of concerns**: `Models`, `Services`, `Screens`, `Helpers`, `Data`  
- 🧰 **Generic base service** for common CRUD with EF Core  
- 🧯 Graceful console messages + minimal error handling on `SaveChanges()`  

---

## 🗂️ Project Structure

```
CourseManagementSystem/
├── Data/
│   └── AppDbContext.cs              # EF Core DbContext + relationships
├── Helpers/
│   ├── ConsoleUIHelper.cs           # Boxed menus, prompts
│   └── InputHelper.cs               # Input validation (int/decimal/string)
├── Migrations/                      # EF Core migrations + snapshot
├── Models/
│   ├── CategoryModel.cs
│   ├── CourseModel.cs
│   ├── EnrollmentModel.cs
│   ├── InstructorModel.cs
│   └── StudentModel.cs
├── Screens/
│   ├── Category/
│   │   ├── AddCategoryScreen.cs
│   │   ├── CategoryMenuScreen.cs
│   │   └── ViewCategoriesScreen.cs
│   ├── Course/
│   │   ├── AddCourseScreen.cs
│   │   ├── CourseMenuScreen.cs
│   │   ├── UpdateCourseScreen.cs
│   │   └── ViewCourseScreen.cs
│   ├── Instructor/
│   │   ├── AddInstructorScreen.cs
│   │   ├── InstructorMenuScreen.cs
│   │   └── ViewInstructorsScreen.cs
│   ├── Reports/
│   │   ├── ReportPrinter.cs
│   │   ├── ReportsMenuScreen.cs
│   │   └── ReportsRenderingMethodsScreen.cs
│   └── Student/
│       ├── AddStudentScreen.cs
│       ├── DeleteStudentScreen.cs
│       ├── EnrollStudentScreen.cs
│       ├── StudentMenuScreen.cs
│       ├── UpdateStudentScreen.cs
│       └── ViewStudentsScreen.cs
├── Services/
│   ├── BaseService.cs
│   ├── CategoryService.cs
│   ├── CourseService.cs
│   ├── EnrollmentService.cs
│   ├── InstructorService.cs
│   ├── ReportService.cs
│   └── StudentService.cs
└── Program.cs
```

---

## 🧩 Models & Relationships

```
Category (1) ─── (∞) Course (∞) ───  (∞) Student    via Enrollment 
                    │
                    └── (1) Instructor
```

- **Many-to-Many** between `Student` and `Course` inplemented via **Enrollment** join table
- **One-to-Many**: `Instructor` -> `Courses`, `Category` -> `Courses`
- Relationships configured in `AppDbContext.OnModelCreating(…)`. 

---

## 🧾 Properties of Models

- **StudentModel**
  - `int Id`, `string FullName`, `string Email`
  - `ICollection<EnrollmentModel> Enrollments`
- **InstructorModel**
  - `int Id`, `string FullName`, `string Email`
  - `ICollection<CourseModel> Courses`
- **CategoryModel**
  - `int Id`, `string Name`
  - `ICollection<CourseModel> Courses`
- **CourseModel**
  - `int Id`, `string Title`, `string Description`, `decimal Price`
  - `int InstructorId`, `InstructorModel Instructor`
  - `int CategoryId`, `CategoryModel Category`
  - `ICollection<EnrollmentModel> Enrollments`
- **EnrollmentModel**
  - `int Id`
  - `int StudentId`, `StudentModel Student`
  - `int CourseId`, `CourseModel Course` 

---

## 🧠 Services Overview

- **BaseService<T>**
  - `Add(T entity)`, `Update(T entity)`, `T? GetById(int id)`, `List<T> GetAll()`
- **StudentService : BaseService<StudentModel>**
  - `Delete(int id)` ➜ removes student + their enrollments  
  - `GetStudentsWithoutCourses()`  
- **InstructorService : BaseService<InstructorModel>**
- **CategoryService : BaseService<CategoryModel>**
- **CourseService : BaseService<CourseModel>**
  - `GetCoursesUnderPrice(decimal maxPrice)` ➜ `{ Title, Price }`
- **EnrollmentService : BaseService<EnrollmentModel>**
- **ReportService**
  - `GetCoursesWithInstructors()` ➜ `{ Title, InstructorName }`  
  - `GetEnrollmentsCount()` ➜ `{ Title, StudentCount }`  
  - `GetStudentsWithCourses()` ➜ `StudentModel` + `Enrollments.Course`  
  - `GetCourseWithStudents(int id)` ➜ `CourseModel` + `Enrollments.Student`  
  - `GetTop3CoursesByEnrollments()` ➜ `{ Title, Count }` 

---

## 🧭 Console Flow

```
[MAIN MENU]
  1) Student Menu
  2) Category & Instructor Management
  3) Course Menu
  4) Reports Menu
  5) Exit
```

**Recommended workflow**

1. **Add Category** → 2. **Add Instructor** → 3. **Add Course**  
4. **Add Student** → 5. **Enroll Student in Course** → 6. **Run Reports** 

---

## 🚀 Quick Start

```bash
# 1) Clone
git clone https
cd CourseManagementSystem

# 2) Ensure .NET SDK & EF Tools
dotnet --version
dotnet tool install --global dotnet-ef

# 3) Apply EF Core migrations (SQL Server LocalDB)
dotnet ef database update

# 4) Run
dotnet run
```

> Connection string lives in `AppDbContext.OnConfiguring` (LocalDB):  
> `Server=(localdb)\mssqllocaldb;Database=CourseManagementSystem;Trusted_Connection=True;`  
> You can adapt it for a full SQL Server instance if needed. 

---

## 🧰 Teck Stack
- 🧱 **C# .NET** (Console App)
- 🗄️ **Entity Framework Core** (with **Migrations**)
- 🐘 **SQL Server LocalDB**
- 🧮 **LINQ** queries + `Include`/`ThenInclude`
- 🖥️ **Console UI** with boxed menus & validated input
- 🧩 **Clean separation** across Data/Models/Services/Screens/Helpers

---

## 👀 Preview

```
╔══════════════════════════════════════════╗
║                MAIN MENU                 ║
╠══════════════════════════════════════════╣
║[1] Student Menu                          ║
║[2] Category & Instructor Management      ║
║[3] Course Menu                           ║
║[4] Reports Menu                          ║
║[5] Exit                                  ║
╚══════════════════════════════════════════╝
-> Select an option:
```

**Sample “View Students” table**

```
┌────┬────────────────────────────┬────────────────────────────────────┐
│ ID │        Full Name           │              Email                 │
├────┼────────────────────────────┼────────────────────────────────────┤
│  1 │ Mohamed Ahmed              │ mohamed@gmail.com                  │
│  2 │ Maria Amr                  │ maria@gmail.com                    │ 
└────┴────────────────────────────┴────────────────────────────────────┘
```

**Report: Top 3 Courses by Enrollments**

```
TOP 3 COURSES BY ENROLLMENTS
---------------------------------------------
Course Title                  |  Enrollments
---------------------------------------------
C# Fundamentals               |           12
SQL for Beginners             |            9
ASP.NET Core Essentials       |            7
---------------------------------------------
```

---

## 🧪 Example

```
# Add a Category
[Category Menu] -> Add Category
-> Enter Category Name: "Programming"

# Add an Instructor
[Instructor Menu] -> Add Instructor
-> Full Name: "Dr. Mostafa Saad"
-> Email: "mostafasaad@gamil.com"

# Add a Course
[Course Menu] -> Add Course
-> Title: "C++ Fundamentals"
-> Description: "Intro to C++"
-> Price: 1000.00
-> Instructor ID: 1
-> Category ID: 1

# Add Student
[Student Menu] -> Add Student
-> Full Name: "Mohamed Ahmed"
-> Email: "mohamed@gmail.com"

# Enroll Student
[Student Menu] -> Enroll Student in Course
-> Student ID: 1
-> Course ID: 1

# Reports
[Reports Menu] -> Enrollment count per course
```

---

## 🧠 What I Learned

- Modeling **1–N** and **N–N** relationships in EF Core with a join entity
- writing espressive **LINQ** queries with `Include`/`ThenInclude` for eager loading
- Building a **generic service layer** to reduce CRUD relationships
- Designing **console-first UX** (clear menus, aligend tables, helpful prompts)
- Organizing a solution for **maintainability** (Data/Models/Services/Screens/Helpers)
- Using **migrations** and **LocalDB** connection for quick persistence 

---

## 🔭 Future Enhancement

- ✅ Use the **“courses under price”** query in the UI (currently implemented at service level)  
- 🔍 Search & filters (by name, price range, category) + pagination in listings  
- 🧹 Stronger input validation, domain rules, and centralized error handling  
- 🧱 Introduce DTOs/mappers to separate UI from EF entities  
- 🧪 Unit tests for services and helpers  
- 🧾 Seed data for quick demos  
- ⚙️ Move connection string to configuration (appsettings) and support multiple environments  
- 📤 Export reports to CSV/JSON  
- 🧑‍💻 Consider moving to a web UI (ASP.NET Core MVC/Minimal APIs) later

---

## 🤍 Task Outline in Breakin Point (Student Activity)

📎 [Task Outline (Google Drive)](https://drive.google.com/drive/folders/1bymBuYNscCCfwwqLD2zsopTTDEiqJDAX)

📸 [Archived Copy at submission time (Google Drive)](https://drive.google.com/drive/u/1/folders/1sb7paWmxPK0UtUOy_JzGELNE5tkZX3az)

Made with ❤️ by **Kenzy Ragab**

Feel free to **fork**, **use**, or **contribute** to this project!
