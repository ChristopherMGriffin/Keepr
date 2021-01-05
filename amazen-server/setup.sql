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
ALTER TABLE vaultkeeps


-- ALTER TABLE  keeps
-- DROP COLUMN keeps,
-- ADD COLUMN keepCount int NOT NULL

-- ALTER TABLE keeps
-- ADD COLUMN isPrivate TINYINT
-- MODIFY COLUMN description VARCHAR(955)
-- MODIFY COLUMN keepCount int DEFAULT 0
-- DROP COLUMN isPrivate
-- MODIFY COLUMN views int DEFAULT 0
-- MODIFY COLUMN shares int DEFAULT 0
-- MODIFY COLUMN image VARCHAR(255)
-- DROP COLUMN keepCount
-- CHANGE COLUMN image img VARCHAR(255) not NULL
-- ADD COLUMN isPrivate TINYINT DEFAULT 0
-- DROP COLUMN keepCount
-- ADD COLUMN keeps int DEFAULT 0
--  drop TABLE keeps

-- ALTER TABLE keeps
-- RENAME TO keepstable



