USE [master]
GO
/****** Object:  Database [LibraryDB]    Script Date: 13.11.2019 21:00:59 ******/
CREATE DATABASE [LibraryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
GO
ALTER DATABASE [LibraryDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryDB] SET QUERY_STORE = OFF
GO
USE [LibraryDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [LibraryDB]
GO
/****** Object:  DatabaseRole [user]    Script Date: 13.11.2019 21:01:00 ******/
CREATE ROLE [user]
GO
/****** Object:  DatabaseRole [librarian]    Script Date: 13.11.2019 21:01:00 ******/
CREATE ROLE [librarian]
GO
/****** Object:  DatabaseRole [administrator]    Script Date: 13.11.2019 21:01:00 ******/
CREATE ROLE [administrator]
GO
/****** Object:  Table [dbo].[books_authors]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books_authors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book_id] [int] NOT NULL,
	[author_id] [int] NOT NULL,
 CONSTRAINT [PK_BooksAutors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[authors_full_names]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[authors_full_names]
AS
SELECT        id AS author_id, name + ' ' + last_name AS author_full_name
FROM            dbo.Authors
GO
/****** Object:  View [dbo].[books_authors_full_names]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[books_authors_full_names]
AS
SELECT        dbo.books_authors.book_id, dbo.authors_full_names.author_full_name
FROM            dbo.books_authors INNER JOIN
                         dbo.authors_full_names ON dbo.books_authors.author_id = dbo.authors_full_names.author_id
GO
/****** Object:  Table [dbo].[patents_authors]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patents_authors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[patent_id] [int] NOT NULL,
	[author_id] [int] NOT NULL,
 CONSTRAINT [PK_PatentsAuthors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[patents_autors_full_name]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[patents_autors_full_name]
AS
SELECT        dbo.patents_authors.patent_id, dbo.authors_full_names.author_full_name
FROM            dbo.patents_authors INNER JOIN
                         dbo.authors_full_names ON dbo.patents_authors.author_id = dbo.authors_full_names.author_id
GO
/****** Object:  Table [dbo].[books]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](300) NOT NULL,
	[city_id] [int] NOT NULL,
	[publishing_id] [int] NOT NULL,
	[year_publication] [datetime2](7) NOT NULL,
	[page_count] [int] NOT NULL,
	[notes] [nvarchar](2000) NULL,
	[ISBN] [nvarchar](20) NULL,
	[mark_delete] [bit] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_books] UNIQUE NONCLUSTERED 
(
	[name] ASC,
	[year_publication] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countries]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logs]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_time_operation] [datetime] NOT NULL,
	[object_type_id] [int] NOT NULL,
	[object_id] [int] NOT NULL,
	[description] [nvarchar](500) NULL,
	[user_name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[newspapers]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[newspapers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[newspaper_name_id] [int] NOT NULL,
	[city_id] [int] NOT NULL,
	[publishing_id] [int] NOT NULL,
	[year_publication] [datetime2](7) NOT NULL,
	[page_count] [int] NOT NULL,
	[notes] [nvarchar](2000) NULL,
	[number] [int] NULL,
	[date_publication] [datetime2](7) NOT NULL,
	[mark_delete] [bit] NOT NULL,
 CONSTRAINT [PK_Newspapers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_newspapers] UNIQUE NONCLUSTERED 
(
	[newspaper_name_id] ASC,
	[date_publication] ASC,
	[publishing_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[newspapers_names]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[newspapers_names](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](300) NOT NULL,
	[ISSN] [nvarchar](20) NULL,
 CONSTRAINT [PK_NewspapersNames] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objects_types]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[objects_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[object_type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_objects_types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patents]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](300) NOT NULL,
	[country_id] [int] NOT NULL,
	[registration_number] [bigint] NOT NULL,
	[date_application] [datetime2](7) NULL,
	[date_publication] [datetime2](7) NOT NULL,
	[page_count] [int] NOT NULL,
	[notes] [nvarchar](2000) NULL,
	[mark_delete] [bit] NOT NULL,
 CONSTRAINT [PK_Patents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_patents] UNIQUE NONCLUSTERED 
(
	[country_id] ASC,
	[registration_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[publishings]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publishings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Publishings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[books] ADD  CONSTRAINT [DF_Books_MarkOfDelete]  DEFAULT ((0)) FOR [mark_delete]
GO
ALTER TABLE [dbo].[logs] ADD  CONSTRAINT [DF_logs_date_time_operation]  DEFAULT (getdate()) FOR [date_time_operation]
GO
ALTER TABLE [dbo].[logs] ADD  CONSTRAINT [DF_logs_user_name]  DEFAULT (user_name()) FOR [user_name]
GO
ALTER TABLE [dbo].[newspapers] ADD  CONSTRAINT [DF_Newspapers_MarkOfDelete]  DEFAULT ((0)) FOR [mark_delete]
GO
ALTER TABLE [dbo].[patents] ADD  CONSTRAINT [DF_Patents_MarkOfDelete]  DEFAULT ((0)) FOR [mark_delete]
GO
ALTER TABLE [dbo].[books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Cities] FOREIGN KEY([city_id])
REFERENCES [dbo].[cities] ([id])
GO
ALTER TABLE [dbo].[books] CHECK CONSTRAINT [FK_Books_Cities]
GO
ALTER TABLE [dbo].[books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishings] FOREIGN KEY([publishing_id])
REFERENCES [dbo].[publishings] ([id])
GO
ALTER TABLE [dbo].[books] CHECK CONSTRAINT [FK_Books_Publishings]
GO
ALTER TABLE [dbo].[books_authors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Authors] FOREIGN KEY([author_id])
REFERENCES [dbo].[authors] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[books_authors] CHECK CONSTRAINT [FK_BooksAuthors_Authors]
GO
ALTER TABLE [dbo].[books_authors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Books] FOREIGN KEY([book_id])
REFERENCES [dbo].[books] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[books_authors] CHECK CONSTRAINT [FK_BooksAuthors_Books]
GO
ALTER TABLE [dbo].[newspapers]  WITH CHECK ADD  CONSTRAINT [FK_Newspapers_Cities] FOREIGN KEY([city_id])
REFERENCES [dbo].[cities] ([id])
GO
ALTER TABLE [dbo].[newspapers] CHECK CONSTRAINT [FK_Newspapers_Cities]
GO
ALTER TABLE [dbo].[newspapers]  WITH CHECK ADD  CONSTRAINT [FK_Newspapers_NewspapersNames] FOREIGN KEY([newspaper_name_id])
REFERENCES [dbo].[newspapers_names] ([id])
GO
ALTER TABLE [dbo].[newspapers] CHECK CONSTRAINT [FK_Newspapers_NewspapersNames]
GO
ALTER TABLE [dbo].[newspapers]  WITH CHECK ADD  CONSTRAINT [FK_Newspapers_Publishings] FOREIGN KEY([publishing_id])
REFERENCES [dbo].[publishings] ([id])
GO
ALTER TABLE [dbo].[newspapers] CHECK CONSTRAINT [FK_Newspapers_Publishings]
GO
ALTER TABLE [dbo].[patents]  WITH CHECK ADD  CONSTRAINT [FK_Patents_Countries] FOREIGN KEY([country_id])
REFERENCES [dbo].[countries] ([id])
GO
ALTER TABLE [dbo].[patents] CHECK CONSTRAINT [FK_Patents_Countries]
GO
ALTER TABLE [dbo].[patents_authors]  WITH CHECK ADD  CONSTRAINT [FK_PatentsAuthors_Authors] FOREIGN KEY([author_id])
REFERENCES [dbo].[authors] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[patents_authors] CHECK CONSTRAINT [FK_PatentsAuthors_Authors]
GO
ALTER TABLE [dbo].[patents_authors]  WITH CHECK ADD  CONSTRAINT [FK_PatentsAuthors_Patents] FOREIGN KEY([patent_id])
REFERENCES [dbo].[patents] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[patents_authors] CHECK CONSTRAINT [FK_PatentsAuthors_Patents]
GO
/****** Object:  StoredProcedure [dbo].[add_author]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_author] 
	@name nvarchar(50),
	@last_name nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.authors WHERE name = @name AND last_name = @last_name)
	INSERT INTO dbo.authors ([name], last_name)
	VALUES (@name, @last_name)
END
GO
/****** Object:  StoredProcedure [dbo].[add_book]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_book] 
	@name nvarchar(300),
	@city nvarchar(200),
	@publishing nvarchar(300),
	@year_publication datetime2(7),
	@page_count int,
	@notes nvarchar(2000),
	@ISBN nvarchar(20),
	@autors nvarchar(4000)
AS
BEGIN	
	SET NOCOUNT ON;

	DECLARE @city_id int = (SELECT c.id FROM dbo.cities c WHERE c.[name] = @city), 
	@publishing_id int = (SELECT p.id FROM dbo.publishings p WHERE p.[name] = @publishing)

	IF  @ISBN IS NULL
		IF NOT EXISTS(SELECT 1 FROM dbo.books WHERE Name = @name AND year_publication = @year_publication)
		INSERT INTO dbo.books ([name], city_id, publishing_id, year_publication, page_count, notes, ISBN)
		VALUES (@name, @city_id, @publishing_id, @year_publication, @page_count, @notes, @ISBN)
	IF  @ISBN IS NOT NULL
		IF NOT EXISTS(SELECT 1 FROM dbo.books WHERE ISBN = @ISBN)
		INSERT INTO dbo.books ([name], city_id, publishing_id, year_publication, page_count, notes, ISBN)
		VALUES (@name, @city_id, @publishing_id, @year_publication, @page_count, @notes, @ISBN)

	DECLARE @id int
	SET @id = SCOPE_IDENTITY()

	-- Work with Autors 
	IF @id IS NOT NULL 
	INSERT INTO dbo.books_authors (book_id, author_id)
	SELECT @id, a.author_id
	FROM dbo.authors_full_names AS a
	JOIN (SELECT value FROM STRING_SPLIT(@autors, ',')) AS s ON a.author_full_name = s.value	
	
END
GO
/****** Object:  StoredProcedure [dbo].[add_city]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_city] 
	@name nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.cities WHERE [name] = @name)
	INSERT INTO dbo.cities ([name])
	VALUES (@name)
END
GO
/****** Object:  StoredProcedure [dbo].[add_country]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_country] 
	@name nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.countries WHERE [name] = @name)
	INSERT INTO dbo.countries([name])
	VALUES (@name)
END
GO
/****** Object:  StoredProcedure [dbo].[add_newspaper]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_newspaper] 
	@newspaper_name nvarchar(300),
	@ISSN nvarchar(20),
	@city nvarchar(200),
	@publishing nvarchar(300),
	@year_publication datetime2(7),
	@page_count int,
	@notes nvarchar(2000),
	@number int,
	@date_publication datetime2(7)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @city_id int = (SELECT c.id FROM dbo.cities c WHERE c.[name] = @city) 
	, @publishing_id int = (SELECT p.id FROM dbo.publishings p WHERE p.[name] = @publishing)
	, @newspaper_name_id int = (SELECT n.id  FROM dbo.newspapers_names n WHERE @newspaper_name = n.[name])

	IF @ISSN IS NULL
	IF NOT EXISTS(SELECT 1 FROM dbo.newspapers WHERE newspaper_name_id = @newspaper_name_id AND publishing_id = @publishing_id AND date_publication = @date_publication)
	IF (DATEDIFF(year, @year_publication, @date_publication) = 0)
	INSERT INTO dbo.newspapers (newspaper_name_id, city_id, publishing_id, year_publication, page_count, notes, number, date_publication)
	VALUES (@newspaper_name_id, @city_id, @publishing_id, @year_publication, @page_count, @notes, @number, @date_publication)
	
	IF @ISSN IS NOT NULL
	IF @newspaper_name = (SELECT n.[name] FROM dbo.newspapers_names n WHERE @ISSN = n.ISSN)	
	IF NOT EXISTS(SELECT 1 FROM dbo.newspapers WHERE newspaper_name_id = @newspaper_name_id AND publishing_id = @publishing_id AND date_publication = @date_publication)	
    IF (DATEDIFF(year, @year_publication, @date_publication) = 0)
	INSERT INTO dbo.newspapers (newspaper_name_id, city_id, publishing_id, year_publication, page_count, notes, number, date_publication)
	VALUES (@newspaper_name_id, @city_id, @publishing_id, @year_publication, @page_count, @notes, @number, @date_publication)

END
GO
/****** Object:  StoredProcedure [dbo].[add_newspaper_name_and_ISSN]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_newspaper_name_and_ISSN] 
	@name nvarchar(300),
	@ISSN nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;

    IF @ISSN IS NULL
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM dbo.newspapers_names WHERE [name] = @name)
			INSERT INTO dbo.newspapers_names ([name], [ISSN])
			VALUES (@name, @ISSN)
		END			
	IF @ISSN IS NOT NULL
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM dbo.newspapers_names WHERE [name] = @name AND ISSN = @ISSN )
			INSERT INTO dbo.newspapers_names ([name], ISSN)
			VALUES (@name, @ISSN)
		END	
	
END
GO
/****** Object:  StoredProcedure [dbo].[add_object_type]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_object_type]
	@object_type nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.objects_types (object_type)
	VALUES(@object_type)

END
GO
/****** Object:  StoredProcedure [dbo].[add_patent]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_patent]
	@name nvarchar(300),
	@country nvarchar(200),
	@registration_number bigint,
	@date_application datetime2(7),
	@date_publication datetime2(7),
	@page_count int,
	@notes nvarchar(2000),
	@autors nvarchar(4000)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @country_id int = (SELECT c.id FROM dbo.countries c WHERE @country = c.[name]) 

	IF NOT EXISTS(SELECT 1  FROM dbo.patents p WHERE @registration_number = p.registration_number AND @country_id = p.country_id )
	INSERT INTO dbo.patents ([name], country_id, registration_number, date_application, date_publication, page_count, notes)
	VALUES (@name, @country_id, @registration_number, @date_application, @date_publication, @page_count, @notes)

	DECLARE @id int
	SET @id = SCOPE_IDENTITY()

	-- Work with Autors 
	IF @id IS NOT NULL 
	INSERT INTO dbo.patents_authors(patent_id, author_id)
	SELECT @id, a.author_id
	FROM dbo.authors_full_names AS a
	JOIN (SELECT value FROM STRING_SPLIT(@autors, ',')) AS s ON a.author_full_name = s.value	
END
GO
/****** Object:  StoredProcedure [dbo].[add_publishing]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_publishing] 
	@name nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM dbo.publishings WHERE [name] = @name)
	INSERT INTO dbo.publishings ([name])
	VALUES (@name)
END
GO
/****** Object:  StoredProcedure [dbo].[delete_author]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_author] 
	@author nvarchar(250)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM dbo.authors_full_names a WHERE a.author_full_name = @author)	
	DELETE FROM dbo.authors WHERE id = (SELECT a.author_id FROM dbo.authors_full_names a WHERE a.author_full_name = @author)

END
GO
/****** Object:  StoredProcedure [dbo].[delete_book]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_book] 
	@name nvarchar(300),
	@ISBN nvarchar(20),
	@year_publication datetime2(7),
	@autors nvarchar(4000)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @book_id int = 0

	IF @ISBN IS NOT NULL	
	BEGIN
		IF EXISTS (SELECT 1 FROM dbo.books WHERE ISBN = @ISBN AND [name] = @name)
		SET @book_id = (SELECT id FROM dbo.books WHERE ISBN = @ISBN)
	END
	ELSE
	BEGIN		
		IF EXISTS (SELECT 1 FROM dbo.books WHERE [name] = @name)		
		SET @book_id = (SELECT id FROM dbo.books WHERE [name] = @name)
	END

	IF IS_MEMBER('librarian') = 0
	BEGIN
		IF ((SELECT DATEDIFF(year, b.year_publication, @year_publication) FROM dbo.books b WHERE b.id = @book_id) = 0)
		DELETE FROM dbo.books WHERE id = @book_id	
	END
	ELSE
	BEGIN
		UPDATE dbo.books SET dbo.books.mark_delete = 1 WHERE dbo.books.id = @book_id
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[delete_city]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_city]
	@name nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.cities WHERE [name] = @name)	
	DELETE FROM dbo.cities WHERE id = (SELECT c.id FROM dbo.cities c WHERE c.[name] = @name)

END
GO
/****** Object:  StoredProcedure [dbo].[delete_country]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_country] 
	@name nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM dbo.countries WHERE [name] = @name)	
	DELETE FROM dbo.countries WHERE id = (SELECT c.id FROM dbo.countries c WHERE c.[name] = @name)
END
GO
/****** Object:  StoredProcedure [dbo].[delete_newspaper]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_newspaper]
	@newspaper_name nvarchar(300),
	@publishing nvarchar(300),
	@number int,
	@date_publication datetime2(7)
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @newspaper_id int
	, @publishing_id int = (SELECT p.id FROM dbo.publishings p WHERE p.[name] = @publishing)
	, @newspaper_name_id int = (SELECT n.id  FROM dbo.newspapers_names n WHERE @newspaper_name = n.[name])

	IF EXISTS(SELECT 1 FROM dbo.newspapers WHERE publishing_id = @publishing_id AND newspaper_name_id = @newspaper_name_id AND number = @number)
	IF ((SELECT DATEDIFF(day, n.date_publication, @date_publication) FROM dbo.newspapers n WHERE n.id = @newspaper_id) = 0)
	SET @newspaper_id = (SELECT id FROM dbo.newspapers WHERE publishing_id = @publishing_id AND newspaper_name_id = @newspaper_name_id AND number = @number)

	IF IS_MEMBER('librarian') = 0
	BEGIN		
		DELETE FROM dbo.newspapers WHERE id = @newspaper_id		
	END
	ELSE
	BEGIN
		UPDATE dbo.newspapers SET dbo.newspapers.mark_delete = 1 WHERE dbo.newspapers.id = @newspaper_id
	END	

END
GO
/****** Object:  StoredProcedure [dbo].[delete_newspaper_name_and_ISSN]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_newspaper_name_and_ISSN]
	@name nvarchar(300),
	@ISSN nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	IF @ISSN IS NULL
		BEGIN
			IF EXISTS (SELECT 1 FROM dbo.newspapers_names WHERE [name] = @name)
			DELETE FROM dbo.newspapers_names WHERE id = (SELECT n.id FROM dbo.newspapers_names n WHERE n.[name] = @name)
		END			
	IF @ISSN IS NOT NULL
		BEGIN
			IF EXISTS (SELECT 1 FROM dbo.newspapers_names WHERE [name] = @name AND ISSN = @ISSN )
			DELETE FROM dbo.newspapers_names WHERE id = (SELECT n.id FROM dbo.newspapers_names n WHERE n.[name] = @name)
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[delete_patent]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_patent] 
	@country nvarchar(200),
	@registration_number bigint	
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @country_id int = (SELECT c.id FROM dbo.countries c WHERE @country = c.[name]),
	@patent_id int

	IF EXISTS(SELECT 1  FROM dbo.patents p WHERE p.registration_number = @registration_number AND p.country_id = @country_id)
    SET @patent_id = (SELECT p.id FROM dbo.patents p WHERE p.registration_number = @registration_number AND p.country_id = @country_id)
	
	IF @patent_id IS NOT NULL
	BEGIN
		IF IS_MEMBER('librarian') = 0
		BEGIN
			DELETE FROM dbo.patents WHERE id = @patent_id
		END
		ELSE
		BEGIN
			UPDATE dbo.patents SET dbo.patents.mark_delete = 1 WHERE dbo.patents.id = @patent_id
		END	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[delete_publishing]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_publishing] 
	@name nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.publishings WHERE [name] = @name)	
	DELETE FROM dbo.publishings WHERE id = (SELECT p.id FROM dbo.publishings p WHERE p.[name] = @name)
END
GO
/****** Object:  StoredProcedure [dbo].[get_all_books]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_all_books] 

AS
BEGIN
	SET NOCOUNT ON;

	EXEC dbo.get_books_by_name ''

END
GO
/****** Object:  StoredProcedure [dbo].[get_all_newspapers]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_all_newspapers] 

AS
BEGIN
	SET NOCOUNT ON;

	SELECT nn.[name] AS [name],  n.number, n.date_publication, p.[name] AS publishing, n.year_publication, n.page_count, n.notes FROM dbo.newspapers n
	JOIN dbo.newspapers_names nn ON n.newspaper_name_id = nn.id 
	JOIN dbo.publishings p ON n.publishing_id = p.id
 	
END
GO
/****** Object:  StoredProcedure [dbo].[get_all_patents]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_all_patents] 

AS
BEGIN
	SET NOCOUNT ON;

    SELECT p.name, c.[name] AS country, p.registration_number, pa_table.authors AS authors , p.date_application, p.date_publication, p.page_count, p.notes FROM dbo.patents p
	JOIN dbo.countries c ON p.country_id = c.id
	JOIN (SELECT pa.patent_id AS book_id, 
		STUFF((SELECT ' ' + paf.author_full_name FROM dbo.patents_autors_full_name paf WHERE pa.patent_id = paf.patent_id FOR XML PATH('')),1,1,'') AS authors
		FROM dbo.patents_autors_full_name pa 
		GROUP BY pa.patent_id ) pa_table
	ON p.id = pa_table.book_id

END
GO
/****** Object:  StoredProcedure [dbo].[get_books_by_name]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_books_by_name] 
	@query nvarchar(500)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT b.[name] AS [name], ba_table.authors AS authors, c.[name] AS city, p.[name] AS publishing, b.year_publication, b.page_count, b.notes, b.ISBN  FROM dbo.books b
	JOIN dbo.cities c ON b.city_id = c.id 
	JOIN dbo.publishings p ON b.publishing_id = p.id  
	JOIN (SELECT ba.book_id AS book_id, 
		STUFF((SELECT ' ' + baf.author_full_name FROM dbo.books_authors_full_names baf WHERE ba.book_id = baf.book_id FOR XML PATH('')),1,1,'') AS authors
		FROM dbo.books_authors_full_names ba 
		GROUP BY ba.book_id ) ba_table
	ON b.id = ba_table.book_id
	WHERE b.name LIKE '%' + @query + '%'
    
END
GO
/****** Object:  StoredProcedure [dbo].[update_book_notes]    Script Date: 13.11.2019 21:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[update_book_notes] 
	@name nvarchar(300),
	@notes nvarchar(2000),
	@ISBN nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @book_id int = NULL

	IF @ISBN IS NOT NULL 
    IF EXISTS (SELECT 1 FROM dbo.books WHERE [name] = @name AND ISBN = @ISBN)
	SET @book_id = (SELECT b.id FROM dbo.books b WHERE b.[name] = @name AND b.ISBN = @ISBN)

	IF @ISBN IS NULL
	IF EXISTS (SELECT 1 FROM dbo.books WHERE [name] = @name)
	SET @book_id = (SELECT b.id FROM dbo.books b WHERE b.[name] = @name)

	IF @book_id IS NOT NULL
	UPDATE dbo.books SET dbo.books.notes = @notes WHERE dbo.books.id = @book_id

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Authors"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1890
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'authors_full_names'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'authors_full_names'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "books_authors"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "authors_full_names"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 427
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'books_authors_full_names'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'books_authors_full_names'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "patents_authors"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "authors_full_names"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 427
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'patents_autors_full_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'patents_autors_full_name'
GO
USE [master]
GO
ALTER DATABASE [LibraryDB] SET  READ_WRITE 
GO
