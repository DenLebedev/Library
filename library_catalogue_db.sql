USE [master]
GO
/****** Object:  Database [LibraryCatalogueDB]    Script Date: 15.12.2019 15:53:14 ******/
CREATE DATABASE [LibraryCatalogueDB]
 CONTAINMENT = NONE
GO
ALTER DATABASE [LibraryCatalogueDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryCatalogueDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryCatalogueDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryCatalogueDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryCatalogueDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryCatalogueDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryCatalogueDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryCatalogueDB] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryCatalogueDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryCatalogueDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryCatalogueDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryCatalogueDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryCatalogueDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryCatalogueDB] SET QUERY_STORE = OFF
GO
USE [LibraryCatalogueDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [LibraryCatalogueDB]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](200) NULL,
 CONSTRAINT [PK_authors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[books]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[id] [int] NOT NULL,
	[publishing_id] [int] NOT NULL,
	[city_id] [int] NOT NULL,
	[year_publication] [int] NOT NULL,
	[ISBN] [nvarchar](20) NULL,
 CONSTRAINT [PK_books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[books_authors]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books_authors](
	[book_id] [int] NOT NULL,
	[author_id] [int] NOT NULL,
 CONSTRAINT [PK_books_authors] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC,
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_cities] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countries]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_countries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logs]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_time_operation] [datetime] NOT NULL,
	[publication_type_id] [int] NOT NULL,
	[card_id] [int] NOT NULL,
	[description] [nvarchar](500) NULL,
	[user_name] [nvarchar](100) NULL,
 CONSTRAINT [PK_logs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[newspapers]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[newspapers](
	[id] [int] NOT NULL,
	[number] [int] NOT NULL,
	[publishing_id] [int] NOT NULL,
	[city_id] [int] NOT NULL,
	[year_publication] [int] NOT NULL,
	[date_application] [datetime2](7) NOT NULL,
	[ISSN] [nvarchar](20) NULL,
 CONSTRAINT [PK_newspapers_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[newspapers_names]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[newspapers_names](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](300) NULL,
 CONSTRAINT [PK_newspapers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patents]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patents](
	[id] [int] NOT NULL,
	[country_id] [int] NOT NULL,
	[registration_number] [bigint] NOT NULL,
	[date_publication] [datetime2](7) NOT NULL,
	[date_application] [datetime2](7) NULL,
 CONSTRAINT [PK_patents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patents_athors]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patents_athors](
	[patent_id] [int] NOT NULL,
	[author_id] [int] NOT NULL,
 CONSTRAINT [PK_patents_athors] PRIMARY KEY CLUSTERED 
(
	[patent_id] ASC,
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[publications]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publications](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](300) NOT NULL,
	[page_count] [int] NOT NULL,
	[notes] [nvarchar](2000) NULL,
	[mark_delete] [bit] NOT NULL,
 CONSTRAINT [PK_catalogue_carts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[publications_types]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publications_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[publication_type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_objects_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[publishings]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publishings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_publishings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[publications] ADD  CONSTRAINT [DF_catalogue_carts_mark_delete]  DEFAULT ((0)) FOR [mark_delete]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_role_id]  DEFAULT ((1)) FOR [role_id]
GO
ALTER TABLE [dbo].[books_authors]  WITH CHECK ADD  CONSTRAINT [FK_books_authors_authors] FOREIGN KEY([author_id])
REFERENCES [dbo].[authors] ([id])
GO
ALTER TABLE [dbo].[books_authors] CHECK CONSTRAINT [FK_books_authors_authors]
GO
ALTER TABLE [dbo].[books_authors]  WITH CHECK ADD  CONSTRAINT [FK_books_authors_books_authors] FOREIGN KEY([book_id])
REFERENCES [dbo].[books] ([id])
GO
ALTER TABLE [dbo].[books_authors] CHECK CONSTRAINT [FK_books_authors_books_authors]
GO
ALTER TABLE [dbo].[logs]  WITH CHECK ADD  CONSTRAINT [FK_logs_cards_types] FOREIGN KEY([publication_type_id])
REFERENCES [dbo].[publications_types] ([id])
GO
ALTER TABLE [dbo].[logs] CHECK CONSTRAINT [FK_logs_cards_types]
GO
ALTER TABLE [dbo].[newspapers]  WITH CHECK ADD  CONSTRAINT [FK_newspapers_cities] FOREIGN KEY([city_id])
REFERENCES [dbo].[cities] ([id])
GO
ALTER TABLE [dbo].[newspapers] CHECK CONSTRAINT [FK_newspapers_cities]
GO
ALTER TABLE [dbo].[newspapers]  WITH CHECK ADD  CONSTRAINT [FK_newspapers_publications] FOREIGN KEY([id])
REFERENCES [dbo].[publications] ([id])
GO
ALTER TABLE [dbo].[newspapers] CHECK CONSTRAINT [FK_newspapers_publications]
GO
ALTER TABLE [dbo].[newspapers]  WITH CHECK ADD  CONSTRAINT [FK_newspapers_publishings] FOREIGN KEY([publishing_id])
REFERENCES [dbo].[publishings] ([id])
GO
ALTER TABLE [dbo].[newspapers] CHECK CONSTRAINT [FK_newspapers_publishings]
GO
ALTER TABLE [dbo].[patents]  WITH CHECK ADD  CONSTRAINT [FK_patents_countries] FOREIGN KEY([country_id])
REFERENCES [dbo].[countries] ([id])
GO
ALTER TABLE [dbo].[patents] CHECK CONSTRAINT [FK_patents_countries]
GO
ALTER TABLE [dbo].[patents]  WITH CHECK ADD  CONSTRAINT [FK_patents_publications] FOREIGN KEY([id])
REFERENCES [dbo].[publications] ([id])
GO
ALTER TABLE [dbo].[patents] CHECK CONSTRAINT [FK_patents_publications]
GO
ALTER TABLE [dbo].[patents_athors]  WITH CHECK ADD  CONSTRAINT [FK_patents_athors_authors] FOREIGN KEY([author_id])
REFERENCES [dbo].[authors] ([id])
GO
ALTER TABLE [dbo].[patents_athors] CHECK CONSTRAINT [FK_patents_athors_authors]
GO
ALTER TABLE [dbo].[patents_athors]  WITH CHECK ADD  CONSTRAINT [FK_patents_athors_patents] FOREIGN KEY([patent_id])
REFERENCES [dbo].[patents] ([id])
GO
ALTER TABLE [dbo].[patents_athors] CHECK CONSTRAINT [FK_patents_athors_patents]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_roles]
GO
/****** Object:  StoredProcedure [dbo].[author_add]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[author_add] 
	@name nvarchar(50),
	@surname nvarchar(200),
	@id int OUTPUT
AS
BEGIN

	SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.authors WHERE [name] = @name AND surname = @surname)
	INSERT INTO dbo.authors ([name], surname)
	VALUES (@name, @surname)

	SET @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[author_delete]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[author_delete]
	@id int
AS
BEGIN

	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM dbo.authors a WHERE a.id = @id)	
	DELETE FROM dbo.authors WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[author_edit]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[author_edit] 
	@name nvarchar(50),
	@surname nvarchar(200),
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE dbo.authors SET [name] = @Name, surname = @Surname WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[author_get_by_id]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[author_get_by_id] 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 id, [name], surname FROM dbo.authors WHERE id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[authors_get_all]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[authors_get_all] 
	
AS
BEGIN
	SET NOCOUNT ON;

    SELECT id, [name], surname FROM dbo.authors
END
GO
/****** Object:  StoredProcedure [dbo].[book_add]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[book_add]
	@book nvarchar(MAX),
	@id int OUTPUT
AS
BEGIN

	SET NOCOUNT ON;	

	INSERT INTO dbo.publications(
	[name]
	, [page_count]
	, [notes])

	SELECT 
	[name]
	, [page_count]
	, [notes]
	FROM OPENJSON (@book)
	WITH(
		[name] nvarchar(300) '$.Name'
		, [page_count] int '$.PageCount'
		, [notes] nvarchar(2000) '$.Notes'
	)
	SET @id = @@IDENTITY

	INSERT INTO dbo.books(
	[id]
	, [city_id]
	, [publishing_id]
	, [year_publication]
	, [ISBN]) 
	SELECT
	@id
	, [city_id]
	, [publishing_id]
	, [year_publication]
	, [ISBN]
	FROM OPENJSON (@book)
	WITH(
		[city_id] int '$.City.Id'
		, [publishing_id] int '$.Publishing.Id'
		, [year_publication] int '$.YearPublication'
		, [ISBN] nvarchar(20) '$.ISBN'
	) 

	INSERT INTO dbo.books_authors(
	[book_id]
	, [author_id])
	SELECT
	@id
	, [author_id]
	FROM OPENJSON (@book)
	WITH(
		[author_id] int '$.Author.Id'
	) 

END
GO
/****** Object:  StoredProcedure [dbo].[book_delete]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[book_delete] 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.publications p WHERE p.id = @id)	
	DELETE FROM dbo.publications WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[book_edit]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[book_edit] 
	@book nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE p
	SET 
	p.[name] = book.[name]
	, p.[page_count] = book.[page_count]
	, p.[notes] = book.[notes]
	FROM dbo.publications p
		INNER JOIN
			(SELECT 
			JSON_VALUE(@book, '$.Id') AS [id]
			, JSON_VALUE(@book, '$.Name') AS [name]
			, JSON_VALUE(@book, '$.PageCount') AS [page_count]
			, JSON_VALUE(@book, '$.Notes') AS [notes]
			) AS book
		ON p.id = book.id
	WHERE p.id = book.id

	UPDATE b
	SET 
	b.[city_id] = book.[city_id]
	, b.[publishing_id] = book.[publishing_id]
	, b.[year_publication] = book.[year_publication]
	, b.[ISBN] = book.[ISBN]
	FROM dbo.books b
		JOIN
			(SELECT 
			JSON_VALUE(@book, '$.Id') AS [id]
			, JSON_VALUE(@book, '$.City.Id') AS [city_id]
			, JSON_VALUE(@book, '$.Publishing.Id') AS [publishing_id]
			, JSON_VALUE(@book, '$.YearPublication') AS [year_publication]
			, JSON_VALUE(@book, '$.ISBN') AS [ISBN]
			) AS book
		ON b.id = book.id
	WHERE b.id = book.id

	UPDATE ba
	SET 
	ba.[author_id] = book.[author_id]
	FROM dbo.books_authors ba
		JOIN
			(SELECT 
			JSON_VALUE(@book, '$.Id') AS [id]
			, JSON_VALUE(@book, '$.Author.Id') AS [author_id]
			) AS book
		ON ba.book_id = book.id
	WHERE ba.book_id = book.id

END
GO
/****** Object:  StoredProcedure [dbo].[book_get_by_id]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[book_get_by_id]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 
	p.id AS [Id]
	, p.[name] AS [Name]
	, p.page_count AS [PageCount]
	, p.notes AS [Notes]
	, p.mark_delete AS [MarkDelete]
	, b.year_publication AS [YearPublication]
	, b.ISBN AS [ISBN]
	, b.city_id AS [CityId]
	, c.[name] AS [CityName]
	, b.publishing_id AS [PublishingId]
	, pb.[name] AS [PublishingName]
	, au.author_id AS [AuthorId]
	, au.[name] AS [AuthorName]
	, au.surname AS [AuthorSurname]
	FROM dbo.publications p
	JOIN dbo.books b ON b.id = p.id
	JOIN dbo.cities c ON b.city_id = c.id
	JOIN dbo.publishings pb ON b.publishing_id = pb.id
	JOIN (SELECT ba.book_id, ba.author_id, a.[name], a.surname FROM dbo.books_authors ba, authors a WHERE ba.author_id = a.id) AS au
	ON au.book_id = p.id
	 WHERE p.id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[cities_get_all]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cities_get_all]

AS
BEGIN
	SET NOCOUNT ON;

    SELECT id, [name] FROM dbo.cities
END
GO
/****** Object:  StoredProcedure [dbo].[city_add]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[city_add]
	@name nvarchar(200),
	@id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.cities WHERE [name] = @name)
	INSERT INTO dbo.cities([name])
	VALUES (@name)

	SET @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[city_delete]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[city_delete] 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM dbo.cities c WHERE c.id = @id)	
	DELETE FROM dbo.cities WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[city_edite]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[city_edite]
	@name nvarchar(200),
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.cities SET [name] = @Name WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[city_get_by_id]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[city_get_by_id] 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 id, [name] FROM dbo.cities WHERE id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[countries_get_all]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[countries_get_all]

AS
BEGIN
	SET NOCOUNT ON;

    SELECT id, [name] FROM dbo.countries
END
GO
/****** Object:  StoredProcedure [dbo].[country_add]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[country_add] 
	@name nvarchar(200),
	@id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.countries WHERE [name] = @name)
	INSERT INTO dbo.countries([name])
	VALUES (@name)

	SET @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[country_delete]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[country_delete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.countries c WHERE c.id = @id)	
	DELETE FROM dbo.countries WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[country_edite]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[country_edite] 
	@name nvarchar(200),
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.countries SET [name] = @Name WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[country_get_by_id]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[country_get_by_id] 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 id, [name] FROM dbo.countries WHERE id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[newspaper_name_add]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspaper_name_add] 
	@name nvarchar(300),
	@id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.newspapers_names WHERE [name] = @name)
	INSERT INTO dbo.newspapers_names([name])
	VALUES (@name)

	SET @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[newspaper_name_delete]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspaper_name_delete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.newspapers_names WHERE id = @id)	
	DELETE FROM dbo.newspapers_names WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[newspaper_name_edite]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspaper_name_edite] 
	@name nvarchar(300),
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE dbo.newspapers_names SET [name] = @Name WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[newspaper_name_get_by_id]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspaper_name_get_by_id] 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 id, [name] FROM dbo.newspapers_names WHERE id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[newspapers_names_get_all]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspapers_names_get_all] 

AS
BEGIN
	SET NOCOUNT ON;

    SELECT id, [name] FROM dbo.newspapers_names
END
GO
/****** Object:  StoredProcedure [dbo].[publications_get_all]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[publications_get_all]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
	p.id AS [Id]
	, p.[name] AS [Name]
	, p.page_count AS [PageCount]
	, p.notes AS [Notes]
	, p.mark_delete AS [MarkDelete]
	, b.year_publication AS [YearPublication]
	, b.ISBN AS [ISBN]
	, b.city_id AS [CityId]
	, c.[name] AS [CityName]
	, b.publishing_id AS [PublishingId]
	, pb.[name] AS [PublishingName]
	, au.author_id AS [AuthorId]
	, au.[name] AS [AuthorName]
	, au.surname AS [AuthorSurname]
	FROM dbo.publications p
	JOIN dbo.books b ON b.id = p.id
	JOIN dbo.cities c ON b.city_id = c.id
	JOIN dbo.publishings pb ON b.publishing_id = pb.id
	JOIN (SELECT ba.book_id, ba.author_id, a.[name], a.surname FROM dbo.books_authors ba, authors a WHERE ba.author_id = a.id) AS au
	ON au.book_id = p.id
END
GO
/****** Object:  StoredProcedure [dbo].[publications_get_top_ten]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[publications_get_top_ten]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 10
	p.id AS [Id]
	, p.[name] AS [Name]
	, p.page_count AS [PageCount]
	, p.notes AS [Notes]
	, p.mark_delete AS [MarkDelete]
	, b.year_publication AS [YearPublication]
	, b.ISBN AS [ISBN]
	, b.city_id AS [CityId]
	, c.[name] AS [CityName]
	, b.publishing_id AS [PublishingId]
	, pb.[name] AS [PublishingName]
	, au.author_id AS [AuthorId]
	, au.[name] AS [AuthorName]
	, au.surname AS [AuthorSurname]
	FROM dbo.publications p
	JOIN dbo.books b ON b.id = p.id
	JOIN dbo.cities c ON b.city_id = c.id
	JOIN dbo.publishings pb ON b.publishing_id = pb.id
	JOIN (SELECT ba.book_id, ba.author_id, a.[name], a.surname FROM dbo.books_authors ba, authors a WHERE ba.author_id = a.id) AS au
	ON au.book_id = p.id
	ORDER BY p.id DESC
END
GO
/****** Object:  StoredProcedure [dbo].[publishing_add]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[publishing_add] 
	@name nvarchar(300),
	@id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.publishings WHERE [name] = @name)
	INSERT INTO dbo.publishings([name])
	VALUES (@name)

	SET @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[publishing_delete]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[publishing_delete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.publishings p WHERE p.id = @id)	
	DELETE FROM dbo.publishings WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[publishing_edite]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[publishing_edite]
	@name nvarchar(300),
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.publishings SET [name] = @Name WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[publishing_get_all]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[publishing_get_all]

AS
BEGIN
	SET NOCOUNT ON;

    SELECT id, [name] FROM dbo.publishings
END
GO
/****** Object:  StoredProcedure [dbo].[publishing_get_by_id]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[publishing_get_by_id]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 id, [name] FROM dbo.publishings WHERE id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[user_add]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[user_add]
	@name nvarchar(50),
	@password nvarchar(50),
	@id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.users u WHERE u.[username] = @name)
	INSERT INTO dbo.users ([username], [password])
	VALUES (@name, @password)

	SET @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[user_delete]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[user_delete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.users u WHERE u.id = @id)	
	DELETE FROM dbo.users WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[user_edit]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[user_edit]
	@id int,
	@name nvarchar(50),
	@role_id int
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.users u WHERE u.id = @id)
	UPDATE dbo.users SET [username] = @name, [role_id] = @role_id WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[user_get_by_id]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[user_get_by_id]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 1 
	u.id
	, u.username
	, u.role_id 
	, r.role_name
	FROM dbo.users u 
	JOIN dbo.roles r
	ON u.role_id = r.id
	WHERE u.id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[user_get_by_name]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[user_get_by_name]
	@name nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (SELECT 1 FROM dbo.users u WHERE u.[username] = @name)
    (SELECT u.username AS [name], r.role_name AS [role_name] FROM dbo.users u 
	JOIN dbo.roles r 
	ON u.role_id = r.id
	WHERE u.[username] = @name)
END
GO
/****** Object:  StoredProcedure [dbo].[user_login]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[user_login]
	@name nvarchar(50),
	@password nvarchar(50),
	@id int OUTPUT,
	@role_name nvarchar(50) OUTPUT,
	@role_id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.users u WHERE u.[username] = @name AND u.[password] = @password)
		SET @id = NULL
	IF EXISTS (SELECT 1 FROM dbo.users u WHERE u.[username] = @name AND u.[password] = @password)
		SET @id = (SELECT u.id FROM dbo.users u WHERE u.[username] = @name AND u.[password] = @password)
		SET @role_id = (SELECT u.role_id FROM dbo.users u WHERE u.[username] = @name AND u.[password] = @password)
		SET @role_name = (SELECT r.role_name FROM dbo.roles r WHERE r.[id] = @role_id)
END
GO
/****** Object:  StoredProcedure [dbo].[user_roles_get_all]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[user_roles_get_all]

AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
	r.[id]
	, r.[role_name]
	FROM dbo.roles r
END
GO
/****** Object:  StoredProcedure [dbo].[users_get_all]    Script Date: 15.12.2019 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[users_get_all]

AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
	u.id AS [id]
	, u.username AS [name]
	, u.role_id AS [role_id]
	, r.role_name AS [role]
	FROM dbo.users u
	JOIN dbo.roles r
	ON u.role_id = r.id
END
GO
USE [master]
GO
ALTER DATABASE [LibraryCatalogueDB] SET  READ_WRITE 
GO
