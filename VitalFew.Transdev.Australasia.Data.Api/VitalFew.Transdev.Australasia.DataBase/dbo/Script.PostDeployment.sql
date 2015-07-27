/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO
SET IDENTITY_INSERT [dbo].[VF_API_CATALOG_CLIENTS] ON 

GO
INSERT [dbo].[VF_API_CATALOG_CLIENTS] ([TRANSDEV_ID], [CLIENT_ID], [CLIENT_NAME], [CLIENT_TOKEN], [CLIENT_STATUS]) VALUES (1, N'bc5805f9-8ac8-447b-90e9-5b906b4c1b66', N'KEAZ', N'123ADDDEEE', 1)
GO
SET IDENTITY_INSERT [dbo].[VF_API_CATALOG_CLIENTS] OFF
GO
INSERT [dbo].[VF_API_CLIENT_OBJECTS] ([TRANSDEV_ID], [TRANSDEV_PARAM], [DB_SERVER_NAME], [DB_INSTANCE_NAME], [DB_SERVER_PORT], [DB_NAME], [DB_USER], [DB_USER_PASSWORD], [DB_AUTHENTICATION_TYPE], [DB_INTEGRATED_SECURITY], [OBJECT_ID], [DB_SCHEMA], [DB_OBJECT_TYPE], [DB_OBJECT_NAME], [DB_OBJECT_CREATED_DATE], [DB_OBJECT_MODIFIED_DATE]) VALUES (1, N'user', N'LOCALHOST', N'MSSQLSERVER', N'1433', N'TRBOnet', N'dbuser', N'wx38t#2', N'SQLSERVER', 0, 1, N'dbo', N'view', N'users', CAST(0x0000A4DA00EC14DB AS DateTime), CAST(0x0000A4DA00EC14DB AS DateTime))
GO
