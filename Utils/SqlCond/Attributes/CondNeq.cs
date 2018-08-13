namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 生成SQL条件组件：不等于
    /// </summary>
    public class CondNeq: BaseCond
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public CondNeq(): base("!=") { }
    }
}