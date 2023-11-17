# SWKOM PaperLess Semester-Project

Welcome to the Paperless-NGX Backend project developed as part of the SWKOM course at FH Technikum Wien. This backend solution complements the Paperless-NGX frontend, providing basic functionality for a paperless document management system. The repository is managed by Schwaiger Andreas, Rutschka Simon and Wunsch Lukas.

## Architecture

The project follows a three-layer architecture consisting of the data access layer, the business layer and the web service facade, with a web application serving external clients.

## Start Services

Clone the repository and execute the following command to run the services:
```bash
docker compose up -d
```

To Stop the Services run the following command:
```bash
docker compose down --remove-orphans
```


## Project structure

### Sprint-Overview

The development process is organized in 7 sprints, each lasting about 2 weeks and following the principles of Scrum. The sprints are designed to build on each other and use small iterations where hard-coded components are replaced over time.

- **Sprint 1:** REST API, OpenAPI, (optional: CI/CD)
- **Sprint 2:** UI, Object Mapping, Validation
- **Sprint 3:** Data Access Layer, Repositories, O/R Mapper
- **Sprint 4:** Queueing, Dependency Injection, Logging, Code Review
- **Sprint 5:** Service Agent (OCR), Error Handling
- **Sprint 6:** Elastic Search, Use Cases
- **Sprint 7:** Integration Tests, Finalization, Code Review

### Frontend: Paperless-ngx

The UI of [Paperless-ngx](https://docs.paperless-ngx.com/) is used as the projects front end. This open source document management system enables the conversion of physical documents into a searchable online archive. The UI is precompiled, as this project is focused on the implementation of a backend.

### API creation with OpenAPI Contract

An OpenAPI contract was provided by the course for API development. This contract serves as the basis for the creation of the RESTful API, which enables various functionalities of the document management system.

### Used Technologies

The technologies used in the project include:

- **Programming Language:** C#
- **Messaging-Queue:** RabbitMQ
- **Database:** PostgreSQL
- **Version-Control:** GitHub
- **Framework:** .NET 7.0/ASP.Net
- **Search Optimization:** ElasticSearch

### Docker container for microservices

A main goal of the project is to develop various microservices and deploy them in a Docker environment. Docker enables the containerization of the microservices, which allows for easy deployment, scalability and maintenance.

The use of Docker is crucial to ensure a consistent and isolated environment for the individual microservices. Containerization allows the microservices to be developed, tested and deployed independently of each other.

## Contributors

- Schwaiger Andreas
- Rutschka Simon
- Wunsch Lukas