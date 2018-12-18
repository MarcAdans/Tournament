# Tournament

Aplicação possui doumentação da API em https://localhost:5001/swagger

## Poster opcional.
A Aplicação busca os posters dos filmes na API do IMDB (http://www.omdbapi.com/)
Essa configuração pode ser habilitada em Tournament.Api/appsettings.Development:ImdbMovieOptions:Enabled

[![N|Solid](https://avatars1.githubusercontent.com/u/16047163?s=100&v=4)](https://github.com/MarcAdans)
# Modo 1 (ClickAndRun)
    1.Na pasta do projeto ../Tournament
    1.2 Execute run.cmd
    1.3 Abra a url https://localhost:49753
    
# Mod 2 (Script)
    1.1 abra uma janela de linha de comando (cmd)
        1.2 cd ../src/api/Tournament.Api
        1.3 dotnet build
        1.4 dotnet run
        
    2.1 abra uma nova janela de linha de comando (cmd)
        2.2 cd ../src/web/Tournament.Angular.Web
        2.3 dotnet build
        2.4 dotnet run       
    
    3. Abra a url https://localhost:49753    

# Modo 3 - Edição, DEBUG!

## Solution!
    1.Click com o botão direito do mouse na Solution Tournament.
    1.1 Menu Properties.
    1.2 Selecione a opção 'Multiple Start Projects'
        1.3 Projeto Tournament.Angular.Web aplicar action como 'Start'
        1.4 Projeto Tournament.Api aplicar action como 'Start'
        
        
<a href="https://raw.githubusercontent.com/MarcAdans/Tournament/master/doc/img/solution-property.png"><img src="https://raw.githubusercontent.com/MarcAdans/Tournament/master/doc/img/solution-property.png" height="300" width="500" ></a>

## Tournament.Api!
    2.Navegue até src/api/Tournament.Api, Click com o botão direito do mouse.
        2.1 Menu Properties-Debug.
        2.2 Selecione em Profile: Tournament.Api
        2.3 Selecione em launch: Project
        2.5 Launch browser: swagger/
        2.6 Environment variables: ASPNETCORE_ENVIRONMENT=Development
        2.7 App url: https://localhost:5001;http://localhost:5000
<a href="https://raw.githubusercontent.com/MarcAdans/Tournament/master/doc/img/project-api.png"><img src="https://raw.githubusercontent.com/MarcAdans/Tournament/master/doc/img/project-api.png" height="300" width="500" ></a>


## Tournament.Angular.Web!
    2.Navegue até src/web/Tournament.Angular.Web, Click com o botão direito do mouse.
        2.1 Menu Properties->Debug.
        2.2 Selecione em Profile: IIS Express
        2.3 Selecione em launch: IIS Express
        2.4 Environment variables: ASPNETCORE_ENVIRONMENT=Development
        2.5 App url: http://localhost:49753
<a href="https://raw.githubusercontent.com/MarcAdans/Tournament/master/doc/img/project-web.png"><img src="https://raw.githubusercontent.com/MarcAdans/Tournament/master/doc/img/project-web.png" height="300" width="500" ></a>
