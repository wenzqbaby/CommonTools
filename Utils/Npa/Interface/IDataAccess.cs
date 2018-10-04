using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// 数据访问接口
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// 执行插入语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns></returns>
        int insert(String sql);

        /// <summary>
        /// 执行插入语句
        /// </summary>
        /// <param name="preparedSql">参数化SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        int insert(List<DbParameter> parameters, string preparedSql);

        int insert(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// 执行删除语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns></returns>
        int delete(String sql);

        /// <summary>
        /// 执行删除语句
        /// </summary>
        /// <param name="preparedSql">参数化SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        int delete(List<DbParameter> parameters, String preparedSql);

        int delete(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// 执行更新语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns></returns>
        int update(String sql);

        /// <summary>
        /// 执行更新语句
        /// </summary>
        /// <param name="preparedSql">参数化SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        int update(List<DbParameter> parameters, String preparedSql);

        int update(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>查询结果的数据集</returns>
        DataSet select(String sql);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="preparedSql"></param>
        /// <param name="parameters"></param>
        /// <returns>查询结果的数据集</returns>
        DataSet select(List<DbParameter> parameters, String preparedSql);

        DataSet select(String preparedSql, params DbParameter[] parameters);
    }
}
