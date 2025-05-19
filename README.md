# 🛒 EShop Microservices

## 🏗 Architecture Overview

<img width="1258" alt="image" src="https://github.com/user-attachments/assets/aa0a0eea-995d-459b-8eb6-a7318bf81bff" />

---

## 🧰 Tech Stack

- **.NET 8** – Backend APIs & services
- **Docker** – Containerization
- **Redis** – Distributed caching
- **RabbitMQ** – Messaging broker
- **MassTransit** – Message bus abstraction
- **PostgreSQL/Marten** – Catalog and basket databases
- **SQL Server** – Ordering database
- **gRPC** – High-performance RPC (Discount service)
- **YARP / API Gateway** – Unified entry point to microservices
- **Razor Pages/Refit (Shopping.Web)** – Frontend web app

---

## 🚀 Getting Started (Local Development)

### 1. Clone the Repository

```bash
git clone https://github.com/a-ghanem1/EShop-Microservices.git
cd eshop-microservices
```

---

### 2. Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop)

---

### 3. Build Docker Services

```bash
docker compose build
```

---

### 4. Run the Application

```bash
docker compose up -d
```

---

### 5. Access the Application

- Frontend: [http://localhost:5100](http://localhost:5100)
- API Gateway: [http://localhost:5005](http://localhost:5005)
- RabbitMQ Management UI: [http://localhost:15672](http://localhost:15672)  
  - Username: `guest`  
  - Password: `guest`

---

## 📦 Microservices Overview

| Service        | Port | Description                    |
|----------------|------|--------------------------------|
| `catalog.api`  | 5001 | Catalog management             |
| `basket.api`   | 5002 | Basket operations with Redis   |
| `discount.grpc`| 5003 | Discount service (gRPC)        |
| `ordering.api` | 5004 | Order placement and tracking   |
| `api-gateway`  | 5005 | Aggregates and proxies APIs    |
| `shopping.web` | 5100 | User-facing frontend app       |

