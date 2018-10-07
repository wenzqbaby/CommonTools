using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.cmd
{
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
