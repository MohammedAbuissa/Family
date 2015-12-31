USE [Family_Database]
GO

/****** Object:  Table [dbo].[Likes]    Script Date: 31-Dec-15 10:47:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Likes](
	[User_Id] [int] NOT NULL,
	[Post_Id] [datetime] NOT NULL,
	[Like_Owner_Id] [int] NOT NULL,
 CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC,
	[Post_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Likes_dbo.Users_Like_Owner_Id] FOREIGN KEY([Like_Owner_Id])
REFERENCES [dbo].[Users] ([User_Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_dbo.Likes_dbo.Users_Like_Owner_Id]
GO

ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_LikePost] FOREIGN KEY([User_Id], [Post_Id])
REFERENCES [dbo].[Posts] ([User_Id], [Time])
GO

ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_LikePost]
GO


