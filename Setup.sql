USE legotimz;

CREATE TABLE bricks
(
  id INT AUTO_INCREMENT,
  description VARCHAR(255),
  PRIMARY KEY (id)
);

INSERT INTO bricks
(description)
VALUES
("2x2 yellow brick"),("2x2 blue brick"),("1x8 black brick"),("2x4 red brick");
