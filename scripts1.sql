use webstoreproject;

select count(*) from product;

delete from product where id > 50;
select * from product_images;

select * from product;
select * from employees;

insert into product (id, descricao, marca_id, categoria_id, valor_venda) values 
(1, 'produto1', 51,55, 10.0),
(2, 'produto1', 51,55, 10.0),
(3, 'produto1', 51,55, 10.0),
(4, 'produto1', 51,55, 10.0),
(5, 'produto1', 51,55, 10.0),
(6, 'produto1', 51,55, 10.0),
(7, 'produto1', 51,55, 10.0),
(8, 'produto1', 51,55, 10.0),
(9, 'produto1', 51,55, 10.0),
(10, 'produto1', 51,55, 10.0);