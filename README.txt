Para facilitar a procura forense para além de usar a localização pré-definida dos ficheiros do Firefox e Google Chrome é também dada a opção de poder escolher uma localização diferente para procurar, o que facilita a investigação quando foi guardada a pasta para outro lugar.

Para utilizar esta outra localização é preciso criar uma pasta onde se vai colocar uma pasta para o perfil do Firefox e outra para o Chrome.
Passo do firefox: copiar a pasta do perfil do Firefox ( C:\Users\%user%\AppData\Roaming\Mozilla\Firefox\Profiles\%alphanumerics%.default ) para a pasta criada anteriormente e mudar o nome para Firefox.
Passo do chrome: copiar a pasta do perfil do Chrome (C:\Users\%user%\AppData\Local\Google\Chrome\User Data\%profile% ) para a pasta criada anteriormente e mudar o nome para Chrome.
    %profile% costuma ser "Default" mas também pode ter outro nome se existirem mais perfis como "Profile 2" e "Profile 3"

Para poder usar a nova localização é preciso clicar no botão "Other Location..." e escolher a pasta que foi antes criada e tem as pastas Firefox e/ou CHrome lá dentro.
Caso queira voltar à pré-definida basta clicar em "Reset Location"

Exemplo:
Criar pasta BrowserForensics
copiar C:\Users\root\AppData\Roaming\Mozilla\Firefox\Profiles\sr09fjuy.default para BrowserForensics e mudar o nome para Firefox
copiar C:\Users\root\AppData\Local\Google\Chrome\User Data\Default para BrowserForensics e mudar o nome para Chrome

resultado: .\BrowserForensics
              .\Firefox
                 places.sqlite
                 ...etc...
              .\Chrome
                 History
                 ...etc...