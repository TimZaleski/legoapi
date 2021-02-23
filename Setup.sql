USE legotimz;

CREATE TABLE bricks
(
  id INT AUTO_INCREMENT,
  description VARCHAR(255),
  color VARCHAR(255),
  PRIMARY KEY (id)
);

INSERT INTO bricks
(description, color)
VALUES
("2x2 brick", "yellow"),("2x2 brick", "blue"),("1x8 brick", "black"),("2x4 brick", "red");

