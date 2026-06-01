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

Dans Prometheus, verifier que la target `brasilburger-app` est `UP`, puis montrer les alertes de `monitoring/alerting_rules.yml`.
