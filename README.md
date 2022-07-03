# HungryPizzaAPI

Dentro do appsettings.json, alterar a chave DefaultConnection para a instância do SQL Server da sua máquina.

O sistema automaticamente cria o banco, tabelas e inserts iniciais na primeira execução.

Foi inserido manualmente alguns dados, para facilitar os testes:

Clientes:

<img width="176" alt="image" src="https://user-images.githubusercontent.com/7013966/177057955-2b0d82f6-6998-46bc-a37a-02171a75eeec.png">

Endereços:

<img width="261" alt="image" src="https://user-images.githubusercontent.com/7013966/177057977-608d843e-ce6f-4cca-bd91-b024d847c051.png">


Sabores:

<img width="254" alt="image" src="https://user-images.githubusercontent.com/7013966/177057989-d01a20fe-d9ae-4345-a663-445448fed359.png">

Para facilitar os testes do método de consulta, já deixei cadastrado também algumas pizzas e pedidos:

Pizzas:

<img width="195" alt="image" src="https://user-images.githubusercontent.com/7013966/177058030-722255fc-de38-4d90-be19-15ab699cf18e.png">

Pedidos:

<img width="326" alt="image" src="https://user-images.githubusercontent.com/7013966/177058051-4ee00602-702d-43a1-b736-f51e57ee0924.png">


Também para facilitar os testes, deixei configurado o Swagger, abaixo alguns testes nos dois métodos:

Listagem de pedidos por cliente paginado. Nesse exemplo, obtenho os 5 últimos pedidos feitos pelo cliente do Id = 2

<img width="1148" alt="image" src="https://user-images.githubusercontent.com/7013966/177058179-fe9655e0-8afd-4a6c-bf2c-ce9e82fb380e.png">

<img width="1107" alt="image" src="https://user-images.githubusercontent.com/7013966/177058190-354c4de8-24fb-4541-b925-4a0d5f896746.png">

Criar um novo pedido:

Sou obrigado a passar um clienteId ou EnderecoId e dentro do Body tenho que passar uma lista de PizzaDTOs, que só é composta pela lista de ids de Sabores.

<img width="313" alt="image" src="https://user-images.githubusercontent.com/7013966/177058278-776ed3d6-701f-452b-bc1f-49bd3909a4df.png">

Nesse exemplo vou tentar criar um Pedido para o Cliente do Id 2 e passo no Body uma lista contendo 2 PizzasDTO, a primeira PizzaDTO tem os SaboresId = 1 e 2 e a segunda PizzaDTO tem os SaboresId = 3.

Ou seja, um pedido contendo duas pizzas, a primeira com os sabores de 3 Queijos e Frango com requeijão e a segunda pizza com o sabor Mussarela.

<img width="1095" alt="image" src="https://user-images.githubusercontent.com/7013966/177058328-5a973f64-98cc-4133-a3cf-a041a5b6aa35.png">

Após executar, o retorno vai ser o identificado único do pedido, que deixei sendo o Id da tabela Pedido mesmo.

<img width="1070" alt="image" src="https://user-images.githubusercontent.com/7013966/177058422-97f1feda-f80f-42b4-82c5-9db3216e5dc7.png">

Executando novamente a listagem de pedidos do Cliente Id = 2, verificar que retornou também o Pedido do Id 18

<img width="899" alt="image" src="https://user-images.githubusercontent.com/7013966/177058452-3af343d3-6334-4af9-9640-e94a079b4527.png">


