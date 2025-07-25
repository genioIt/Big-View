# Big-View
Pagina de valoracion en desarrollo

FRONT:

# La Tienda de Don Juan - Blazor Server

Este es un proyecto de e-commerce desarrollado con Blazor Server y Tailwind CSS que permite a los usuarios registrarse, iniciar sesión y navegar por la tienda.

## Características

- **Blazor Server** con SignalR para comunicación en tiempo real
- **Tailwind CSS** para diseño responsive y moderno
- **Validación de formularios** con DataAnnotations
- **Consumo de API REST** para autenticación y gestión de usuarios
- **Interfaz responsive** que se adapta a diferentes dispositivos
- **Diseño moderno** con gradientes y animaciones

## Páginas Disponibles

### 1. Página Principal (`/`)
- Página de bienvenida con el logo de "La Tienda de Don Juan"
- Navegación principal con enlaces a:
  - Iniciar Sesión
  - Registro
  - Carrito de Compras
- Sección de características de la tienda
- Diseño atractivo con gradientes y elementos visuales

### 2. Página de Inicio de Sesión (`/login`)
- Formulario de autenticación con email y contraseña
- Consume el endpoint: `POST http://localhost:5111/api/Auth/login`
- Parámetros: `{"email": "string", "password": "string"}`
- Validación en tiempo real
- Mensajes de éxito y error
- Redirección automática después del login exitoso
- Almacenamiento del token de autenticación

### 3. Página de Registro (`/register`)
- Permite registrar nuevos usuarios
- Consume el endpoint: `POST http://localhost:5111/api/Users/CreateUser`
- Campos requeridos:
  - Nombre completo (máximo 100 caracteres)
  - Email (formato válido)
  - Contraseña (mínimo 6 caracteres)
- Diseño consistente con la página de login

### 4. Página del Carrito (`/cart`)
- Interfaz del carrito de compras (actualmente muestra carrito vacío)
- Diseño preparado para futuras funcionalidades de e-commerce
- Enlaces para continuar comprando

## Estructura del Proyecto

```
BlazorUserManagement/
├── Models/
│   └── User.cs                 # Modelo de usuario con validaciones
├── Services/
│   └── UserService.cs          # Servicio para consumir la API
├── Pages/
│   ├── Index.razor            # Página de inicio
│   ├── Register.razor         # Página de registro
│   └── Update.razor           # Página de actualización
├── Shared/
│   ├── MainLayout.razor       # Layout principal
│   └── NavMenu.razor          # Menú de navegación
└── wwwroot/css/
    ├── app.css               # Estilos base con Tailwind
    └── site.css              # Estilos compilados
```

## Configuración de la API

El proyecto está configurado para consumir una API que debe estar ejecutándose en:
```
http://localhost:5111
```

### Endpoints esperados:

1. **Crear Usuario**
   - URL: `POST /api/Users/CreateUser`
   - Body: `{"id": 0, "name": "string", "email": "string", "passwordHash": "string"}`

2. **Actualizar Usuario**
   - URL: `PUT /api/Users/UpdateUser/{id}`
   - Body: `{"id": 0, "name": "string", "email": "string", "passwordHash": "string"}`

## Instalación y Ejecución

### Prerrequisitos
- .NET 8.0 SDK
- Node.js (para Tailwind CSS)

### Pasos para ejecutar:

1. **Restaurar dependencias de .NET:**
   ```bash
   dotnet restore
   ```

2. **Instalar dependencias de Node.js:**
   ```bash
   npm install
   ```

3. **Compilar estilos de Tailwind CSS:**
   ```bash
   npx tailwindcss -i ./wwwroot/css/app.css -o ./wwwroot/css/site.css --watch
   ```

4. **Ejecutar la aplicación:**
   ```bash
   dotnet run
   ```

5. **Abrir en el navegador:**
   ```
   https://localhost:7xxx (el puerto se mostrará en la consola)
   ```

## Desarrollo

### Para desarrollo con recarga automática de estilos:
```bash
# En una terminal
npx tailwindcss -i ./wwwroot/css/app.css -o ./wwwroot/css/site.css --watch

# En otra terminal
dotnet watch run
```

## Tecnologías Utilizadas

