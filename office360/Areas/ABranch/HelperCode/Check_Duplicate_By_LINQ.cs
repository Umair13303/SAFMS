﻿using System.Linq;
using System.Web;
using static office360.Models.General.DocumentStatus;
using static office360.Models.General.Http_Server_Status;
using static office360.Models.General.DBListCondition;
using DocumentStatus = office360.Models.General.DocumentStatus;
using System.Data.Entity.Infrastructure;
using office360.Models.EDMX;
using office360.Models.General;
using office360.Common.CommonHelper;
using System.Data.Entity.Core.Objects;
using office360.Extensions;
using System;


namespace office360.Areas.ABranch.HelperCode
{
    public class Check_Duplicate_By_LINQ
    {
        #region HELPER FOR :: CHECK IF Branch(ACTIVE_BRANCH) ALREADY EXIST
        public static int? IS_EXIST_BM_BRANCH_BY_PARAMETER(_SqlParameters PostedData)
        {
            using (SESEntities db = new SESEntities())
            {
                bool IsRecordExist = false;
                int? Response = (int?)Http_DB_Response.CODE_DATA_ALREADY_EXIST;
                try
                {
                    switch (PostedData.OperationType)
                    {

                        case nameof(DB_OperationType.INSERT_DATA_INTO_DB):

                            #region IN CASE OF INSERT :: CHECK IF ENTERY RECORD EXIST , BASED ON DATA ENTERED
                            IsRecordExist = db.BM_Branch
                                .Any(x =>
                                    x.Description == PostedData.Description &&
                                    x.CompanyId == PostedData.CompanyId &&
                                    x.DocumentStatus == (int?)DocStatus.ACTIVE_BRANCH &&
                                    x.Status == true
                                );
                            #endregion
                            if (!IsRecordExist)
                                Response = (int?)Http_DB_Response.CODE_AUTHORIZED;
                            else
                                Response = (int?)Http_DB_Response.CODE_DATA_ALREADY_EXIST;
                            break;

                        case nameof(DB_OperationType.UPDATE_DATA_INTO_DB):
                            #region IN CASE OF UPDATE :: CHECK IF ENTERY RECORD EXIST , BASED ON SYSTEM GUID
                            IsRecordExist = db.BM_Branch.Any(x => x.GuID == PostedData.GuID);
                            #endregion
                            if (!IsRecordExist)
                                Response = (int?)Http_DB_Response.CODE_DATA_DOES_NOT_EXIST;
                            else
                                Response = (int?)Http_DB_Response.CODE_AUTHORIZED;

                            break;

                        default:
                            Response = (int?)Http_DB_Response.CODE_DATA_ALREADY_EXIST;
                            break;


                    }
                    return Response;
                }
                catch (Exception Ex)
                {
                    return Http_Server_Status.Http_DB_Response.CODE_UN_KNOWN_ACTIVITY.ToInt();

                }

            }
        }
        #endregion


    }
}