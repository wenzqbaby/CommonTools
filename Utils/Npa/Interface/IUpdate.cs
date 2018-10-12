using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   更新语句获取接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IUpdate<T>
    {
        /// <summary>
        /// 根据对象主键生成更新SQL语句，该类必须有主键列且不能为空
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
        String getSql(T t);

        /// <summary>
        /// 根据对象主键生成更新参数化语句，该类必须有主键列且不能为空
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>参数化指令</returns>
        PreparedCmd getPreparedSql(T t);

        /// <summary>
        /// 根据指定条件生成更新SQL语句
        /// </summary>
        /// <param name="t">实体</param>
        /// <param name="propConds">更新的条件(实体的属性名)，若为空或空集合则为ID，条件属性不能为空</param>
        /// <param name="propUpdates">更新的属性(实体的属性名)，若为空或空集合则为全部属性</param>
        /// <returns></returns>
        String getSql(T t, List<String> propConds, List<String> propUpdates);

        /// <summary>
        /// 根据指定条件生成更新SQL语句
        /// </summary>
        /// <param name="t">实体</param>
        /// <param name="propConds">更新的条件(实体的属性名)，若为空或空集合则为ID，条件属性不能为空</param>
        /// <param name="propUpdates">更新的属性(实体的属性名)，若为空或空集合则为全部属性</param>
        /// <returns>参数化指令</returns>
        PreparedCmd getPreparedSql(T t, List<String> propConds, List<String> propUpdates);

        /// <summary>
        /// 根据对象主键生成更新SQL语句，该类必须有主键列且不能为空
        /// 若属性为空则更新为null值
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
        String getSqlWithNull(T t);

        /// <summary>
        /// 根据对象主键生成更新参数化语句，该类必须有主键列且不能为空
        /// 若属性为空则更新为null值
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>参数化指令</returns>
        PreparedCmd getPSqlWithNull(T t);
    }
}
