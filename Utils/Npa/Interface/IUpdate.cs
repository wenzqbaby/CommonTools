using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// 更新语句获取接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUpdate<T>
    {
        /// <summary>
        /// 获取根据对象主键更新语句，该类必须有主键列且不能为空
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        String getSql(T t);

        /// <summary>
        /// 获取根据对象主键更新预编译语句，该类必须有主键列且不能为空
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        PreparedCmd getPreparedSql(T t);

        /// <summary>
        /// 获取根据对象主键更新语句，该类必须有主键列且不能为空
        /// 若属性为空则更新为null值
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        String getSqlWithNull(T t);

        /// <summary>
        /// 获取根据对象主键更新预编译语句，该类必须有主键列且不能为空
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        PreparedCmd getPSqlWithNull(T t);
    }
}
