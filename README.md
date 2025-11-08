# 🛒 EShop Microservices

This project is a learning / educational implementation of modern microservices using .NET 8, RabbitMQ, Redis, PostgreSQL and Kubernetes.  
Originally this project started as Docker Compose based — but now the primary deployment model is **Helm + Kubernetes**.

---

## 🏗 Architecture Overview

<img width="1258" alt="eshop architecture" src="https://github.com/user-attachments/assets/aa0a0eea-995d-459b-8eb6-a7318bf81bff" />

---

## 🧰 Tech Stack

| Area | Technology |
|------|------------|
| Backend | .NET 8 Microservices, gRPC, MassTransit |
| Databases | PostgreSQL (all services), Redis |
| Messaging | RabbitMQ |
| API Composition | YARP API Gateway |
| Web App | Razor Pages (Shopping.Web) |
| Deployment | Kubernetes + Helm |

---

## 📂 Repository Structure

| Path | Purpose |
|------|---------|
| `deploy/helm/eshop` | Umbrella Helm chart |
| `deploy/helm/eshop/charts/*` | Individual microservice Helm sub-charts |
| `k8s/databases/postgres` | raw DB manifests (legacy) |
| `k8s/services` | raw deployments before Helm (legacy) |
| `k8s/infra` | legacy infra manifests (redis, rabbitmq, etc) before Helm conversion |

---

## ☸️ Deploying on Kubernetes (Primary)

**namespace:** `ecommerce`  
**helm release name:** `eshop`

> **Prerequisite:** You must have an ingress controller running (recommended: ingress-nginx)

### 1) Create Namespace

```bash
kubectl create namespace ecommerce
```

### 2) Install Full Platform via Helm

```bash
helm upgrade --install eshop deploy/helm/eshop -n ecommerce
```

### 3) Verify Pods

```bash
kubectl get pods -n ecommerce
```

### 4) Access via Ingress (local dev)

Add to `/etc/hosts` if needed:

```
127.0.0.1 shop.ecommerce.local
127.0.0.1 api.ecommerce.local
```

| UI | URL |
|----|-----|
| Shopping Web | http://shop.ecommerce.local |
| API Gateway | http://api.ecommerce.local |

---

## 🧪 Local Development (Optional Legacy Docker Mode)

```bash
docker compose up -d
```

| Service | URL |
|--------|-----|
| Shopping.Web | http://localhost:5100 |
| API Gateway | http://localhost:5005 |
| RabbitMQ UI | http://localhost:15672 (guest / guest) |

---

## 🔥 Next Roadmap Steps

| Phase | Status |
|-------|--------|
| Multi-Arch docker images | ✅ done |
| Convert all services to helm charts | ✅ done |
| CI (GitHub Actions) → build + push images | ⏳ next phase |
| CD to Amazon EKS | ⏳ after CI |
