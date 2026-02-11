# Employee Management Console App

<img width="469" height="456" alt="image" src="https://github.com/user-attachments/assets/e079079f-733f-4477-8b79-c99eb2a04cbe" /></br>
<img width="464" height="45" alt="image" src="https://github.com/user-attachments/assets/68330833-4e4d-4d82-89ee-f4676e847738" /> </br>
<img width="351" height="181" alt="image" src="https://github.com/user-attachments/assets/df4dd94e-9643-4c65-9915-35f84f933437" />
<img width="301" height="171" alt="image" src="https://github.com/user-attachments/assets/a3d4723e-823c-45fc-829d-ba2bff45a3f4" />


*Example of the application in console view.*

## Description
This console application allows you to **create, read, update, and delete employees** (CRUD) using an **XML file** as a simple database.  
It is built with **C#** and demonstrates practical usage of XML manipulation and basic CRUD operations.

### Key Features
- **Create**: Add employees with automatically generated IDs  
- **Read**: Display a list of all employees  
- **Update**: Update employee details (name, age, role)  
- **Delete**: Remove employees by ID  
- Sort employees by ID  
- Clean and simple **console UI**  

---

## Technologies Used
- C# (.NET)  
- XML for data storage  
- Git / GitHub for version control  

---

## Installation
1. Clone the repository:
```bash
git clone https://github.com/USERNAME/REPO_NAME.git
```

## Usage

After running the application, you can manage employees using the following **console commands**:

### CRUD Operations

| Operation | Command             | Description                        |
|-----------|-------------------|-----------------------------------|
| Create    | `/add`             | Add a new employee                 |
| Read      | `/show`            | Display all employees              |
| Update    | `/update -fullname`| Update an employee's full name     |
| Update    | `/update -age`     | Update an employee's age           |
| Update    | `/update -role`    | Update an employee's role          |
| Delete    | `/delete`          | Remove an employee by ID           |

### Other Useful Commands

| Command | Description                          |
|---------|--------------------------------------|
| `/save` | Save all employee data to XML         |
| `/sort` | Sort and reassign employee IDs        |
| `/help` | Display help menu                     |
| `/clear`| Clear the console                     |
| `/exit` | Exit the application                  |

### Example Workflow

**1. Add an employee**

```text
> /add
Enter full name: John Doe
Enter age: 25
Enter role: Developer
Employee John Doe added.

