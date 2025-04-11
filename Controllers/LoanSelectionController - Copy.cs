using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Text;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Data;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace LoanSelectAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoanSelectionController : ApiController
    {
        //[HttpPost]
        //[Route("api/GetLoanBoardingData")]
        //public dynamic GetLoanBoardingData(int LoanID, int EmpNum, int WhatProcess)
        //{
        //    Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
        //    DataSet Resultdtset = new DataSet();
        //    IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
        //    IDataParameter[] param;
        //    objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
        //    IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
        //    objComm.CommandTimeout = 0;
        //    objComm.Connection = objConnection;
        //    objComm.CommandType = CommandType.StoredProcedure;
        //    objComm.CommandText = "CMS.dbo.CMS_SP_LoanBoarding_GetData";
        //    param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LoanBoarding_GetData");
        //    daHelper.AttachParameters(objComm, param);
        //    param[0].Value = LoanID;
        //    param[1].Value = EmpNum;
        //    param[2].Value = WhatProcess;
        //    Resultdtset = daHelper.ExecuteDataset(objComm);
        //    return JsonConvert.SerializeObject(Resultdtset);
        //}

        [HttpPost]
        [Route("api/GetLoanBoardingData")]
        public dynamic GetLoanBoardingData(int LoanID, int EmpNum, int WhatProcess, int Testing, string SessionId)
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_LoanBoarding_GetData_JSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LoanBoarding_GetData_JSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanID;
            param[1].Value = EmpNum;
            param[2].Value = WhatProcess;
            param[3].Value = Testing;
            param[4].Value = SessionId;
            param[5].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[5].Value.ToString();
            //return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/DMTracking_getAddressValidation")]
        public dynamic DMTracking_getAddressValidation(int LoanID, int EmpNum)
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.DMTracking_getAddressValidation";
            param = daHelper.GetSpParameterSet("CMS.dbo.DMTracking_getAddressValidation");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanID;
            param[1].Value = EmpNum;
            param[2].Value = ParameterDirection.Output;
            param[3].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString() + '~' + param[3].Value.ToString();
        }

        [HttpPost]
        [Route("api/GetNeededTypeOptions")]
        public dynamic GetNeededTypeOptions()
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_LoanBoarding_GetNeededTypeOptions1";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LoanBoarding_GetNeededTypeOptions1");
            daHelper.AttachParameters(objComm, param);
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/GetCompressedJSON")]
        public dynamic GetCompressedJSON(string Inputjson)
        {
            try
            {
                Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
                DataSet Resultdtset = new DataSet();
                IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
                IDataParameter[] param;
                objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
                IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
                objComm.CommandTimeout = 0;
                objComm.Connection = objConnection;
                //objComm.CommandType = CommandType.StoredProcedure;
                //objComm.CommandText = "CMS.dbo.CMS_SP_LnAppr_Get_LoanPrograms_IU_JSON";
                //param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LnAppr_Get_LoanPrograms_IU_JSON");
                //daHelper.AttachParameters(objComm, param);
                //Resultdtset = daHelper.ExecuteDataset(objComm);

                objComm.CommandType = CommandType.StoredProcedure;
                objComm.CommandText = "CMS.dbo.CMS_SP_LnAppr_Get_LoanPrograms_IU_JSON";
                param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LnAppr_Get_LoanPrograms_IU_JSON");
                daHelper.AttachParameters(objComm, param);
                param[0].Value = Inputjson;
                param[1].Value = ParameterDirection.Output;
                Resultdtset = daHelper.ExecuteDataset(objComm);
                //byte[] compressedData = (byte[])param[1].Value.;
                string compressedData = param[1].Value.ToString();

                // if the original encoding was ASCII
                //string decompressedJson = Encoding.ASCII.GetString(compressedData);

                //// if the original encoding was UTF-8
                //string decompressedJson = Encoding.UTF8.GetString(compressedData);

                //// if the original encoding was UTF-16
                //string decompressedJson = Encoding.Unicode.GetString(compressedData);

                //// Decompress the data
                //string decompressedJson = DecompressData(compressedData);

                return compressedData;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        [HttpPost]
        [Route("api/GetDecompressedValue")]
        public dynamic GetDecompressedValue(byte[] InputValue)
        {
            string decompressedJson = "";
            try
            {
                byte[] compressedData = InputValue;
                decompressedJson = DecompressGzipData(compressedData);
            }
            catch (Exception e) {
                decompressedJson = "Error";
            }
            return decompressedJson;
        }
        //API_Get_LoanPrograms_IU_Wrapper
        [HttpPost]
        [Route("api/Get_LoanProgramIU")]
        public dynamic Get_LoanProgramIU(int OutFlag,string Inputjson)
        {
            try
            {
                string decompressedJson = "";
                string connectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
                string storedProcedureName = "CMS.dbo.API_Get_LoanPrograms_IU_Wrapper";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@outFlag", OutFlag);
                        command.Parameters.AddWithValue("@InputJSON", Inputjson);
                        SqlParameter outputParameter = new SqlParameter
                        {
                            ParameterName = "@JSONOut",
                            SqlDbType = System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Output,
                            Size = int.MaxValue 
                        };
                        command.Parameters.Add(outputParameter);
                        SqlParameter outputParameter_ = new SqlParameter
                        {
                            ParameterName = "@JSONOut_",
                            SqlDbType = System.Data.SqlDbType.VarBinary,
                            Direction = System.Data.ParameterDirection.Output,
                            Size = int.MaxValue  //8000 //Set the appropriate size
                        };
                        command.Parameters.Add(outputParameter_);
                        command.ExecuteNonQuery();
                        
                        if (OutFlag == 1)
                        {
                            byte[] compressedData = (byte[])outputParameter_.Value;
                            decompressedJson = DecompressGzipData(compressedData); //Encoding.UTF8.GetString(decompressedJsonbyt); //.ToString();
                        }
                        else
                        {
                            if (outputParameter.Value != DBNull.Value)
                            {
                                string jsonOutput = outputParameter.Value.ToString();
                                decompressedJson = jsonOutput;
                            }
                            else {
                            decompressedJson = outputParameter.Value.ToString();
                            }
                        }
                    }
                }
                return decompressedJson;
            }
            catch (Exception e) { return e.Message.ToString(); }
        }
        
        [HttpPost]
        [Route("api/GetLoanProgramIU_Json")]
        public dynamic GetLoanProgramIU_Json(string Inputjson)
        {
            try
            {
                string decompressedJson = "";
                string connectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
                string storedProcedureName = "CMS.dbo.CMS_SP_LnAppr_Get_LoanPrograms_IU_JSONBinary";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@InputJSON", Inputjson);
                        SqlParameter outputParameter = new SqlParameter
                        {
                            ParameterName = "@JSONOut_",
                            SqlDbType = System.Data.SqlDbType.VarBinary,
                            Direction = System.Data.ParameterDirection.Output,
                            Size = int.MaxValue  //8000 //Set the appropriate size
                        };
                        command.Parameters.Add(outputParameter);
                        command.ExecuteNonQuery();
                        byte[] compressedData = (byte[])outputParameter.Value;
                        decompressedJson = DecompressGzipData(compressedData); //Encoding.UTF8.GetString(decompressedJsonbyt); //.ToString();
                    }
                }
                return decompressedJson;
            }
            catch (Exception e) { return e.Message.ToString(); }
        }
        [HttpPost]
        [Route("api/GetCompressedJSONTesting")]
        public dynamic GetCompressedJSONTesting(string Inputjson)
        {
            try
            {
                string decompressedJson = "";
                //string connectionString = "your_sql_connection_string";
                //string connectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString");
                string connectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
                string storedProcedureName = "CMS.dbo.CMS_SP_LnAppr_Get_LoanPrograms_IU_JSON_testing";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@InputJSON", Inputjson);
                        SqlParameter outputParameter = new SqlParameter
                        {
                            ParameterName = "@JSONOut_",
                            SqlDbType = System.Data.SqlDbType.VarBinary,
                            Direction = System.Data.ParameterDirection.Output,
                            Size = 8000  // Set the appropriate size
                        };
                        command.Parameters.Add(outputParameter);
                        command.ExecuteNonQuery();
                        byte[] compressedData = (byte[])outputParameter.Value;
                        //byte[] decompressedJsonbyt = decompressbyteGzip(compressedData);
                        //decompressedJson = DecompressData(compressedData);
                        decompressedJson = DecompressGzipData(compressedData); //Encoding.UTF8.GetString(decompressedJsonbyt); //.ToString();
                        //decompressedJson = DecompressDeflate(compressedData); 

                        //decompressedJson = Encoding.Unicode.GetString(decompressedJson);
                        //decompressedJson = Decompressbyttest(compressedData);
                    }
                }
                return decompressedJson;
            }
            catch (Exception e) { return e.Message.ToString(); }
        }
        static string DecompressDeflate(byte[] compressedData)
        {
            using (MemoryStream memoryStream = new MemoryStream(compressedData))
            using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress))
            using (StreamReader reader = new StreamReader(deflateStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
        static string Decompressbyttest(byte[] compressedData)
        {
            using (MemoryStream memoryStream = new MemoryStream(compressedData))
            using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
            using (StreamReader reader = new StreamReader(gzipStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
        [HttpPost]
        [Route("api/GetCompressedJSONTest")]
        public dynamic GetCompressedJSONTest(string Inputjson)
        {
            try
            {
                //Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
                //DataSet Resultdtset = new DataSet();
                //IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
                //IDataParameter[] param;
                //objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
                //IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
                //objComm.CommandTimeout = 0;
                //objComm.Connection = objConnection;
                //objComm.CommandType = CommandType.StoredProcedure;
                //objComm.CommandText = "CMS.dbo.CMS_SP_LnAppr_Get_LoanPrograms_IU_JSON";
                //param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LnAppr_Get_LoanPrograms_IU_JSON");
                //daHelper.AttachParameters(objComm, param);
                //param[0].Value = Inputjson;
                //param[1].Value = ParameterDirection.Output;
                //Resultdtset = daHelper.ExecuteDataset(objComm);
                //byte[] compressedData = (byte[])param[1].Value;
                //string compressedData = param[1].Value.ToString();
                //string decompressedData = new GZipStream(compressedData, CompressionMode.Decompress);
                // if the original encoding was ASCII
                //string decompressedJson = Encoding.ASCII.GetString(compressedData);

                //// if the original encoding was UTF-8
                //string decompressedJson = Encoding.UTF8.GetString(compressedData);

                //// if the original encoding was UTF-16
                //string decompressedJson = Encoding.Unicode.GetString(compressedData);

                //// Decompress the data
                //string decompressedJson = DecompressData(compressedData);
                string decompressedJson = "";
                //string connectionString = "your_sql_connection_string";
                string connectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString");
                string storedProcedureName = "CMS.dbo.CMS_SP_LnAppr_Get_LoanPrograms_IU_JSON";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Get the compressed data from the stored procedure output
                                byte[] compressedData = (byte[])reader["YourOutputParameterName"];

                                // Decompress the data
                                //var decompreArr = decompressbyteGzip(compressedData)
                                decompressedJson = DecompressData(compressedData);

                                // Now you have the decompressed data
                                //Console.WriteLine(decompressedJson);
                            }
                        }
                    }
                }
                return decompressedJson;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        static string DecompressData(byte[] compressedData)
        {
            using (MemoryStream compressedStream = new MemoryStream(compressedData))
            {
                using (MemoryStream decompressedStream = new MemoryStream())
                {
                    using (DeflateStream decompressionStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedStream);
                    }

                    // Convert decompressed stream to string using UTF-8 encoding
                    return Encoding.UTF8.GetString(decompressedStream.ToArray());
                }
            }
        }
        [HttpPost]
        [Route("api/DOSLPTasks")]
        public dynamic DOSLPTasks(string InputJSON)
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_DoSLPTasks_JSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_DoSLPTasks_JSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = InputJSON;
            param[1].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[1].Value.ToString();
            //return JsonConvert.SerializeObject(Resultdtset);
        }

        static byte[] decompressbyteGzip(byte[] gzipData)
        {
            using (var compressedStream = new MemoryStream(gzipData))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }

        static string DecompressGzipData(byte[] compressedData)
        {
            using (MemoryStream compressedStream = new MemoryStream(compressedData))
            {
                using (MemoryStream decompressedStream = new MemoryStream())
                {
                    using (GZipStream decompressionStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedStream);
                    }

                    // Convert decompressed stream to string using UTF-8 encoding
                    return Encoding.UTF8.GetString(decompressedStream.ToArray());
                }
            }
        }
        //static string DecompressData(byte[] compressedData)
        //{
        //    using (MemoryStream compressedStream = new MemoryStream(compressedData))
        //    {
        //        using (MemoryStream decompressedStream = new MemoryStream())
        //        {
        //            using (DeflateStream decompressionStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
        //            {
        //                decompressionStream.CopyTo(decompressedStream);
        //            }

        //            // Convert decompressed stream to string
        //            return Encoding.UTF8.GetString(decompressedStream.ToArray());
        //        }
        //    }
        //}
        //public async TaskInvoke(HttpContext context)
        //{
        //    if (context.Request.Headers["Content-Encoding"].Contains("gzip"))
        //    {
        //        context.Request.Body = new GZipStream(context.Request.Body, CompressionMode.Decompress);
        //    }

        //    await _next(context);
        //}
        [HttpPost]
        [Route("api/Get_LastLoanSearch")]
        public dynamic Get_LastLoanSearch(int SearchId, int LoanId )
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_Get_LastLoanSearchJSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_Get_LastLoanSearchJSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = SearchId;
            param[1].Value = LoanId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/GetAPRValue")]
        public dynamic GetAPRValue(int lineid, float IntRate)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_GetAprvalueGrid";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GetAprvalueGrid");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = lineid;
            param[1].Value = IntRate;
            param[2].Value = ParameterDirection.Output;
            param[3].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString() + '~' + param[3].Value.ToString();

        }
        [HttpPost]
        [Route("api/GetARMDetails")]
        public dynamic GetARMDetails(int lineid, float IntRate, int LockPeriodID)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_Get_ARMDetails";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_Get_ARMDetails");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = lineid;
            param[1].Value = IntRate;
            param[2].Value = LockPeriodID;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);

        }
        [HttpPost]
        [Route("api/GetLoanOfficer")]
        public dynamic GetLoanOfficer(int flag, int LOChoice)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_LoanBoarding_GetNeededLoanOfficer";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LoanBoarding_GetNeededLoanOfficer");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = flag;
            param[1].Value = LOChoice;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);

        }
        [HttpPost]
        [Route("api/GetBrokerSearchList")]
        public dynamic GetBrokerSearchList(string SessionId, string Name, int EmpNum)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_GetBrokerSearchList_BootStrap";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GetBrokerSearchList_BootStrap");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = SessionId;
            param[1].Value = Name;
            param[2].Value = EmpNum;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);

        }

        [HttpPost]
        [Route("api/GetBrokerSearchListByCompNum")]
        public dynamic GetBrokerSearchListByCompNum(string SessionId, string Id, int IsAlpha)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_Nav_IsSearchBrokerCompNum";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_Nav_IsSearchBrokerCompNum");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = SessionId;
            param[1].Value = Id;
            param[2].Value = IsAlpha;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);

        }
        [HttpPost]
        [Route("api/GetCompanySelection")]
        public dynamic GetCompanySelection(int CompanyNum)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_GetFeesinRates_CompanySelection";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GetFeesinRates_CompanySelection");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = CompanyNum;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);

        }
        [HttpPost]
        [Route("api/SaveLoanOfficer")]
        public dynamic SaveLoanOfficer(int LoanId, int UserId)
        {
 
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
 
            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_SaveLoanOfficer";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_SaveLoanOfficer");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = UserId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
 
        }
        [HttpPost]
        [Route("api/GetLoanlevelRestriction")]
        public dynamic GetLoanlevelRestriction(int LoanID, int LOID, int CompNum, int EmpNum)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.Cms_SP_Loanlevel_FeesinRate_Restriction";
            param = daHelper.GetSpParameterSet("CMS.dbo.Cms_SP_Loanlevel_FeesinRate_Restriction");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanID;
            param[1].Value = LOID;
            param[2].Value = ParameterDirection.Output;
            param[3].Value = CompNum;
            param[4].Value = EmpNum;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();

        }
        [HttpPost]
        [Route("api/getLOFeesinRate")]
        public dynamic getLOFeesinRate(int LOId)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_getLOFeesinRates";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_getLOFeesinRates");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LOId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);

        }
        [HttpPost]
        [Route("api/InValidateAddress")]
        public dynamic InValidateAddress(int LoanId, string SessionId)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.DMTracking_InValidateAddress";
            param = daHelper.GetSpParameterSet("CMS.dbo.DMTracking_InValidateAddress");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = SessionId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);

        }
        [HttpPost]
        [Route("api/GetZipCodeDetails")]
        public dynamic GetZipCodeDetails(int Zipcode)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.cms_sp_get_zipcodedetails";
            param = daHelper.GetSpParameterSet("CMS.dbo.cms_sp_get_zipcodedetails");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Zipcode;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);

        }
        [HttpPost]
        [Route("api/GetSessionData")]
        public dynamic GetSessionData(string strSessionId, string SessVarName)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.GetSessionVar";
            param = daHelper.GetSpParameterSet("CMS.dbo.GetSessionVar");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = strSessionId;
            param[1].Value = SessVarName;
            param[2].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();

        }
        [HttpPost]
        [Route("api/GetEmpPreQualLoan")]
        public dynamic GetEmpPreQualLoan(string strEmpNum)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.cmsdata_Employee_PreQualLoanId_Get";
            param = daHelper.GetSpParameterSet("CMS.dbo.cmsdata_Employee_PreQualLoanId_Get");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = strEmpNum;
            param[1].Value = 0;
            param[1].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[1].Value.ToString();

        }
        [HttpPost]
        [Route("api/SaveBrokerSelected")]
        public dynamic SaveBrokerSelected(int brokerid, int newloanid)
        {

            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            IDataParameter[] param;
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "CMS.dbo.CMS_SP_SaveBrokerSelected";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_SaveBrokerSelected");
            daHelper.AttachParameters(objComm, param);
            //param[0].Value = brokerid;
            //param[1].Value = newloanid;
            //param[0].Value = 1;
            param[0].Value = newloanid;
            param[1].Value = brokerid;
            param[2].Value = 1;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);

        }
    }
}
