<div align="center">

# PokeStats V1

**(https://github.com/Enrique-Mercado) · Mario Mercado Software Engineering**

Una Pokédex interactiva construida con ASP.NET Core MVC — consumiendo la PokéAPI pública para entregar datos en tiempo real con una interfaz limpia y responsiva.

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=flat-square&logo=bootstrap&logoColor=white)](https://getbootstrap.com/)
[![PokéAPI](https://img.shields.io/badge/PokéAPI-v2-EF5350?style=flat-square)](https://pokeapi.co/)
[![Licencia](https://img.shields.io/badge/Licencia-MIT-blue?style=flat-square)](./LICENSE)
[![Estado](https://img.shields.io/badge/Estado-En%20Desarrollo-brightgreen?style=flat-square)]()

---

<!-- PLACEHOLDER DE CAPTURA DE PANTALLA -->
> 📸 *Captura de pantalla — Interfaz principal de búsqueda*
> `![Búsqueda principal](docs/screenshots/1. Pantalla de busqueda.png)`

</div>

---

## Descripción general

**PokeStats V1** es una aplicación web full-stack que expone la profundidad de la [PokéAPI](https://pokeapi.co/) a través de una interfaz intuitiva y bien estructurada. Más que una simple capa de visualización de datos, la aplicación está construida sobre un diseño de separación de responsabilidades que refleja soluciones .NET de nivel productivo — con capas de servicio dedicadas, mapeadores de respuesta y ViewModels fuertemente tipados.

El proyecto funciona como una Pokédex para jugadores competitivos y entusiastas, ofreciendo análisis de estadísticas, visualización de cadenas evolutivas y variantes de formas en una sola experiencia cohesiva.

---

## Funcionalidades

### Funcionalidad Principal
- 🔍 **Búsqueda con Autocompletado** — sugerencias en tiempo real mientras el usuario escribe
- 📊 **Visualización de Estadísticas Base** — barras de progreso animadas escaladas al techo de 255
- 🎨 **Tematización Dinámica por Tipo** — los colores de la tarjeta y la interfaz se adaptan al tipo primario del Pokémon
- 📱 **Totalmente Responsivo** — optimizado para escritorio, tablet y móvil

### Datos del Pokémon
- ✅ Estadísticas base (PS, Ataque, Defensa, Atq. Esp., Def. Esp., Velocidad)
- ✅ Habilidades incluyendo habilidades ocultas
- ✅ Iconos de tipo con indicadores emoji
- ✅ Número de Pokédex e información de especie

### Sistema de Evolución
- ✅ Cadenas evolutivas lineales
- ✅ Árboles de evolución ramificados (ej. Eevee, Slowpoke)
- ✅ Métodos de evolución — subida de nivel, piedra, intercambio, amistad y más
- ✅ Tarjetas de evolución clickeables para navegación instantánea

### Variantes de Forma
- ✅ Formas Regionales (Alola, Galar, Hisui, Paldea)
- ✅ Mega Evoluciones
- ✅ Formas Gigamax

### Experiencia de Desarrollo
- ✅ Manejo centralizado de errores
- ✅ Pipeline de mapeo seguro ante valores nulos
- ✅ Registro estructurado vía `Console` durante el desarrollo

---

## Arquitectura

La aplicación sigue el patrón **MVC (Modelo-Vista-Controlador)** con una estructura de capas extendida para mantener las responsabilidades claramente separadas.

```
POKESTATSV1/
│
├── Controllers/                  # Manejo de peticiones y enrutamiento
│   ├── HomeController.cs         # Página de inicio y entrada de búsqueda
│   └── PokemonController.cs      # Búsqueda y visualización principal
│
├── Models/                       # Entidades del dominio
│   ├── Pokemon.cs
│   ├── EvolucionPokemon.cs
│   └── ...
│
├── ViewModels/                   # Contratos de datos específicos de la vista
│   └── PokemonViewModel.cs
│
├── Services/                     # Lógica de negocio y consumo de API
│   ├── PokemonService.cs         # Datos principales del Pokémon
│   ├── PokemonListService.cs     # Datos de lista y autocompletado
│   ├── EvolutionService.cs       # Resolución de cadena evolutiva
│   └── SpeciesService.cs         # Especie y texto descriptivo
│
├── Mappers/                      # Traducción de respuesta API → Modelo de dominio
│   ├── PokemonMapper.cs
│   ├── EvolutionMapper.cs
│   └── Helpers/
│       └── PokemonHelpers.cs     # Utilidades compartidas (iconos, colores, etc.)
│
├── Views/                        # Plantillas Razor
│   ├── Home/
│   ├── Pokemon/
│   │   └── index.cshtml          # Vista de detalle principal del Pokémon
│   └── Shared/
│       ├── _Layout.cshtml
│       └── Error.cshtml
│
└── wwwroot/                      # Archivos estáticos
    └── css/
        └── pokemon.css
```

### Flujo de Datos

```
Petición del Usuario
        │
        ▼
Controlador  ──► Capa de Servicios  ──► PokéAPI (externa)
        │               │
        │               ▼
        │         Capa de Mappers  ──► Modelos de Dominio
        │
        ▼
Vista (Razor) ──► Respuesta HTML ──► Navegador
```

---

## Primeros Pasos

### Prerrequisitos

| Requisito | Versión |
|---|---|
| [.NET SDK](https://dotnet.microsoft.com/download) | 8.0 o superior |
| Conexión a internet | Requerida (llamadas a PokéAPI) |

### Instalación

```bash
# 1. Clonar el repositorio
git clone https://github.com/Enrique-Mercado/POKESTATSV1.git

# 2. Navegar al directorio del proyecto
cd POKESTATSV1

# 3. Restaurar dependencias
dotnet restore

# 4. Ejecutar la aplicación
dotnet run
```

La aplicación estará disponible en `http://localhost:5000`.

> **Nota:** No se requiere configuración de base de datos. Todos los datos se obtienen en tiempo real desde la [PokéAPI](https://pokeapi.co/) pública.

---

## Capturas de Pantalla

> 📸 *Búsqueda y Página Principal*
> `![Búsqueda principal](docs/screenshots/2. Busqueda de Pokemon.png)`

---

> 📸 *Detalle del Pokémon — Estadísticas*
> `![Búsqueda principal](docs/screenshots/3. Detalle de pokemon.png)`

---

> 📸 *Cadena Evolutiva — Lineal*
> `![Búsqueda principal](docs/screenshots/4. Cadena Evolutiva.png)`

---

> 📸 *Cadena Evolutiva — Ramificada*
> `![Búsqueda principal](docs/screenshots/5. Cadena evolutiva Ramificada.png)`

---

> 📸 *Formas Regionales y Mega Evoluciones*
>`![Búsqueda principal](docs/screenshots/6. Formas regionales y megas.png)`

---

## Hoja de Ruta

Las siguientes funcionalidades están planificadas para próximas versiones:

### V1.1 — Herramientas Competitivas
- [ ] Comparación de Pokémon lado a lado (1 vs 1)
- [ ] Selector de naturaleza con visualización de modificadores de stat (+10% / -10%)
- [ ] Tabla de efectividad y resistencia de tipos

### V1.2 — Calculadora de Daño
- [ ] Sliders de EV / IV con recálculo de stats en tiempo real
- [ ] Estimador de daño de movimientos contra un objetivo seleccionado

### V1.3 — Constructor de Equipos
- [ ] Construir y guardar un equipo de 6 Pokémon
- [ ] Análisis de cobertura de tipos del equipo
- [ ] Exportar equipo en formato compatible con Showdown

### V2.0 — Móvil
- [ ] Portar funcionalidades principales a **.NET MAUI** para Android e iOS
- [ ] Modo sin conexión con caché local

---

## Aprendizajes del Proyecto

Este proyecto fue desarrollado como aplicación práctica de los siguientes conceptos:

| Concepto | Aplicado en |
|---|---|
| Arquitectura ASP.NET Core MVC | Estructura completa del proyecto |
| C# async/await | Todas las llamadas a servicios de API |
| Consumo de API REST | Integración con PokéAPI vía `HttpClient` |
| Patrones de mapeo de respuesta | Capas de Mapper y Helper |
| Sintaxis Razor y enlace de datos | Todas las vistas `.cshtml` |
| Layout responsivo Bootstrap 5 | Todas las vistas y componentes |
| Programación segura ante nulos (`?.`, `??`) | Métodos de mapper y helper |
| LINQ | Filtrado y agrupación de datos |
| Algoritmos recursivos | Recorrido de cadena evolutiva |

---

## Acerca del Desarrollador

<div align="center">


Construido y mantenido por **Enrique Mercado** — Ingeniero de Software con base en Guadalajara, México.

[![GitHub](https://img.shields.io/badge/GitHub-Enrique--Mercado-181717?style=flat-square&logo=github)](https://github.com/Enrique-Mercado)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-enrique--mercado-0A66C2?style=flat-square&logo=linkedin)](https://linkedin.com/in/enrique-mercado)

</div>

---

## Licencia

Este proyecto está bajo la **Licencia MIT** — consulta el archivo [LICENSE](./LICENSE) para más detalles.

> Pokémon y todos los nombres relacionados son marcas registradas de Nintendo / Game Freak / The Pokémon Company.
> Este proyecto no está afiliado ni respaldado por Nintendo. Todos los datos de Pokémon provienen de la [PokéAPI](https://pokeapi.co/) pública.

---

<div align="center">

Hecho con 💙 por **Marxtopia** · Guadalajara, México

</div>
