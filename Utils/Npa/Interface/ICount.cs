using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/10
    /// desc:   数据列接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICount<T>
    {
        /// <summary>
        /// 根据传入对象不为空的属性为条件，生成查询数量语句
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
        String count(T t);

        /// <summary>
        /// 根据传入对象不为空的属性为条件，生成查询数量参数化指令
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>参数化指令</returns>
        PreparedCmd countPrepared(T t);

        /// <summary>
        /// 根据传入对象的主键属性为条件(主键属性不能为空)，生成查询数量语句
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
        String countById(T t);

        /// <summary>
        /// 根据传入对象的主键属性为条件(主键属性不能为空)，生成查询数量语句
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>参数化指令</returns>
        PreparedCmd countPreparedById(T t);
    }
}
