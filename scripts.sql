create database mobileproject;
use mobileproject;

create database art_register;
use art_register;

create table products(
	id int auto_increment,
    name varchar(200),
    description varchar(200),
    price decimal(10,2),
    active boolean default true,
    deleted boolean default false,
    created_date timestamp default current_timestamp,
    last_change timestamp on update current_timestamp,
    section_id int not null,
    CONSTRAINT pk_products PRIMARY KEY (id),
    CONSTRAINT fk_section FOREIGN KEY (section_id) references sections(id)
);

create table sections(
	id int auto_increment,
    name varchar(200),
    active boolean default true,
    deleted boolean default false,
    created_date timestamp default current_timestamp,
    last_change timestamp on update current_timestamp,
    CONSTRAINT pk_sections PRIMARY KEY (id)
);

select * from sections;
select * from products;

create database flutterproject;
use flutterproject;

drop table products;
create table products(
	id int auto_increment,
    gtin varchar(20) not null,
    description varchar(200), -- ADD GTIN - CÓDIGO DE BARRAS DO PRODUTO
    price decimal(10,2), -- ALTERAR PARA VARCHAR (CORRESPONDE VALOR COM MASCARA)
    brand_name varchar(200),
    gpc_code varchar(100),
    gpc_description varchar(500),
    ncm_code varchar(100),
    ncm_description varchar(500),
    ncm_full_description varchar(1000),
    thumbnail varchar(250),
    in_stock int default 0,
    active boolean default true,
    deleted boolean default false,
    created_date timestamp default current_timestamp,
    last_change timestamp on update current_timestamp,
    CONSTRAINT pk_products PRIMARY KEY (id)
);
use flutterproject;
select * from products;