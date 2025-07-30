# FundProcessSolution

Solution .NET multi-projets pour simuler un traitement de performance.

## Structure du projet

FundProcessSolution/
├── FundProcess.Lib         # Bibliothèque métier réutilisable (PerformanceService)
├── FundProcess.ConsoleDemo # Application console de démonstration de la lib
├── FundProcess.Tests       # Tests unitaires pour la bibliothèque
└── FundProcessDev.sln      # Fichier de solution .NET

## Lancer le projet de démo

cd FundProcess.ConsoleDemo
dotnet run

## Exécuter les tests

cd FundProcess.Tests
dotnet test

## Dépendances

- .NET SDK 8+
- xUnit (pour les tests)

## Objectif

Cette solution a pour but de séparer clairement :
- la logique métier (FundProcess.Lib)
- l'exécution (FundProcess.ConsoleDemo)
- les tests (FundProcess.Tests)

---

Projet initié le 30 juillet 2025 pour découvrir la structure modulaire de .NET avec C#.
