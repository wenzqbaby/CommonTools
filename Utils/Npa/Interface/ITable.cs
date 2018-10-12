using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   数据表接口
    /// </summary>
    public interface ITable
    {
        /// <summary>
        /// 设置当前的类类型
        /// </summary>
        /// <param name="t"></param>
        void setType(Type t);

        /// <summary>
        /// 获取数据表名
        /// </summary>
        /// <returns></returns>
        String getTableName();

        /// <summary>
        /// 获取命名空间名
        /// </summary>
        /// <returns></returns>
        String getScheme();
    }
}
