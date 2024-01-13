Create database cafe tablespace family_cafe;
Create schema cafe;
Create domain domain_price as decimal(8,2) check(value >= 0);
create domain domain_count as int check (value>=0);
create domain domain_count1 as float check (value>=0);
Create type place as enum ('В зале', 'С собой');
Create type status as enum ('Готовится', 'Готово', 'Ошибка');
Create type stop_list as enum ('Есть в наличии', 'Нет в наличии');

CREATE TABLE Visitor
(
 id_visitor serial NOT NULL primary key,
 name       varchar(20) NOT NULL,
 telephone  varchar(12) NOT NULL,
CONSTRAINT phone check(telephone ~* '^((\+7|7|8)+([0-9]){10})$'),
 D_of_B     date NOT NULL,
 bonuses    domain_count default 0,
CONSTRAINT unique_telephone unique (telephone)
);

CREATE TABLE Orderr
(
 id_order          int NOT NULL primary key,
 id_table          serial NOT NULL,
 id_visitor        int NOT NULL REFERENCES Visitor ( id_visitor )
on delete cascade
on update cascade,
 place_of_order    place NOT NULL,
 number_of_visitor domain_count NOT NULL,
 order_time        timestamp NOT NULL,
 status            status NOT NULL default 'Готовится',
 total_amount      domain_price NOT NULL 
);

CREATE TABLE Menu
(
 Menu_view      varchar(20) NOT NULL primary key,
 time_of_action timestamp NOT NULL 
);

CREATE TABLE Dish
(
 id_position    serial NOT NULL primary key,
 name         varchar(50) NOT NULL,
 quantity_in_order         int NOT NULL,
 cooking_course int NOT NULL,
 stop_list        stop_list NOT NULL default 'Есть в наличии',
 menu_view    varchar(20) NOT NULL REFERENCES Menu ( Menu_view )
on delete cascade
on update cascade,
 status         status NOT NULL default 'Готовится',
 description    text NOT NULL,
 calories       decimal(6,2) NOT NULL,
 amount         domain_price NOT NULL
);

CREATE TABLE Ingredient
(
 id_ingredient serial NOT NULL primary key,
 name          varchar(25) NOT NULL,
 calories      decimal(6, 2) NOT NULL,
 unit      varchar(10) NOT NULL,
 remainder     domain_count NOT NULL
);
CREATE TABLE Contents_of_dish
(
 id_ingredient int NOT NULL REFERENCES Ingredient ( id_ingredient )
on delete cascade
on update cascade,
 id_position   int NOT NULL REFERENCES Dish ( id_position )
on delete cascade
on update cascade,
 quantity      float NOT NULL,
 PRIMARY KEY ( id_ingredient, id_position ) 
);
CREATE TABLE Contents_of_order
(
 id_order    int NOT NULL  REFERENCES Orderr ( id_order) 
  on delete restrict
  on update cascade,
 comment     text NOT NULL,
 id_position int NOT NULL REFERENCES Dish ( id_position )
  on delete restrict
  on update cascade
);
insert into visitor values
(1, 'Григорий', 89365478512, '2001-10-01', 50),
(2, 'Виктор', 89568921457, '1998-04-22', 350),
(3, 'Олеся', 89325633547, '2003-03-24', 610),
(4, 'Наталья', 89548562587, '1978-11-29', 411),
(5, 'Михаил', 89356856587, '2004-10-16', 455),
(6, 'Лариса', 89121512148, '2010-01-21', 11),
(7, 'Дарья', 89325632542, '1996-04-22', 150),
(8, 'Андрей', 89555566854, '2001-12-03', 75),
(9, 'Алёна', 89223366445, '2000-05-18', 320),
(10, 'Екатерина', 89995542154, '2001-10-01', 50),
(11, 'Антон', 89112563245, '1990-09-11', 740);

