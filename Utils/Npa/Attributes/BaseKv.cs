using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    public abstract class BaseKv : BaseColumn
    {
        protected const Char SEP = '=';
        private String[] _fomatter;

        public String[] Fomatter
        {
            get { return _fomatter; }
            set {
                _fomatter = value;
                init(_fomatter);
            }
        }

        public BaseKv(params String[] kvs)
        {
            init(kvs);
        }

        public void init(String[] kvs)
        {
            if (kvs == null || kvs.Length < 1)
            {
                throw new Exception(this.GetType().ToString() + "转换的键值对不能为空");
            }
            Dictionary<String, String> kvDic = new Dictionary<string, string>();
            String another = null;
            for (int i = 0; i < kvs.Length; i++)
            {
                try
                {
                    String[] kv = kvs[i].Split(SEP);
                    kvDic[kv[0]] = kv[1];
                }
                catch (Exception)
                {
                    if (i == kvs.Length -1)
                    {
                        another = kvs[i];
                    }
                    else
                    {
                        throw new Exception(String.Format("{0} 要转换的键值对设置错误：{}", this.GetType().ToString(), kvs));
                    }
                }
            }
            this.TypeHandler = new KvTypeHandler(kvDic, another);
        }

        public override object getValue(object obj)
        {
            Object value = base.getValue(obj);
            if (value == null)
            {
                return null;
            }
            return this.TypeHandler.formatProp(value);
        }
    }
}
