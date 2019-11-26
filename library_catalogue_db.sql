USE [master]
GO
/****** Object:  Database [LibraryCatalogueDB]    Script Date: 26.11.2019 23:16:25 ******/
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
/****** Object:  Table [dbo].[authors]    Script Date: 26.11.2019 23:16:25 ******/
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
/****** Object:  Table [dbo].[cards_authors]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cards_authors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[card_id] [int] NOT NULL,
	[author_id] [int] NOT NULL,
 CONSTRAINT [PK_carts_authors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cards_types]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cards_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[card_type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_objects_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catalogue_cards]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catalogue_cards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_id] [int] NOT NULL,
	[name] [nvarchar](300) NOT NULL,
	[publishing_id] [int] NULL,
	[city_id] [int] NULL,
	[country_id] [int] NULL,
	[year_publication] [datetime2](7) NULL,
	[date_publication] [datetime2](7) NULL,
	[date_application] [datetime2](7) NULL,
	[ISBN] [nvarchar](20) NULL,
	[ISSN] [nvarchar](20) NULL,
	[registration_number] [bigint] NULL,
	[page_count] [int] NOT NULL,
	[notes] [nvarchar](2000) NULL,
	[mark_delete] [bit] NOT NULL,
 CONSTRAINT [PK_catalogue_carts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  Table [dbo].[countries]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  Table [dbo].[logs]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_time_operation] [datetime] NOT NULL,
	[card_type_id] [int] NOT NULL,
	[card_id] [int] NOT NULL,
	[description] [nvarchar](500) NULL,
	[user_name] [nvarchar](100) NULL,
 CONSTRAINT [PK_logs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[newspapers]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[newspapers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](300) NULL,
 CONSTRAINT [PK_newspapers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[publishings]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] NOT NULL,
	[login] [nvarchar](30) NOT NULL,
	[password] [nvarchar](100) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[catalogue_cards] ADD  CONSTRAINT [DF_catalogue_carts_mark_delete]  DEFAULT ((0)) FOR [mark_delete]
GO
ALTER TABLE [dbo].[cards_authors]  WITH CHECK ADD  CONSTRAINT [FK_cards_authors_authors] FOREIGN KEY([card_id])
REFERENCES [dbo].[authors] ([id])
GO
ALTER TABLE [dbo].[cards_authors] CHECK CONSTRAINT [FK_cards_authors_authors]
GO
ALTER TABLE [dbo].[cards_authors]  WITH CHECK ADD  CONSTRAINT [FK_cards_authors_catalogue_cards] FOREIGN KEY([card_id])
REFERENCES [dbo].[catalogue_cards] ([id])
GO
ALTER TABLE [dbo].[cards_authors] CHECK CONSTRAINT [FK_cards_authors_catalogue_cards]
GO
ALTER TABLE [dbo].[catalogue_cards]  WITH CHECK ADD  CONSTRAINT [FK_catalogue_cards_cards_types] FOREIGN KEY([type_id])
REFERENCES [dbo].[cards_types] ([id])
GO
ALTER TABLE [dbo].[catalogue_cards] CHECK CONSTRAINT [FK_catalogue_cards_cards_types]
GO
ALTER TABLE [dbo].[catalogue_cards]  WITH CHECK ADD  CONSTRAINT [FK_catalogue_cards_cities] FOREIGN KEY([city_id])
REFERENCES [dbo].[cities] ([id])
GO
ALTER TABLE [dbo].[catalogue_cards] CHECK CONSTRAINT [FK_catalogue_cards_cities]
GO
ALTER TABLE [dbo].[catalogue_cards]  WITH CHECK ADD  CONSTRAINT [FK_catalogue_cards_countries] FOREIGN KEY([country_id])
REFERENCES [dbo].[countries] ([id])
GO
ALTER TABLE [dbo].[catalogue_cards] CHECK CONSTRAINT [FK_catalogue_cards_countries]
GO
ALTER TABLE [dbo].[catalogue_cards]  WITH CHECK ADD  CONSTRAINT [FK_catalogue_cards_publishings] FOREIGN KEY([publishing_id])
REFERENCES [dbo].[publishings] ([id])
GO
ALTER TABLE [dbo].[catalogue_cards] CHECK CONSTRAINT [FK_catalogue_cards_publishings]
GO
ALTER TABLE [dbo].[logs]  WITH CHECK ADD  CONSTRAINT [FK_logs_cards_types] FOREIGN KEY([card_type_id])
REFERENCES [dbo].[cards_types] ([id])
GO
ALTER TABLE [dbo].[logs] CHECK CONSTRAINT [FK_logs_cards_types]
GO
ALTER TABLE [dbo].[logs]  WITH CHECK ADD  CONSTRAINT [FK_logs_catalogue_cards] FOREIGN KEY([card_id])
REFERENCES [dbo].[catalogue_cards] ([id])
GO
ALTER TABLE [dbo].[logs] CHECK CONSTRAINT [FK_logs_catalogue_cards]
GO
/****** Object:  StoredProcedure [dbo].[author_add]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[author_delete]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[author_edite]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[author_edite] 
	@name nvarchar(50),
	@surname nvarchar(200),
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE dbo.authors SET [name] = @Name, surname = @Surname WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[author_get_by_id]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[authors_get_all]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[cities_get_all]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[city_add]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[city_delete]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[city_edite]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[city_get_by_id]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[countries_get_all]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[country_add]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[country_delete]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[country_edite]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[country_get_by_id]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[newspaper_add]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspaper_add] 
	@name nvarchar(300),
	@id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.newspapers WHERE [name] = @name)
	INSERT INTO dbo.newspapers([name])
	VALUES (@name)

	SET @id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[newspaper_delete]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspaper_delete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.newspapers WHERE id = @id)	
	DELETE FROM dbo.newspapers WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[newspaper_edite]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspaper_edite] 
	@name nvarchar(300),
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE dbo.newspapers SET [name] = @Name WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[newspaper_get_by_id]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspaper_get_by_id] 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 id, [name] FROM dbo.newspapers WHERE id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[newspapers_get_all]    Script Date: 26.11.2019 23:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[newspapers_get_all] 

AS
BEGIN
	SET NOCOUNT ON;

    SELECT id, [name] FROM dbo.newspapers
END
GO
/****** Object:  StoredProcedure [dbo].[publishing_add]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[publishing_delete]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[publishing_edite]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[publishing_get_all]    Script Date: 26.11.2019 23:16:26 ******/
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
/****** Object:  StoredProcedure [dbo].[publishing_get_by_id]    Script Date: 26.11.2019 23:16:26 ******/
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
USE [master]
GO
ALTER DATABASE [LibraryCatalogueDB] SET  READ_WRITE 
GO
