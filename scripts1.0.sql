use art_register;
select * from products;

alter table products add column photo_url varchar(1000) not null;


alter table products drop column photo_url;