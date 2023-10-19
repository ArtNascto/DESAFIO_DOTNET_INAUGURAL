# DESAFIO_DOTNET_INAUGURAL

## Proposta  

O time deve desenvolver um projeto que adivinhe um número de 1 a 1000 concatenado com uma vogal podendo ter acento, ou ser maiúscula ou minúscula.

Ex.: A chave pode ser 10A, 48i, 798à ou A13, A38, i4 ...etc 

Após criar os números o sistema deve fazer um POST no endpoint abaixo, ele não tem autenticação.

*https://fiap-turma3.azurewebsites.net/fiap*


```shell
Exemplo do corpo do JSON:
curl --location 'https://fiap-inaugural.azurewebsites.net/fiap' \
--header 'Content-Type: application/json' \
--data '
{
    "Key": "X99h",
    "grupo":"seu_grupo"
}
'
```

Esse endpoint deve retornar uma string com duas hashtags.
 
O grupo deve fazer um post no LinkedIn com a foto do grupo, junto com essa hashtag marcando a FIAP. O primeiro grupo que voltar com o link do post na sala principal é o vencedor 😉
