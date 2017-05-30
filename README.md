# ImportarFIPE
Programa desenvolvido para baixar as informações da Tabela FIPE contidas no site [fipeapi.appspot.com](https://fipeapi.appspot.com) e exporta-las para SQL, bem como Deserializar Objetos e Lista de Objetos em JSON e exportar seus dados para Classes.

Após a primeira Importação Completa concluida com sucesso, ele gera arquivos Serializados na pasta 
'/cfg'
com a extenção '.serializer', que na verdade são as Classes\Lista de Classes serializadas. 
Estas classes\listas serializadas são utilizadas para quando ao abrir o programa novamente, ele detecte que você já importou anteriormente os dados e sendo assim ele re-estabelece a classe deserializando a mesma para suas devidas classes\listas.

** Desenvolvido com fins acadêmicos. **

### DATA API
* [fipeapi.appspot.com](https://fipeapi.appspot.com/)

### Libraries
* [Newtonsoft.Json](http://www.newtonsoft.com/json)

### License
GNU General Public License

### Desenvolvedor
* Matheus Azambuja [<matheushenrique.ads@gmail.com>](matheushenrique.ads@gmail.com)