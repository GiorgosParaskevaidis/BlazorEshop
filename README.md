# BlazorEshop

This is the Blazor WebAssembly (WASM) Eshop project.

## Description

BlazorEshop is a sample e-commerce application built with Blazor WebAssembly. It demonstrates the use of Blazor for building a modern web application with a rich user interface, secure authentication, and integration with a backend server.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any other database you are using)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)

## GitHub Repository

[Click here to view the project on GitHub](https://github.com/GiorgosParaskevaidis/BlazorEshop)

## Installation Instructions

1.  **Clone the repository**:
   git clone https://github.com/GiorgosParaskevaidis/BlazorEshop.git
   cd BlazorEshop

2. Open SSMS and create a user giorgos1 with password 123456 (at least DB creator rights).
3. Open VS2022 and Package manager inside Blazoreshop.Server and run dotnet ef database update.

## Instruction for use (IFU)

1. Admin is predifined  as miky@mouse.com and password: mytopsecretpass
2. You can create as many customers as you want.

## Project Structure

BlazorEshop.Client: Blazor WebAssembly standalone project.
BlazorEshop.Server: ASP.NET Core Web API project.
BlazorEshop.Shared: Shared models and DTOs between Client and Server.

Contact
For any issues or inquiries, please contact us at georgios.paraske@gmail.com
