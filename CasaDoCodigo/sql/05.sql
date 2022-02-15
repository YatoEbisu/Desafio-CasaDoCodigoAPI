create table "Clientes"(
	"Id" uuid Primary Key,
	"Email" varchar unique not null,
	"Nome" varchar not null,
	"Sobrenome" varchar not null,
	"Documento" varchar unique not null,
	"Endereco" varchar not null,
	"Complemento" varchar not null,
	"Cidade" varchar not null,
	"PaisId" uuid not null,
	"EstadoId" uuid ,
	"Telefone" varchar not null,
	"CEP" varchar not null
);