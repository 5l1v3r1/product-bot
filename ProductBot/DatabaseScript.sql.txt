USE [master]

GO

CREATE DATABASE Bot_database;

GO

USE [Bot_database]

GO

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[e_mails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mail_address] [nchar](150) NULL,
	[price_percent] [int] NULL,
 CONSTRAINT [PK_e_mails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](100) NULL,
	[platform] [nchar](50) NULL,
	[url] [nchar](500) NULL,
	[url_name] [nchar](250) NULL,
	[price] [decimal](18, 0) NULL,
	[date] [datetime] NULL,
	[mail_id] [int] NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_e_mails] FOREIGN KEY([mail_id])
REFERENCES [dbo].[e_mails] ([id])
GO

ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_e_mails]
GO

CREATE TYPE [dbo].[products_model] AS TABLE(  
    [name] [nchar](100) NULL,  
    [platform] [nchar](50) NULL,  
    [url] [nchar](500) NULL,  
    [url_name] [nchar](250) NULL,
	[price] [decimal](18,0) NULL,  
    [date] [datetime] NULL,
	[mail_id] [int] NULL
)

GO

create procedure [dbo].[insert_product](@tableproducts products_model readonly)  
as  
begin  
   insert into products select [name],[platform],[url],[url_name],[price],[date],[mail_id] from @tableproducts  
end    