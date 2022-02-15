alter table "Autor" rename to "Autores";
alter table "Categoria" rename to "Categorias";


create table "Livros"(
	"Id" uuid Primary Key,
	"Titulo" varchar unique not null,
	"Resumo" varchar(500) not null,
	"Sumario" text,
	"Preco" decimal(18,2) not null,
	"NrPaginas" integer not null,
	"ISBN" varchar unique not null,
	"DataPublicacao" timestamp without time zone,
	"CategoriaId" uuid not null,
	"AutorId" uuid not null,
	foreign key ("CategoriaId") references "Categorias" ("Id"),
	foreign key ("AutorId") references "Autores" ("Id")
);