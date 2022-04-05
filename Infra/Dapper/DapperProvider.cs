using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infrastructure.Dapper
{
    public interface IDapper
    {
        DbConnection GetDbconnection();

        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        Task<T> GetAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        Task<List<T>> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        List<T> GetList<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        IEnumerable<T> GetAllItem<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        Task Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        int ExecuteNotAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        public DynamicParameters AddParam<T>(T model, string storeName, Guid? userId = null);
    }

    public class DapperRepository : IDapper
    {
        private readonly IConfiguration _config;
        private readonly string Connectionstring = "Default";

        public DapperRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            await db.ExecuteAsync(sp, parms, commandType: commandType);
        }

        public int ExecuteNotAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Execute(sp, parms, commandType: commandType);
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.QueryFirstOrDefault<T>(sp, parms, commandType: commandType);
        }

        public async Task<T> GetAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return await db.QueryFirstOrDefaultAsync<T>(sp, parms, commandType: commandType);
        }

        public async Task<List<T>> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return (await db.QueryAsync<T>(sp, parms, commandType: commandType)).ToList();
        }

        public List<T> GetList<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public IEnumerable<T> GetAllItem<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var item = db.Query<T>(sp, parms, commandType: commandType);
            return item;
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return await db.QueryAsync<T>(sp, parms, commandType: commandType);
        }

        public DynamicParameters AddParam<T>(T model, string storeName, Guid? userId = null)
        {
            DynamicParameters dbparam = new DynamicParameters();
            var lstParam = GetParamFromProce(storeName);

            foreach (string param in lstParam)
            {
                if (param == "TotalCount")
                {
                    dbparam.Add("TotalCount", 0, DbType.Int32, ParameterDirection.Output);
                }
                else if (param == "CreatedBy" || param == "UpdatedBy")
                {
                    dbparam.Add(param, userId, DbType.Guid);
                }
                else
                {
                    var prop = model.GetType().GetProperty(param);
                    var typeDB = dbTypeMap.ContainsKey(prop.PropertyType.Name) ? dbTypeMap[prop.PropertyType.Name] : DbType.String;
                    if (prop.PropertyType.Name == typeof(List<Guid>).Name)
                    {
                        List<Guid> listValue = prop.GetValue(model, null) != null ? (List<Guid>)prop.GetValue(model, null) : new List<Guid>();
                        dbparam.Add(param, listValue.Count > 0 ? string.Join(";", listValue) : "", typeDB);
                    }
                    else if (prop.PropertyType.Name == typeof(List<string>).Name)
                    {
                        List<string> listValue = prop.GetValue(model, null) != null ? (List<string>)prop.GetValue(model, null) : new List<string>();
                        dbparam.Add(param, listValue.Count > 0 ? string.Join(";", listValue) : "", typeDB);
                    }
                    else
                    {
                        dbparam.Add(param, prop.GetValue(model, null), typeDB);
                    }
                }
            }
            return dbparam;
        }

        private Dictionary<string, DbType> dbTypeMap = new Dictionary<string, DbType>()
        {
            { typeof(bool).Name, DbType.Boolean},
            { typeof(DateTime).Name, DbType.DateTime},
            { typeof(decimal).Name, DbType.Decimal},
            { typeof(double).Name, DbType.Double},
            { typeof(Guid).Name, DbType.Guid},
             { typeof(Guid?).Name, DbType.Guid},
            { typeof(short).Name, DbType.Int16},
            { typeof(int).Name, DbType.Int32},
            { typeof(long).Name, DbType.Int64},
            { typeof(string).Name, DbType.String},
            { typeof(List<Guid>).Name, DbType.String},
        };

        private List<string> GetParamFromProce(string storeName)
        {
            DynamicParameters dbparam = new DynamicParameters();
            dbparam.Add("StoreName", storeName, DbType.String);
            return GetList<string>("Proc_GetListParam", dbparam, commandType: CommandType.StoredProcedure);
        }
    }
}