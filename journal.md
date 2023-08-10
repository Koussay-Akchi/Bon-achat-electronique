Sujet :

Le projet consiste à développer une application web pour la gestion des bons d'achat electroniques pour une entreprise ayant déjà une clientèle utilisant des cartes électroniques.
L'objectif principal est de créer une plateforme conviviale permettant la gestion des bons, leurs types(utilisabilite), leurs sources et leurs etats.
L'application devra offrir des fonctionnalités de création, modification, suppression et consultation pour chaque catégorie.
Il sera essentiel d'appliquer une architecture modulaire et une séparation claire des préoccupations, en utilisant ASP.NET Core et Entity Framework pour manipuler une base de données PostgreSQL.
Le projet vise à mettre en pratique les meilleures pratiques de développement, y compris l'injection de dépendances, la gestion des erreurs et la documentation complète du code.
L'évaluation finale se concentrera sur la fonctionnalité, la qualité du code et les performances de l'API, avec une utilisation de Swagger pour tester et documenter l'API.

==================
Semaine 1 :

Lundi :
Rencontre avec l'équipe. Présentation des membres et de leurs rôles. Discussions sur les attentes et objectifs du stage.

Mardi :
Formation sur PostgreSQL. rappel sur les bases de données relationnelles, requêtes SQL de base, création de tables et d'index.

Mercredi :
Formation sur .NET Core. Vue d'ensemble du framework, création de projets, gestion des dépendances, et mise en place d'une application simple.

Jeudi :
Examen des projets exemples. Observation de différents projets développés par l'équipe. Compréhension des architectures, des bonnes pratiques et des technologies utilisées.

Vendredi :
Continuation de la formation sur .NET Core.

==================
Semaine 2 :

Lundi :
Discussion approfondie sur le projet assigné. Échange sur les fonctionnalités, les exigences et les objectifs. Clarification des points flous et identification des défis potentiels.

Mardi :
Création du premier diagramme du projet. Réalisation d'un diagramme de classes pour visualiser les interactions entre les différentes composantes du système.

Mercredi :
Réunion pour discuter du premier diagramme. Évaluation des avantages et inconvénients, ajustements apportés pour mieux représenter l'architecture du projet.

Jeudi :
Création du deuxième diagramme. Réalisation d'un diagramme d'états-transitions  pour définir tout les etats possibles pour un bon d'achat electronique (l'element de notre table principale).

Vendredi :
Réunion de discussion sur le deuxième diagramme. Analyse approfondie des relations et des attributs. Finalisation du diagramme de classes après échanges et retours.

==================
Semaine 3 :

Lundi :
Création de la base de données PostgreSQL. Configuration des tables en fonction des besoins du projet. Définition des relations entre les tables. insertions des etats, sources et types definis en ==================
Semaine 2 et insertion de 20 examples de bon d'achat afin de les tester plus tard.

Mardi :
Initialisation d'un projet .NET Core 3.1 avec le modèle MVC (Model-Vue-Controller). Mise en place de la structure du projet et des dossiers nécessaires.

Mercredi :
Mapping de la base de données au projet .NET Core. Génération manuelle des modèles à partir de la base de données existante. Génération manuelle des contrôleurs et leurs methodes get/post avec des requetes SQL directes.

Jeudi :
Finalisation des contrôleurs. Génération des vues pour l'affichage. Tests de lecture, d'écriture et de modification des données depuis l'application web.

Vendredi :
Utilisation des contrôleurs pour effectuer des opérations CRUD (Création, Lecture, Mise à jour, Suppression) sur les tables de la base de données.
==================
Semaine 4 :

Lundi :
Création d'un nouveau projet dans .NET Core 7.0. Installation des prérequis d'Entity Framework pour gérer la base de données.

Mardi :
Création de deux sous-projets distincts : un pour les données(DATA) et un pour l'API. Mise en place des structures de dossiers et de fichiers nécessaires dans chaque sous-projet.

Mercredi :
Démarrage du travail sur le sous-projet de data. Configuration du contexte de la base de données, Création des modèles en générant automatiquement le code à partir de la base de données en utilisant Entity Framework.

Jeudi :
Mise en place d'une classe de repo pour gérer les opérations liées aux modèles. Création d'une interface pour cette classe afin de définir les méthodes abstraite. 
Création d'une repo et son interface pour chaque modèle, en utilisant l'héritage de la classe et l'interface génériques.


Vendredi :
Référencement du sous-projet de données dans le sous-projet API. Configuration de l'injection de dépendances pour le contexte de base de données et les classes de repository. Le test de l'API est également effectué à l'aide de Swagger.

==================
Semaine 5 :

Lundi :
Réunion pour discuter des problèmes actuels avec la méthodologie en cours.
Évaluation des lacunes et des défis rencontrés jusqu'à présent.

Mardi :
Analyse approfondie d'un autre projet similaire.
Étude de son architecture, de ses modèles de données et de son approche pour séparer la logique métier.

Mercredi :
Décomposition des méthodes dans les contrôleurs actuels en services distincts. Création d'interfaces pour les services afin de définir les opérations disponibles de manière abstraite.
Implémentation des services en se basant sur les interfaces définies. Transfert de la logique métier des contrôleurs vers les services correspondants.

Jeudi :
Évaluation finale du projet.
Test exhaustif de l'API, en mettant l'accent sur la modularité, la séparation des préoccupations et les performances.
