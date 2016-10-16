Drop database LojaNegociacao

create database LojaNegociacao

use LojaNegociacao
create table mercadorias
(
	Id int primary key identity(1,1),
	CodMercadoria varchar(10),
	TipoMercadoria varchar(30),
	NomeMercadoria  varchar(30),
	Quantidade int,
	Preco float,
	TipoNegociacao int
)
go
