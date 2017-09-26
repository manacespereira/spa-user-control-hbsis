# spa-user-control-hbsis

# SERVER
* 1 - Abrir solução do visual studio na pasta server, restaurar os pacotes e rodar o projeto de webapi na camada services
* 2 - Para funcionar sem nenhum problema, recomendo usar uma extensão do chrome para habilitar CORS e não dá problemas na hora de fazer as requisições. (https://chrome.google.com/webstore/detail/cors-toggle/omcncfnpmcabckcddookmnajignpffnh)
* 3 - Para rodar os testes, precisamos ir no menu superior > Test > Run > All Tests ou CTRL R, A

# CLIENT
* 1 - Com o servidor rodando, agora vamos à aplicação client. Com o node e o npm instalados precisamos rodar o comando (npm i -g bower).
* 2 - Agora precisamos ir até o projeto, através do terminal, e na pasta que está o package.json digitar (npm install).
* 3 - Agora vamos, através do termina, na pasta public e digitamos o comando (bower install).
* 4 - Para testar a aplicação, precisamos voltar o nível via terminal, até a pasta que está o arquivo gulpfile.js e digitar (gulp), o navegador abrirá automaticamente.
* 5 - Para rodar os testes, pode parar o processo do gulp ou abrir outro terminal, navegar até a pasta do projeto novamente e digitar (npm test).
* 6 - Ao rodar o gulp, automaticamente também preparo a app para distribuição, minificando os arquivos JS, CSS, HTML, otimizando as imagens e etc. Todos os arquivos para distribuição da app ficam na pasta dist.
* 7 - Para testar os arquivos de distribuição/build, rodar o comando (npm start), abrir o navador manualmente e acessar (http://localhost:5000).
