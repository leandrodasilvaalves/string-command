# String Command

## Instalação

Abra um terminal dentro do diretório do projeto e execute o comando abaixo para gerar o build:
```
 dotnet build -c Release -o ~/str
```

Após isso execute os commandos abaixo para mover para o diretório correto e criar um link na pasta bin
```
 sudo mv ~/str /usr/local/share
 sudo ln -s /usr/local/share/str/LSA.StringCommand /usr/local/bin/str    
```

Por fim execute o commando `str --help` no terminal. Deverá ter uma saída como a do exemplo abaixo:
```
str [OPTION] [TEXT]
              -f --firstUpper -> Primeira letra em maiúsculo 
              -g --guid [NUMBER, Default=1] -> Returns one or more guids as specified by arguments. The default quantity returned is 1.
              -l --lower -> Return all lowercase letters.  
              -u --upper -> Return all uppercase letters.  
```
