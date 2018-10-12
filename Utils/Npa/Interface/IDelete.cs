using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   数据列接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDelete<T>
    {
        /// <summary>
        /// 根据实体的主键属性生成删除SQL语句，必须设置主键属性且不能为空
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
        String getSql(T t);

        /// <summary>
        /// 根据实体的主键属性生成参数化的删除SQL语句，必须设置主键属性且不能为空
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>参数化指令</returns>
        PreparedCmd getPreparedSql(T t);
    }
}
