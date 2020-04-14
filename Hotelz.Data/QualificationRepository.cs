using Dapper;
using Hotelz.Core;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Hotelz.Data
{
    public class QualificationRepository : IQualificationRepository
    {
        public bool Delete(int QualificationID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@QualificationID", value: QualificationID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Qualification", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Qualification Find(int QualificationID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@QualificationID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: QualificationID);
                return db.QuerySingle<Qualification>("proc_Qualification", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Qualification> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Qualification>("proc_Qualification", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Qualification obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@QualificationID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.QualificationName
                });
                db.Execute("proc_Qualification", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@QualificationID");
            }
        }

        public bool Update(Qualification obj, int QualificationID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@QualificationID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: QualificationID);
                p.AddDynamicParams(new
                {
                    obj.QualificationName
                });
                var result = db.Execute("proc_Qualification", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
