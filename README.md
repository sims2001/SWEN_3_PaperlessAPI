# PaperLess API

## Setup

1. Pull latest changes
2. In main directory where `docker-compose.yml` files are located:
  - 2.1 `docker compose build` to build the image
  - FOR DEVELOPMENT: `docker compose up` to start container which runs the api 
  - FOR PRODUCTION: `docker compose -f "docker-compose.production.yml" up` to start container which runs the api 
3. In Browser: `http://localhost:8081` (swagger is only enabled in development environment)

## Workflow

- We will only deploy working solutions (current SPRINT) on `main` to secure a stable and working branch
- Our developing branch is `develop`
- Create feature branches from `develop` when done => merge into `develop`
- When we think a SPRINT is done and stable => merge `develop` into `main`
