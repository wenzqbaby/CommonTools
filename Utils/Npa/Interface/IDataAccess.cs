using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/5
    /// desc:   数据访问接口
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// 设置日志
        /// </summary>
        /// <param name="t"></param>
        void setLog(Type t);

        /// <summary>
        /// 获取事务
        /// </summary>
        /// <returns></returns>
        DbTransaction getTrans();

        /// <summary>
        /// 开始事务
        /// </summary>
        void beginTrans();

        /// <summary>
        /// 提交事务
        /// </summary>
        void commit();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void rollBack();

        /// <summary>
        /// 执行数据插入操作
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>受影响的行数</returns>
        int insert(String sql);

        /// <summary>
        /// 执行数据插入操作
        /// </summary>
        /// <param name="preparedSql">参数列表</param>
        /// <param name="parameters">参数化SQL语句</param>
        /// <returns>受影响的行数</returns>
        int insert(List<DbParameter> parameters, string preparedSql);

        /// <summary>
        /// 执行数据插入操作
        /// </summary>
        /// <param name="preparedSql">参数化SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>受影响的行数</returns>
        int insert(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// 执行数据插入操作
        /// </summary>
        /// <param name="cmd">参数化指令</param>
        /// <returns>受影响的行数</returns>
        int insert(PreparedCmd cmd);

        /// <summary>
        /// 执行数据删除操作
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        int delete(String sql);

        /// <summary>
        /// 执行数据删除操作
        /// </summary>
        /// <param name="preparedSql">参数化SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>受影响的行数</returns>
        int delete(List<DbParameter> parameters, String preparedSql);

        /// <summary>
        /// 执行数据删除操作
        /// </summary>
        /// <param name="preparedSql">参数化SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>受影响的行数</returns>
        int delete(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// 执行数据删除操作
        /// </summary>
        /// <param name="cmd">参数化指令</param>
        /// <returns>受影响的行数</returns>
        int delete(PreparedCmd cmd);

        /// <summary>
        /// 执行数据更新操作
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        int update(String sql);

        /// <summary>
        /// 执行数据更新操作
        /// </summary>
        /// <param name="preparedSql">参数化SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        int update(List<DbParameter> parameters, String preparedSql);

        /// <summary>
        /// 执行数据更新操作
        /// </summary>
        /// <param name="preparedSql">参数化SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>受影响的行数</returns>
        int update(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// 执行数据更新操作
        /// </summary>
        /// <param name="cmd">参数化指令</param>
        /// <returns>受影响的行数</returns>
        int update(PreparedCmd cmd);

        /// <summary>
        /// 执行数据查询操作
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>查询结果的数据集</returns>
        DataSet select(String sql);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="preparedSql"></param>
        /// <param name="parameters"></param>
        /// <returns>查询结果的数据集</returns>
        DataSet select(List<DbParameter> parameters, String preparedSql);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="preparedSql">参数化SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果的数据集</returns>
        DataSet select(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="cmd">参数化指令</param>
        /// <returns>查询结果的数据集</returns>
        DataSet select(PreparedCmd cmd);
    }
}