insert into orderr values
(1, 5, 4, 'В зале', 1, '2023-10-04 11:23:54', 'Готово', 1200),
(2, 1, 7, 'В зале', 3, '2023-10-03 15:10:00', 'Готово', 3620),
(3, 12, 8, 'С собой', 4, '2023-10-05 15:30:32', 'Готовится', 4600),
(4, 4, 11, 'С собой', 1, '2023-10-03 12:24:05', 'Ошибка', 350),
(5, 8, 5, 'В зале', 6, '2023-10-05 14:00:54', 'Готово', 3000),
(6, 10, 6, 'В зале', 3, '2023-10-05 16:20:43', 'Готовится', 1200),
(7, 9, 3, 'С собой', 2, '2023-10-05 17:40:15', 'Готовится', 500),
(8, 3, 1, 'В зале', 2, '2023-10-04 20:14:10', 'Ошибка', 720),
(9, 7, 9, 'В зале', 5, '2023-10-05 17:13:39', 'Готовится', 6047),
(10, 15, 2, 'В зале', 4, '2023-10-05 13:32:55', 'Готово', 4240);

insert into menu values
('Сезонное', '2023-12-01 00:00:00'),
('Обеденное', '2023-10-05 17:00:00'),
('Основное', '2023-10-06 00:00:00'),
('Новинка', '2023-12-10 00:00:00'),
('Детское', '2023-11-06 00:00:00'),
('Акция', '2023-11-1 00:00:00');

insert into dish values
(1, 'Оджахури', 1, 2, 'Есть в наличии', 'Основное', 'Готовится', 'Ароматное грузинское оджахури со свининой', 650, 400),
(2, 'Удон', 2, 1, 'Есть в наличии', 'Новинка', 'Готово', 'Удон с курицей под сливочным соусом', 440, 359),
(3, 'Овощи-гриль', 1, 1, 'Нет в наличии', 'Основное', 'Готовится', 'Цукини, шампиньоны, болгарский перец, тыква', 172, 270),
(4, 'Гренки с чесноком', 3, 1, 'Есть в наличии', 'Основное', 'Готово', 'Отличная закуска к пиву', 462, 150),
(5, 'Сырные палочки', 2, 1, 'Есть в наличии', 'Основное', 'Готово', 'Сыр моцарелла в панировке', 870, 230),
(6, 'Салат Цезарь с курицей', 3, 1, 'Есть в наличии', 'Обеденное', 'Готовится', 'Салат айсберг, куриное бедро, помидоры черри, сухарики', 540, 390),
(7, 'Наггетсы', 2, 1, 'Есть в наличии', 'Детское', 'Готово', 'Филе куриного бедра в панировке', 750, 290),
(8, 'Бефстроганов с пюре', 1, 1, 'Есть в наличии', 'Акция', 'Готовится', 'Филе бедра индейки в сливочном соусе с нежным картофельным пюре', 880, 450),
(9, 'Фирменный десерт', 3, 3, 'Есть в наличии', 'Основное', 'Ошибка', 'Десерт из шоколадного бисквит с заварным кремом', 430, 299);

insert into ingredient values
(1, 'Свинина', 440, 'кг', 9),
(2, 'Сливки', 520, 'л', 2.5),
(3, 'Лапша', 360, 'кг', 4),
(4, 'Болгарский перец', 107, 'кг', 3),
(5, 'Шампиньоны', 98, 'кг', 3.5),
(6, 'Бородинский хлеб', 144, 'шт', 5),
(7, 'Сыр моцарелла', 501, 'кг', 7.8),
(8, 'Курица', 240, 'кг', 10.2),
(9, 'Пюре', 357, 'кг', 4),
(10, 'помидоры черри', 120, 'кг', 6);

insert into contents_of_order values
(1, '-', 1),
(2, '-', 8),
(3, 'цезари без черри', 6),
(5, 'гренки подать раньше', 4),
(10, 'подать вместе с сырными палочками', 7);

insert into contents_of_dish values
(1, 1, 0.310),
(2, 8, 0.150),
(3, 2, 0.5),
(7, 5, 0.300),
(6, 4, 0.210),
(5, 8, 0.350),
(8, 6, 0.240);

