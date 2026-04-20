# Project Overview: Repaso2

`Repaso2` is a C# Windows Forms application designed for managing a vehicle rental system. It serves as a review project (indicated by the name "Repaso2") for core C# concepts including Object-Oriented Programming (OOP), WinForms UI development, and data persistence using both plain text and JSON formats.

## Key Technologies
- **Language:** C#
- **Framework:** .NET Framework 4.7.2
- **UI:** Windows Forms (WinForms)
- **Data Persistence:** Manual file I/O (System.IO) for `.txt` files and `Newtonsoft.Json` for `.json` files.

## Architecture
The project follows a simple layered architecture:

### 1. Models (Data Structures)
- `Cliente.cs`: Represents a client with properties like Nit, Nombre, and Direccion.
- `Vehiculo.cs`: Represents a vehicle with properties like Placa, Marca, Modelo, Color, and PrecioKm.
- `Alquiler.cs`: Represents a rental transaction, linking a client (Nit) and a vehicle (Placa), with dates and kilometers traveled.
- `Reporte.cs`: A data transfer object (DTO) used to aggregate data for display or reporting.

### 2. Persistence Layer (Data Access)
- `ClientePersistencia.cs`: Handles reading client data from `Clientes.txt`.
- `VehiculoPersistencia.cs`: Handles reading and writing vehicle data to `Vehiculos.txt`.
- `AlquilerPersistencia.cs`: Handles reading and writing rental data to both `Alquileres.txt` and `Alquileres.json`.

### 3. Presentation Layer (UI)
- `Form1.cs`: The main entry point for the user interface. It uses `TabControl` to separate different management areas (Clients, Vehicles, Rentals) and `DataGridView` for data display.
- `Program.cs`: The standard entry point for a WinForms application.

## Building and Running
To build and run the project:
1.  **Requirement:** .NET Framework 4.7.2 and MSBuild (or Visual Studio).
2.  **Dependencies:** Ensure `Newtonsoft.Json` is restored via NuGet (check `packages.config`).
3.  **Command:**
    - Using Visual Studio: Open `Repaso2.slnx` and press F5.
    - Using Command Line:
      ```powershell
      msbuild Repaso2.csproj
      .\bin\Debug\Repaso2.exe
      ```

## Development Conventions
- **Naming:** Follows standard C# PascalCase for classes and properties, and camelCase for private fields (often without underscores, e.g., `string placa;`).
- **Data Storage:** Data is stored in the application's execution directory in files like `Clientes.txt`, `Vehiculos.txt`, `Alquileres.txt`, and `Alquileres.json`.
- **UI Binding:** Data is bound to `DataGridView` controls by setting their `DataSource` property, often resetting it to `null` first to refresh the view.

## Key Files
- `Repaso2.csproj`: Project configuration and dependencies.
- `Form1.cs`: Central logic for event handling and UI orchestration.
- `*Persistencia.cs`: Classes responsible for file operations.
- `packages.config`: Lists NuGet dependencies (`Newtonsoft.Json`).
