using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   数据集创建对象接口
    /// </summary>
    public interface ICreate
    {
        /// <summary>
        /// 根据数据集第一个表的第一行数据生成指定类型的对象
        /// 数据列名对应属性名(驼峰式命名)
        /// 列名首字母大写，'_'后的首字母大写，其余为小写对应相应的属性名
        /// </summary>
        /// <typeparam name="T">生成的对象类型</typeparam>
        /// <param name="ds">数据集</param>
        /// <returns>数据实体</returns>
        T get<T>(DataSet ds);

        /// <summary>
        /// 根据数据集第一个表的第一行数据生成指定类型的对象
        /// 指定数据列对应的属性名等配置
        /// </summary>
        /// <typeparam name="T">生成的对象类型</typeparam>
        /// <param name="ds">数据集</param>
        /// <param name="results">结果集配置指令集合</param>
        /// <returns>数据实体</returns>
        T get<T>(DataSet ds, List<ResultCmd> results);

        /// <summary>
        /// 根据数据集第一个表的第一行数据生成指定类型的对象
        /// 对象属性带有List
        /// </summary>
        /// <typeparam name="T">生成的对象类型，建议该类型重写Equals和GetHashCode方法</typeparam>
        /// <typeparam name="E">生成的对象里面嵌套的List类型</typeparam>
        /// <param name="ds">数据集</param>
        /// <param name="results">结果集配置指令集合</param>
        /// <param name="resultCollection">结果嵌套集合指令</param>
        /// <returns>数据实体</returns>
        T get<T, E>(DataSet ds, List<ResultCmd> results, ResultCollectionCmd<E> resultCollection);

        /// <summary>
        /// 根据数据集第一个表的数据生成指定类型的对象
        /// 数据列名对应属性名(驼峰式命名)
        /// 列名首字母大写，'_'后的首字母大写，其余为小写对应相应的属性名
        /// </summary>
        /// <typeparam name="T">生成的对象类型</typeparam>
        /// <param name="ds">数据集</param>
        /// <returns>数据实体集合</returns>
        List<T> getList<T>(DataSet ds);

        /// <summary>
        /// 根据数据集第一个表的数据生成指定类型的对象
        /// 指定数据列对应的属性名等配置
        /// </summary>
        /// <typeparam name="T">生成的对象类型</typeparam>
        /// <param name="ds">数据集</param>
        /// <param name="results">结果集配置指令集合</param>
        /// <returns>数据实体集合</returns>
        List<T> getList<T>(DataSet ds, List<ResultCmd> results);

        /// <summary>
        /// 根据数据集第一个表的数据生成指定类型的对象
        /// 对象属性带有List
        /// </summary>
        /// <typeparam name="T">生成的对象类型，建议该类型重写Equals和GetHashCode方法</typeparam>
        /// <typeparam name="E">生成的对象里面嵌套的List类型</typeparam>
        /// <param name="ds">数据集</param>
        /// <param name="results">结果集配置指令集合</param>
        /// <param name="resultCollection">结果嵌套集合指令</param>
        /// <returns>数据实体集合</returns>
        List<T> getList<T, E>(DataSet ds, List<ResultCmd> results, ResultCollectionCmd<E> resultCollection);

        /// <summary>
        /// 根据数据集第一个表的第一行第一列数据生成int类型，要求该值必须能转换为int类型
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <returns></returns>
        int getCount(DataSet ds);
    }
}
