<div align="center">

<!-- Animated header banner (local file) -->
<img src="assets/banner.svg" alt="Employee Manager XML banner" width="100%"/>

<!-- Animated typing line -->
<a href="https://github.com/MIhajloS07/EmployeeManagerXML">
  <img src="https://readme-typing-svg.demolab.com?font=Fira+Code&weight=500&size=20&pause=1000&color=00B4DB&center=true&vCenter=true&width=620&lines=Create+%E2%80%A2+Read+%E2%80%A2+Update+%E2%80%A2+Delete;Zero+dependencies.+Zero+database+server.;XML+as+a+lightweight+persistence+layer;Built+with+C%23+and+.NET" alt="Typing animation" />
</a>

<br/>

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![XML](https://img.shields.io/badge/XML-Storage-FF6600?style=for-the-badge&logo=xml&logoColor=white)](https://www.w3.org/XML/)
[![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)](https://visualstudio.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)](LICENSE)

![Stars](https://img.shields.io/github/stars/MIhajloS07/EmployeeManagerXML?style=flat-square&color=gold)
![Forks](https://img.shields.io/github/forks/MIhajloS07/EmployeeManagerXML?style=flat-square)
![Last commit](https://img.shields.io/github/last-commit/MIhajloS07/EmployeeManagerXML?style=flat-square)
![Repo size](https://img.shields.io/github/repo-size/MIhajloS07/EmployeeManagerXML?style=flat-square)
![Top language](https://img.shields.io/github/languages/top/MIhajloS07/EmployeeManagerXML?style=flat-square)

</div>

---

## 📑 Table of Contents

- [Overview](#-overview)
- [Preview](#-preview)
- [Features](#-features)
- [Architecture](#-architecture)
- [Data Model](#-data-model)
- [Tech Stack](#-tech-stack)
- [Getting Started](#-getting-started)
- [Usage](#-usage)
- [Example Session](#-example-session)
- [Project Structure](#-project-structure)
- [Design Decisions](#-design-decisions)
- [Roadmap](#-roadmap)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🎯 Overview

**Employee Manager XML** is a terminal-based application for managing employee records. It implements the full **CRUD** lifecycle (Create, Read, Update, Delete) on top of a plain **XML file**, which acts as a lightweight, human-readable database.

The project is a practical demonstration of:

- **XML parsing and manipulation** in C# (loading, querying, mutating and persisting a document)
- **Command-driven console interfaces** with a slash-command syntax
- **Stateful ID management**, including auto-generation and re-sequencing
- Persistence without any external database engine

> 💡 **Why XML?** It requires no server, no setup and no extra packages. The data file can be opened, diffed and version-controlled with any text editor, which makes it ideal for learning, prototyping and small tools.

---

## 🖼 Preview

<div align="center">

<img width="469" height="456" alt="Application main view" src="https://github.com/user-attachments/assets/e079079f-733f-4477-8b79-c99eb2a04cbe" />
<br/><br/>
<img width="464" height="45" alt="Command prompt" src="https://github.com/user-attachments/assets/68330833-4e4d-4d82-89ee-f4676e847738" />
<br/><br/>
<img width="351" height="181" alt="Employee list output" src="https://github.com/user-attachments/assets/df4dd94e-9643-4c65-9915-35f84f933437" />
&nbsp;&nbsp;
<img width="301" height="171" alt="Update flow" src="https://github.com/user-attachments/assets/a3d4723e-823c-45fc-829d-ba2bff45a3f4" />

<sub><i>The application running in a console window.</i></sub>

</div>

---

## ✨ Features

| | Feature | Details |
|---|---|---|
| ➕ | **Create** | Add employees; unique IDs are generated automatically |
| 📋 | **Read** | List every employee in a clean, aligned console view |
| ✏️ | **Update** | Modify full name, age or role independently |
| 🗑 | **Delete** | Remove an employee by ID |
| 🔢 | **Sort / re-index** | Sort by ID and reassign sequential IDs |
| 💾 | **Explicit save** | Persist the in-memory state to XML on demand |
| 🧭 | **Built-in help** | `/help` lists every available command |
| 🧹 | **Console utilities** | `/clear` and `/exit` for a smooth session |

---

## 🏗 Architecture

```mermaid
flowchart LR
    U([👤 User]) -->|types /command| C[Console UI<br/>input loop]
    C --> P{Command<br/>parser}
    P -->|/add| A[Create]
    P -->|/show| R[Read]
    P -->|/update| M[Update]
    P -->|/delete| D[Delete]
    P -->|/sort| S[Sort / re-index]
    A & M & D & S --> L[(In-memory<br/>employee list)]
    R --> L
    L <-->|load / /save| X[(employees.xml)]
    L --> O[Formatted output]
    O --> U
```

**Flow of a session**

1. On startup the XML file is **loaded** into memory.
2. The app enters a **read–parse–execute** loop and waits for a slash command.
3. Each command mutates or queries the in-memory collection.
4. `/save` **serializes** the current state back to the XML file.

---

## 🗂 Data Model

Each employee is stored as an XML element with the following attributes:

| Field | Type | Description |
|-------|------|-------------|
| `Id` | `int` | Unique identifier, auto-generated |
| `FullName` | `string` | Employee's first and last name |
| `Age` | `int` | Employee's age |
| `Role` | `string` | Job title / position |

Illustrative shape of the stored document *(the exact element names are defined in the source code)*:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Employees>
  <Employee>
    <Id>1</Id>
    <FullName>John Doe</FullName>
    <Age>25</Age>
    <Role>Developer</Role>
  </Employee>
</Employees>
```

---

## 🧰 Tech Stack

<div align="center">

| Layer | Technology |
|-------|-----------|
| Language | **C#** |
| Runtime | **.NET** |
| Persistence | **XML** (`System.Xml` / LINQ to XML) |
| IDE | **Visual Studio** |
| Version control | **Git & GitHub** |

</div>

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (match the target framework in the project's `.csproj`)
- *Optional:* [Visual Studio](https://visualstudio.microsoft.com/) 2022 or newer

Verify your installation:

```bash
dotnet --version
```

### Installation

**1. Clone the repository**

```bash
git clone https://github.com/MIhajloS07/EmployeeManagerXML.git
cd EmployeeManagerXML
```

**2. Build**

```bash
dotnet build "xml projekat.sln"
```

**3. Run**

```bash
dotnet run --project "xml projekat"
```

<details>
<summary><b>🪟 Prefer Visual Studio?</b></summary>

1. Open `xml projekat.sln`
2. Set the console project as the startup project
3. Press <kbd>F5</kbd> (debug) or <kbd>Ctrl</kbd> + <kbd>F5</kbd> (run without debugging)

</details>

---

## 🎮 Usage

Once running, everything is controlled through **slash commands**.

### CRUD Operations

| Operation | Command | Description |
|-----------|---------|-------------|
| ➕ Create | `/add` | Add a new employee |
| 📋 Read | `/show` | Display all employees |
| ✏️ Update | `/update -fullname` | Update an employee's full name |
| ✏️ Update | `/update -age` | Update an employee's age |
| ✏️ Update | `/update -role` | Update an employee's role |
| 🗑 Delete | `/delete` | Remove an employee by ID |

### Utility Commands

| Command | Description |
|---------|-------------|
| `/save` | Save all employee data to the XML file |
| `/sort` | Sort employees and reassign IDs |
| `/help` | Display the help menu |
| `/clear` | Clear the console |
| `/exit` | Exit the application |

> ⚠️ **Tip:** run `/save` before `/exit` so your changes are written to disk.

---

## 🧪 Example Session

**Adding an employee**

```text
> /add
Enter full name: John Doe
Enter age: 25
Enter role: Developer
Employee John Doe added.
```

**Listing employees**

```text
> /show
```

**Updating a role**

```text
> /update -role
```

**Persisting changes**

```text
> /save
> /exit
```

---

## 📁 Project Structure

```text
EmployeeManagerXML/
├── xml projekat/          # C# console project (source code)
├── xml projekat.sln       # Visual Studio solution
├── .gitattributes
├── .gitignore
├── LICENSE                # MIT
└── README.md
```

---

## 🧠 Design Decisions

- **XML over a database engine**: removes all setup friction and keeps data transparent and diffable.
- **Slash-command interface**: a consistent, discoverable syntax that is easy to extend with new commands.
- **In-memory working set + explicit `/save`**: fast operations and a clear persistence boundary.
- **Re-sequencing IDs via `/sort`**: keeps identifiers contiguous after deletions.

---

## 🗺 Roadmap

- [x] Full CRUD over XML
- [x] Auto-generated IDs
- [x] Sort and re-index
- [ ] Input validation (age range, empty fields)
- [ ] Search and filter (by name, role, age)
- [ ] Auto-save on exit
- [ ] Export to CSV / JSON
- [ ] Unit tests (xUnit)
- [ ] CI pipeline with GitHub Actions

---

## 🤝 Contributing

Contributions, issues and feature requests are welcome.

1. **Fork** the project
2. Create a feature branch: `git checkout -b feature/amazing-feature`
3. Commit your changes: `git commit -m "Add amazing feature"`
4. Push the branch: `git push origin feature/amazing-feature`
5. Open a **Pull Request**

---

## 📄 License

Distributed under the **MIT License**. See [`LICENSE`](LICENSE) for details.

---

<div align="center">

**Made with ❤️ and C# by [MIhajloS07](https://github.com/MIhajloS07)**

⭐ If you found this project useful, consider giving it a star!

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:00B4DB,100:512BD4&height=100&section=footer" width="100%" alt="footer"/>

</div>
