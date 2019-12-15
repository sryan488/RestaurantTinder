-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

BEGIN TRANSACTION;

-- default username of 'user' and default password of 'greatwall'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('user', 'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', '9CWPUTvXqQ4=', 'User');

INSERT INTO users
  (username,password,salt,role)
VALUES
  ('Joe', 'ilovedogs', '9CWPUTvXqQ4=', 'User');

INSERT INTO users
  (username,password,salt,role)
VALUES
  ('Steve', 'ilovedogs', '9CWPUTvXqQ4=', 'User');

INSERT INTO users
  (username,password,salt,role)
VALUES
  ('Sean', 'ilovedogs', '9CWPUTvXqQ4=', 'User');

INSERT INTO users
  (username,password,salt,role)
VALUES
  ('Alex', 'ilovedogs', '9CWPUTvXqQ4=', 'User');

INSERT Preferences
  (users_id, city, cuisine, price, distance)
VALUES
  (1, 'Cleveland', 'Italian', 3, 4.6);

  INSERT INTO Preferences
  (users_id, city, cuisine, price, distance)
VALUES
  (2, 'Pittsburgh', 'American', 1, 10);

  INSERT INTO Preferences
  (users_id, city, cuisine, price, distance)
VALUES
  (3, 'Bay Village', 'German', 4, 15);

    INSERT INTO Preferences
  (users_id, city, cuisine, price, distance)
VALUES
   (4, 'Lakewood', 'Chinese', 2, 11);

       INSERT INTO Preferences
  (users_id, city, cuisine, price, distance)
VALUES
   (5, 'Mentor', 'Mexican', 4, 20);


SELECT * FROM preferences

SELECT * FROM users

COMMIT TRANSACTION