--test veritabanınızda employee isimli sütun bilgileri id(INTEGER), name VARCHAR(50), birthday DATE, 
--email VARCHAR(100) olan bir tablo oluşturalım.
CREATE TABLE employee(
  id SERIAL PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  birthday DATE,
  email VARCHAR(100)
);

--Oluşturduğumuz employee tablosuna 'Mockaroo' servisini kullanarak 50 adet veri ekleyelim.
insert into employee (name, birthday, email) values ('Towney Agiolfinger', '1995-09-05', 'tagiolfinger0@businessinsider.com');
insert into employee (name, birthday, email) values ('Karola Snel', '1965-03-27', 'ksnel1@newyorker.com');
insert into employee (name, birthday, email) values ('Louis Whyley', '1995-08-20', 'lwhyley2@uol.com.br');
insert into employee (name, birthday, email) values ('Menard Beisley', '1989-08-02', 'mbeisley3@creativecommons.org');
insert into employee (name, birthday, email) values ('Storm Davenhall', '1985-12-05', 'sdavenhall4@simplemachines.org');
insert into employee (name, birthday, email) values ('Jeane Drains', '1981-12-23', 'jdrains5@github.com');
insert into employee (name, birthday, email) values ('Sheena Waadenburg', '1953-05-29', 'swaadenburg6@vkontakte.ru');
insert into employee (name, birthday, email) values ('Charlotta Coverly', '1954-03-18', 'ccoverly7@buzzfeed.com');
insert into employee (name, birthday, email) values ('Janos Kristiansen', '1981-08-14', 'jkristiansen8@eepurl.com');
insert into employee (name, birthday, email) values ('Vonni Harbor', null, 'vharbor9@github.com');
insert into employee (name, birthday, email) values ('Anton Lowy', '1967-07-09', 'alowya@hao123.com');
insert into employee (name, birthday, email) values ('Hanna Ellin', '1996-11-09', 'hellinb@weebly.com');
insert into employee (name, birthday, email) values ('Yard Wintringham', '1985-01-29', 'ywintringhamc@tinyurl.com');
insert into employee (name, birthday, email) values ('Lil Plenty', '1990-01-02', 'lplentyd@fema.gov');
insert into employee (name, birthday, email) values ('Christine Toovey', '1995-03-23', 'ctooveye@state.tx.us');
insert into employee (name, birthday, email) values ('Darnall De Lacey', '1983-07-29', 'ddef@chron.com');
insert into employee (name, birthday, email) values ('Horace Segebrecht', null, 'hsegebrechtg@clickbank.net');
insert into employee (name, birthday, email) values ('Luce Corter', '1973-10-13', 'lcorterh@yolasite.com');
insert into employee (name, birthday, email) values ('Kayne Fockes', '1980-11-13', 'kfockesi@friendfeed.com');
insert into employee (name, birthday, email) values ('Jilleen Di Maria', null, 'jdij@diigo.com');
insert into employee (name, birthday, email) values ('Nathalie Itscovitz', '1998-08-08', 'nitscovitzk@wufoo.com');
insert into employee (name, birthday, email) values ('Michaeline Harmer', '1970-03-06', 'mharmerl@imgur.com');
insert into employee (name, birthday, email) values ('Rafa Whacket', null, 'rwhacketm@tmall.com');
insert into employee (name, birthday, email) values ('Pen Hardway', '1993-10-08', 'phardwayn@gizmodo.com');
insert into employee (name, birthday, email) values ('Pooh Yukhov', '1963-07-08', 'pyukhovo@domainmarket.com');
insert into employee (name, birthday, email) values ('Chandal Rundall', null, 'crundallp@bluehost.com');
insert into employee (name, birthday, email) values ('Bartel Domingues', '1966-06-26', 'bdominguesq@howstuffworks.com');
insert into employee (name, birthday, email) values ('Ertha Sprake', '1964-08-16', 'espraker@mac.com');
insert into employee (name, birthday, email) values ('Vivyanne Lishmund', '1974-11-01', 'vlishmunds@bandcamp.com');
insert into employee (name, birthday, email) values ('Owen Stanyan', '1990-05-25', 'ostanyant@timesonline.co.uk');
insert into employee (name, birthday, email) values ('Antonin Attersoll', '1976-03-03', 'aattersollu@google.de');
insert into employee (name, birthday, email) values ('Luce Duffet', '1951-07-10', 'lduffetv@mozilla.com');
insert into employee (name, birthday, email) values ('Haley Cheek', '1954-04-08', 'hcheekw@google.pl');
insert into employee (name, birthday, email) values ('Erina Thunnercliff', '1999-08-29', 'ethunnercliffx@ed.gov');
insert into employee (name, birthday, email) values ('Carlen Cowthart', '1989-05-18', 'ccowtharty@qq.com');
insert into employee (name, birthday, email) values ('Bale Lead', '1992-08-14', 'bleadz@imdb.com');
insert into employee (name, birthday, email) values ('Ferrell Andrysek', null, 'fandrysek10@hubpages.com');
insert into employee (name, birthday, email) values ('Ariel Moland', null, 'amoland11@nih.gov');
insert into employee (name, birthday, email) values ('Ceciley Belderfield', '1954-02-10', 'cbelderfield12@bing.com');
insert into employee (name, birthday, email) values ('Susannah Keely', '1984-10-09', 'skeely13@indiegogo.com');
insert into employee (name, birthday, email) values ('Aldrich Fluin', '1955-12-27', 'afluin14@sphinn.com');
insert into employee (name, birthday, email) values ('Burch O''Daly', null, 'bodaly15@apple.com');
insert into employee (name, birthday, email) values ('Burnaby Senechault', '1982-01-22', 'bsenechault16@google.ca');
insert into employee (name, birthday, email) values ('Sofia Connerry', '1978-02-17', 'sconnerry17@apache.org');
insert into employee (name, birthday, email) values ('Raynard Weedall', '1953-02-28', 'rweedall18@technorati.com');
insert into employee (name, birthday, email) values ('Ludovika Studdal', '1968-02-22', 'lstuddal19@bloomberg.com');
insert into employee (name, birthday, email) values ('Ced Strowger', '1966-05-11', 'cstrowger1a@webs.com');
insert into employee (name, birthday, email) values ('Aloise Morad', '1963-04-24', 'amorad1b@soundcloud.com');
insert into employee (name, birthday, email) values ('Franz Luxmoore', '1998-02-28', 'fluxmoore1c@weather.com');
insert into employee (name, birthday, email) values ('Georgine Rigmond', '1977-06-12', 'grigmond1d@epa.gov');

