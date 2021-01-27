
-- DELETE table wishlistproducts
-- DELETE table wishlists


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
-- ALTER TABLE vaultkeeps


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

-- UPDATE profiles SET name = 'Chris' WHERE id = '3e2ec1fd-bdfe-4cff-a154-9a718f2d2035'
-- UPDATE profiles SET name = 'Ned Flanders' WHERE id = '4f041796-e380-4297-ba5a-5181a84e1a7c'
-- UPDATE profiles SET name = 'Joe Dirt' WHERE id = '587f6a76-aaf4-48ba-9ee9-005879a94da7'
-- UPDATE profiles SET picture = 'https://images.pexels.com/photos/321552/pexels-photo-321552.jpeg?cs=srgb&dl=pexels-visionpic-net-321552.jpg&fm=jpg' WHERE id = '3e2ec1fd-bdfe-4cff-a154-9a718f2d2035'
-- UPDATE profiles SET picture = 'https://www.usmagazine.com/wp-content/uploads/David-Spade-Joe-Dirt-467.jpg?w=400&quality=86&strip=all' WHERE id = '587f6a76-aaf4-48ba-9ee9-005879a94da7'
-- TRUNCATE TABLE vaultkeeps




