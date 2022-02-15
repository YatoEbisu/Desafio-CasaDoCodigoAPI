create table "Paises"(
	"Id" uuid Primary Key,
	"Nome" varchar not null
);

create table "Estados"(
	"Id" uuid Primary Key,
	"Nome" varchar not null,
	"PaisId" uuid not null,
	foreign key ("PaisId") references "Paises" ("Id")
);