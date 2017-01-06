using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.NaverSearch.Definition.ConstValue
{
    public class ConstValue
    {
        public struct NaverClintInfo
        {
            public const string ID = "LtZtd8UjmufzEAi37KdB";
            public const string PASS = "v7hwdxjn0m";
        }

        public static DataTable ProductInfoTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CODE");
            dt.Columns.Add("CODE_NAME");

            DataRow dr = dt.NewRow();

            dr["CODE"] = "1";
            dr["CODE_NAME"] = "[일반상품]가격비교상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "2";
            dr["CODE_NAME"] = "[일반상품]가격비교 비매칭 일반상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "3";
            dr["CODE_NAME"] = "[일반상품]가격비교 매칭 일반상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "4";
            dr["CODE_NAME"] = "[중고상품]가격비교 상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "5";
            dr["CODE_NAME"] = "[중고상품]가격비교 비매칭 일반상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "6";
            dr["CODE_NAME"] = "[중고상품]가격비교 매칭 일반상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "7";
            dr["CODE_NAME"] = "[단종상품]가격비교 상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "8";
            dr["CODE_NAME"] = "[단종상품]가격비교 비매칭 일반상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "9";
            dr["CODE_NAME"] = "[단종상품]가격비교 매칭 일반상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "10";
            dr["CODE_NAME"] = "[판매예정상품]가격비교 상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "11";
            dr["CODE_NAME"] = "[판매예정상품]가격비교 비매칭 일반상품";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "12";
            dr["CODE_NAME"] = "[판매예정상품]가격비교 매칭 일반상품";

            dt.Rows.Add(dr);

            return dt;
        }
    }
}
