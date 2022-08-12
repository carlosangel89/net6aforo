pipeline {
    agent any

    stages {
        stage('SCM') {
            steps {
                git branch: 'master', url: 'https://github.com/carlosangel89/net6aforo.git'
            }
        }
              stage ('Build Net6.0') {
           steps {
            bat(script: 'dir' , returnStdout:true);
            bat(script: 'dotnet restore' , returnStdout:true);
            bat(script: 'dotnet build' , returnStdout:true);
            bat(script: 'dotnet test' , returnStdout:true);
           }
       }
     stage ("Docker Build") {
           
           steps{
             // docker login  
             bat(script: 'docker build -t carlosangel89/ceafservicenet6.0 .' , returnStdout:true);
             bat(script: 'docker push carlosangel89/ceafservicenet6.0' , returnStdout:true);  
           }
       }   
       stage ("AKS Build") {
           
           steps{
             bat(script: 'az login --service-principal --username 7cd716f8-0988-4ccb-a8d2-d3c2d4a564df --password Hj48Q~1LTWrq15O~AVA_FO0jPbcUVbkvcg7sKaf- --tenant ebf0e84f-e828-4a31-91d4-2f995072e084' , returnStdout:true);
             bat(script: 'az account set --subscription 04952ef8-1111-41ae-b55a-737c4d1a8f26' , returnStdout:true); 
             bat(script: 'az aks get-credentials --resource-group DevOps --name jenkinsaks' , returnStdout:true); 
             bat(script: 'az aks get-credentials --resource-group DevOps --name jenkinsaks & kubectl config get-contexts --kubeconfig=%KUBE_PATH_CONFIG%' , returnStdout:true); 
             bat(script: 'kubectl config use-context jenkinsaks --kubeconfig=%KUBE_PATH_CONFIG%' , returnStdout:true); 
             bat(script: 'kubectl rollout restart deployment app-deployment --kubeconfig=%KUBE_PATH_CONFIG%', returnStdout: true);
             bat(script: 'kubectl apply -f k8s.yml --kubeconfig=%KUBE_PATH_CONFIG%' , returnStdout:true); 
           }
       }   
       
    }
}
