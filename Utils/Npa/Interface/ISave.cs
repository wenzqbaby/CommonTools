using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   插入语句获取接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISave<T>
    {
        /// <summary>
        /// 根据实体生成插入的SQL语句
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
        String getSql(T t);

        /// <summary>
        /// 根据实体生成插入的参数化SQL语句
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
        PreparedCmd getPreparedSql(T t);
    }
}
