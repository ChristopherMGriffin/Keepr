-- CREATE TABLE keeps (
--   id int AUTO_INCREMENT NOT NULL  PRIMARY KEY,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   image VARCHAR(255) NOT NULL,
--   views int NOT NULL,
--   shares intR(255) NOT NULL,
--   keeps int NOT NULL,
--   FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )

-- CREATE TABLE vaults (
--   id int AUTO_INCREMENT NOT NULL  PRIMARY KEY,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   isPublished TINYINT NOT NULL
-- )

-- CREATE TABLE vaultkeeps (
--   id int AUTO_INCREMENT NOT NULL  PRIMARY KEY,
--   creatorId VARCHAR(255) NOT NULL,
--   vaultId int NOT NULL,
--   keepId int NOT NULL,

--   FOREIGN KEY (vaultId)
--   REFERENCES vaults (id)
--   ON DELETE CASCADE,

--   FOREIGN KEY (keepId)
--   REFERENCES keeps (id)
--   ON DELETE CASCADE,

--   FOREIGN KEY (creatorId)
--   REFERENCES profiles(id)
--   ON DELETE CASCADE
-- )

-- ALTER TABLE  keeps
-- DROP COLUMN keeps,
-- ADD COLUMN keepCount int NOT NULL

ALTER TABLE keeps
-- ADD COLUMN isPrivate TINYINT
MODIFY COLUMN description VARCHAR(955)

