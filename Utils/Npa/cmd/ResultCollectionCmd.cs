using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Cmd
{
    /// <summary>
    /// 结果嵌套集合指令
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultCollectionCmd<T>
    {
        private String _property;
        /// <summary>
        /// 对象的属性名
        /// </summary>
        public String Property
        {
            get { return _property; }
            set { _property = value; }
        }

        private Dictionary<String, ResultCmd> _results = new Dictionary<String, ResultCmd>();
        /// <summary>
        /// 属性名对应结果集配置指令集合
        /// </summary>
        public Dictionary<String, ResultCmd> Results
        {
            get { return _results; }
            set { _results = value; }
        }

        public List<ResultCmd> getResultList()
        {
            List<ResultCmd> list = new List<ResultCmd>();
            if (Results == null || Results.Count < 1)
            {
                return list;
            }
            list.AddRange(Results.Values);
            return list;
        }
    }
}
