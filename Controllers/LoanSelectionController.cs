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
            catch (Exception e)
            {
                decompressedJson = "Error";
            }
            return decompressedJson;
        }
        //API_Get_LoanPrograms_IU_Wrapper
        [HttpPost]
        [Route("api/Get_LoanProgramIU")]
        public dynamic Get_LoanProgramIU(int OutFlag, string Inputjson)
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
                            else
                            {
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
        [HttpPost]
        [Route("api/DOSLPTasks_")]
        public dynamic DOSLPTasks_([FromBody] JObject parameters)
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
            param[0].Value = parameters.GetValue("InputJSON").ToString();
            param[1].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[1].Value.ToString();
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
        public dynamic Get_LastLoanSearch(int SearchId, int LoanId)
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

        [HttpPost]
        [Route("api/GetRankingInfo")]
        public dynamic GetRankingInfo(int LoanID, int RunID, string CommonID, int LockPeriod, int IncludeFee)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LoanSearchResults_Ranking_JSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LoanSearchResults_Ranking_JSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanID;
            param[1].Value = RunID;
            param[2].Value = CommonID;
            param[3].Value = LockPeriod;
            param[4].Value = IncludeFee;
            param[5].Value = 0;
            param[6].Value = ParameterDirection.Output; ;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[6].Value.ToString();
        }

        [HttpPost]
        [Route("api/SavePaymentDetails")]
        public dynamic SavePaymentDetails(int LineId, int LoanId, string HazIns, string RETax, string HOADues, string Other, string TotalPITI)
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
            objComm.CommandText = "CMS.dbo.CMSOS_SP_SavePaymentDetails";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMSOS_SP_SavePaymentDetails");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LineId;
            param[1].Value = LoanId;
            param[2].Value = HazIns;
            param[3].Value = RETax;
            param[4].Value = HOADues;
            param[5].Value = Other;
            param[6].Value = TotalPITI;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/GetAdjustmentDetails")]
        public dynamic GetAdjustmentDetails(int LineId, int IntRate, int LockPeriod, string ChangeRateXML)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LnAppr_Get_BasePricing_Info_JSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LnAppr_Get_BasePricing_Info_JSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LineId;
            param[1].Value = LockPeriod;
            param[2].Value = IntRate;
            param[3].Value = ChangeRateXML;
            param[4].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[4].Value.ToString();
        }
        [HttpPost]
        [Route("api/GetAdjustmentDetails_")]
        public dynamic GetAdjustmentDetails_([FromBody] JObject parameters)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LnAppr_Get_BasePricing_Info_JSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LnAppr_Get_BasePricing_Info_JSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = parameters.GetValue("LineId").ToString();
            param[1].Value = parameters.GetValue("LockPeriod").ToString();
            param[2].Value = parameters.GetValue("IntRate").ToString();
            param[3].Value = parameters.GetValue("ChangeRateXML").ToString();
            param[4].Value = ParameterDirection.Output;
            param[5].Value = parameters.GetValue("RateSheetId").ToString();
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[4].Value.ToString();
        }

        [HttpPost]
        [Route("api/GetExtendRateDetails")]
        public dynamic GetExtendRateDetails(int LoanId)
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
            objComm.CommandText = "CMS.dbo.DMIntRate_LockExtension_Rst";
            param = daHelper.GetSpParameterSet("CMS.dbo.DMIntRate_LockExtension_Rst");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [Route("api/IsPreQualLoan")]
        public dynamic IsPreQualLoan(int LoanId, int EmpNum)
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
            objComm.CommandText = "CMS.dbo.DMLoans_IsPreQualLoan";
            param = daHelper.GetSpParameterSet("CMS.dbo.DMLoans_IsPreQualLoan");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = EmpNum;
            param[2].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();
        }

        [HttpPost]
        [Route("api/CreateNewLoanUsingPreQual")]
        public dynamic CreateNewLoanUsingPreQual(int CompanyNum, string Input, int NeedJSON)
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
            objComm.CommandText = "CMS.dbo.DMLoans_CreateLoanUsingPreQual_LoanBoarding1";
            param = daHelper.GetSpParameterSet("CMS.dbo.DMLoans_CreateLoanUsingPreQual_LoanBoarding1");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = CompanyNum;
            param[1].Value = Input;
            //param[2].Value = NeedJSON;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/GenerateClosingDisc")]
        public dynamic GenerateClosingDisc(int LoanId, int Type)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_GenerateClosingDiscReports";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GenerateClosingDiscReports");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = Type;
            param[2].Value = 0;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/LockRateValidation_DBChecks")]
        public dynamic LockRateValidation_DBChecks(int LineID, int EmpNum, int LoanId, int RateSheetId, int ChangeLnPrgm, string Sessionid, int flag, string BaseRate, string BasePoints, string ParPeriod)
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
            objComm.CommandText = "CMS.dbo.LoanProgram_Select_LockRate_Call3";
            param = daHelper.GetSpParameterSet("CMS.dbo.LoanProgram_Select_LockRate_Call3");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LineID;
            param[1].Value = EmpNum;
            param[2].Value = LoanId;
            param[3].Value = RateSheetId;
            param[4].Value = ParameterDirection.Output;
            param[5].Value = ChangeLnPrgm;
            param[6].Value = Sessionid;
            param[7].Value = flag;
            param[8].Value = BaseRate;
            param[9].Value = BasePoints;
            param[10].Value = ParPeriod;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[4].Value.ToString();
        }

        [HttpPost]
        [Route("api/DoLockRateProcess")]
        public dynamic DoLockRateProcess(int LineID, int EmpNum, string BaseRate, string BasePoints, string ParPeriod, int LoanId, int RateSheetId, string LockType, string SessionID, string FinalPoints, int ProcessType, int NeedJson)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_DoLockRateProcess";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_DoLockRateProcess");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LineID;
            param[1].Value = EmpNum;
            param[2].Value = BaseRate;
            param[3].Value = BasePoints;
            param[4].Value = ParPeriod;
            param[5].Value = LoanId;
            param[6].Value = RateSheetId;
            param[7].Direction = ParameterDirection.Output;
            param[8].Value = LockType;
            param[9].Value = ProcessType;
            param[10].Value = SessionID;
            param[11].Value = FinalPoints;
            param[12].Value = NeedJson;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[7].Value.ToString();
        }

        [HttpPost]
        [Route("api/UpdatePITIValue")]
        public dynamic UpdatePITIValue(int SearchedLoan, int NewLoan)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_UpdatePITIVal";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_UpdatePITIVal");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = SearchedLoan;
            param[1].Value = NewLoan;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/LockRateValidation")]
        public dynamic LockRateValidation(int LineID, int EmpNum, int LoanId, int RateSheetId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LockRate_Validation";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LockRate_Validation");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LineID;
            param[1].Value = EmpNum;
            param[2].Value = LoanId;
            param[3].Value = RateSheetId;
            param[4].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[4].Value.ToString();
        }

        [HttpPost]
        [Route("api/RateLockOption_SelectOnly")]
        public dynamic RateLockOption_SelectOnly(int LineID, int EmpNum, string BaseRate, string BasePoints, string ParPeriod, int LoanId, int RateSheetId, string LockType, string SessionID, string FinalPoints)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_RateLockOption_SelectOnly";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_RateLockOption_SelectOnly");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LineID;
            param[1].Value = EmpNum;
            param[2].Value = BaseRate;
            param[3].Value = BasePoints;
            param[4].Value = ParPeriod;
            param[5].Value = LoanId;
            param[6].Value = RateSheetId;
            param[7].Direction = ParameterDirection.Output;
            param[8].Value = LockType;
            param[9].Value = 1;
            param[10].Value = SessionID;
            param[11].Value = FinalPoints;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[7].Value.ToString();
        }

        [HttpPost]
        [Route("api/IsLoanLocked")]
        public dynamic IsLoanLocked(int LoanId)
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
            objComm.CommandText = "CMS.dbo.DMLoans_LoanLockedNew";
            param = daHelper.GetSpParameterSet("CMS.dbo.DMLoans_LoanLockedNew");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[1].Value.ToString();
        }

        [HttpPost]
        [Route("api/IsSearchLoanNumber")]
        public dynamic IsSearchLoanNumber(string strSessionId, string LoanId, string Text)
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
            objComm.CommandText = "CMS.dbo.Cms_SP_LandingPage_LoanSearch_Wrapper";
            param = daHelper.GetSpParameterSet("CMS.dbo.Cms_SP_LandingPage_LoanSearch_Wrapper");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = strSessionId;
            param[1].Value = LoanId;
            param[2].Value = 1;
            param[3].Value = Text;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/GetSearchResults")]
        public dynamic GetSearchResults(string strSessionId, string Name, string LoanId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_GetSearchList_BootStrap1";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GetSearchList_BootStrap1");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = strSessionId;
            param[1].Value = Name;
            param[2].Value = LoanId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/GetLockRateXMLBySearchId")]
        public dynamic GetLockRateXMLBySearchId(int SearchId, int LoanId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_GetLockRateXMLBySearchId";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GetLockRateXMLBySearchId");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = SearchId;
            param[1].Value = LoanId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/UserCustomOrder")]
        public dynamic UserCustomOrder(int EmpNum, string UserType, string inputxml, int Flag, int UWFees, int LOId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_RateLock_CustomSort_Save_JSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_RateLock_CustomSort_Save_JSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = EmpNum;
            param[1].Value = UserType;
            param[2].Value = inputxml;
            param[3].Value = Flag;
            param[4].Value = UWFees;
            param[5].Value = LOId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/UpdateSortOrder")]
        public dynamic UpdateSortOrder(int UserId, int SortOrder)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_UpdateRateSortOrder";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_UpdateRateSortOrder");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = UserId;
            param[1].Value = SortOrder;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        //[HttpPost]
        //[Route("api/GetCompanySelection")]
        //public dynamic GetCompanySelection(int CompNum)
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
        //    objComm.CommandText = "CMS.dbo.CMS_SP_GetFeesinRates_CompanySelection";
        //    param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GetFeesinRates_CompanySelection");
        //    daHelper.AttachParameters(objComm, param);
        //    param[0].Value = CompNum;
        //    Resultdtset = daHelper.ExecuteDataset(objComm);
        //    return JsonConvert.SerializeObject(Resultdtset);
        //}

        [HttpPost]
        [Route("api/GetSortOrder")]
        public dynamic GetSortOrder(int UserId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_GETRateSortOrder";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GETRateSortOrder");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = UserId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/GetInvIncome")]
        public dynamic GetInvIncome(int LoanId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_RateLock_GetInvInfo";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_RateLock_GetInvInfo");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/GetLeadSourceRights")]
        public dynamic GetLeadSourceRights(int EmpNum)
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
            objComm.CommandText = "CMS.dbo.Cms_Sp_GetLeadSourceRights";
            param = daHelper.GetSpParameterSet("CMS.dbo.Cms_Sp_GetLeadSourceRights");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = EmpNum;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/SaveConfirmationFields")]
        public dynamic SaveConfirmationFields(int LoanId, string SaveXML)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_SaveConfirmationFields";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_SaveConfirmationFields");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = SaveXML;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/UpdateInvestorInfo")]
        public dynamic UpdateInvestorInfo(int Loanid, string strXml)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_UpdateInvestorInfo";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_UpdateInvestorInfo");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            param[1].Value = strXml;
            param[2].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();
        }

        [HttpPost]
        [Route("api/SaveSupervisorLock")]
        public dynamic SaveSupervisorLock(int Loanid, string strXml)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_Save_SupervisorLock_Data";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_Save_SupervisorLock_Data");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            param[1].Value = strXml;
            param[2].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();
        }

        [HttpPost]
        [Route("api/getJournalPostStatus")]
        public dynamic getJournalPostStatus(int LoanId)
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
            objComm.CommandText = "CMS.dbo.GL_Post_Entries_To_AccountingCentral_Status";
            param = daHelper.GetSpParameterSet("CMS.dbo.GL_Post_Entries_To_AccountingCentral_Status");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = 1;
            param[2].Direction = ParameterDirection.Output; // Status
            param[3].Direction = ParameterDirection.Output; // Error Msg
            param[4].Direction = ParameterDirection.Output; // Un Post Flag
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString() + '~' + param[3].Value.ToString() + '~' + param[4].Value.ToString();
        }

        [HttpPost]
        [Route("api/UnPostJournal")]
        public dynamic UnPostJournal(string XmlDataIn)
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
            objComm.CommandText = "CMS.dbo.GL_Post_Entries_To_AccountingCentral";
            param = daHelper.GetSpParameterSet("CMS.dbo.GL_Post_Entries_To_AccountingCentral");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = XmlDataIn;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return '1';
        }

        [HttpPost]
        [Route("api/SaveLockRateCancelReason")]
        public dynamic SaveLockRateCancelReason(int Loanid, int EmpNum, string CancelReason, string CancelType)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LockRateCancelReason";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LockRateCancelReason");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            param[1].Value = EmpNum;
            param[2].Value = CancelReason;
            param[3].Value = CancelType;
            param[4].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[4].Value.ToString();
        }

        [HttpPost]
        [Route("api/GoLockTransfer")]
        public dynamic GoLockTransfer(int Loanid, int TargetLoanid)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_Get_TransferLock_Data";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_Get_TransferLock_Data");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            param[1].Value = TargetLoanid;
            param[2].Direction = ParameterDirection.Output;
            param[3].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString() + "~" + param[3].Value.ToString();
        }

        [HttpPost]
        [Route("api/DoTransferLock")]
        public dynamic DoTransferLock(int Loanid, int TargetLoanid, string TransferXml, int EmpNum)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_DoTransferLock";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_DoTransferLock");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            param[1].Value = TargetLoanid;
            param[2].Value = TransferXml;
            param[3].Value = EmpNum;
            param[4].Direction = ParameterDirection.Output;
            param[5].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[4].Value.ToString() + "~" + param[5].Value.ToString();
        }
        [HttpPost]
        [Route("api/Iswholesaleaccess")]
        public dynamic Iswholesaleaccess(int EmpNum)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_wholesaleintAccess";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_wholesaleintAccess");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = EmpNum;
            param[1].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[1].Value.ToString();

        }


        [HttpPost]
        [Route("api/CheckExtensionUsed")]
        public dynamic CheckExtensionUsed(int Loanid)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_CheckExtensionUsed";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_CheckExtensionUsed");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/Test_LockExtensionRestriction")]
        public dynamic Test_LockExtensionRestriction(int Loanid, int EmpNum)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_TestLockExtensionRestriction";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_TestLockExtensionRestriction");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            param[1].Value = EmpNum;
            param[2].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();

        }
        [HttpPost]
        [Route("api/SaveLockRateExtendLock")]
        public dynamic SaveLockRateExtendLock(int Loanid, int EmpNum, string strXML)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_SaveLockRateExtendLock";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_SaveLockRateExtendLock");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            param[1].Value = EmpNum;
            param[2].Value = strXML;
            param[3].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[3].Value.ToString();

        }
        [HttpPost]
        [Route("api/ChangeRateSet")]
        public dynamic ChangeRateSet(int Loanid)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LockRate_LockChangeRateSet";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LockRate_LockChangeRateSet");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return '1';
        }
        [HttpPost]
        [Route("api/GetPrequalLoanInfoXML")]
        public dynamic GetPrequalLoanInfoXML(int PrequalLoanId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_GetPrequalLoanInfoXML";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GetPrequalLoanInfoXML");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = PrequalLoanId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/CheckAddressValidity")]
        public dynamic CheckAddressValidity(int LoanId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_CheckAddressValidity";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_CheckAddressValidity");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/ValidateLoanBasicInfo")]
        public dynamic ValidateLoanBasicInfo(int LoanId, int IsPrequalLoan)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LoanBoarding_ValidateLoanBasicInfo";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LoanBoarding_ValidateLoanBasicInfo");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = IsPrequalLoan;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/ChangeRate")]
        public dynamic ChangeRate(int LineId, int EmpNum, int LoanId, string SessionId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_RateLock_GetData_JSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_RateLock_GetData_JSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LineId;
            param[1].Value = EmpNum;
            param[2].Value = LoanId;
            param[3].Value = SessionId;
            param[4].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[4].Value.ToString();
        }
        [HttpPost]
        [Route("api/FloatDownSet")]
        public dynamic FloatDownSet(int Loanid, int EmpNum)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LockRate_FloatDownSet";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LockRate_FloatDownSet");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            param[1].Value = EmpNum;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return '1';
        }
        [HttpPost]
        [Route("api/PrintLockConf")]
        public dynamic PrintLockConf(int Loanid, int EmpNum)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_Print_LockConfirmation";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_Print_LockConfirmation");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = Loanid;
            param[1].Value = EmpNum;
            param[2].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();
        }
        [HttpPost]
        [Route("api/ClearRelock")]
        public dynamic ClearRelock(int LoanId, int EmpNum, string SessionId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_RateLock_ClearRelockfee";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_RateLock_ClearRelockfee");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = EmpNum;
            param[2].Value = SessionId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return '1';
        }
        [HttpPost]
        [Route("api/FindChangeLogXML")]
        public dynamic FindChangeLogXML(int LoanId, int CustID, int DBFieldId, int ItemId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_Generic_Framework_ChangeLogXML";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_Generic_Framework_ChangeLogXML");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = CustID;
            param[2].Value = DBFieldId;
            param[3].Value = ItemId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/GetEditRights")]
        public dynamic GetEditRights(int LoanId, int EmpId, string userType, int FromId)
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
            objComm.CommandText = "CMS.dbo.FormRights";
            param = daHelper.GetSpParameterSet("CMS.dbo.FormRights");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = userType;
            param[2].Value = EmpId;
            param[3].Value = FromId;
            param[4].Direction = ParameterDirection.Output;
            param[5].Value = 0;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[4].Value.ToString();
        }

        [HttpPost]
        [Route("api/WorseCaseTest")]
        public dynamic WorseCaseTest(int LoanId, int LoanProgId, int EmpNum, int LnProgActiveId, int TestOnly)
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
            objComm.CommandText = "CMS.dbo.LockRate_Worst_Case_Cal";
            param = daHelper.GetSpParameterSet("CMS.dbo.LockRate_Worst_Case_Cal");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = LoanProgId;
            param[2].Value = EmpNum;
            param[3].Value = LnProgActiveId;
            param[4].Value = TestOnly;
            param[5].Direction = ParameterDirection.Output;
            param[6].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[6].Value.ToString();
        }
        [HttpPost]
        [Route("api/AddressValidation")]
        public dynamic AddressValidation(int LoanId, int CustId, string SessionId, int EmpNum)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_AddressValidation_WebserviceCall";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_AddressValidation_WebserviceCall");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = CustId;
            param[2].Value = SessionId;
            param[3].Value = EmpNum;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/ManualValidation")]
        public dynamic ManualValidation(int LoanId, int EmpNum, string SessionId)
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
            objComm.CommandText = "CMS.dbo.DMTRACKING_ValidateNewConstructionAddress";
            param = daHelper.GetSpParameterSet("CMS.dbo.DMTRACKING_ValidateNewConstructionAddress");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = EmpNum;
            param[2].Value = SessionId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/GetAddressInfo")]
        public dynamic GetAddressInfo(int LoanId, int EmpNum)
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
            objComm.CommandText = "CMS.dbo.DMTracking_GetAddressValidation";
            param = daHelper.GetSpParameterSet("CMS.dbo.DMTracking_GetAddressValidation");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = EmpNum;
            param[2].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();
        }
        [HttpPost]
        [Route("api/UnValidateAddress")]
        public dynamic UnValidateAddress(int LoanID, string SessionID)
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
            param[0].Value = LoanID;
            param[1].Value = SessionID;
            param[2].Value = 1;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/AddressValidationResult")]
        public dynamic AddressValidationResult(int LoanID, string SessionID, string strOutput, string pageContent, int success)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_AddressValidation_Result";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_AddressValidation_Result");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanID;
            param[1].Value = SessionID;
            param[2].Value = strOutput;
            param[3].Value = pageContent;
            param[4].Value = success;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/LoanBoardingSave")]
        public dynamic LoanBoardingSave(int LoanID, string SaveJson)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LoanBoarding_SaveData_JSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LoanBoarding_SaveData_JSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanID;
            param[1].Value = SaveJson;
            param[2].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();
        }


        [HttpPost]
        [Route("api/LoanBoardingSave_")]
        public dynamic LoanBoardingSave_([FromBody] JObject parameters)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LoanBoarding_SaveData_JSON";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LoanBoarding_SaveData_JSON");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = parameters.GetValue("LoanID").ToString();
            param[1].Value = parameters.GetValue("SaveJson").ToString();
            param[2].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();
        }

        [HttpPost]
        [Route("api/SaveWindowSize")]
        public dynamic SaveWindowSize(string SessionId, string ViewJson, int UpdateFlag, int FormID, string FormName)
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
            objComm.CommandText = "CMS.dbo.Cms_Sp_Get_Update_FormLastView";
            param = daHelper.GetSpParameterSet("CMS.dbo.Cms_Sp_Get_Update_FormLastView");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = SessionId;
            param[1].Value = ViewJson;
            param[2].Value = UpdateFlag;
            param[3].Value = FormID;
            param[4].Value = FormName;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/GetLendercompplanCheck")]
        public dynamic GetLendercompplanCheck(int CompNum)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_Get_LendercompplanCheck";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_Get_LendercompplanCheck");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = CompNum;
            param[1].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[1].Value.ToString();
        }
        [HttpPost]
        [Route("api/AddressValidationDuringSLP")]
        public dynamic AddressValidationDuringSLP(int LoanId, int CustId, string SessionId, int UserId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_AddressValidation_WebserviceCall";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_AddressValidation_WebserviceCall");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = CustId;
            param[2].Value = SessionId;
            param[3].Value = UserId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/SearchCompanyByEmp")]
        public dynamic SearchCompanyByEmp(string UserType, string SearchTxt)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_FormsMenu_UserCompanyResult_New";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_FormsMenu_UserCompanyResult_New");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = UserType;
            param[1].Value = SearchTxt;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/GetCompNameByCompID")]
        public dynamic GetCompNameByCompID(int CompNum)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_GetCompNameByCompID";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GetCompNameByCompID");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = CompNum;
            param[1].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[1].Value.ToString();
        }

        [HttpPost]
        [Route("api/wholesaleintrateaccess")]
        public dynamic wholesaleintrateaccess(int EmpNum)
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
            objComm.CommandText = "CMS.dbo.Rights_Wholesale_Intrate_Access2";
            param = daHelper.GetSpParameterSet("CMS.dbo.Rights_Wholesale_Intrate_Access2");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = EmpNum;
            param[1].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[1].Value.ToString();
        }
        [HttpPost]
        [Route("api/UpdateLenderComp")]
        public dynamic UpdateLenderComp(int EmpNum, int Value, int Flag)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_FetchUpdateLenderComp";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_FetchUpdateLenderComp");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = EmpNum;
            param[1].Value = Value;
            param[2].Value = Flag;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }


        [HttpPost]
        [Route("api/ValidateCommitment")]
        public dynamic ValidateCommitment(int Value)
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.Text;
            objComm.CommandText = "SELECT CMS.dbo.cms_fn_validate_commitment(@Value)";
            IDataParameter paramValue = new System.Data.SqlClient.SqlParameter("@Value", Value);
            objComm.Parameters.Add(paramValue);
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)objComm);
            da.Fill(Resultdtset);
            return JsonConvert.SerializeObject(Resultdtset);
        }


        [HttpPost]
        [Route("api/UpdateSearchFlow")]
        public dynamic UpdateSearchFlow(int Value, int LoanId)
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();

            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.Text;
            objComm.CommandText = "UPDATE CMS.dbo.lnapprtemp SET Run_Pricing_IN_MO = @Value WHERE LoanId = @LoanId";
            IDataParameter paramValue = new System.Data.SqlClient.SqlParameter("@Value", Value);
            IDataParameter paramCondition = new System.Data.SqlClient.SqlParameter("@LoanId", LoanId);
            objComm.Parameters.Add(paramValue);
            objComm.Parameters.Add(paramCondition);
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)objComm);
            da.Fill(Resultdtset);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/GetMOSearchFlow")]
        public dynamic GetMOSearchFlow(int LoanId)
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.Text;
            objComm.CommandText = "SELECT ISNULL(Run_Pricing_IN_MO,0) as 'Run_Pricing_IN_MO' FROM CMS.dbo.lnapprtemp WHERE LoanId = @LoanId";
            IDataParameter paramValue = new System.Data.SqlClient.SqlParameter("@LoanId", LoanId);
            objComm.Parameters.Add(paramValue);
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)objComm);
            da.Fill(Resultdtset);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/CreateDepositEntry")]
        public dynamic CreateDepositEntry(int LoanId, string CheckAmount, string CheckDate, int DocumentReviewed)
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
            objComm.CommandText = "CMS.dbo.Cms_Sp_Create_DepositEntry";
            param = daHelper.GetSpParameterSet("CMS.dbo.Cms_Sp_Create_DepositEntry");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = CheckAmount;
            param[2].Value = CheckDate;
            param[3].Value = DocumentReviewed;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/LogDWVisitorsEvent")]
        public dynamic LogDWVisitorsEvent(string PageTitle, string PageURL, string device, string IPAddress, int ParentId, string detailsJson)
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
                objComm.CommandType = CommandType.StoredProcedure;
                objComm.CommandText = "contact.dbo.Contact_SP_LogDWVisitorsEvent_onload";
                param = daHelper.GetSpParameterSet("contact.dbo.Contact_SP_LogDWVisitorsEvent_onload");
                daHelper.AttachParameters(objComm, param);
                param[0].Value = PageTitle;
                param[1].Value = PageURL;
                param[2].Value = device;
                param[3].Value = IPAddress;
                param[4].Value = ParentId;
                param[5].Value = detailsJson;
                Resultdtset = daHelper.ExecuteDataset(objComm);
                return Resultdtset.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [HttpPost]
        [Route("api/fnLogDWCallToActionEvent")]
        public dynamic fnLogDWCallToActionEvent(string PageTitle, string PageURL, string device, string IPAddress, string ParentId, string Buttontext, string detailsJson)
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
                objComm.CommandType = CommandType.StoredProcedure;
                objComm.CommandText = "contact.dbo.Contact_Sp_DWLog_CallToActions";
                param = daHelper.GetSpParameterSet("contact.dbo.Contact_Sp_DWLog_CallToActions");
                daHelper.AttachParameters(objComm, param);
                param[0].Value = PageTitle;
                param[1].Value = PageURL;
                param[2].Value = device;
                param[3].Value = IPAddress;
                param[4].Value = ParentId;
                param[5].Value = Buttontext;
                param[6].Value = detailsJson;

                Resultdtset = daHelper.ExecuteDataset(objComm);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [HttpPost]
        [Route("api/ReLockRate")]
        public dynamic ReLockRate(int LoanId, int EmpNum, int ExpMoreThan30)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_ReLockRate";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_ReLockRate");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            param[1].Value = EmpNum;
            param[2].Value = ExpMoreThan30;
            param[3].Direction = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[3].Value.ToString();
        }

        [HttpPost]
        [Route("api/GetLoanDetails")]
        public dynamic GetLoanDetails(int LoanId)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_ManualLoanSelection_GetLoanDetails";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_ManualLoanSelection_GetLoanDetails");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanId;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
       
        // MI Quote API Begins
        [HttpPost]
        [Route("api/GetMIQuote_Wrapper")]
        public dynamic GetMIQuote_Wrapper(int LoanID, string SessionID, int PlanType, string VendorIds, int fromRatelock, string coverages)
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
            objComm.CommandText = "CMS.[dbo].[CMS_SP_MIQuote_Wrapper]";
            param = daHelper.GetSpParameterSet("CMS.[dbo].[CMS_SP_MIQuote_Wrapper]");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanID;
            param[1].Value = SessionID;
            param[2].Value = ParameterDirection.Output;
            param[3].Value = PlanType;
            param[4].Value = VendorIds;
            param[5].Value = fromRatelock;
            param[6].Value = coverages;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[2].Value.ToString();
        }

        [HttpPost]
        [Route("api/OpenPopUp_MIQuote")]
        public dynamic OpenPopUp_MIQuote(int LoanID, int isUpdatedelay)
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
            objComm.CommandText = "CMS.[dbo].[CMS_SP_DisplayPrompt_MIQuote]";
            param = daHelper.GetSpParameterSet("CMS.[dbo].[CMS_SP_DisplayPrompt_MIQuote]");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanID;
            param[1].Value = isUpdatedelay;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return Resultdtset.Tables[0].Rows[0][0].ToString();
        }

        [HttpPost]
        [Route("api/ProceedRunMiQuote")]
        public dynamic ProceedRunMiQuote(int LoanID, string Fico, float LoanAmount, float LoanAmounttwo, float LTV, float CLTV)
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
            objComm.CommandText = "CMS.[dbo].[CMS_SP_isMIQuote_Exists]";
            param = daHelper.GetSpParameterSet("CMS.[dbo].[CMS_SP_isMIQuote_Exists]");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LoanID;
            param[1].Value = Fico;
            param[2].Value = LoanAmount;
            param[3].Value = LoanAmounttwo;
            param[4].Value = LTV;
            param[5].Value = CLTV;
            param[6].Value = ParameterDirection.Output;
            param[7].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[6].Value.ToString() + '~' + param[7].Value.ToString();
        }

        [HttpPost]
        [Route("api/SelectMIQuote")]
        public dynamic SelectMIQuote(int LineId, string SessionId, string Fico, float LoanAmount, float LoanAmounttwo, float LTV, float CLTV)
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
            objComm.CommandText = "CMS.[dbo].[CMS_SP_SelectMIQuote_Line]";
            param = daHelper.GetSpParameterSet("CMS.[dbo].[CMS_SP_SelectMIQuote_Line]");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = LineId;
            param[1].Value = SessionId;
            param[2].Value = Fico;
            param[3].Value = LoanAmount;
            param[4].Value = LoanAmounttwo;
            param[5].Value = LTV;
            param[6].Value = CLTV;
            param[7].Value = ParameterDirection.Output;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return param[7].Value.ToString();
        }

        [HttpPost]
        [Route("api/GetUpdatedPaymentSection")]
        public dynamic GetUpdatedPaymentSection(int RunID, int Lineid)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_GetUpdatedPaymentSection";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_GetUpdatedPaymentSection");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = RunID;
            param[1].Value = Lineid;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        } 
        // MI Quote API Ends


        // Document Begins
        [HttpPost]
        [Route("api/ConditionAssociations")]
        public dynamic ConditionAssociations(int scandocid, int loanid)
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
            objComm.CommandText = "CMS.dbo.GetMultipleConditions_Data";
            param = daHelper.GetSpParameterSet("CMS.dbo.GetMultipleConditions_Data");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = scandocid;
            param[1].Value = loanid;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/SaveConditionAssociations")]
        public dynamic SaveConditionAssociations(int scandocid, int loanid, string conditions, int flag)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_SaveMultipleConditions";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_SaveMultipleConditions");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = scandocid;
            param[1].Value = loanid;
            param[2].Value = conditions;
            param[3].Value = flag;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        } 
        //Document Ends

        [HttpPost]
        [Route("api/ManualLoanSelectionWrapper")]
        public dynamic ManualLoanSelectionWrapper(int loanid, string type, string input)
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
            objComm.CommandText = "CMS.dbo.ManualLoanSelectionWrapper";
            param = daHelper.GetSpParameterSet("CMS.dbo.ManualLoanSelectionWrapper");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = loanid;
            param[1].Value = type;
            param[2].Value = input;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/LoanBasicInfo")]
        public dynamic LoanBasicInfo(int loanid)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_LoanBasicInfo";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_LoanBasicInfo");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = loanid;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }

        [HttpPost]
        [Route("api/getManualLoanSelectionRights")]
        public dynamic getManualLoanSelectionRights(string sessionid)
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
            objComm.CommandText = "CMS.dbo.getManualLoanSelectionRights";
            param = daHelper.GetSpParameterSet("CMS.dbo.getManualLoanSelectionRights");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = sessionid;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }


        [HttpPost]
        [Route("api/Updateempscandoc")]
        public dynamic Updateempscandoc(string EntityName)
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
            objComm.CommandText = "CMS.dbo.cms_sp_Updateempscandoc";
            param = daHelper.GetSpParameterSet("CMS.dbo.cms_sp_Updateempscandoc");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = EntityName;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/UpdateEscWaiver")]
        public dynamic UpdateEscWaiver(int LoanId, int Value)
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.Text;
            objComm.CommandText = "Update Loandata3 SET LockEscWaiver = @Value WHERE LoanId = @LoanId";
            IDataParameter paramValue = new System.Data.SqlClient.SqlParameter("@LoanId", LoanId);
            IDataParameter paramValue_ = new System.Data.SqlClient.SqlParameter("@Value", Value);
            objComm.Parameters.Add(paramValue);
            objComm.Parameters.Add(paramValue_);
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)objComm);
            da.Fill(Resultdtset);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/pricingErrorHanding")]
        public dynamic pricingErrorHanding(int EmpNum, int Loan, string ErrorMessage, int type)
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
            objComm.CommandText = "CMS.dbo.CMS_SP_PricingErrorHandling";
            param = daHelper.GetSpParameterSet("CMS.dbo.CMS_SP_PricingErrorHandling");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = EmpNum;
            param[1].Value = Loan;
            param[2].Value = ErrorMessage;
            param[3].Value = type;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/DMCRunId")]
        public dynamic DMCRunId(string Id)
        {
            Mvc4Application.Model.SQLDataAccessHelper daHelper = new Mvc4Application.Model.SQLDataAccessHelper();
            DataSet Resultdtset = new DataSet();
            IDbConnection objConnection = new System.Data.SqlClient.SqlConnection();
            objConnection.ConnectionString = Mvc4Application.Utility.Utilities.getValMessageforConnection("connString") + ";Connection Timeout=0;";
            IDbCommand objComm = new System.Data.SqlClient.SqlCommand();
            objComm.CommandTimeout = 0;
            objComm.Connection = objConnection;
            objComm.CommandType = CommandType.Text;
            objComm.CommandText = "EXEC FundedLoanRunData.dbo.FundedLoanScenariodata @Id";
            IDataParameter paramValue = new System.Data.SqlClient.SqlParameter("@Id", Id);
            objComm.Parameters.Add(paramValue);
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)objComm);
            da.Fill(Resultdtset);
            return JsonConvert.SerializeObject(Resultdtset);
        }
        [HttpPost]
        [Route("api/InterestRateSetupMainWrapper")]
        public dynamic InterestRateSetupMainWrapper(string type, string input)
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
            objComm.CommandText = "Intrates.dbo.InterestRateSetupMainWrapper";
            param = daHelper.GetSpParameterSet("Intrates.dbo.InterestRateSetupMainWrapper");
            daHelper.AttachParameters(objComm, param);
            param[0].Value = type;
            param[1].Value = input;
            Resultdtset = daHelper.ExecuteDataset(objComm);
            return JsonConvert.SerializeObject(Resultdtset);
        }
    }
}
