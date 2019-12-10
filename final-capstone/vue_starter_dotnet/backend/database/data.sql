-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

BEGIN TRANSACTION;

-- default username of 'user' and default password of 'greatwall'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('user', 'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', '9CWPUTvXqQ4=', 'User');

COMMIT TRANSACTION;


BEGIN TRANSACTION;

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

COMMIT TRANSACTION;

INSERT INTO Preferences
  (city, cuisine, price, distance)
VALUES
  ('Cleveland', 'Italian', 3, 4.6);

COMMIT TRANSACTION;
