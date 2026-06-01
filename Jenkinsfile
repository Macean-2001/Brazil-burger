pipeline {
    agent any

    options {
        skipDefaultCheckout()
        disableConcurrentBuilds()
    }

    stages {

        stage('Checkout') {
            steps {
                checkout([
                    $class: 'GitSCM',
                    branches: [[name: '*/main']],
                    userRemoteConfigs: [[url: 'https://github.com/Macean-2001/Brazil-burger.git']]
                ])
            }
        }

        stage('Build .NET') {
            steps {
                sh 'dotnet build csharp_web/csharp_web.csproj --configuration Release'
            }
        }

        stage('Test .NET') {
            steps {
                sh 'dotnet test csharp_web.Tests/csharp_web.Tests.csproj --configuration Release --verbosity normal'
            }
        }

        stage('Build Docker') {
            steps {
                sh 'docker build -t yacine1108/brasilburger:latest .'
            }
        }

        stage('Push Docker Image') {
            steps {
                withCredentials([usernamePassword(credentialsId: 'docker-hub-credentials', usernameVariable: 'DOCKER_USERNAME', passwordVariable: 'DOCKER_PASSWORD')]) {
                    sh 'echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_USERNAME" --password-stdin'
                    sh 'docker push yacine1108/brasilburger:latest'
                }
            }
        }

        stage('Run Container') {
            steps {
                sh 'docker stop brasilburger_ci || true'
                sh 'docker rm brasilburger_ci || true'
                sh 'docker run -d --name brasilburger_ci -p 8084:8080 yacine1108/brasilburger:latest'
            }
        }
    }
}
