CREATE TABLE [dbo].[Users]
(
	[User_Id] int identity(1,1) Primary Key,
	[First_Name] varchar(15) NOT NULL,
	[Last_Name] varchar(15) NOT NULL,
	[E_Mail] varchar(50) NOT NULL Unique,
	[Password] varchar(40) NOT NULL,
	[Profile_Picture] DateTime,
	[Phone_Number] varchar(20) NULL,
	[Gender] bit NOT NULL,
	[Birthday] date NOT NULL,
	[Marital_Status] tinyint NOT NULL,
	[About_me] text, 
    [HomeTown] VARCHAR(50) NULL,
)

CREATE TABLE [dbo].[Friends]
(
	[User_Id] INT NOT NULL foreign key references Users (User_Id),
	[Friend_Id] INT NOT NULL foreign key references Users (User_Id)
    constraint pk_friend primary key (User_Id, Friend_Id)
)

CREATE TABLE [dbo].[Posts]
(
	[User_Id] INT FOREIGN KEY REFERENCES Users(User_Id),
	[Caption] text,
	[Time] DATETIME NOT NULL,
	[Private_Public] bit default(0),
	constraint PK_Post Primary key(User_Id,Time)
)


CREATE TABLE [dbo].[Comments]
(
	[User_Id] INT NOT NULL ,
	[Post_Id] DATETIME NOT NULL ,
	[Comment_User_Id] INT NOT NULL,
	[Comment_Id] DATETIME NOT NULL ,
	constraint PK_Comments primary key (User_Id, Post_Id),
	constraint FK_Post foreign key (User_Id,Post_Id) references Posts(User_Id,Time),
	constraint FK_CommentPost foreign key (Comment_User_Id,Comment_Id) references Posts(User_Id,Time)	
)


CREATE TABLE [dbo].[Likes]
(
	[User_Id] INT NOT NULL,
	[Post_Id] DATETIME NOT NULL,
	[Like_Owner_Id] INT NOT NULL, 
    constraint PK_Likes primary key (User_Id, Post_Id),
	constraint FK_LikePost foreign key (User_Id,Post_Id) references Posts(User_Id,Time)
)

