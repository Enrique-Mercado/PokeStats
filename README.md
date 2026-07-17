<div align="center">
PokeStats V1

by MarxLabs · MarxLabs Software Engineering

An interactive Pokédex built with ASP.NET Core MVC — consuming the public PokéAPI to deliver real-time Pokémon data with a clean, responsive interface.



<!-- SCREENSHOT PLACEHOLDER -->

📸 Screenshot — Main search interface
<div align="center">
  <img src="docs/screenshots/1. Pantalla de busqueda.png" alt="Búsqueda y Página Principal" width="800"/>
</div>




</div>

Overview

PokeStats V1 is a full-stack web application that exposes the depth of the PokéAPI through a clean and intuitive interface. Rather than a simple data display layer, the application is architected around a separation-of-concerns design that mirrors production-grade .NET solutions — featuring dedicated service layers, response mappers, and strongly-typed ViewModels.

The project serves as a functional Pokédex for competitive players and enthusiasts, providing stat analysis, evolution chain visualization, and form variants in a single, cohesive experience.


Features

Core Functionality


🔍 Autocomplete Search — real-time suggestions as the user types
📊 Base Stat Visualization — animated progress bars scaled to the 255 stat ceiling
🎨 Dynamic Type Theming — card and UI colors adapt to the Pokémon's primary type
📱 Fully Responsive — optimized for desktop, tablet, and mobile viewports


Pokémon Data


✅ Base stats (HP, Attack, Defense, Sp. Atk, Sp. Def, Speed)
✅ Abilities including hidden abilities
✅ Type icons with emoji indicators
✅ Pokédex number and species information


Evolution System


✅ Linear evolution chains
✅ Branched evolution trees (e.g. Eevee, Slowpoke)
✅ Evolution methods — level-up, stone, trade, friendship, and more
✅ Clickable evolution cards for instant navigation


Form Variants


✅ Regional Forms (Alolan, Galarian, Hisuian, Paldean)
✅ Mega Evolutions
✅ Gigantamax Forms


Developer Experience


✅ Centralized error handling
✅ Null-safe mapping pipeline
✅ Structured logging via Console during development



Architecture

The application follows the MVC (Model-View-Controller) pattern with an extended layer structure to keep concerns cleanly separated.

POKESTATSV1/
│
├── Controllers/                  # Request handling and routing
│   ├── HomeController.cs         # Landing page and search entry
│   └── PokemonController.cs      # Core Pokémon lookup and display
│
├── Models/                       # Domain entities
│   ├── Pokemon.cs
│   ├── EvolucionPokemon.cs
│   └── ...
│
├── ViewModels/                   # View-specific data contracts
│   └── PokemonViewModel.cs
│
├── Services/                     # Business logic and API consumption
│   ├── PokemonService.cs         # Core Pokémon data
│   ├── PokemonListService.cs     # List and autocomplete data
│   ├── EvolutionService.cs       # Evolution chain resolution
│   └── SpeciesService.cs         # Species and flavor text
│
├── Mappers/                      # API response → Domain model translation
│   ├── PokemonMapper.cs
│   ├── EvolutionMapper.cs
│   └── Helpers/
│       └── PokemonHelpers.cs     # Shared utilities (icons, colors, etc.)
│
├── Views/                        # Razor templates
│   ├── Home/
│   ├── Pokemon/
│   │   └── index.cshtml          # Primary Pokémon detail view
│   └── Shared/
│       ├── _Layout.cshtml
│       └── Error.cshtml
│
└── wwwroot/                      # Static assets
    └── css/
        └── pokemon.css

Data Flow

User Request
    │
    ▼
Controller  ──► Service Layer  ──► PokéAPI (external)
    │               │
    │               ▼
    │           Mapper Layer  ──► Domain Models
    │
    ▼
View (Razor) ──► HTML Response ──► Browser


Getting Started

Prerequisites

RequirementVersion.NET SDK8.0 or laterInternet connectionRequired (PokéAPI calls)

Installation

bash# 1. Clone the repository
git clone https://github.com/Enrique-Mercado/POKESTATSV1.git

# 2. Navigate to the project directory
cd POKESTATSV1

# 3. Restore dependencies
dotnet restore

# 4. Run the application
dotnet run

The application will be available at http://localhost:5000.


Note: No database configuration is required. All data is fetched at runtime from the public PokéAPI.




Screenshots


📸 Search and Landing
<div align="center">
  <img src="docs/screenshots/2. Busqueda de Pokemon.png" alt="Búsqueda y Página Principal" width="800"/>
</div>





📸 Pokémon Detail — Stats
<div align="center">
  <img src="docs/screenshots/3. Detalle de pokemon.png" alt="Búsqueda y Página Principal" width="800"/>
</div>





📸 Evolution Chain — Linear
<div align="center">
  <img src="docs/screenshots/4. Cadena Evolutiva.png" alt="Búsqueda y Página Principal" width="800"/>
</div>





📸 Evolution Chain — Branched
<div align="center">
  <img src="docs/screenshots/5. Cadena evolutiva Ramificada.png" alt="Búsqueda y Página Principal" width="800"/>
</div>





📸 Regional Forms & Mega Evolutions
<div align="center">
  <img src="docs/screenshots/6. Formas regionales y megas.png" alt="Búsqueda y Página Principal" width="800"/>
</div>




Roadmap

The following capabilities are planned for upcoming releases:

V1.1 — Competitive Toolkit


 Side-by-side Pokémon comparison (1 vs 1)
 Nature selector with stat modifier visualization (+10% / -10%)
 Type effectiveness and resistance chart


V1.2 — Damage Calculator


 EV / IV input sliders with real-time stat recalculation
 Move damage estimator against a selected target


V1.3 — Team Builder


 Build and save a team of 6 Pokémon
 Team type coverage analysis
 Export team as Showdown-compatible format


V2.0 — Mobile


 Port core functionality to .NET MAUI for Android and iOS
 Offline mode with local caching



Learning Outcomes

This project was developed as a hands-on application of the following concepts:

ConceptApplied ThroughASP.NET Core MVC architectureFull project structureC# async/awaitAll API service callsREST API consumptionPokéAPI integration via HttpClientResponse mapping patternsMapper + Helper layersRazor syntax and data bindingAll .cshtml viewsBootstrap 5 responsive layoutAll views and componentsNull-safe programming (?., ??)Mapper and helper methodsLINQData filtering and groupingRecursive algorithmsEvolution chain traversal


About the Developer

<div align="center">
MarxLabs Software Engineering

Built and maintained by Enrique Mercado — Software Engineer based in Guadalajara, México.

Mostrar imagen
Mostrar imagen

</div>

License

This project is licensed under the MIT License — see the LICENSE file for details.


Pokémon and all related names are trademarks of Nintendo / Game Freak / The Pokémon Company.
This project is not affiliated with or endorsed by Nintendo. All Pokémon data is sourced from the public PokéAPI.




<div align="center">
Made with 💙 by MarxLabs · Guadalajara, México

</div>
