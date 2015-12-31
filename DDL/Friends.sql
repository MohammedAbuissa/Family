USE [Family_Database]
GO

/****** Object:  Table [dbo].[Friends]    Script Date: 31-Dec-15 10:47:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Friends](
	[User_Id] [int] NOT NULL,
	[Friend_Id] [int] NOT NULL,
 CONSTRAINT [pk_friend] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC,
	[Friend_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Friends]  WITH CHECK ADD FOREIGN KEY([Friend_Id])
REFERENCES [dbo].[Users] ([User_Id])
GO

ALTER TABLE [dbo].[Friends]  WITH CHECK ADD FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([User_Id])
GO


