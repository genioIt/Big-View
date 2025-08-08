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

---

**Desarrollado con ❤️ usando .NET 8 y Clean Architecture**