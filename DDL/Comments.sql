USE [Family_Database]
GO

/****** Object:  Table [dbo].[Comments]    Script Date: 31-Dec-15 10:46:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comments](
	[User_ID] [int] NOT NULL,
	[Post_Id] [datetime] NOT NULL,
	[Comment_User_Id] [int] NOT NULL,
	[Comment_Id] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC,
	[Post_Id] ASC,
	[Comment_User_Id] ASC,
	[Comment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comments_dbo.Posts_Comment_User_Id_Comment_Id] FOREIGN KEY([Comment_User_Id], [Comment_Id])
REFERENCES [dbo].[Posts] ([User_Id], [Time])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_dbo.Comments_dbo.Posts_Comment_User_Id_Comment_Id]
GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comments_dbo.Posts_User_ID_Post_Id] FOREIGN KEY([User_ID], [Post_Id])
REFERENCES [dbo].[Posts] ([User_Id], [Time])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_dbo.Comments_dbo.Posts_User_ID_Post_Id]
GO


