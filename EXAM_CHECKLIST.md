# Checklist de demonstration examen

## Secrets

Preparer les variables sans les commiter :

```powershell
copy .env.example .env
# Modifier DEFAULT_CONNECTION dans .env avec la vraie chaine PostgreSQL
```

Pour Kubernetes, copier `kubernetes/secret.example.yaml`, mettre la vraie chaine de connexion localement, puis appliquer le secret. Ne jamais commiter les vrais mots de passe.

## Pipeline local

```powershell
dotnet restore csharp_web.sln
dotnet build csharp_web.sln --configuration Release
dotnet test csharp_web.Tests\csharp_web.Tests.csproj --configuration Release
docker build -t yacine1108/brasilburger:latest .
docker compose --env-file .env up -d
```

Sur Ubuntu/Jenkins, les memes etapes utilisent `sh` et des chemins Linux :

```bash
dotnet build csharp_web/csharp_web.csproj --configuration Release
dotnet test csharp_web.Tests/csharp_web.Tests.csproj --configuration Release --verbosity normal
docker build -t yacine1108/brasilburger:latest .
docker compose --env-file .env up -d
```

## Verifications applicatives

```powershell
curl http://localhost:8083/health
curl http://localhost:8083/metrics
```

## Kubernetes

```powershell
kubectl apply -f kubernetes/namespace.yaml
kubectl apply -f kubernetes/secret.example.yaml
kubectl apply -f kubernetes/deployment.yaml
kubectl apply -f kubernetes/service.yaml
kubectl get pods -n production
kubectl get svc -n production
```

## Monitoring

La stack monitoring lance Prometheus, Grafana, Alertmanager et Node Exporter avec Docker Compose.

URLs a montrer :

```text
Application:  http://localhost:8083
Healthcheck:  http://localhost:8083/health
Metrics app:  http://localhost:8083/metrics
Prometheus:   http://localhost:9090
Grafana:      http://localhost:3000
Alertmanager: http://localhost:9093
Node Exporter: http://localhost:9100/metrics
```

Dans Prometheus, verifier que les targets `brasilburger-app`, `ubuntu_server`, `prometheus` et `alertmanager` sont `UP`, puis montrer les alertes de `monitoring/alerting_rules.yml`.

Identifiants Grafana de demonstration :

```text
admin / admin
```
