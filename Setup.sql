USE burgertimz;

CREATE TABLE burgers
(
  id INT AUTO_INCREMENT,
  title VARCHAR(255) NOT NULL UNIQUE,
  description VARCHAR(255),
  price DECIMAL(6 , 2) NOT NULL,

  PRIMARY KEY (id)
);

CREATE TABLE sides
(
  id INT AUTO_INCREMENT,
  title VARCHAR(255) NOT NULL UNIQUE,
  description VARCHAR(255),
  price DECIMAL(6 , 2) NOT NULL,

  PRIMARY KEY (id)
);

CREATE TABLE drinks
(
  id INT AUTO_INCREMENT,
  title VARCHAR(255) NOT NULL UNIQUE,
  description VARCHAR(255),
  price DECIMAL(6 , 2) NOT NULL,

  PRIMARY KEY (id)
);

INSERT INTO burgers
(title, description, price)
VALUES
("Santa Burger", "Its from very fatty", 201.21),
("Whiskey River BBQ", "I had it for lunch", 11.50);

INSERT INTO sides
(title, description, price)
VALUES
("Steak Fries", "Thiccc", 2.99),
("Coleslaw", "Gross", 1.99);

INSERT INTO drinks
(title, description, price)
VALUES
("Lemonade", "Tangy", 1.49),
("Root Beer", "Does it float?", 1.49);