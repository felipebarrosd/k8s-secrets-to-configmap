# k8s-secrets-to-configmap

Este repositório foi criado para explorar e testar funcionalidades relacionadas ao uso de **Secrets** e **ConfigMaps** no Kubernetes. O objetivo principal é aprender e experimentar abordagens para gerenciar configurações sensíveis e não sensíveis em aplicações Kubernetes.

O projeto também inclui o uso da ferramenta k8s-sidecar/reload para detectar mudanças em ConfigMaps e Secrets e reiniciar os Pods automaticamente, garantindo que as aplicações estejam sempre atualizadas.

---

## Objetivos do Projeto

- Demonstrar como criar e usar **Secrets** e **ConfigMaps** no Kubernetes.
- Explorar a substituição dinâmica de valores sensíveis em arquivos de configuração usando init containers.
- Testar diferentes abordagens para gerenciar variáveis de ambiente e arquivos de configuração.
- Garantir atualizações automáticas de configuração em Pods com a ferramenta Reload.

---

## Estrutura do Repositório

- **k8s/**: Contém exemplos de manifestos YAML para ConfigMaps, Secrets, Pods e Deployments.
- **Worker/**: Código de um simples worker service em .NET.

---

## Tecnologias e Ferramentas

- Kubernetes
- Docker
- Imagem base: **busybox** (para init containers)
- .NET 6
- k8s-sidecar/reload

---

## Como Usar

### Requisitos

- Kubernetes Cluster
- Ferramenta `kubectl`
- [Reloader](https://github.com/stakater/Reloader) instalado no cluster:
  ```bash
  helm repo add stakater https://stakater.github.io/stakater-charts
  helm install reloader stakater/reloader
  ```

### Deploy

1. Clone o repositório:

   ```bash
   git clone https://github.com/felipebarrosd/k8s-secrets-to-configmap.git
   cd k8s-secrets-to-configmap
   ```

2. Aplique os manifestos de exemplo:

   ```bash
   kubectl apply -f k8s/
   ```

3. Modifique os arquivos em `k8s/` para realizar seus próprios testes.

4. Teste a Ferramenta Reloader:
   Atualize o ConfigMap ou Secret e observe os Pods sendo reiniciados automaticamente:
   ```bash
   kubectl edit configmap meu-worker-config
   ```

---

## Exemplos Incluídos

### Substituição de Configuação Dinâmica com Init Container

- Um exemplo de init container que substitui placeholders no arquivo de configuração usando valores de Secrets:
   - O initContainer config-replacer é executado primeiro.
   - Ele acessa as Secrets e lê as credenciais.
    Copia o arquivo appsettings.json e altera suas configurações de banco de dados com as credenciais lidas.
   - O container principal (meu-worker) é iniciado, montando o arquivo configurado no caminho /app/appsettings.json e utilizando a variável de ambiente definida.
- Manifestos: `k8s/secrets.yaml` e `k8s/deployment.yaml`

### Uso de Variáveis de Ambiente com Secrets

- Demonstra como expor valores de Secrets como variáveis de ambiente em contêineres.
- Manifestos: `k8s/secrets.yaml` e `k8s/deployment.yaml`

### Atualização automática de configmap e secrets com Reloader

- A ferramenta reload monitora mudanças em ConfigMaps e Secrets. Quando detecta alterações, ela reinicia automaticamente os Pods associados. Isso garante que a aplicação sempre opere com as configurações mais recentes, sem intervenção manual.
- Manifestos: `k8s/deployment.yaml`
  
---

