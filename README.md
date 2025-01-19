# IDoctor API

## Overview
This project is an ASP.NET Core 8.0-based backend API designed for managing healthcare data. 
The platform facilitates interactions between doctors and patients by enabling functionalities such as appointments, document sharing, and user account management.

## Features
- **Doctor Registration and Verification**: Doctors can register and upload verification documents for review and also they can manage their profiles.
- **Admin Management:**: Administrators can review and approve/reject doctor verification requests, ensuring only verified professionals access the platform.
- **Patient Registration:**: Patients can create accounts and manage their profiles.
- **Appointment Scheduling**: Patients can book appointments with registered doctors.
- **Document Management**: Patients can upload medical test results, which doctors can review, approve, or reject.
   - Approved results include the doctor’s comments or diagnosis, which are sent to the patient via email.
   - Rejected results trigger an email notification to the patient explaining that the doctor will not proceed with the analysis.
- **User Roles**: Includes role-based access for administrators, doctors, and patients.
- **Secure Authentication**: Uses JWT token for managing authentication and authorization.
- **CRUD Operations**:  For managing users, appointments, and related entities.
- **Real-Time Notifications**:
   - When a doctor registers, an email notification is sent to inform them about the verification process.
   - Upon verification, the doctor receives an email notifying whether their account has been approved or rejected.
   - When a doctor reviews a patient’s test result, the patient receives an email with the doctor's decision, whether approved with comments or rejected.


 ## Technologies Used
- **ASP.NET Core 8.0**: Backend framework.
- **Entity Framework Core**: ORM for database interactions using Code First approach.
- **Microsoft SQL Server**: Database system.
- **Onion Architecture**: Architectural pattern for organizing code.
- **Repository Design Pattern**: Pattern for data access layer abstraction.
- **Lazy Loading**: For deferred loading of related data.
- **Global Exception Handling**: Centralized error handling mechanism.
- **Fluent Validation**: For model validation.
- **AutoMapper**: For mapping between entities and DTOs.
- **JSON Web Token**: For secure user authentication and authorization.
- **Swagger**: For API documentation.

 ## Getting Started
 ### Prerequisites
- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

  ### Setting Up the Project

1. **Clone the Repository:**
   
   ```bash
   git clone https://github.com/shamilgurban/iDoctorBackend.git
   
2. **Set up the database:**
   
   Open the appsettings.Development.json file and configure the connection string:
   ```json
   "ConnectionStrings": {
   "DefaultConnection": "Server=YOUR_SERVER_NAME;initial Catalog=iDoctorDb;integrated Security=true; TrustServerCertificate=true;"
   },
   
3. **Restore Dependencies:**
   
   Ensure all required packages are installed:
   
   ```bash
      dotnet restore
   
4. **Build the project:**

   Build the project to ensure everything compiles correctly:
   
   ```bash
     dotnet build   
   
5. **Change Directory:**
   
   Navigate to the API Project directory and run the below command:
   ```bash
   cd Infrastructure/iDoctor.Persistence
     
6. **Apply Migrations:**
   
   Run the following command to apply migrations and create the database:
   
   ```bash
      dotnet ef database update

7. **Build the project:**

    Build the project again before running the project:
   
   ```bash
     dotnet build
   
8. **Run the project:**
   
   ```bash
     dotnet run

### Running the Project with Docker

1. **Ensure Docker is installed and running:**    
   Make sure Docker Desktop or Docker Engine is installed and running on your machine.

2. **Run the project using docker:**    
   Open the terminal in project folder and run below command

   ```bash
     docker-compose up


## API Documentation
After running the application, you can access the Swagger UI at:

- URL: https://localhost:5271/swagger/index.html

With Docker at:

- URL: https://localhost:8080/swagger/index.html

![Image](https://github.com/user-attachments/assets/093c6911-dce5-4cbe-a287-40cd2d1c2d55)

![Image](https://github.com/user-attachments/assets/cf30a382-8df6-465c-9690-9f691cda52df)

![Image](https://github.com/user-attachments/assets/cce6bdcb-73f1-49ec-b074-23179c4831d0)

![Image](https://github.com/user-attachments/assets/e2461a23-3b72-43ac-8c38-2d8c821756e1)

![Image](https://github.com/user-attachments/assets/4d1fdef6-c9c8-49ab-9166-54166698f42f)

![Image](https://github.com/user-attachments/assets/d44757fb-6732-498a-a4d0-e10e524debad)

![Image](https://github.com/user-attachments/assets/c8f9931b-da43-46fe-98ec-e8316e10774c)





