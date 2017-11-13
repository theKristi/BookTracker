-- Set the database context.
USE BookTracker;
GO

-- Check if the table exists and drop if it exists.
IF OBJECT_ID('dbo.Book', 'U') IS NOT NULL
	DROP TABLE dbo.Book;
GO

-- Output into the stack.
PRINT '.....Creating Table dbo.Book';
GO

-- Define table structure.
CREATE TABLE dbo.Book

	(
		BookID INTEGER NOT NULL IDENTITY(1,1),
		Title NVARCHAR(128) NOT NULL,
		Author NVARCHAR(128) NOT NULL,
		ISBN NVARCHAR(10) NOT NULL,
		Synopsis NVARCHAR(255),
		OwnerID NVARCHAR(450) NOT NULL,
		CheckedOutID NVARCHAR(450)	
	);
GO

-- Add Constraints.
BEGIN;

	-- Primary Key.
	BEGIN;

		-- 
		ALTER TABLE dbo.Book
			WITH CHECK
			ADD CONSTRAINT PK_Book
			PRIMARY KEY CLUSTERED
				(
					BookID ASC
				)
			WITH FILLFACTOR = 90
			ON [PRIMARY];

	END;
	
	-- Foreign Key(s).
	
	-- Foreign Key(s).
	BEGIN;	
		ALTER TABLE dbo.Book
			ADD CONSTRAINT FK_Book_OwnerId FOREIGN KEY (OwnerID)
			REFERENCES dbo.AspNetUsers(ID)

		ALTER TABLE dbo.Book
			ADD CONSTRAINT FK_Book_CheckedOut FOREIGN KEY (CheckedOutID)
			REFERENCES dbo.AspNetUsers(ID)

	
		
	END;
	-- Unique Constraint(s).	


	-- Default Constraint(s).
	

	-- Check Constraints.

END;
GO


