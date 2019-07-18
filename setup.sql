use kitchenex;

-- CREATE TABLE  allergens
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- )
-- CREATE TABLE  stations
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- );
-- CREATE TABLE  categorys
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- );
-- CREATE TABLE  units
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   size DECIMAL,
--   PRIMARY KEY (id)
-- );




-- CREATE TABLE  ingredients
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   brand VARCHAR(255) NOT NULL,
--   distributor VARCHAR(255) NOT NULL,
--   quantity INT NOT NULL,
--   packageCost INT,
--   packageSize DECIMAL,
--   unitId INT,
--   categoryId INT,
--   recipeId INT,
--   inventoryId INT,

--   INDEX(categoryId, recipeId, inventoryId),

--   FOREIGN KEY (categoryId)
--       REFERENCES  categorys(id),
--   FOREIGN KEY (recipeId)
--       REFERENCES  recipes(id),
--   FOREIGN KEY (inventoryId)
--       REFERENCES  inventory(id),
--   FOREIGN KEY (unitId)
--       REFERENCES  units(id),

--   PRIMARY KEY (id)
-- );

-- CREATE TABLE recipes
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   portions INT NOT NULL,
--   portionSize INT NOT NULL,
--   calories INT NOT NULL,
--   side TINYINT NOT NULL,
--   allergensId INT,
--   stationsId INT,
--   unitId INT,
--   kitchenId INT,
--   menuId INT,
--   dayId INT,

--   INDEX(kitchenId, menuId, dayId),

--   FOREIGN KEY (allergensId)
--       REFERENCES allergens(id),
--   FOREIGN KEY (stationsId)
--       REFERENCES stations(id),
--   FOREIGN KEY (unitId)
--       REFERENCES units(id),
--   FOREIGN KEY (kitchenId)
--       REFERENCES kitchens(id),
--   FOREIGN KEY (menuId)
--       REFERENCES menus(id),
--   FOREIGN KEY (dayId)
--       REFERENCES days(id),

--   PRIMARY KEY (id)
-- );

-- CREATE TABLE kitchens
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   siteId INT,
  
--   INDEX(siteId),

--   FOREIGN KEY (siteId)
--       REFERENCES sites(id),

--   PRIMARY KEY (id)
-- )

-- CREATE TABLE sites
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   userId INT,
  
--   FOREIGN KEY (userId)
--       REFERENCES users(id),

--   PRIMARY KEY (id)
-- )
-- CREATE TABLE admins
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   userId INT,

--   INDEX(userId),

--   FOREIGN KEY (userId)
--       REFERENCES users(id),

--   PRIMARY KEY (id)
-- )
-- CREATE TABLE chefs
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   userId INT,

-- INDEX(userId),

--   FOREIGN KEY (userId)
--       REFERENCEs users(id),

--   PRIMARY KEY (id)
-- )
-- CREATE TABLE users
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   password VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id)
-- )
-- CREATE TABLE inventory
-- (
--   id INT AUTO_INCREMENT,
--   kitchenId INT,
   
--   FOREIGN KEY (kitchenId)
--       REFERENCES kitchens(id),
 
--   PRIMARY KEY (id)
-- )
-- CREATE TABLE menus
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   kitchenId INT,
--   siteId INT,
  
--   FOREIGN KEY (kitchenId)
--       REFERENCES kitchens(id),
--   FOREIGN KEY (siteId)
--       REFERENCES sites(id),
 
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE days
-- (
--     id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   menuId INT,
  
--   FOREIGN KEY (menuId)
--       REFERENCES menus (id),

--   PRIMARY KEY (id)
-- )