--Sütunların her birine göre diğer sütunları güncelleyecek 5 adet UPDATE işlemi yapalım.
UPDATE employee
SET name = 'Updated_FullName',
    birthday = '2000-08-10',
	email = 'updatedemail@email.com'
where id = 5
RETURNING *;

UPDATE employee
SET birthday = '2000-08-10',
	email = 'updatedemail@email.com'
where name = 'Louis Whyley'
RETURNING *;

UPDATE employee
SET name = 'Updated_FullName',
	email = 'updatedemail@email.com'
where birthday = '1981-12-23'
RETURNING *;

UPDATE employee
SET name = 'Updated_FullName',
    birthday = '1990-12-06'
where email ILIKE 'ksnel1%'
RETURNING *;

UPDATE employee
SET birthday = '1964-07-14',
	email = 'vonni@updemail.com'
where name ILIKE 'Vonni%'
RETURNING *;

--Sütunların her birine göre ilgili satırı silecek 5 adet DELETE işlemi yapalım;
DELETE FROM employee 
where id = 5
RETURNING *;

DELETE FROM employee 
where name = 'Updated_FullName'
RETURNING *;

DELETE FROM employee 
where birthday = '2000-08-10'
RETURNING *;

DELETE FROM employee 
where email ILIKE 'vonni%'
RETURNING *;

DELETE FROM employee 
where name ILIKE 'Franz%'
RETURNING *;
------------------------------------------------------------------
select * from employee;