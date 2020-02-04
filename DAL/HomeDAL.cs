using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VisitorManagementForm.DataManager;
using VisitorManagementForm.Models;

namespace VisitorManagementForm.DAL
{

    
    public class HomeDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();
        public List<CommonModel> GetBusinessUnit()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<CommonModel> bulist = new List<CommonModel>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetAllBusinessUnit");
                while (dr.Read())
                {
                    CommonModel bul = new CommonModel();
                    bul.BusinessUnitId = (int)dr["BusinessUnitId"];
                    bul.BusinessUnitName = dr["BusinessUnitName"].ToString();
                    bulist.Add(bul);
                }
                return bulist;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<CommonModel> GetLocation()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<CommonModel> bulist = new List<CommonModel>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetAllLocation");
                while (dr.Read())
                {
                    CommonModel bul = new CommonModel();
                    bul.LocationId = (int)dr["LocationId"];
                    bul.LocatioName = dr["LocationName"].ToString();
                    bulist.Add(bul);
                }
                return bulist;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public bool SavevisitoToDatabase(VisitorRequestModel visitor)
        {

            bool result = false;
            try
            {
                    accessManager.SqlConnectionOpen(DataBase.SQQeye);
                    List<SqlParameter> aParameters = new List<SqlParameter>();
                    aParameters.Add(new SqlParameter("@BusinessUnitId", visitor.BusinessUnitId));
                    aParameters.Add(new SqlParameter("@LocationId", visitor.LocationId));
                    aParameters.Add(new SqlParameter("@RequestorName", visitor.RequestorName));
                    aParameters.Add(new SqlParameter("@RequestorEmail", visitor.RequestorEmail));
                    aParameters.Add(new SqlParameter("@RequerstorMobile", visitor.RequerstorMobile));
                    aParameters.Add(new SqlParameter("@RequestorDesignation", visitor.RequestorDesignation));
                    aParameters.Add(new SqlParameter("@RequestorDepartment", visitor.RequestorDepartment));
                    aParameters.Add(new SqlParameter("@visitDate", visitor.VisitDate));
                    aParameters.Add(new SqlParameter("@VisitorName", visitor.VisitorName));
                    aParameters.Add(new SqlParameter("@VisitorEmail", visitor.VisitorEmail));
                    aParameters.Add(new SqlParameter("@VisitorDesignation", visitor.VisitorDesignation));
                    aParameters.Add(new SqlParameter("@VisitorMobile", visitor.VisitorMobile));
                    aParameters.Add(new SqlParameter("@VisitorCompany", visitor.VisitorCompany));
                    aParameters.Add(new SqlParameter("@VisitorNationality", visitor.VisitorNationality));
                    aParameters.Add(new SqlParameter("@PurposeOfVisitSQ", visitor.PurposeOfVisitSQ));
                    aParameters.Add(new SqlParameter("@Chainavisit", visitor.Chainavisit));

                    result = accessManager.SaveData("sp_SaveVisitorForApprove", aParameters);
                
                return result;
            }
            catch (Exception exception)
            {
                accessManager.SqlConnectionClose(true);
                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public List<VisitorRequestModel> GetAllRequestInformation()
        {
            List<VisitorRequestModel> visitorList = new List<VisitorRequestModel>();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@userId", 1));
                aParameters.Add(new SqlParameter("@status", 1));
                aParameters.Add(new SqlParameter("@module", 1));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_AllVisitorInformationGet", aParameters);
                while (dr.Read())
                {
                    VisitorRequestModel visitor = new VisitorRequestModel();
                    visitor.RequestorId = (int)dr["RequestorId"];
                    visitor.RequestorName = dr["RequestorName"].ToString();
                    visitor.RequestorDepartment = dr["RequestorDepartment"].ToString();
                    visitor.RequestorDesignation = dr["RequestorDesignation"].ToString();
                    visitor.VisitorName = dr["VisitorName"].ToString();
                    visitor.VisitorCompany = dr["VisitorCompany"].ToString();
                    visitor.VisitorDesignation = dr["VisitorDesignation"].ToString();
                    visitor.VisitDate = (DateTime)dr["VisitDate"];
                    visitor.PurposeOfVisitSQ = dr["RequestorName"].ToString();
                    visitor.VisitorCompany = dr["VisitorCompany"].ToString();
                    visitor.IsApproved = (int)dr["IsApproved"];

                    visitorList.Add(visitor);
                }
                return visitorList;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public VisitorRequestModel IndividualRequestShow(int PrimaryKey)
        {
            VisitorRequestModel visitor = new VisitorRequestModel();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@userId", 1));
                aParameters.Add(new SqlParameter("@RequestId", PrimaryKey));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_IndividualRequestView", aParameters);
                while (dr.Read())
                {
                    visitor.RequestorId = (int)dr["RequestorId"];
                    visitor.RequestorName = dr["RequestorName"].ToString();
                    visitor.RequestorDepartment = dr["RequestorDepartment"].ToString();
                    visitor.RequestorDesignation = dr["RequestorDesignation"].ToString();
                    visitor.RequestorEmail = dr["RequestorEmail"].ToString();
                    visitor.VisitorName = dr["VisitorName"].ToString();
                    visitor.VisitDate = (DateTime)dr["VisitDate"];
                    visitor.RequerstorMobile = dr["RequerstorMobile"].ToString();
                    visitor.VisitorEmail = dr["VisitorEmail"].ToString();
                    visitor.PurposeOfVisitSQ = dr["PurposeOfVisitSQ"].ToString();
                    visitor.VisitorCompany = dr["VisitorCompany"].ToString();
                    visitor.VisitorDesignation = dr["VisitorDesignation"].ToString();
                    visitor.VisitorNationality = dr["VisitorNationality"].ToString();
                    visitor.Chainavisit = dr["Chainavisit"].ToString();
                    visitor.BusinessUnitName = dr["BusinessUnitName"].ToString();
                    visitor.LocationName = dr["LocationName"].ToString();
                    visitor.VisitorMobile = dr["VisitorMobile"].ToString();
                    visitor.IsApproved = (int)dr["IsApproved"];
                }
                return visitor;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }


    }
}