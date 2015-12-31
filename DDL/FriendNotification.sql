USE [Family_Database]
GO

/****** Object:  Table [dbo].[FriendNotifications]    Script Date: 31-Dec-15 10:46:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FriendNotifications](
	[User_ID] [int] NOT NULL,
	[Time] [datetime] NOT NULL,
	[Friend_ID] [int] NOT NULL,
	[Read] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.FriendNotifications] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC,
	[Time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


