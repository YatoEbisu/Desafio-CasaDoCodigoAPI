create table "Autor"(
	"Id" uuid Primary Key,
	"Email" varchar(50) unique not null,
	"Nome" varchar(50) not null,
	"Descricao" varchar(400) not null,
	"DataCriacao" timestamp without time zone not null
)