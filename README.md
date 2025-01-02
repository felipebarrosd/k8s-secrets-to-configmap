# k8s-secrets-to-configmap

Este repositório foi criado para explorar e testar funcionalidades relacionadas ao uso de **Secrets** e **ConfigMaps** no Kubernetes. O objetivo principal é aprender e experimentar abordagens para gerenciar configurações sensíveis e não sensíveis em aplicações Kubernetes.

---

## Objetivos do Projeto

- Demonstrar como criar e usar **Secrets** e **ConfigMaps** no Kubernetes.
- Explorar a substituição dinâmica de valores sensíveis em arquivos de configuração usando init containers.
- Testar diferentes abordagens para gerenciar variáveis de ambiente e arquivos de configuração.

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

---

## Como Usar

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

---

