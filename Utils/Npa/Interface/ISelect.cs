using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   查询语句生成接口
    /// </summary>
    public interface ISelect<T>
    {
        /// <summary>
        /// 生成查询所有数据SQL语句
        /// </summary>
        /// <returns>SQL语句</returns>
        String find();

        /// <summary>
        /// 生成查询所有数据参数化指令
        /// </summary>
        /// <returns>参数化指令</returns>
        PreparedCmd findPrepared();

        /// <summary>
        /// 根据传入对象的属性为条件，生成查询所有数据SQL语句
        /// </summary>
        /// <param name="t">条件实体</param>
        /// <returns>SQL语句</returns>
        String find(T t);

        /// <summary>
        /// 根据传入对象的属性为条件，生成查询所有数据参数化指令
        /// </summary>
        /// <param name="t">条件实体</param>
        /// <returns>参数化指令</returns>
        PreparedCmd findPrepared(T t);

        /// <summary>
        /// 根据传入对象的主键属性为条件，生成查询SQL语句
        /// </summary>
        /// <param name="t">条件实体</param>
        /// <returns>SQL语句</returns>
        String findById(T t);

        /// <summary>
        /// 根据传入对象的主键属性为条件，生成查询参数化指令
        /// </summary>
        /// <param name="t">条件实体</param>
        /// <returns>参数化指令</returns>
        PreparedCmd findPreparedById(T t);
    }
}
