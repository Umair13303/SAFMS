﻿using office360.Models.EDMX;
using office360.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static office360.Models.General.DocumentStatus;

namespace office360.Areas.AUser.HelperCode
{
    public class Document_Detail_By_GUID_LINQ
    {
        #region HELPER FOR :: GET DATA USING LINQ (UM_USER) ::-- MAIN DB
        public static List<_SqlParameters> GET_MT_UM_USER_INFO_BY_GUID(_SqlParameters PostedData)
        {
            List<_SqlParameters> DATA = new List<_SqlParameters>();

            using (SESEntities db = new SESEntities())
            {
                DATA = ((List<_SqlParameters>)
                       (from U in db.UM_User
                        where 
                        U.GuID == PostedData.GuID
                        select new _SqlParameters
                        {
                            Id = U.Id,
                            GuID = U.GuID,
                            Name = U.Name,
                            UserName = U.UserName,
                            Password = U.Password,
                            EmailAddress = U.EmailAddress,
                            MobileNumber = U.MobileNumber,
                            EmployeeId = U.EmployeeId,
                            RoleId = U.RoleId,
                            AllowedCampusIds = U.AllowedCampusIds,
                            IsLogIn = U.IsLogIn,
                            IsDeveloper = U.IsDeveloper,
                            BranchId = U.BranchId,
                            CompanyId = U.CompanyId,
                            Remarks = U.Remarks,

                        }).ToList());

                return DATA;
            }
        }

        #endregion


        public static List<_SqlParameters> GET_MT_URM_USERRIGHT_INFO_BY_GUID(_SqlParameters PostedData)
        {
            List<_SqlParameters> DATA = new List<_SqlParameters>();

            using (SESEntities db = new SESEntities())
            {
                DATA = ((List<_SqlParameters>)
                       (from UR in db.URM_UserRight
                        where UR.GuID == PostedData.GuID 
                        select new _SqlParameters
                        {
                            Id = UR.Id,
                            GuID = UR.GuID,
                            CompanyId = UR.CompanyId,
                            UserId = UR.UserId,
                            RightId = UR.RightId,
                            Remarks = UR.Remarks,

                        }).ToList());

                return DATA;
            }
        }

    }
}