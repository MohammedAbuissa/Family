USE [Family_Database]
GO

/****** Object:  Table [dbo].[Posts]    Script Date: 31-Dec-15 10:47:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Posts](
	[User_Id] [int] NOT NULL,
	[Caption] [text] NULL,
	[Time] [datetime] NOT NULL,
	[Private_Public] [bit] NULL DEFAULT ((0)),
	[Has_Picture] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC,
	[Time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Posts]  WITH CHECK ADD FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([User_Id])
GO


