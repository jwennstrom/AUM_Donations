USE [AUMSampleData]
GO
/****** Object:  Table [dbo].[Donor]    Script Date: 09/20/2012 20:46:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donor](
	[DonorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED 
(
	[DonorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donation]    Script Date: 09/20/2012 20:46:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donation](
	[DonationId] [int] IDENTITY(1,1) NOT NULL,
	[DonorId] [int] NOT NULL,
	[DateOfDonation] [datetime] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Donation] PRIMARY KEY CLUSTERED 
(
	[DonationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Donation_DateOfDonation]    Script Date: 09/20/2012 20:46:06 ******/
ALTER TABLE [dbo].[Donation] ADD  CONSTRAINT [DF_Donation_DateOfDonation]  DEFAULT (getdate()) FOR [DateOfDonation]
GO
/****** Object:  Default [DF_Donation_Amount]    Script Date: 09/20/2012 20:46:06 ******/
ALTER TABLE [dbo].[Donation] ADD  CONSTRAINT [DF_Donation_Amount]  DEFAULT ((0.00)) FOR [Amount]
GO
/****** Object:  Default [DF_Donation_CreatedOn]    Script Date: 09/20/2012 20:46:06 ******/
ALTER TABLE [dbo].[Donation] ADD  CONSTRAINT [DF_Donation_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_Donor_CreatedOn]    Script Date: 09/20/2012 20:46:06 ******/
ALTER TABLE [dbo].[Donor] ADD  CONSTRAINT [DF_Donor_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  ForeignKey [FK_Donation_Donor]    Script Date: 09/20/2012 20:46:06 ******/
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_Donor] FOREIGN KEY([DonorId])
REFERENCES [dbo].[Donor] ([DonorId])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_Donor]
GO
/****** Object:  ForeignKey [FK_Donor_Donor]    Script Date: 09/20/2012 20:46:06 ******/
ALTER TABLE [dbo].[Donor]  WITH CHECK ADD  CONSTRAINT [FK_Donor_Donor] FOREIGN KEY([DonorId])
REFERENCES [dbo].[Donor] ([DonorId])
GO
ALTER TABLE [dbo].[Donor] CHECK CONSTRAINT [FK_Donor_Donor]
GO
