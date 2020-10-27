USE [IIDRS]
GO

/****** Object:  View [dbo].[Vw_User]    Script Date: 22-10-2020 11:54:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





 

CREATE VIEW [dbo].[Vw_User]  
AS 
SELECT 
U.USER_ID as LoginID,
U.LOGIN,
U.LOGIN_DOMAIN,
U.USER_FLG,
c.PERSON_UID,
C.FST_NAME + '' + C.LAST_NAME AS [Contact Person], 
C.EMAIL_ADDR as [Email],
C.EMP_ID,
C.PHONE_NO,
BU.BU_ID,
BU.BU_TYPE,
BU.DU_NAME AS DU,
BU.PROJ_ID as [ProjectID],
BU.PROJ_NAME AS [ProjectName],
BU.BU_NAME AS BRAND,
Z.zipcode,
z.COUNTRY
from M_User U   
LEFT JOIN M_CONTACT C ON U.PERSON_UID=C.PERSON_UID  
LEFT JOIN M_BU BU ON BU.BU_ID=U.BU_ID 
LEFT JOIN M_ZIPCODE Z ON Z.ROW_ID= C.[ZIPCODE_ROWID]

GO


