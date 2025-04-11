#region Namespace
using System;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;

using System.Security.Cryptography;
#endregion

namespace Mvc4Application.Utility
{
    public class Utilities
    {
        #region Declarations
        //private static TextWriterTraceListener log = null;
       // private static ResourceManager rmValMess;
        private static ResourceManager rmConnValMess;
        private static string connectionString="";
        //private static string strPicPath = "memberPics";
        #endregion

        #region getValMessageforConnection
		  /*
         * This function returns the connection string
         */

        /// <summary>
        /// <name>getValMessageforConnection</name>
        /// <purpose>To return connection string</purpose>
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public static string getValMessageforConnection(string pKey)
        {

            //string dataSource = ConfigurationSettings.AppSettings["DataSource"];

            //string userId = ConfigurationSettings.AppSettings["UserId"];

            //string password = ConfigurationSettings.AppSettings["Password"];

            //string initialCatalog = ConfigurationSettings.AppSettings["InitialCatalog"];

            //connectionString = "Data Source = " + dataSource

            //+ "; User Id = " + userId

            //+ "; Password= " + password

            //+ ";Initial Catalog=" + initialCatalog

            //+ ";Connect Timeout=120";

            // //+ ";Max Pool Size=100"

            //// + ";Min Pool Size=5";


            string dataSource = ConfigurationSettings.AppSettings["server"];

            string initialCatalog = ConfigurationSettings.AppSettings["database"];

            string integratedSecurity = ConfigurationSettings.AppSettings["ConnectionString"];

            connectionString = "Data Source = " + dataSource
                 + ";Initial Catalog=" + initialCatalog
                 + ";" + integratedSecurity;

            //    return connectionString; 

            return connectionString; 
        }
        #endregion

        
    }
}
