# C# To-Do Application

A simple to-do application built with C# for managing tasks and activities.

## Overview

This project is a console-based to-do application that allows users to:
- Add new tasks
- Mark tasks as complete
- View all tasks
- Delete tasks

## Features

- Simple and intuitive command-line interface
- Persistent task storage using JSON files
- Task management with completion tracking
- Clean and maintainable code structure

## Getting Started

These instructions will get you a copy of the project up and running on your local machine.

### Prerequisites

- .NET SDK 6.0 or later
- A compatible operating system (Windows, macOS, or Linux)

### Installation

1. Clone the repository
2. Navigate to the project directory
3. Restore dependencies: `dotnet restore`
4. Build the project: `dotnet build`
5. Run the application: `dotnet run`

## Project Structure

```
.
├── src/
│   ├── Program.cs
│   ├── Models/
│   │   └── Task.cs
│   ├── Services/
│   │   └── TaskService.cs
│   └── Utils/
│       └── TaskStorage.cs
├── tests/
│   └── TaskServiceTests.cs
├── README.md
└── TodoApp.sln
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License.