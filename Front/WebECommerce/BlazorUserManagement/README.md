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