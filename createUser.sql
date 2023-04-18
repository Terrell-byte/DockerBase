USE userDB;

DROP TABLE IF EXISTS users;

CREATE TABLE users (
	username VARCHAR(50) NOT NULL,
	password VARCHAR(50) NOT NULL,
	PRIMARY KEY (username)
);

INSERT INTO users (username, password) VALUES ('admin', 'admin');