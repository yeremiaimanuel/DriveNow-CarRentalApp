# 🚗 DriveNow – Car Rental Management System

**DriveNow** is a car rental desktop application developed using **C# Windows Forms (.NET Framework)** with integration to **SQL Server** and **Crystal Reports**.  
It supports multi-role access such as **Staff** and **Customer**, allowing users to perform car bookings, manage vehicles, and view reports.

---

## 🛠️ Tech Stack

- **C#** – Main programming language  
- **.NET Framework (Windows Forms)** – UI framework  
- **SQL Server** – Database management  
- **Crystal Reports** – For generating reports  
- **Visual Studio** – Development environment  

---

## 🚀 Getting Started

### 1. Clone the Repository
`git clone https://github.com/yeremiaimanuel/DriveNow-CarRentalApp.git`

2. Restore the Database
- Open SQL Server Management Studio (SSMS)
- Right-click Databases → Import Data-tier Application
- Browse to the file: db_drivenow.bacpac
- Finish the wizard to create the db_drivenow database
3. Configure the Connection
In DB/dbConnection.cs, modify the connection string:
`string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=db_drivenow;Integrated Security=True;TrustServerCertificate=True";`
4. Run the Application
- Open DriveNow.sln in Visual Studio
- Build the solution: Ctrl + Shift + B
- Run the application: F5
---
📄 License
This project is open-source under the MIT License.
🔐 Login Form
![Login Form](https://github.com/user-attachments/assets/80124b54-843b-4e21-96f4-1ea797383ed9)
👤 Customer Interface
![Customer Interface](https://github.com/user-attachments/assets/0301a310-6289-4eb2-af65-b3d61e37a50a)
🧑‍💼 Staff Interface
![Staff Interface](https://github.com/user-attachments/assets/5afdfae0-4e53-478f-a7fb-d4be643a1a7c)
📊 Crystal Report
![CrystalReport](https://github.com/user-attachments/assets/6c4540fb-4e85-4ed0-affd-0ca8d6785814)
🚘 View Car – Staff
![ViewCar_Staff](https://github.com/user-attachments/assets/8e988387-243d-426e-b794-2c75e8687762)
