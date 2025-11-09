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

## 🚀 CI/CD Pipeline

### Continuous Deployment to Amazon EKS

The project uses GitHub Actions to automate deployments to a production EKS cluster in AWS `us-east-1`.

**Workflow:** `.github/workflows/cd-eks.yml`

#### How it Works

1. **Trigger**: Manual dispatch via GitHub Actions UI (`workflow_dispatch`) or automatically after successful image builds
2. **Authentication**: Uses AWS credentials stored in GitHub Secrets:
   - `AWS_ACCESS_KEY_ID`
   - `AWS_SECRET_ACCESS_KEY`
   - `DOCKERHUB_USERNAME` (for image registry prefix)
3. **Cluster Access**: Configures `kubectl` to target the `eshop-eks` cluster in `us-east-1`
4. **Helm Deployment**: 
   - Updates Helm dependencies
   - Deploys/upgrades the `eshop` release to the `ecommerce` namespace
   - Uses `--atomic` and `--wait` flags to ensure zero-downtime deployments
   - 10-minute timeout for complete rollout verification
5. **Verification**: Post-deployment health checks via `kubectl get pods` and `kubectl get svc`

#### Required GitHub Secrets

| Secret | Purpose |
|--------|---------|
| `AWS_ACCESS_KEY_ID` | AWS IAM access key for EKS authentication |
| `AWS_SECRET_ACCESS_KEY` | AWS IAM secret key |
| `DOCKERHUB_USERNAME` | Docker Hub username for image registry |

#### Manual Deployment

Navigate to **Actions** → **Deploy to EKS** → **Run workflow** and click "Run workflow" button.

## 🔥 Next Roadmap Steps

| Phase | Status |
|-------|--------|
| Multi-Arch docker images | ✅ Complete |
| Convert all services to Helm charts | ✅ Complete |
| CI/CD Pipeline to Amazon EKS | ✅ Complete |
| Infrastructure as Code (Terraform) | 🔜 Planned |
| Observability Stack (Prometheus/Grafana) | 🔜 Planned |
