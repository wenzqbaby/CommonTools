using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// 查询语句生成接口
    /// </summary>
    public interface ISelect<T>
    {
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        String find();

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        PreparedCmd findPrepared();

        /// <summary>
        /// 根据传入对象的属性为条件查询
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        String find(T t);

        /// <summary>
        /// 根据传入对象的属性为条件查询
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        PreparedCmd findPrepared(T t);
    }
}
