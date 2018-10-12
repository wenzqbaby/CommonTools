using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   根据数据集生成对象接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IGenerate<T>
    {
        /// <summary>
        /// 根据数据集第一个表的第一行数据生成对象
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <returns>实体</returns>
        T get(DataSet ds);

        /// <summary>
        /// 根据数据集第一个表的数据生成对象集合
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <returns>实体集合</returns>
        List<T> getList(DataSet ds);
    }
}
