USE [Family_Database]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 31-Dec-15 10:47:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Users](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](15) NOT NULL,
	[Last_Name] [varchar](15) NOT NULL,
	[E_Mail] [varchar](50) NOT NULL,
	[Password] [varchar](68) NOT NULL,
	[Profile_Picture] [datetime] NULL,
	[Phone_Number] [varchar](20) NULL,
	[Gender] [bit] NOT NULL,
	[Birthday] [date] NOT NULL,
	[Marital_Status] [tinyint] NOT NULL,
	[About_me] [text] NULL,
	[HomeTown] [varchar](50) NULL,
	[FriendNotification_User_ID] [int] NULL,
	[FriendNotification_Time] [datetime] NULL,
	[FriendNotification_User_ID1] [int] NULL,
	[FriendNotification_Time1] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[E_Mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


