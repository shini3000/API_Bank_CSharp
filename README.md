
# API Bancaria en .NET 8

Esta es una API REST desarrollada en C# que ofrece funcionalidades bancarias básicas. Utiliza **JWT** para autenticación, sigue una arquitectura por capas, aplica principios **SOLID**, e implementa **inyección de dependencias**. Además, utiliza **MySQL** como base de datos relacional y **migrations de .NET** para la gestión del esquema de base de datos.

---

## Funcionalidades

### Usuarios
- **Crear usuarios:** Permite registrar nuevos usuarios en el sistema.
- **Iniciar sesión:** Genera un token JWT para la autenticación del usuario.

### Cuentas Bancarias
- **Crear cuentas bancarias:** Asocia una nueva cuenta bancaria a un usuario existente.
- **Obtener el saldo de una cuenta bancaria:** Consulta el saldo actual de una cuenta.
- **Depositar en otra cuenta bancaria:** Transfiere fondos de una cuenta a otra.
- **Obtener el registro de actividad de una cuenta bancaria:** Consulta las transacciones realizadas en una cuenta específica.

---

## Tecnologías y Herramientas Utilizadas

- **.NET 8:** Plataforma base del desarrollo.
- **MySQL:** Base de datos relacional utilizada para almacenar los datos de la aplicación.
- **JWT (JSON Web Tokens):** Para la autenticación segura de los usuarios.
- **Inyección de dependencias:** Para gestionar la creación y el ciclo de vida de las dependencias.
- **Middleware personalizado:** Para manejar tareas como el registro de solicitudes y la validación de tokens.
- **Entity Framework Core:** Para manejar la interacción con la base de datos y las migrations.

---

## Arquitectura

La aplicación sigue una **arquitectura por capas** para facilitar la mantenibilidad y escalabilidad del proyecto:
1. **Capa de API:** Controladores API que gestionan las solicitudes HTTP.
2. **Capa de Aplicación:** Lógica empresarial y validaciones.
3. **Capa de Dominio:** Entidades y contratos (interfaces) que representan las reglas del negocio.
4. **Capa de Infraestructura:** Acceso a datos y la configuración de la base de datos.

---

## Diagram Entity-Relationship (ER)


![image](https://github.com/user-attachments/assets/483f9e14-1753-4397-9a8e-d3a435c1f8a8)

## Instalación y Configuración

### Requisitos Previos
- .NET 8 SDK
- MySQL Server
- Un cliente para gestionar MySQL (como MySQL Workbench o DBeaver)

### Pasos de Instalación

1. **Clona el repositorio:**
   ```bash
   git clone https://github.com/shini3000/API_Bank_CSharp
   cd UserBankApi\API\UserBank

2. **Configuracion para conexion a base de datos**
   ```
   {
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=NumberDeBaseDeDatos;User=NombreDeUsuario;Password=tucontraseña;"
    }
   }

  Configurar en :
    appsettings.json
