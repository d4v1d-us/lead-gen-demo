using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public sealed  class DataAccess
{
    public  static string sDataConnectionString;

	public DataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static SqlParameter[] GetParameters(string spName)
    {
        SqlParameter[] paramsToStore;

        DataTable paramsFromTheSystem = GetSpParameters(spName);
        string sOutPutType;
        try
        {

            paramsToStore = new SqlParameter[paramsFromTheSystem.Rows.Count];


            for (int i = 0; i < paramsToStore.Length; i++)
            {
                //					
                string paramName = paramsFromTheSystem.Rows[i]["ColName"].ToString();
                SqlDbType ParamType = ConvertToSqlDbType(paramsFromTheSystem.Rows[i]["xtype"].ToString());
                int ParamSize = Convert.ToInt32(paramsFromTheSystem.Rows[i]["ColLen"].ToString());

                paramsToStore[i] = new SqlParameter(paramName, ParamType, ParamSize);
                sOutPutType = paramsFromTheSystem.Rows[i]["ColIsOut"].ToString();

                if (sOutPutType.Equals("1"))
                {
                    paramsToStore[i].Direction = ParameterDirection.Output;

                }
                else
                {
                    paramsToStore[i].Direction = ParameterDirection.Input;

                }

            }

        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {

        }
        return paramsToStore;
    }

    public static SqlConnection getConnectionObject()
    {
        string connectionString = GetConnectionString();
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        return connection;
    }
    public static string GetConnectionString()
    {
        string connection = null;        
        connection = (string)System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        return connection;
    }
    public static string GetConnectionForReportData
    {
         get { return sDataConnectionString; }
         set { sDataConnectionString = value; }        
     
    }    

    public static Guid StringToGuid(string value)
    {
        try
        {
            if (value.Length == 0) return Guid.Empty;
            else return new Guid(value);
        }
        catch
        {
            return Guid.Empty;
        }
    }
    private static DataTable GetSpParameters(string spName)
    {
        StringBuilder st = new StringBuilder();
        st.Append("SELECT dbo.sysobjects.name AS ObjName, dbo.sysobjects.xtype AS ObjType,dbo.syscolumns.name AS ColName,");
        st.Append("dbo.syscolumns.colorder AS ColOrder,dbo.syscolumns.length AS ColLen, dbo.syscolumns.colstat AS ColKey,");
        st.Append("dbo.syscolumns.isoutparam AS ColIsOut,dbo.systypes.xtype FROM dbo.syscolumns INNER JOIN dbo.sysobjects ");
        st.Append("ON dbo.syscolumns.id = dbo.sysobjects.id INNER JOIN dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype ");
        st.Append("WHERE (dbo.sysobjects.name = '");
        st.Append(spName);
        st.Append("') order by ColOrder");

        string sSql = st.ToString();
        DataTable oTable = new DataTable();
        DataSet ds = SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.Text, sSql);
        oTable = ds.Tables[0];

        return oTable;
    }
    private static SqlDbType ConvertToSqlDbType(string type)
    {
        SqlDbType dataType;
        switch (type)
        {
            case "34":
                {
                    dataType = SqlDbType.Image;
                    return dataType;
                }
            case "35":
                {
                    dataType = SqlDbType.Text;
                    return dataType;
                }

            case "36":
                {
                    dataType = SqlDbType.UniqueIdentifier;
                    return dataType;
                }
            case "48":
                {
                    dataType = SqlDbType.TinyInt;
                    return dataType;
                }
            case "52":
                {
                    dataType = SqlDbType.SmallInt;
                    return dataType;
                }
            case "56":
                {
                    dataType = SqlDbType.Int;
                    return dataType;
                }
            case "58":
                {
                    dataType = SqlDbType.SmallDateTime;
                    return dataType;
                }
            case "59":
                {
                    dataType = SqlDbType.Real;
                    return dataType;
                }
            case "60":
                {
                    dataType = SqlDbType.Money;
                    return dataType;
                }
            case "61":
                {
                    dataType = SqlDbType.DateTime;
                    return dataType;
                }
            case "62":
                {
                    dataType = SqlDbType.Float;
                    return dataType;
                }
            case "99":
                {
                    dataType = SqlDbType.NText;
                    return dataType;
                }
            case "104":
                {
                    dataType = SqlDbType.Bit;
                    return dataType;
                }
            case "106":
                {
                    dataType = SqlDbType.Decimal;
                    return dataType;
                }
            case "122":
                {
                    dataType = SqlDbType.SmallMoney;
                    return dataType;
                }
            case "127":
                {
                    dataType = SqlDbType.BigInt;
                    return dataType;
                }
            case "165":
                {
                    dataType = SqlDbType.VarBinary;
                    return dataType;
                }
            case "167":
                {
                    dataType = SqlDbType.VarChar;
                    return dataType;
                }
            case "173":
                {
                    dataType = SqlDbType.Binary;
                    return dataType;
                }
            case "175":
                {
                    dataType = SqlDbType.Char;
                    return dataType;
                }
            case "231":
                {
                    dataType = SqlDbType.NVarChar;
                    return dataType;
                }
            case "239":
                {
                    dataType = SqlDbType.NChar;
                    return dataType;
                }
            default:
                {
                    dataType = SqlDbType.VarChar;
                    return dataType;
                }
        }
    }
   
}