- **ASP.NET Core 8.0**
- **Blazor Server**
- **SignalR** (incluido automáticamente con Blazor Server)
- **Tailwind CSS 3.3**
- **DataAnnotations** para validación
- **HttpClient** para consumo de API

## Características de la Interfaz

- **Diseño responsive** que se adapta a móviles, tablets y desktop
- **Validación en tiempo real** de formularios
- **Indicadores de carga** durante las operaciones
- **Mensajes de éxito y error** con estilos diferenciados
- **Navegación intuitiva** entre páginas
- **Estilos modernos** con Tailwind CSS

## Notas Importantes

- Asegúrate de que la API esté ejecutándose en `http://localhost:5111` antes de usar la aplicación
- Los formularios incluyen validación tanto del lado cliente como del servidor
- La aplicación maneja errores de conexión y muestra mensajes apropiados al usuario
- SignalR está configurado automáticamente para la comunicación en tiempo real entre cliente y servidor



BACKEND:

# E-Commerce Web API

Una API REST completa para un sistema de comercio electrónico desarrollada con .NET 8 y arquitectura limpia, que incluye autenticación JWT, gestión de productos, carrito de compras y procesamiento de órdenes.

## 🏗️ Arquitectura

El proyecto sigue los principios de **Clean Architecture** con separación clara de responsabilidades:

```
├── WebApiECommerce/                 # Capa de Presentación (API)
├── WebApiEComerce.Application/      # Capa de Aplicación (Lógica de negocio)
├── WebApiECommerce.Domain/          # Capa de Dominio (Entidades y contratos)
├── WebApiECommerce.Infrastructure/  # Capa de Infraestructura (Datos y servicios externos)
├── Database/                        # Scripts de base de datos
└── FrontEnd/                        # Aplicación cliente (Blazor)
```

## 🚀 Tecnologías Utilizadas

### Backend
- **.NET 8** - Framework principal
- **ASP.NET Core Web API** - API REST
- **Entity Framework Core 5.0** - ORM para acceso a datos
- **SQL Server** - Base de datos
- **AutoMapper** - Mapeo de objetos
- **JWT Bearer Authentication** - Autenticación y autorización
- **Swagger/OpenAPI** - Documentación de API

### Frontend
- **Blazor** - Framework de UI
- **Angular** (configurado para CORS en puerto 4200)

## 📊 Modelo de Datos

La base de datos incluye las siguientes entidades principales:

- **Users** - Gestión de usuarios del sistema
- **Products** - Catálogo de productos con categorías, precios y stock
- **ProductCategories** - Categorización de productos
- **CartItems** - Elementos del carrito de compras
- **Orders** - Órdenes de compra
- **OrderItems** - Detalles de productos en cada orden
- **UserSessions** - Gestión de sesiones de usuario

## 🔧 Configuración y Instalación

### Prerrequisitos
- .NET 8 SDK
- SQL Server (LocalDB o instancia completa)
- Visual Studio 2022 o VS Code

### Configuración de Base de Datos

1. Ejecutar el script de base de datos:
```sql
-- Ejecutar Database/ECommerceDB.sql en SQL Server Management Studio
```

2. Configurar la cadena de conexión en `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ECommerceDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Instalación y Ejecución

1. **Clonar el repositorio**
```bash
git clone [url-del-repositorio]
cd WebApiECommerce
```

2. **Restaurar dependencias**
```bash
dotnet restore
```

3. **Ejecutar la aplicación**
```bash
dotnet run --project WebApiECommerce
```

4. **Acceder a la documentación**
- Swagger UI: `https://localhost:5001/swagger`
- API Base URL: `https://localhost:5001/api`

## 🔐 Autenticación

La API utiliza **JWT (JSON Web Tokens)** para autenticación:

### Configuración JWT
```json
{
  "JwtSettings": {
    "SecretKey": "TuClaveSuperSecretaDe32CaracteresMinimo",
    "Issuer": "MyApp",
    "Audience": "MyAppUsers",
    "ExpirationInMinutes": 60
  }
}
```

### Endpoints de Autenticación
- `POST /api/auth/login` - Iniciar sesión
- `POST /api/auth/register` - Registrar usuario
- `POST /api/auth/logout` - Cerrar sesión

## 📋 Endpoints Principales

