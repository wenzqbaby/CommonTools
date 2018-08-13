using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.SqlCond.Enum
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 数据库字段类型枚举
    /// </summary>
    public enum SqlType
    {
        /// <summary>
        /// 字符类型，包含：VARCHAR, CHAR等
        /// </summary>
        STRING,
        /// <summary>
        /// 数字类型，包含：INTEGER，SHORT，DECIMAL等
        /// </summary>
        NUMBER,
        /// <summary>
        /// 时间类型格式：TIMESTAMP
        /// 若属性类型为字符串，则格式为yyyy-MM-dd HH:mm:ss
        /// </summary>
        TIMESTAMP,
    }
}