### Usuarios
- `GET /api/users` - Listar usuarios
- `GET /api/users/{id}` - Obtener usuario por ID
- `PUT /api/users/{id}` - Actualizar usuario
- `DELETE /api/users/{id}` - Eliminar usuario

### Productos
- `GET /api/products` - Listar productos
- `GET /api/products/{id}` - Obtener producto por ID
- `POST /api/products` - Crear producto
- `PUT /api/products/{id}` - Actualizar producto
- `DELETE /api/products/{id}` - Eliminar producto

### Categorías
- `GET /api/productcategories` - Listar categorías
- `POST /api/productcategories` - Crear categoría
- `PUT /api/productcategories/{id}` - Actualizar categoría

### Carrito de Compras
- `GET /api/cart` - Obtener carrito del usuario
- `POST /api/cart` - Agregar producto al carrito
- `PUT /api/cart/{id}` - Actualizar cantidad
- `DELETE /api/cart/{id}` - Remover del carrito

### Órdenes
- `GET /api/orders` - Listar órdenes del usuario
- `GET /api/orders/{id}` - Obtener orden por ID
- `POST /api/orders` - Crear nueva orden
- `PUT /api/orders/{id}` - Actualizar estado de orden

## 🔒 Seguridad

### Características de Seguridad Implementadas
- **Autenticación JWT** con tokens seguros
- **Autorización basada en roles**
- **Validación de entrada** en todos los endpoints
- **Hashing de contraseñas** para almacenamiento seguro
- **CORS configurado** para frontend Angular
- **Gestión de sesiones** con tokens de expiración

### Headers de Seguridad
```http
Authorization: Bearer {jwt-token}
Content-Type: application/json
```

## 🧪 Testing

Para probar la API puedes usar:

1. **Swagger UI** (recomendado para desarrollo)
2. **Postman** o **Insomnia**
3. **Archivo HTTP** incluido: `WebApiECommerce.http`

### Ejemplo de Petición
```http
POST https://localhost:5001/api/auth/login
Content-Type: application/json

{
  "email": "usuario@ejemplo.com",
  "password": "contraseña123"
}
```

## 📁 Estructura del Proyecto

### WebApiECommerce (API Layer)
- `Controllers/` - Controladores de la API
- `Program.cs` - Configuración de la aplicación
- `appsettings.json` - Configuración de la aplicación

### WebApiEComerce.Application (Application Layer)
- `App/` - Servicios de aplicación
- `Interface/` - Contratos de servicios
- `Mapper/` - Configuración de AutoMapper
- `Model/` - DTOs y modelos de vista
- `Entity/` - Entidades de aplicación

### WebApiECommerce.Domain (Domain Layer)
- `Entity/` - Entidades de dominio
- `Interface/` - Contratos del dominio
- `Model/` - Modelos de dominio
- `Enum/` - Enumeraciones

### WebApiECommerce.Infrastructure (Infrastructure Layer)
- `Persistence/` - Contexto de Entity Framework
- `Repository/` - Implementación de repositorios
- `Security/` - Servicios de seguridad y JWT

## 🚀 Despliegue

### Configuración para Producción

1. **Actualizar appsettings.Production.json**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "[cadena-de-conexion-produccion]"
  },
  "JwtSettings": {
    "SecretKey": "[clave-secreta-segura]"
  }
}
```

2. **Publicar la aplicación**
```bash
dotnet publish -c Release -o ./publish
```

3. **Configurar IIS o servidor web**

## 🤝 Contribución

1. Fork el proyecto
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## 📝 Notas de Desarrollo

### Patrones Implementados
- **Repository Pattern** - Abstracción de acceso a datos
- **Dependency Injection** - Inversión de control
- **DTO Pattern** - Transferencia de datos
- **Clean Architecture** - Separación de capas

### Mejoras Futuras
- [ ] Implementar cache con Redis
- [ ] Agregar logging con Serilog
- [ ] Implementar rate limiting
- [ ] Agregar tests unitarios y de integración
- [ ] Implementar notificaciones en tiempo real
- [ ] Agregar métricas y monitoreo

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

## 📞 Contacto

Para preguntas o soporte, por favor contacta al equipo de desarrollo.
: 3008934507 - Whatapp: 3158121879

**Desarrollado con ❤️ usando .NET 8 y Clean Architecture**